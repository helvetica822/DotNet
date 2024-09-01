using ED.VersatilityExtensions.FactoryProvider.CharacterEncodings;
using System.Text;
using System.Web;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// エンコード・デコードに関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringEncodingExtensions
    {

        // ↓ Extension↓

        #region Encode

        /// <summary>
        /// この文字列を指定した文字コード <paramref name="fromEnc"/> から <paramref name="toEnc"/> にエンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="fromEnc">エンコード前文字コード。</param>
        /// <param name="toEnc">エンコード後文字コード。</param>
        /// <returns>エンコードした文字列。</returns>
        public static string Encode(this string value, Encoding fromEnc, Encoding toEnc) => toEnc.GetString(value.ToBytes(fromEnc));

        #endregion

        #region URL Encode

        /// <summary>
        /// この文字列を指定した文字コード <paramref name="enc"/> で URL エンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <returns>URL エンコードした文字列。</returns>
        public static string UrlEncode(this string value, Encoding enc) => HttpUtility.UrlEncode(value, enc);

        /// <summary>
        /// この文字列を文字コード Shift-JIS で URL エンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード Shift-JIS で URL エンコードした文字列。</returns>
        public static string UrlEncodeShiftJIS(this string value) => value.UrlEncode(CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        /// <summary>
        /// この文字列を文字コード JIS で URL エンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード JIS で URL エンコードした文字列。</returns>
        public static string UrlEncodeJIS(this string value) => value.UrlEncode(CharacterEncodingFactory.JIS.CharacterEncoding);

        /// <summary>
        /// この文字列を文字コード EUC で URL エンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード EUC で URL エンコードした文字列。</returns>
        public static string UrlEncodeEUC(this string value) => value.UrlEncode(CharacterEncodingFactory.EUC.CharacterEncoding);

        /// <summary>
        /// この文字列を文字コード UTF-8 で URL エンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード UTF-8 で URL エンコードした文字列。</returns>
        public static string UrlEncodeUTF8(this string value) => value.UrlEncode(CharacterEncodingFactory.UTF8.CharacterEncoding);

        /// <summary>
        /// この文字列を RFC 3986 に基づいて URL エンコードします。
        ///     <para>.NET Framework 4.5 以前の場合は挙動が変わるため注意すること。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="encodeReservedCharacters">RFC 3986 の予約文字もエンコードする場合は true。それ以外の場合は false。</param>
        /// <returns>RFC 3986 に基づいて URL エンコードした文字列。</returns>
        public static string UrlEncodeRFC3986(this string value, bool encodeReservedCharacters) => encodeReservedCharacters ? Uri.EscapeDataString(value) : Uri.EscapeDataString(value);

        #endregion

        #region URL Decode

        /// <summary>
        /// この文字列を指定した文字コード <paramref name="enc"/> で URL デコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <returns>URL デコードした文字列。</returns>
        public static string UrlDecode(this string value, Encoding enc) => HttpUtility.UrlDecode(value, enc);

        /// <summary>
        /// この文字列を文字コード Shift-JIS で URL デコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード Shift-JIS で URL デコードした文字列。</returns>
        public static string UrlDecodeShiftJIS(this string value) => value.UrlDecode(CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        /// <summary>
        /// この文字列を文字コード JIS で URL デコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード JIS で URL デコードした文字列。</returns>
        public static string UrlDecodeJIS(this string value) => value.UrlDecode(CharacterEncodingFactory.JIS.CharacterEncoding);

        /// <summary>
        /// この文字列を文字コード EUC で URL デコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード EUC で URL デコードした文字列。</returns>
        public static string UrlDecodeEUC(this string value) => value.UrlDecode(CharacterEncodingFactory.EUC.CharacterEncoding);

        /// <summary>
        /// この文字列を文字コード UTF-8 で URL デコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード UTF-8 で URL デコードした文字列。</returns>
        public static string UrlDecodeUTF8(this string value) => value.UrlDecode(CharacterEncodingFactory.UTF8.CharacterEncoding);

        #endregion

    }
}
