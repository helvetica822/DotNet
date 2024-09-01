using MahApps.Metro.Controls.Dialogs;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using vs4w.Models;
using vs4w.Views;
using WE.DotNetStandard4Win.Validation.Attributes;

namespace vs4w.ViewModels
{

    public class MainWindowViewModel : BindableBase, INotifyPropertyChanged
    {

        private IDialogService DialogService { get; }

        private IDialogCoordinator DialogCoordinator { get; }

        private CompositeDisposable Disposables { get; } = new CompositeDisposable();

        private MainWindowModel Model { get; }

        public string Title { get; } = "VPN設定 For Windows";

        [CustomRequired]
        public ReactiveProperty<string> VpnName { get; private set; }

        [CustomRequired]
        public ReactiveProperty<string> UserName { get; private set; }

        [CustomRequired]
        public ReactiveProperty<string> UserPassword { get; private set; }

        public AsyncReactiveCommand ConnectTestCommand { get; }

        public AsyncReactiveCommand RegisterCommand { get; }

        public ReactiveCommand OpenSettingVpnCommand { get; }

        public ReactiveCommand ShowAboutApplicationCommand { get; }

        public AsyncReactiveCommand TestConnectCommand { get; }

        public ReadOnlyReactivePropertySlim<bool> IsEnabled { get; }

        public MainWindowViewModel(IDialogService dialogService, IDialogCoordinator dialogCoordinator, MainWindowModel model)
        {
            this.DialogService = dialogService;
            this.DialogCoordinator = dialogCoordinator;
            this.Model = model;

            this.VpnName = new ReactiveProperty<string>(initialValue: "VPN", mode: ReactivePropertyMode.Default | ReactivePropertyMode.IgnoreInitialValidationError).SetValidateAttribute(() => this.VpnName);
            this.UserName = new ReactiveProperty<string>(initialValue: Environment.UserName, mode: ReactivePropertyMode.Default | ReactivePropertyMode.IgnoreInitialValidationError).SetValidateAttribute(() => this.UserName);
            this.UserPassword = new ReactiveProperty<string>(mode: ReactivePropertyMode.Default | ReactivePropertyMode.IgnoreInitialValidationError).SetValidateAttribute(() => this.UserPassword);

            this.OpenSettingVpnCommand = new ReactiveCommand().WithSubscribe(() => this.OpenSettingVpn()).AddTo(this.Disposables);
            this.ShowAboutApplicationCommand = new ReactiveCommand().WithSubscribe(() => this.ShowAboutApplication()).AddTo(this.Disposables);

            this.TestConnectCommand = new[] { this.VpnName.ObserveHasErrors, this.UserName.ObserveHasErrors, this.UserPassword.ObserveHasErrors }.CombineLatestValuesAreAllFalse().ToAsyncReactiveCommand().
                WithSubscribe(() => this.TestConnectAsync()).AddTo(this.Disposables);
            this.RegisterCommand = new[] { this.VpnName.ObserveHasErrors, this.UserName.ObserveHasErrors, this.UserPassword.ObserveHasErrors }.CombineLatestValuesAreAllFalse().ToAsyncReactiveCommand().
                WithSubscribe(() => this.RegisterVpnAsync()).AddTo(this.Disposables);

            model.LoadVpnConfiguration();
            model.LoadUsedLibraries();
        }

        private async Task TestConnectAsync()
        {
            if (await this.IsEmptyPassword()) return;
            if (!await this.LoadedVpnConfiguration()) return;

            var controller = await this.DialogCoordinator.ShowProgressAsync(this, "接続テスト", "接続を試行しています...");
            await Task.Run(() => this.Model.ConnectTestAsync(this.UserName.Value, this.UserPassword.Value));
            await controller.CloseAsync();

            var caption = this.Model.TestResult.IsSuccess ? "接続成功" : "接続失敗";

            await this.DialogCoordinator.ShowMessageAsync(this, caption, this.Model.TestResult.Message);
        }

        private async Task RegisterVpnAsync()
        {
            if (await this.IsEmptyPassword()) return;
            if (!await this.LoadedVpnConfiguration()) return;

            var controller = await this.DialogCoordinator.ShowProgressAsync(this, "接続情報登録", "接続情報を登録しています...");
            await Task.Run(() => this.Model.RegisterVpnAsync(this.VpnName.Value, this.UserName.Value, this.UserPassword.Value));
            await controller.CloseAsync();

            var caption = this.Model.RegisterResult.IsSuccess ? "登録成功" : "登録失敗";

            await this.DialogCoordinator.ShowMessageAsync(this, caption, this.Model.RegisterResult.Message);
        }

        private void OpenSettingVpn()
        {
            using (var p = new Process())
            {
                p.StartInfo = new ProcessStartInfo("cmd.exe", "/c start ms-settings:network-vpn")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                _ = p.Start();
            }
        }

        private void ShowAboutApplication()
        {
            this.DialogService.ShowDialog(nameof(AboutApplicationWindow));
        }

        private async Task<bool> IsEmptyPassword()
        {
            var isEmpty = string.IsNullOrEmpty(this.UserPassword.Value);

            if (isEmpty) await this.DialogCoordinator.ShowMessageAsync(this, "入力エラー", "パスワードを入力してください。");

            return isEmpty;
        }

        private async Task<bool> LoadedVpnConfiguration()
        {
            var loaded = this.Model.LoadedConfiguration;

            if (!loaded) await this.DialogCoordinator.ShowMessageAsync(this, "設定エラー", "VPN設定が不足しています。");

            return loaded;
        }

        public void Dispose() => this.Disposables.Dispose();

    }

}
