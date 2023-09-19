using ED.VersatilityExtensions.CollectionExtensions;
using ED.VersatilityExtensions.PrimitiveExtensions;
using Org.BouncyCastle.Crypto;
using System.Data;
using System.Data.SQLite;
using System.Runtime.Versioning;
using VL.BrowserCredentials.Browsers;
using VL.BrowserCredentials.EncryptionDecryption;
using VL.BrowserCredentials.Tables;

namespace VL.BrowserCredentials.Readers
{

    internal class LoginsReader
    {

        private LoginsReader() { }

        [SupportedOSPlatform("windows")]
        internal static IEnumerable<Logins>? SelectLoginsRecordsFromChromium(AbstractBrowserSettings settings)
        {
            return SelectLoginsRecordsFromChromium(settings, null);
        }

        [SupportedOSPlatform("windows")]
        internal static IEnumerable<Logins>? SelectLoginsRecordsFromChromium(AbstractBrowserSettings settings, string? profile)
        {
            if (!settings.ExistsDecryptionKey()) return null;

            var profileName = (profile is null ? string.Empty : profile);
            if (!settings.ExistsLoginData(profileName)) return null;

            var key = DpapiKeyLoader.LoadKey(settings);
            if (key is null) return null;

            settings.ProcessName.KillSameNameProcesses();

            using var con = new SQLiteConnection($"Data Source={settings.LoginDataPath(profileName)};");
            try
            {
                con.Open();

                using var command = con.CreateCommand();
                command.CommandText = @"
                    SELECT origin_url
                        , username_value
                        , password_value
                    FROM logins
                    WHERE username_value <> ''
                        AND password_value <> ''
                    ORDER BY origin_url;";

                using var adapter = new SQLiteDataAdapter(command);
                using var table = new DataTable();
                _ = adapter.Fill(table);
                var records = table.ToList<Logins>();

                foreach (var record in records)
                {
                    if (record.PasswordValue is null) continue;

                    (var initialVector, var cipherText) = PasswordCipher.SeparateBinaryValues(record.PasswordValue);
                    try
                    {
                        record.Password = PasswordCipher.DecryptPassword(key, initialVector, cipherText);
                    }
                    catch (InvalidCipherTextException)
                    {
                        // 複合に失敗したレコードは飛ばす
                    }
                }

                return records;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

    }

}
