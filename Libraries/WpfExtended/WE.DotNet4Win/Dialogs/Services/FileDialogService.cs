using WE.DotNet4Win.Dialogs.Interfaces;
using WE.DotNet4Win.Dialogs.Settings;

namespace WE.DotNet4Win.Dialogs.Services
{

    public class FileDialogService : ICommonDialogService
    {

        public bool ShowDialog(ICommonDialogSettings settings)
        {
            using var dialog = this.CreateFileDialog(settings);
            if (dialog is null) return false;

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.SetSelectedFileNameToSettings(dialog, settings);
                return true;
            }
            else
            {
                return false;
            }
        }

        private FileDialog? CreateFileDialog(ICommonDialogSettings settings)
        {
            if (settings is null) return null;

            FileDialog? dialog = settings switch
            {
                OpenFileDialogSettings => new OpenFileDialog(),
                SaveFileDialogSettings => new SaveFileDialog(),
                _ => null,
            };

            if (dialog is null) return null;

            var dialogSettings = (FileDialogSettings)settings;

            dialog.FileName = dialogSettings.FileName;
            dialog.Filter = dialogSettings.Filter;
            dialog.InitialDirectory = dialogSettings.InitialDirectory;

            return dialog;
        }

        private void SetSelectedFileNameToSettings(FileDialog dialog, ICommonDialogSettings settings)
        {
            var dialogSettings = (FileDialogSettings)settings;
            dialogSettings.FileName = dialog.FileName;
        }

    }

}
