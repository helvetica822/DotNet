namespace VL.BrowserCredentials.Browsers
{

    [BrowserInfo("Opera")]
    internal class OperaSettings : AbstractBrowserSettings
    {

        internal override string BrowserCommonPath => @"Opera Software\Opera Stable";

        internal override SettingDataType LoginDataType => SettingDataType.SQLite;

        internal override string DecryptionKeyPath => $@"{this.GetBrowserCommonPathFromRoot()}\Local State";

        internal override SettingDataType DecryptionKeyType => SettingDataType.JSON;

        internal override string ProcessName => "opera";

        internal override string LoginDataPath(string profile)
        {
            _ = profile;
            return $@"{this.GetBrowserCommonPathFromRoot()}\Login Data";
        }

        internal override IDictionary<string, string> GetProfiles() => new Dictionary<string, string>() { { string.Empty, "<プロファイルなし>" } };

        protected override UserFolderType FolderType => UserFolderType.Roming;

    }

}
