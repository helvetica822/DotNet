using PassView.Models;
using PassView.ViewModels;
using PassView.Views;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;
using WE.DotNet4Win.Dialogs.Interfaces;
using WE.DotNet4Win.Dialogs.Services;

namespace PassView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICommonDialogService, CommonDialogService>();
            _ = containerRegistry.RegisterSingleton<MainWindowModel>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
        }

    }
}
