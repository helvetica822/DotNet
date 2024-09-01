using ED.VersatilityExtensions.PrimitiveExtensions;
using Newtonsoft.Json;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using VL.BrowserCredentials.Browsers;

namespace VL.BrowserCredentials.EncryptionDecryption
{

    internal class DpapiKeyLoader
    {

        private DpapiKeyLoader() { }

        [SupportedOSPlatform("windows")]
        internal static byte[]? LoadKey(AbstractBrowserSettings settings)
        {
            var value = File.ReadAllText(settings.DecryptionKeyPath);
            dynamic? json = JsonConvert.DeserializeObject(value);

            if (json is null) return null;
            string key = json.os_crypt.encrypted_key;

            var encryptedKey = key.FromBase64String().Skip("DPAPI".Length).ToArray();

            // ProtectedData.Unprotect は Windows のみサポート
            return ProtectedData.Unprotect(encryptedKey, null, DataProtectionScope.CurrentUser);
        }

    }

}
