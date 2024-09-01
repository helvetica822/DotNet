using System.Security.Cryptography;

namespace ED.VersatilityExtensions.PrimitiveExtensions.Cryptography
{

    /// <summary>
    /// <see cref="Aes"/> オブジェクトを提供します。
    /// </summary>
    internal class AesProvider
    {

        #region Constructor

        /// <summary>
        /// <see cref="Aes"/> オブジェクト提供クラスのインスタンスを生成します。
        /// </summary>
        internal AesProvider() { }

        #endregion

        // ↓Internal static method↓

        #region Create Aes

        /// <summary>
        /// <see cref="Aes"/> オブジェクトを生成します。
        /// </summary>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="key">キー。</param>
        /// <param name="keySize">キーサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns><see cref="Aes"/> オブジェクト。</returns>
        internal static Aes CreateAesManaged(string initialVector, string key, AesKeySize keySize, CipherMode mode, PaddingMode padding)
        {
            var binaryInitialVector = initialVector.ToUTF8Bytes();
            var binaryKey = key.ToUTF8Bytes();

            return CreateAesManaged(ref binaryInitialVector, ref binaryKey, keySize, mode, padding);
        }

        /// <summary>
        /// <see cref="Aes"/> オブジェクトを生成します。
        /// </summary>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。</param>
        /// <param name="key">キーのバイトシーケンス。</param>
        /// <param name="keySize">キーサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns><see cref="Aes"/> オブジェクト。</returns>
        internal static Aes CreateAesManaged(string initialVector, byte[] key, AesKeySize keySize, CipherMode mode, PaddingMode padding)
        {
            var binaryInitialVector = initialVector.ToUTF8Bytes();
            return CreateAesManaged(ref binaryInitialVector, ref key, keySize, mode, padding);
        }

        /// <summary>
        /// <see cref="Aes"/> オブジェクトを生成します。
        /// </summary>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。</param>
        /// <param name="key">キーのバイトシーケンス。</param>
        /// <param name="keySize">キーサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns><see cref="Aes"/> オブジェクト。</returns>
        internal static Aes CreateAesManaged(ref byte[] initialVector, ref byte[] key, AesKeySize keySize, CipherMode mode, PaddingMode padding)
        {
            var aes = CreateAesManagedWithCommonParams(keySize, mode, padding);

            if (initialVector is null)
            {
                aes.GenerateIV();
                initialVector = aes.IV;
            }
            else
            {
                aes.IV = initialVector;
            }

            if (key is null)
            {
                aes.GenerateKey();
                key = aes.Key;
            }
            else
            {
                aes.Key = key;
            }

            return aes;
        }

        /// <summary>
        /// <see cref="Aes"/> オブジェクトを生成し、共通のパラメータを設定します。
        /// </summary>
        /// <param name="keySize">キーサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns><see cref="Aes"/> オブジェクト。</returns>
        internal static Aes CreateAesManagedWithCommonParams(AesKeySize keySize, CipherMode mode, PaddingMode padding)
        {
            var aes = Aes.Create();

            aes.KeySize = (int)keySize;
            aes.BlockSize = (int)AesBlockSize.BlockSize128Bit;
            aes.Mode = mode;
            aes.Padding = padding;

            return aes;
        }

        #endregion

    }
}
