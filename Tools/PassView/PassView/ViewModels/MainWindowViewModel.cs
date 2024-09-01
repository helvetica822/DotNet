using PassView.Domains;
using PassView.Models;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using WE.DotNet4Win.Controls.Attributes;
using WE.DotNet4Win.Controls.Converters;
using WE.DotNet4Win.Dialogs.Interfaces;
using WE.DotNet4Win.Dialogs.Settings;

namespace PassView.ViewModels
{

    public class MainWindowViewModel : BindableBase, INotifyPropertyChanged
    {

        public string Title { get; } = "ブラウザ認証情報表示";

        private CompositeDisposable Disposables { get; } = new CompositeDisposable();

        private ICommonDialogService CommonDialogService { get; }

        private MainWindowModel Model { get; }

        public ReactivePropertySlim<int> BrowsersSelectedIndex { get; }

        public ReactivePropertySlim<int> ProfilesSelectedIndex { get; set; }

        public ReactiveProperty<CombBoxItem> BrowsersSelectedItem { get; } = new ReactiveProperty<CombBoxItem>();

        public ReactiveProperty<CombBoxItem> ProfilesSelectedItem { get; } = new ReactiveProperty<CombBoxItem>();

        public ReadOnlyReactiveCollection<CombBoxItem> Browsers { get; set; }

        public ReactiveCollection<CombBoxItem> Profiles { get; set; } = new ReactiveCollection<CombBoxItem>();

        public AsyncReactiveCommand ViewCommand { get; }

        public AsyncReactiveCommand SaveCommand { get; }

        public ReadOnlyReactivePropertySlim<IEnumerable<BrowserCredential>> BrowserCredentials { get; set; }

        public ReactivePropertySlim<string> RecordsCount { get; set; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<bool> CanSaveExcel { get; set; } = new ReactivePropertySlim<bool>(false);

        private IDictionary<string, DataGridColumnHeaderAttribute> DataGridHeaders { get; } = DataGridColumnHeaderConverter.CollectDataGridHeadersAttributes(typeof(BrowserCredential));

        public ReactiveCommand<DataGridColumn> AutoGeneratingColumnCommand { get; set; }

        public MainWindowViewModel(ICommonDialogService comDialogService, MainWindowModel model)
        {
            this.Model = model;
            this.CommonDialogService = comDialogService;

            this.Browsers = this.CreateTargetBrowsersList().ToReadOnlyReactiveCollection().AddTo(this.Disposables);
            this.BrowsersSelectedItem.Subscribe(s => this.ChangeItemsBySelectedBrowser(s)).AddTo(this.Disposables);
            this.BrowsersSelectedIndex = new ReactivePropertySlim<int>(0).AddTo(this.Disposables);

            this.ProfilesSelectedIndex = new ReactivePropertySlim<int>(0).AddTo(this.Disposables);
            this.Profiles.ObserveAddChangedItems().Subscribe(_ => this.ProfilesSelectedIndex.Value = 0).AddTo(this.Disposables); ;

            this.BrowserCredentials = this.Model.ObserveProperty(x => x.BrowserCredentials).ToReadOnlyReactivePropertySlim<IEnumerable<BrowserCredential>>().AddTo(this.Disposables);
            this.DisplayNumberOfBrowserCredentials();

            this.AutoGeneratingColumnCommand = new ReactiveCommand<DataGridColumn>().WithSubscribe(x => DataGridColumnHeaderConverter.ConvertDataGridHeaders(x, this.DataGridHeaders)).AddTo(this.Disposables);

            this.ViewCommand = (AsyncReactiveCommand)new AsyncReactiveCommand().WithSubscribe(_ => this.DisplayBrowserCredentials()).AddTo(this.Disposables);
            this.SaveCommand = (AsyncReactiveCommand)new AsyncReactiveCommand().WithSubscribe(_ => this.WriteBrowserCredentialsToExcel()).AddTo(this.Disposables);
        }

        private async Task DisplayBrowserCredentials()
        {
            var browser = this.BrowsersSelectedItem.Value.Value;
            var profile = this.ProfilesSelectedItem.Value.Value;

            await Task.Run(() => this.Model.SelectBrowserCredentials(browser, profile));
            this.BrowserCredentials = this.Model.ObserveProperty(x => x.BrowserCredentials).ToReadOnlyReactivePropertySlim<IEnumerable<BrowserCredential>>().AddTo(this.Disposables);
            this.DisplayNumberOfBrowserCredentials();
        }

        private void DisplayNumberOfBrowserCredentials()
        {
            var count = this.Model.BrowserCredentials.Count();
            this.RecordsCount.Value = $"認証情報 : {string.Format("{0, 4}", count)} 件";
            this.CanSaveExcel.Value = count > 0;
        }

        private void ChangeItemsBySelectedBrowser(CombBoxItem selected)
        {
            if (selected is not null)
            {
                this.Profiles.Clear();

                var profiles = this.Model.FindProfiles(selected.Value);
                this.Profiles.AddRange(this.CreateObservableCollection(profiles));
            }
        }

        private async Task WriteBrowserCredentialsToExcel()
        {
            var settings = new SaveFileDialogSettings()
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                FileName = "ブラウザ認証情報",
                Filter = "Excelブック|*.xlsx|すべてのファイル|*.*"
            };

            if (this.CommonDialogService.ShowDialog(settings))
            {
                await Task.Run(() => this.Model.WriteBrowserCredentialsToExcel(settings.FileName));
            }
        }

        private ObservableCollection<CombBoxItem> CreateTargetBrowsersList()
        {
            return this.CreateObservableCollection(this.Model.FindUsableBrowsers());
        }

        private ObservableCollection<CombBoxItem> CreateObservableCollection(IDictionary<string, string> items)
        {
            var list = new ObservableCollection<CombBoxItem>();

            foreach (var item in items)
            {
                list.Add(new CombBoxItem(item.Value, item.Key));
            }

            return list;
        }

        public void Dispose() => this.Disposables.Dispose();

    }
}
