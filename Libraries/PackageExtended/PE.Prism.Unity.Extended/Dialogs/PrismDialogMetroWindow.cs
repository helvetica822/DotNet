using MahApps.Metro.Controls;
using Prism.Services.Dialogs;
using System.Windows;

namespace PE.Prism.Unity.Extended.Dialogs
{

    public partial class PrismDialogMetroWindow : MetroWindow, IDialogWindow
    {

        public IDialogResult Result { get; set; }

        private void AboutApplicationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is IDialogAware) this.Title = (this.DataContext as IDialogAware).Title;

            this.Loaded -= this.AboutApplicationWindow_Loaded;
        }

        public PrismDialogMetroWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.Loaded += this.AboutApplicationWindow_Loaded;
        }

    }

}
