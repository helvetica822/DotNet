using ED.VersatilityExtensions.PrimitiveExtensions;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

namespace VL.BrowserCredentials.EncryptionDecryption
{

    internal class PasswordCipher
    {

        private PasswordCipher() { }

        internal static (byte[] initialVector, byte[] cipherText) SeparateBinaryValues(byte[] encryptedData)
        {
            var initialVector = new byte[12];
            var cipherText = new byte[encryptedData.Length - 3 - initialVector.Length];

            Array.Copy(encryptedData, 3, initialVector, 0, initialVector.Length);
            Array.Copy(encryptedData, 3 + initialVector.Length, cipherText, 0, cipherText.Length);

            return (initialVector, cipherText);
        }

        internal static string DecryptPassword(byte[] key, byte[] iv, byte[] encryptedBytes)
        {
            var cipher = new GcmBlockCipher(new AesEngine());
            var parameters = new AeadParameters(new KeyParameter(key), 128, iv, null);

            cipher.Init(false, parameters);
            var plainBytes = new byte[cipher.GetOutputSize(encryptedBytes.Length)];
            var len = cipher.ProcessBytes(encryptedBytes, 0, encryptedBytes.Length, plainBytes, 0);
            _ = cipher.DoFinal(plainBytes, len);

            return plainBytes.ToUTF8String().TrimEnd("\r\n\0".ToCharArray());
        }

        internal static byte[] EncryptPassword(byte[] key, byte[] iv, string plaintext)
        {
            var cipher = new GcmBlockCipher(new AesEngine());
            var parameters = new AeadParameters(new KeyParameter(key), 128, iv, null);

            cipher.Init(true, parameters);
            var plainBytes = plaintext.ToUTF8Bytes();
            var encryptedBytes = new byte[cipher.GetOutputSize(plainBytes.Length)];
            var len = cipher.ProcessBytes(plainBytes, 0, plainBytes.Length, encryptedBytes, 0);
            _ = cipher.DoFinal(encryptedBytes, len);

            return encryptedBytes;
        }

    }

}
