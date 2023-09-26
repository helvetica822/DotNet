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

        internal override string LoginDataPath(string profile) => $@"{this.GetBrowserCommonPathFromRoot()}\{profile}\Login Data";

        internal override IDictionary<string, string> GetProfiles() => this.GetDefaultAndNumberingProfiles();

        protected override UserFolderType FolderType => UserFolderType.Local;

    }

}
