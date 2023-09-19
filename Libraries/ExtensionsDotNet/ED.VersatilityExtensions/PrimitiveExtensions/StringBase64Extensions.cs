using ED.VersatilityExtensions.FactoryProvider.CharacterEncodings;
using System.Text;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// Base 64 に関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringBase64Extensions
    {

        // ↓ Extension↓

        #region To Base 64 Encode Decode

        /// <summary>
        /// この文字列を Base 64 形式の文字列にエンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">エンコード文字コード。</param>
        /// <returns>エンコードした Base 64 形式文字列。</returns>
        public static string ToBase64Encode(this string value, Encoding enc) => Convert.ToBase64String(enc.GetBytes(value));

        /// <summary>
        /// この Base 64 形式文字列をデコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">デコード文字コード。</param>
        /// <returns>デコードされた文字列。</returns>
        public static string ToBase64Decode(this string value, Encoding enc) => enc.GetString(Convert.FromBase64String(value));

        #endregion

        #region From Base 64 String

        /// <summary>
        /// Base 64 文字列から <see cref="byte[]"/> 型配列に変換します。
        /// </summary>
        /// <param name="value">文字列</param>
        /// <returns>Base 64 文字列を変換した <see cref="byte[]"/> 型配列。</returns>
        public static byte[] FromBase64String(this string value) => Convert.FromBase64String(value);

        #endregion

        #region To Base 64 String

        /// <summary>
        /// この文字列に格納されている値を、指定した文字コードの Base 64 文字列に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <returns>Base 64 文字列。</returns>
        public static string ToBase64String(this string value, Encoding enc) => enc.GetBytes(value).ToBase64String();

        /// <summary>
        /// この文字列に格納されている値を、文字コード Shift-JIS の Base 64 文字列に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード Shift-JIS の Base 64 文字列。</returns>
        public static string ToBase64StringFromShiftJIS(this string value) => value.ToBase64String(CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード JIS の Base 64 文字列に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード JIS の Base 64 文字列。</returns>
        public static string ToBase64StringFromJIS(this string value) => value.ToBase64String(CharacterEncodingFactory.JIS.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード EUC の Base 64 文字列に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード EUC の Base 64 文字列。</returns>
        public static string ToBase64StringFromEUC(this string value) => value.ToBase64String(CharacterEncodingFactory.EUC.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード UTF-8 の Base 64 文字列に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード UTF-8 の Base 64 文字列。</returns>
        public static string ToBase64StringFromUTF8(this string value) => value.ToBase64String(CharacterEncodingFactory.UTF8.CharacterEncoding);

        #endregion

        #region From Base 64 RFC2047 String

        /// <summary>
        /// Base 64 形式 RFC2047 文字列をデコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>デコードした文字列。</returns>
        public static string FromBase64RFC2047String(this string value) => value.FromBase64RFC2047String(out _);

        /// <summary>
        /// Base 64 形式 RFC2047 文字列をデコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">エンコーディング。エンコードに使用されていた <see cref="Encoding"/> オブジェクトが取得されます。</param>
        /// <returns>デコードした文字列。</returns>
        public static string FromBase64RFC2047String(this string value, out Encoding enc)
        {
            var values = value.Split('?');

            if (values[2] != "B") throw new Exception("Base 64 形式ではないエンコード形式です。");

            var base64 = values[3].FromBase64String();
            enc = CharacterEncodingFactory.CreateEncoding(values[1]);

            return base64.ToEncodingString(enc);
        }

        #endregion

        #region To Base 64 RFC2047 String

        /// <summary>
        /// この文字列に格納されている値を、指定した文字コードの Base 64 形式 RFC2047 文字列に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <returns>RFC2047 文字列。</returns>
        public static string ToBase64RFC2047String(this string value, Encoding enc) => enc.GetBytes(value).ToBase64RFC2047String(enc);

        /// <summary>
        /// この文字列に格納されている値を、文字コード Shift-JIS の Base 64 形式 RFC2047 文字列に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード Shift-JIS の RFC2047 文字列。</returns>
        public static string ToBase64RFC2047StringFromShiftJIS(this string value) => value.ToBase64RFC2047String(CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード JIS の Base 64 形式 RFC2047 文字列に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード JIS の RFC2047 文字列。</returns>
        public static string ToBase64RFC2047StringFromJIS(this string value) => value.ToBase64RFC2047String(CharacterEncodingFactory.JIS.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード EUC の Base 64 形式 RFC2047 文字列に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード EUC の RFC2047 文字列。</returns>
        public static string ToBase64RFC2047StringFromEUC(this string value) => value.ToBase64RFC2047String(CharacterEncodingFactory.EUC.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード UTF-8 の Base 64 形式 RFC2047 文字列に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード UTF-8 の RFC2047 文字列。</returns>
        public static string ToBase64RFC2047StringFromUTF8(this string value) => value.ToBase64RFC2047String(CharacterEncodingFactory.UTF8.CharacterEncoding);

        #endregion

    }
}
