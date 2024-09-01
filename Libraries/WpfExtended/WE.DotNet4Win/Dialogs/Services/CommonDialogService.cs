using WE.DotNet4Win.Dialogs.Interfaces;
using WE.DotNet4Win.Dialogs.Settings;

namespace WE.DotNet4Win.Dialogs.Services
{

    public class CommonDialogService : ICommonDialogService
    {

        public bool ShowDialog(ICommonDialogSettings settings)
        {
            var service = this.CreateDialogService(settings);
            if (service is null) return false;

            return service.ShowDialog(settings);
        }

        private ICommonDialogService? CreateDialogService(ICommonDialogSettings settings)
        {
            if (settings is null) return null;

            return settings switch
            {
                OpenFileDialogSettings or SaveFileDialogSettings => new FileDialogService(),
                FolderBrowserDialogSettings => new FolderBrowserDialogService(),
                _ => null,
            };
        }

    }

}
