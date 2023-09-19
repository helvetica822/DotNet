using WE.DotNet4Win.Dialogs.Interfaces;
using WE.DotNet4Win.Dialogs.Settings;

namespace WE.DotNet4Win.Dialogs.Services
{

    public class FolderBrowserDialogService : ICommonDialogService
    {

        public bool ShowDialog(ICommonDialogSettings settings)
        {
            using var dialog = this.CreateFolderBrowserDialog(settings);
            if (dialog is null) return false;

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.SetSelectedPathToSettings(dialog, settings);
                return true;
            }
            else
            {
                return false;
            }
        }

        private FolderBrowserDialog? CreateFolderBrowserDialog(ICommonDialogSettings settings)
        {
            if (settings is null) return null;
            return new FolderBrowserDialog { SelectedPath = settings.InitialDirectory };
        }

        private void SetSelectedPathToSettings(FolderBrowserDialog dialog, ICommonDialogSettings settings)
        {
            var dialogSettings = (FolderBrowserDialogSettings)settings;
            dialogSettings.SelectedPath = dialog.SelectedPath;
        }

    }
}
