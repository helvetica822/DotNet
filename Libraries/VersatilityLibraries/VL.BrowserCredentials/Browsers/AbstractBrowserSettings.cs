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

        protected abstract UserFolderType FolderType { get; }

        internal abstract string LoginDataPath(string profile);

        internal abstract IDictionary<string, string> GetProfiles();

        protected string GetBrowserCommonPathFromRoot()
        {
            var userFolder = (this.FolderType == UserFolderType.Roming) ? this.GetRomingApplicationDataPath() : this.GetLocalApplicationDataPath();
            return $@"{userFolder}\{this.BrowserCommonPath}";
        }

        internal bool ExistsBrowserCommonPath() => this.GetBrowserCommonPathFromRoot().ExistsDirectory();

        private string GetRomingApplicationDataPath() => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private string GetLocalApplicationDataPath() => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        internal bool ExistsLoginData(string profile) => this.LoginDataPath(profile).ExistsFile();

        internal bool ExistsDecryptionKey() => this.DecryptionKeyPath.ExistsFile();

    }

}
