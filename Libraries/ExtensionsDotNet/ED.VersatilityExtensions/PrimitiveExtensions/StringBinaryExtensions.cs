using ED.VersatilityExtensions.FactoryProvider.CharacterEncodings;
using System.Text;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// バイト処理に関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringBinaryExtensions
    {

        // ↓ Extension↓

        #region Byte Count

        /// <summary>
        /// この文字列に格納されている値を、指定した文字コードのバイトシーケンスにエンコードすることで得られるバイト数を計算します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <returns>指定した文字コードのバイトシーケンスにエンコードすることで得られるバイト数。</returns>
        public static int GetBytesCount(this string value, Encoding enc) => enc.GetByteCount(value);

        /// <summary>
        /// この文字列に格納されている値を、文字コード Shift-JIS のバイトシーケンスにエンコードすることで得られるバイト数を計算します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード Shift-JIS のバイトシーケンスにエンコードすることで得られるバイト数。</returns>
        public static int GetShiftJISBytesCount(this string value) => value.GetBytesCount(CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード JIS のバイトシーケンスにエンコードすることで得られるバイト数を計算します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード JIS のバイトシーケンスにエンコードすることで得られるバイト数。</returns>
        public static int GetJISBytesCount(this string value) => value.GetBytesCount(CharacterEncodingFactory.JIS.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード EUC のバイトシーケンスにエンコードすることで得られるバイト数を計算します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード EUC のバイトシーケンスにエンコードすることで得られるバイト数。</returns>
        public static int GetEUCBytesCount(this string value) => value.GetBytesCount(CharacterEncodingFactory.EUC.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード UTF-8 のバイトシーケンスにエンコードすることで得られるバイト数を計算します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード UTF-8 のバイトシーケンスにエンコードすることで得られるバイト数。</returns>
        public static int GetUTF8BytesCount(this string value) => value.GetBytesCount(CharacterEncodingFactory.UTF8.CharacterEncoding);

        #endregion

        #region SubstringByte

        /// <summary>
        /// このインスタンスから部分文字列を取得します。部分文字列は、文字列中の指定したバイト数の位置で開始し、文字列の末尾まで続きます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="startIndex">このインスタンスから部分文字列の 0 から始まる開始位置。</param>
        /// <returns>このインスタンスの <paramref name="startIndex"/> で始まる部分文字列と等価な文字列。または、<paramref name="startIndex"/> がこのインスタンスの長さと等しい場合は <see cref="string.Empty"/>。</returns>
        public static string SubstringByte(this string value, int startIndex) => value.SubstringByte(startIndex, value.GetBytesCount(CharacterEncodingFactory.ShiftJIS.CharacterEncoding));

        /// <summary>
        /// このインスタンスから部分文字列を取得します。部分文字列は、文字列中の指定したバイト数の位置で開始し、指定したバイト数の文字列です。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="startIndex">このインスタンスから部分文字列の 0 から始まる開始位置。</param>
        /// <param name="length">部分文字列のバイト数。</param>
        /// <returns>このインスタンスの <paramref name="startIndex"/> から始まる長さ <paramref name="length"/> の部分文字列と等価な文字列。または、<paramref name="startIndex"/> がこのインスタンスの長さと等しく、<paramref name="length"/> が 0 の場合は <see cref="string.Empty"/>。</returns>
        public static string SubstringByte(this string value, int startIndex, int length)
        {
            var binaryText = value.ToShiftJISBytes();

            if (binaryText.Length < 1) return string.Empty;
            if (binaryText.Length < length) length = binaryText.Length;

            var subStringText = binaryText.ToShiftJISString(startIndex, length);

            var firstCharOnLeft = binaryText.ToShiftJISString(0, 1);
            var firstCharOneLeftOnLeft = value[firstCharOnLeft.Length - 1];

            // 最初の文字が全角の途中で切れていた場合、除去します。
            if (subStringText.Length > 0 && firstCharOneLeftOnLeft != subStringText.First()) subStringText = subStringText[1..];

            var subStringLastChar = binaryText.ToShiftJISString(0, length);
            var lastChar = value[subStringLastChar.Length - 1];

            // 最後の文字が全角の途中で切れていた場合、除去します。
            if (subStringText.Length > 0 && subStringText[^1] != lastChar) subStringText = subStringText[..^1];

            return subStringText;
        }

        #endregion

    }
}
