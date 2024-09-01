using System.Security.Cryptography;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// デジタル署名に関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringDigitalSignatureExtensions
    {

        // ↓ Extension↓

        #region RSA

        /// <summary>
        /// RSA アルゴリズムを使用してこの文字列にデジタル署名を行います。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="privateKey">秘密鍵。</param>
        /// <returns>署名。</returns>
        public static string SignDigitalSignatureRSA(this string value, string privateKey) => value.SignDigitalSignatureRSA(privateKey, 1);

        /// <summary>
        /// RSA アルゴリズムを使用してこの文字列にデジタル署名を行います。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="privateKey">秘密鍵。</param>
        /// <param name="strechCount">ハッシュ化時のストレッチ回数。</param>
        /// <returns>署名。</returns>
        public static string SignDigitalSignatureRSA(this string value, string privateKey, int strechCount)
        {
            var hash = value.ComputeHashSHA256(strechCount);

            using var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);

            var formatter = new RSAPKCS1SignatureFormatter(rsa);
            formatter.SetHashAlgorithm("SHA256");

            byte[] sign = formatter.CreateSignature(hash);

            return sign.ToBase64String();
        }

        /// <summary>
        /// RSA アルゴリズムを使用してこの文字列のデジタル署名を検証します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="sign">署名。</param>
        /// <param name="publicKey">公開鍵。</param>
        /// <returns>デジタル署名の認証に成功した場合は true。それ以外の場合は false。</returns>
        public static bool VerifyDigitalSignatureRSA(this string value, string sign, string publicKey) => value.VerifyDigitalSignatureRSA(sign, publicKey, 1);

        /// <summary>
        /// RSA アルゴリズムを使用してこの文字列のデジタル署名を検証します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="sign">署名。</param>
        /// <param name="publicKey">公開鍵。</param>
        /// <param name="strechCount">ハッシュ化時のストレッチ回数。</param>
        /// <returns>デジタル署名の認証に成功した場合は true。それ以外の場合は false。</returns>
        public static bool VerifyDigitalSignatureRSA(this string value, string sign, string publicKey, int strechCount)
        {
            var hash = value.ComputeHashSHA256(strechCount);

            using var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);

            var deformatter = new RSAPKCS1SignatureDeformatter(rsa);
            deformatter.SetHashAlgorithm("SHA256");

            return deformatter.VerifySignature(hash, sign.FromBase64String());
        }

        #endregion

    }
}
