using System.Security.Cryptography;

namespace ED.VersatilityExtensions.PrimitiveExtensions.Cryptography
{

    /// <summary>
    /// <see cref="Rfc2898DeriveBytes"/> オブジェクトを提供します。
    /// </summary>
    internal class Rfc2898DeriveBytesProvider
    {

        #region Constructor

        /// <summary>
        /// <see cref="Rfc2898DeriveBytes"/> オブジェクト提供クラスのインスタンスを生成します。
        /// </summary>
        internal Rfc2898DeriveBytesProvider() { }

        #endregion

        // ↓Internal static method↓

        #region Create AesManagedRfc2898DeriveBytes

        /// <summary>
        /// <see cref="Rfc2898DeriveBytes"/> オブジェクトを生成します。
        /// </summary>
        /// <param name="password">パスワード。</param>
        /// <param name="passwordSize">AES パスワードサイズ。</param>
        /// <returns><see cref="Rfc2898DeriveBytes"/> オブジェクト。</returns>
        internal static Rfc2898DeriveBytes CreateRfc2898DeriveBytes(string password, AesPasswordSize passwordSize) => new(password, (int)passwordSize);

        #endregion

    }
}
