using ED.VersatilityExtensions.PrimitiveExtensions.Cryptography;
using System.Security.Cryptography;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// AES アルゴリズムに基づいた暗号化・復号に関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringAESExtensions
    {

        // ↓ Extension↓

        #region Encrypt (byte[])

        /// <summary>
        /// AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para>初期化ベクタと暗号化キーが未指定の場合は自動生成されます。</para>
        ///     <para>暗号化キーサイズは 128 bit が使用されます。</para>
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="key">暗号化キーのバイトシーケンス。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="keySize">暗号化キーサイズ。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptAES(this string value, ref byte[] initialVector, ref byte[] key)
        {
            return value.EncryptAES(ref initialVector, ref key, AesKeySize.KeySize128Bit);
        }

        /// <summary>
        /// AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para>初期化ベクタと暗号化キーが未指定の場合は自動生成されます。</para>
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="key">暗号化キーのバイトシーケンス。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="keySize">暗号化キーサイズ。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptAES(this string value, ref byte[] initialVector, ref byte[] key, AesKeySize keySize)
        {
            return value.EncryptAES(ref initialVector, ref key, keySize, CipherMode.CBC, PaddingMode.PKCS7);
        }

        /// <summary>
        /// AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para>初期化ベクタと暗号化キーが未指定の場合は自動生成されます。</para>
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="key">暗号化キーのバイトシーケンス。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="keySize">暗号化キーサイズ。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptAES(this string value, ref byte[] initialVector, ref byte[] key, AesKeySize keySize, PaddingMode padding)
        {
            return value.EncryptAES(ref initialVector, ref key, keySize, CipherMode.CBC, padding);
        }

        /// <summary>
        /// AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para>初期化ベクタと暗号化キーが未指定の場合は自動生成されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="key">暗号化キーのバイトシーケンス。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="keySize">暗号化キーサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptAES(this string value, ref byte[] initialVector, ref byte[] key, AesKeySize keySize, CipherMode mode)
        {
            return value.EncryptAES(ref initialVector, ref key, keySize, mode, PaddingMode.PKCS7);
        }

        /// <summary>
        /// AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para>初期化ベクタと暗号化キーが未指定の場合は自動生成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="key">暗号化キーのバイトシーケンス。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="keySize">暗号化キーサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptAES(this string value, ref byte[] initialVector, ref byte[] key, AesKeySize keySize, CipherMode mode, PaddingMode padding)
        {
            using var aes = AesProvider.CreateAesManaged(ref initialVector, ref key, keySize, mode, padding);
            return value.EncryptAES(aes);
        }

        #endregion

        #region Encrypt (string)

        /// <summary>
        /// AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para>暗号化キーサイズは 128 bit が使用されます。</para>
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="key">暗号化キー。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptAES(this string value, string initialVector, string key)
        {
            return value.EncryptAES(initialVector, key, AesKeySize.KeySize128Bit);
        }

        /// <summary>
        /// AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="key">暗号化キー。</param>
        /// <param name="keySize">暗号化キーサイズ。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptAES(this string value, string initialVector, string key, AesKeySize keySize)
        {
            return value.EncryptAES(initialVector, key, keySize, CipherMode.CBC, PaddingMode.PKCS7);
        }

        /// <summary>
        /// AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="key">暗号化キー。</param>
        /// <param name="keySize">暗号化キーサイズ。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptAES(this string value, string initialVector, string key, AesKeySize keySize, PaddingMode padding)
        {
            return value.EncryptAES(initialVector, key, keySize, CipherMode.CBC, padding);
        }

        /// <summary>
        /// AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="key">暗号化キー。</param>
        /// <param name="keySize">暗号化キーサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptAES(this string value, string initialVector, string key, AesKeySize keySize, CipherMode mode)
        {
            return value.EncryptAES(initialVector, key, keySize, mode, PaddingMode.PKCS7);
        }

        /// <summary>
        /// AES アルゴリズムを使用して文字列を暗号化します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="key">暗号化キー。</param>
        /// <param name="keySize">暗号化キーサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptAES(this string value, string initialVector, string key, AesKeySize keySize, CipherMode mode, PaddingMode padding)
        {
            using var aes = AesProvider.CreateAesManaged(initialVector, key, keySize, mode, padding);
            return value.EncryptAES(aes);
        }

        #endregion

        #region Encrypt (Aes)

        /// <summary>
        /// AES アルゴリズムを使用して文字列を暗号化します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="aes"><see cref="Aes"/> オブジェクト。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptAES(this string value, Aes aes)
        {
            var binaryValue = value.ToUTF8Bytes();
            return aes.CreateEncryptor().TransformFinalBlock(binaryValue, 0, binaryValue.Length).ToBase64String();
        }

        #endregion

        #region EncryptPassword (byte[])

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para>暗号化パスワードサイズは 128 bit が使用されます。</para>
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="password">暗号化パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptPasswordAES(this string value, ref byte[] initialVector, string password, ref byte[] salt)
        {
            return value.EncryptPasswordAES(ref initialVector, password, ref salt, AesPasswordSize.PasswordSize16Byte);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="password">暗号化パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">暗号化パスワードサイズ。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptPasswordAES(this string value, ref byte[] initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize)
        {
            return value.EncryptPasswordAES(ref initialVector, password, ref salt, passwordSize, CipherMode.CBC, PaddingMode.PKCS7);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="password">暗号化パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">暗号化パスワードサイズ。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptPasswordAES(this string value, ref byte[] initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, PaddingMode padding)
        {
            return value.EncryptPasswordAES(ref initialVector, password, ref salt, passwordSize, CipherMode.CBC, padding);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="password">暗号化パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">暗号化パスワードサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptPasswordAES(this string value, ref byte[] initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, CipherMode mode)
        {
            return value.EncryptPasswordAES(ref initialVector, password, ref salt, passwordSize, mode, PaddingMode.PKCS7);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を暗号化します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。未指定の場合は自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="password">暗号化パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">暗号化パスワードサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptPasswordAES(this string value, ref byte[] initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, CipherMode mode, PaddingMode padding)
        {
            using var deriveBytes = Rfc2898DeriveBytesProvider.CreateRfc2898DeriveBytes(password, passwordSize);
            var key = deriveBytes.GetBytes((int)passwordSize);
            salt = deriveBytes.Salt;

            using var aes = AesProvider.CreateAesManaged(ref initialVector, ref key, passwordSize.ToAESKeySize(), mode, padding);
            return value.EncryptAES(aes);
        }

        #endregion

        #region EncryptPassword (string)

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para>暗号化パスワードサイズは 128 bit が使用されます。</para>
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">暗号化パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptPasswordAES(this string value, string initialVector, string password, ref byte[] salt)
        {
            return value.EncryptPasswordAES(initialVector, password, ref salt, AesPasswordSize.PasswordSize16Byte);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">暗号化パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">暗号化パスワードサイズ。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptPasswordAES(this string value, string initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize)
        {
            return value.EncryptPasswordAES(initialVector, password, ref salt, passwordSize, CipherMode.CBC, PaddingMode.PKCS7);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">暗号化パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">暗号化パスワードサイズ。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptPasswordAES(this string value, string initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, PaddingMode padding)
        {
            return value.EncryptPasswordAES(initialVector, password, ref salt, passwordSize, CipherMode.CBC, padding);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を暗号化します。
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">暗号化パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">暗号化パスワードサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptPasswordAES(this string value, string initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, CipherMode mode)
        {
            return value.EncryptPasswordAES(initialVector, password, ref salt, passwordSize, mode, PaddingMode.PKCS7);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を暗号化します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">暗号化パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">暗号化パスワードサイズ。</param>
        /// <param name="mode">ブロック暗号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>暗号文字列。</returns>
        public static string EncryptPasswordAES(this string value, string initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, CipherMode mode, PaddingMode padding)
        {
            using var deriveBytes = Rfc2898DeriveBytesProvider.CreateRfc2898DeriveBytes(password, passwordSize);
            var key = deriveBytes.GetBytes((int)passwordSize);
            salt = deriveBytes.Salt;

            using var aes = AesProvider.CreateAesManaged(initialVector, key, passwordSize.ToAESKeySize(), mode, padding);
            return value.EncryptAES(aes);
        }

        #endregion

        #region Decrypt (byte[])

        /// <summary>
        /// AES アルゴリズムを使用して暗号文字列を復号します。
        ///     <para>復号キーサイズは 128 bit が使用されます。</para>
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。</param>
        /// <param name="key">復号キーのバイトシーケンス。</param>
        /// <param name="keySize">復号キーサイズ。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptAES(this string value, byte[] initialVector, byte[] key)
        {
            return value.DecryptAES(initialVector, key, AesKeySize.KeySize128Bit);
        }

        /// <summary>
        /// AES アルゴリズムを使用して暗号文字列を復号します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。</param>
        /// <param name="key">復号キーのバイトシーケンス。</param>
        /// <param name="keySize">復号キーサイズ。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptAES(this string value, byte[] initialVector, byte[] key, AesKeySize keySize)
        {
            return value.DecryptAES(initialVector, key, keySize, CipherMode.CBC, PaddingMode.PKCS7);
        }

        /// <summary>
        /// AES アルゴリズムを使用して暗号文字列を復号します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。</param>
        /// <param name="key">復号キーのバイトシーケンス。</param>
        /// <param name="keySize">復号キーサイズ。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptAES(this string value, byte[] initialVector, byte[] key, AesKeySize keySize, PaddingMode padding)
        {
            return value.DecryptAES(initialVector, key, keySize, CipherMode.CBC, padding);
        }

        /// <summary>
        /// AES アルゴリズムを使用して暗号文字列を復号します。
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。</param>
        /// <param name="key">復号キーのバイトシーケンス。</param>
        /// <param name="keySize">復号キーサイズ。</param>
        /// <param name="mode">ブロック復号モード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptAES(this string value, byte[] initialVector, byte[] key, AesKeySize keySize, CipherMode mode)
        {
            return value.DecryptAES(initialVector, key, keySize, mode, PaddingMode.PKCS7);
        }

        /// <summary>
        /// AES アルゴリズムを使用して暗号文字列を復号します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタのバイトシーケンス。</param>
        /// <param name="key">復号キーのバイトシーケンス。</param>
        /// <param name="keySize">復号キーサイズ。</param>
        /// <param name="mode">ブロック復号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptAES(this string value, byte[] initialVector, byte[] key, AesKeySize keySize, CipherMode mode, PaddingMode padding)
        {
            using var aes = AesProvider.CreateAesManaged(ref initialVector, ref key, keySize, mode, padding);
            return value.DecryptAES(aes);
        }

        #endregion

        #region Decrypt (string)

        /// <summary>
        /// AES アルゴリズムを使用して復号文字列を復号します。
        ///     <para>復号キーサイズは 128 bit が使用されます。</para>
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="key">復号キー。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptAES(this string value, string initialVector, string key)
        {
            return value.DecryptAES(initialVector, key, AesKeySize.KeySize128Bit);
        }

        /// <summary>
        /// AES アルゴリズムを使用して復号文字列を復号します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="key">復号キー。</param>
        /// <param name="keySize">復号キーサイズ。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptAES(this string value, string initialVector, string key, AesKeySize keySize)
        {
            return value.DecryptAES(initialVector, key, keySize, CipherMode.CBC, PaddingMode.PKCS7);
        }

        /// <summary>
        /// AES アルゴリズムを使用して復号文字列を復号します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="key">復号キー。</param>
        /// <param name="keySize">復号キーサイズ。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptAES(this string value, string initialVector, string key, AesKeySize keySize, PaddingMode padding)
        {
            return value.DecryptAES(initialVector, key, keySize, CipherMode.CBC, padding);
        }

        /// <summary>
        /// AES アルゴリズムを使用して復号文字列を復号します。
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="key">復号キー。</param>
        /// <param name="keySize">復号キーサイズ。</param>
        /// <param name="mode">ブロック復号モード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptAES(this string value, string initialVector, string key, AesKeySize keySize, CipherMode mode)
        {
            return value.DecryptAES(initialVector, key, keySize, mode, PaddingMode.PKCS7);
        }

        /// <summary>
        /// AES アルゴリズムを使用して復号文字列を復号します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="key">復号キー。</param>
        /// <param name="keySize">復号キーサイズ。</param>
        /// <param name="mode">ブロック復号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptAES(this string value, string initialVector, string key, AesKeySize keySize, CipherMode mode, PaddingMode padding)
        {
            using var aes = AesProvider.CreateAesManaged(initialVector, key, keySize, mode, padding);
            return value.DecryptAES(aes);
        }

        #endregion

        #region Decrypt (Aes)

        /// <summary>
        /// AES アルゴリズムを使用して暗号文字列を復号します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="aes"><see cref="Aes"/> オブジェクト。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptAES(this string value, Aes aes)
        {
            var binaryValue = value.FromBase64String();
            return aes.CreateDecryptor().TransformFinalBlock(binaryValue, 0, binaryValue.Length).ToUTF8String();
        }

        #endregion

        #region DecryptPassword (byte[])

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を復号します。
        ///     <para>復号パスワードサイズは 128 bit が使用されます。</para>
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">復号パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptPasswordAES(this string value, ref byte[] initialVector, string password, ref byte[] salt)
        {
            return value.DecryptPasswordAES(ref initialVector, password, ref salt, AesPasswordSize.PasswordSize16Byte);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を復号します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">復号パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">復号パスワードサイズ。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptPasswordAES(this string value, ref byte[] initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize)
        {
            return value.DecryptPasswordAES(ref initialVector, password, ref salt, passwordSize, CipherMode.CBC, PaddingMode.PKCS7);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を復号します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">復号パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">復号パスワードサイズ。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptPasswordAES(this string value, ref byte[] initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, PaddingMode padding)
        {
            return value.DecryptPasswordAES(ref initialVector, password, ref salt, passwordSize, CipherMode.CBC, padding);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を復号します。
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">復号パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">復号パスワードサイズ。</param>
        /// <param name="mode">ブロック復号モード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptPasswordAES(this string value, ref byte[] initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, CipherMode mode)
        {
            return value.DecryptPasswordAES(ref initialVector, password, ref salt, passwordSize, mode, PaddingMode.PKCS7);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を復号します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">復号パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">復号パスワードサイズ。</param>
        /// <param name="mode">ブロック復号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptPasswordAES(this string value, ref byte[] initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, CipherMode mode, PaddingMode padding)
        {
            using var deriveBytes = Rfc2898DeriveBytesProvider.CreateRfc2898DeriveBytes(password, passwordSize);
            var key = deriveBytes.GetBytes((int)passwordSize);
            salt = deriveBytes.Salt;

            using var aes = AesProvider.CreateAesManaged(ref initialVector, ref key, passwordSize.ToAESKeySize(), mode, padding);
            return value.DecryptAES(aes);
        }

        #endregion

        #region DecryptPassword (string)

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を復号します。
        ///     <para>復号パスワードサイズは 128 bit が使用されます。</para>
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">復号パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptPasswordAES(this string value, string initialVector, string password, ref byte[] salt)
        {
            return value.DecryptPasswordAES(initialVector, password, ref salt, AesPasswordSize.PasswordSize16Byte);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を復号します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">復号パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">復号パスワードサイズ。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptPasswordAES(this string value, string initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize)
        {
            return value.DecryptPasswordAES(initialVector, password, ref salt, passwordSize, CipherMode.CBC, PaddingMode.PKCS7);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を復号します。
        ///     <para><see cref="CipherMode"/> は <see cref="CipherMode.CBC"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">復号パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">復号パスワードサイズ。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptPasswordAES(this string value, string initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, PaddingMode padding)
        {
            return value.DecryptPasswordAES(initialVector, password, ref salt, passwordSize, CipherMode.CBC, padding);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を復号します。
        ///     <para><see cref="PaddingMode"/> は <see cref="PaddingMode.PKCS7"/> が使用されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">復号パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">復号パスワードサイズ。</param>
        /// <param name="mode">ブロック復号モード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptPasswordAES(this string value, string initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, CipherMode mode)
        {
            return value.DecryptPasswordAES(initialVector, password, ref salt, passwordSize, mode, PaddingMode.PKCS7);
        }

        /// <summary>
        /// パスワードベースの AES アルゴリズムを使用して文字列を復号します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="initialVector">初期化ベクタ。</param>
        /// <param name="password">復号パスワード。</param>
        /// <param name="salt">パスワードソルト。自動生成されたバイトシーケンスが取得されます。</param>
        /// <param name="passwordSize">復号パスワードサイズ。</param>
        /// <param name="mode">ブロック復号モード。</param>
        /// <param name="padding">パディングモード。</param>
        /// <returns>復号文字列。</returns>
        public static string DecryptPasswordAES(this string value, string initialVector, string password, ref byte[] salt, AesPasswordSize passwordSize, CipherMode mode, PaddingMode padding)
        {
            using var deriveBytes = Rfc2898DeriveBytesProvider.CreateRfc2898DeriveBytes(password, passwordSize);
            var key = deriveBytes.GetBytes((int)passwordSize);
            salt = deriveBytes.Salt;

            using var aes = AesProvider.CreateAesManaged(initialVector, key, passwordSize.ToAESKeySize(), mode, padding);
            return value.DecryptAES(aes);
        }

        #endregion

    }
}
