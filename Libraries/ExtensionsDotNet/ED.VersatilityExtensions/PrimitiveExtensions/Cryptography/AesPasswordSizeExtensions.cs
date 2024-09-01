namespace ED.VersatilityExtensions.PrimitiveExtensions.Cryptography
{

    /// <summary>
    /// <see cref="AesPasswordSize"/> の拡張機能を提供します。
    /// </summary>
    internal static class AesPasswordSizeExtensions
    {

        // ↓ Extension↓

        #region To AES Key Size

        /// <summary>
        /// パスワードサイズをキーサイズに変換します。
        /// </summary>
        /// <param name="passwordSize">パスワードサイズ。</param>
        /// <returns>キーサイズ。</returns>
        internal static AesKeySize ToAESKeySize(this AesPasswordSize passwordSize)
        {
            return passwordSize switch
            {
                AesPasswordSize.PasswordSize16Byte => AesKeySize.KeySize128Bit,
                AesPasswordSize.PasswordSize24Byte => AesKeySize.KeySize192Bit,
                AesPasswordSize.PasswordSize32Byte => AesKeySize.KeySize256Bit,
                _ => AesKeySize.KeySize128Bit,// 128 ビットをデフォルトとします。
            };
        }

        #endregion

    }
}
