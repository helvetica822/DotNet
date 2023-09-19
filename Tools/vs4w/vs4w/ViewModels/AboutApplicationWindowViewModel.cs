using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reflection;
using System.Windows.Controls;
using vs4w.Domains;
using vs4w.Models;
using WE.DotNetStandard4Win.Controls.Attributes;
using WE.DotNetStandard4Win.Controls.Converters;

namespace vs4w.ViewModels
{

    public class AboutApplicationWindowViewModel : BindableBase, IDialogAware
    {

        private CompositeDisposable Disposables { get; } = new CompositeDisposable();

        public string Title { get; } = "アプリケーションについて";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        private IDictionary<string, DataGridColumnHeaderAttribute> DataGridHeaders { get; } = DataGridColumnHeaderConverter.CollectDataGridHeadersAttributes(typeof(UsedLibrary));

        public ReactivePropertySlim<string> ApplicationVersion { get; } 

        public ReadOnlyReactivePropertySlim<IEnumerable<UsedLibrary>> UsedLibraries { get; }

        public ReactiveCommand<DataGridColumn> AutoGeneratingColumnCommand { get; }

        public AboutApplicationWindowViewModel(MainWindowModel mainWindowModel)
        {
            this.ApplicationVersion = new ReactivePropertySlim<string>(Assembly.GetExecutingAssembly().GetName().Version.ToString()).AddTo(this.Disposables);
            this.UsedLibraries = mainWindowModel.ObserveProperty(x => x.Libraries).ToReadOnlyReactivePropertySlim().AddTo(this.Disposables);
            this.AutoGeneratingColumnCommand = new ReactiveCommand<DataGridColumn>().WithSubscribe(x => DataGridColumnHeaderConverter.ConvertDataGridHeaders(x, this.DataGridHeaders)).AddTo(this.Disposables);
        }

        public void OnDialogOpened(IDialogParameters parameters) { }

        public void OnDialogClosed() { }

        public void Dispose() => this.Disposables.Dispose();

    }

}
