using MahApps.Metro.Controls.Dialogs;
using PE.Prism.Unity.Extended.Dialogs;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;
using vs4w.Models;
using vs4w.ViewModels;
using vs4w.Views;
using WE.DotNetStandard4Win.Validation.Configuration;

namespace vs4w
{

    public partial class App : PrismApplication
    {

        protected override Window CreateShell()
        {
            ValidationConfiguration.DefaultErrorMessageResourceTypeProvider = (attribute) => typeof(Properties.Resources);
            ValidationConfiguration.DefaultErrorMessageResourceNameProvider = (attribute) =>
            {
                var attributeName = attribute.GetType().Name.Replace("Attribute", string.Empty);
                return attributeName.StartsWith("Custom") ? attributeName : $"Custom{attributeName}";
            };

            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<MainWindowModel>();
            containerRegistry.RegisterInstance(DialogCoordinator.Instance);
            containerRegistry.RegisterDialog<AboutApplicationWindow, AboutApplicationWindowViewModel>(nameof(AboutApplicationWindow));
            containerRegistry.RegisterDialogWindow<PrismDialogMetroWindow>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<AboutApplicationWindow, AboutApplicationWindowViewModel>();
        }

    }
}
