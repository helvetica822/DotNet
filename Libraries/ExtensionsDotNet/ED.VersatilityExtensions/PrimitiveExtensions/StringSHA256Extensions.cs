using System.Security.Cryptography;
using System.Text;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// SHA 256 アルゴリズムに基づいたハッシュ化に関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringSHA256Extensions
    {

        // ↓ Extension↓

        #region Hash

        /// <summary>
        /// SHA 256 アルゴリズムを使用してこの文字列をソルトを含めてハッシュ化します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="saltValue">ソルトの元とする文字列。</param>
        /// <returns>ハッシュ文字列。</returns>
        public static string HashSHA256WithSalt(this string value, string saltValue) => value.HashSHA256WithSalt(saltValue, 1);

        /// <summary>
        /// SHA 256 アルゴリズムを使用してこの文字列をソルトを含めてハッシュ化します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="saltValue">ソルトの元とする文字列。</param>
        /// <param name="stretchCount">ストレッチ回数。</param>
        /// <returns>ハッシュ文字列。</returns>
        public static string HashSHA256WithSalt(this string value, string saltValue, int stretchCount)
        {
            if (stretchCount < 1) stretchCount = 1;

            var hash = string.Empty;
            var salt = saltValue.HashSHA256();

            return (hash + salt + value).HashSHA256(stretchCount);
        }

        /// <summary>
        /// SHA 256 アルゴリズムを使用してこの文字列をハッシュ化します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ハッシュ文字列。</returns>
        public static string HashSHA256(this string value)
        {
            var buf = new StringBuilder();

            var hash = value.ComputeHashSHA256();

            for (var i = 0; i < hash.Length; i++)
            {
                _ = buf.AppendFormat("{0:x2}", hash[i]);
            }

            return buf.ToString();
        }

        /// <summary>
        /// SHA 256 アルゴリズムを使用してこの文字列をハッシュ化します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="stretchCount">ストレッチ回数。</param>
        /// <returns>ハッシュ文字列。</returns>
        public static string HashSHA256(this string value, int stretchCount)
        {
            var hash = string.Empty;

            for (var i = 0; i < stretchCount; i++)
            {
                hash = (hash + value).HashSHA256();
            }

            return hash;
        }

        #endregion

        #region Compute Hash

        /// <summary>
        /// SHA 256 アルゴリズムを使用してこの文字列からソルトを含めてハッシュ値のバイト配列を計算します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="saltValue">ソルトの元とする文字列。</param>
        /// <returns>計算したハッシュ値のバイト配列。</returns>
        public static byte[] ComputeHashSHA256WithSalt(this string value, string saltValue) => value.ComputeHashSHA256WithSalt(saltValue, 1);

        /// <summary>
        /// SHA 256 アルゴリズムを使用してこの文字列からソルトを含めてハッシュ値のバイト配列を計算します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="saltValue">ソルトの元とする文字列。</param>
        /// <param name="stretchCount">ストレッチ回数。</param>
        /// <returns>計算したハッシュ値のバイト配列。</returns>
        public static byte[] ComputeHashSHA256WithSalt(this string value, string saltValue, int stretchCount)
        {
            if (stretchCount < 1) stretchCount = 1;

            var salt = saltValue.HashSHA256();

            return (salt + value).ComputeHashSHA256(stretchCount);
        }

        /// <summary>
        /// SHA 256 アルゴリズムを使用してこの文字列からハッシュ値のバイト配列を計算します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>計算したハッシュ値のバイト配列。</returns>
        public static byte[] ComputeHashSHA256(this string value)
        {
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(value.ToUTF8Bytes());

            return hash;
        }

        /// <summary>
        /// SHA 256 アルゴリズムを使用してこの文字列からハッシュ値のバイト配列を計算します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="stretchCount">ストレッチ回数。</param>
        /// <returns>計算したハッシュ値のバイト配列。</returns>
        public static byte[] ComputeHashSHA256(this string value, int stretchCount)
        {
            if (stretchCount < 1) stretchCount = 1;

            var hash = string.Empty;

            for (var i = 0; i < stretchCount - 1; i++)
            {
                hash = (hash + value).HashSHA256();
            }

            return (hash + value).ComputeHashSHA256();
        }

        #endregion

    }
}
