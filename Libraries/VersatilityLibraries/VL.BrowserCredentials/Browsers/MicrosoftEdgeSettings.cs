namespace VL.BrowserCredentials.Browsers
{

    [BrowserInfo("MicrosoftEdge", "Microsoft Edge")]
    internal class MicrosoftEdgeSettings : AbstractBrowserSettings
    {

        internal override string BrowserCommonPath => @"Microsoft\Edge\User Data";

        internal override SettingDataType LoginDataType => SettingDataType.SQLite;

        internal override string DecryptionKeyPath => $@"{this.GetBrowserCommonPathFromRoot()}\Local State";

        internal override SettingDataType DecryptionKeyType => SettingDataType.JSON;

        internal override string ProcessName => "msedge";

        protected override UserFolderType FolderType => UserFolderType.Local;

        internal override string LoginDataPath(string profile) => $@"{this.GetBrowserCommonPathFromRoot()}\{profile}\Login Data";

        internal override IDictionary<string, string> GetProfiles() => new Dictionary<string, string>() { { "Default", "Default" } };

    }

}
