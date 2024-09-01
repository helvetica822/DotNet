using ED.VersatilityExtensions.PrimitiveExtensions;

namespace VL.BrowserCredentials.Browsers
{

    public abstract class AbstractBrowserSettings
    {

        internal abstract string BrowserCommonPath { get; }

        internal abstract SettingDataType LoginDataType { get; }

        internal abstract string DecryptionKeyPath { get; }

        internal abstract SettingDataType DecryptionKeyType { get; }

        internal abstract string ProcessName { get; }

        internal abstract string LoginDataPath(string profile);

        internal abstract IDictionary<string, string> GetProfiles();

        protected abstract UserFolderType FolderType { get; }

        internal bool ExistsBrowserCommonPath() => this.GetBrowserCommonPathFromRoot().ExistsDirectory();

        internal bool ExistsLoginData(string profile) => this.LoginDataPath(profile).ExistsFile();

        internal bool ExistsDecryptionKey() => this.DecryptionKeyPath.ExistsFile();

        protected string GetBrowserCommonPathFromRoot()
        {
            var userFolder = (this.FolderType == UserFolderType.Roming) ? this.GetRomingApplicationDataPath() : this.GetLocalApplicationDataPath();
            return $@"{userFolder}\{this.BrowserCommonPath}";
        }

        protected IDictionary<string, string> GetDefaultAndNumberingProfiles()
        {
            var paths = new Dictionary<string, string>();

            foreach (var p in this.GetBrowserCommonPathFromRoot().GetSubDirectoriesPathOfCurrent().Where(p => this.IsDefaultAndNumberingProfile(p)).Select(p => p.GetFileName()))
            {
                if (p is not null) paths.Add(p, p);
            }

            return paths;
        }

        private string GetRomingApplicationDataPath() => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private string GetLocalApplicationDataPath() => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        private bool IsDefaultAndNumberingProfile(string path)
        {
            var directoryName = path.GetFileName();
            if (directoryName is null) return false;

            return directoryName.StartsWith("Profile ") || directoryName == "Default";
        }

    }

}
