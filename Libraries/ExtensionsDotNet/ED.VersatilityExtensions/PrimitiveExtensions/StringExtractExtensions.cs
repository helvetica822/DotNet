using ED.VersatilityExtensions.FactoryProvider.CharacterEncodings;
using System.IO.Compression;
using System.Text;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// 展開処理に関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringExtractExtensions
    {

        // ↓ Extension↓

        #region JIS

        /// <summary>
        /// パス文字列の文字コード JIS ZIP 書庫を書庫と同じディレクトリに同じ名前で解凍します。
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void ExtractFromJISZipFile(this string value) => value.ExtractFromJISZipFile(null);

        /// <summary>
        /// パス文字列の文字コード JIS ZIP 書庫を指定したディレクトリに解凍します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">解凍先のディレクトリパス。</param>
        public static void ExtractFromJISZipFile(this string value, string? destFilePath) => value.ExtractFromZipFile(destFilePath, CharacterEncodingFactory.JIS.CharacterEncoding);

        #endregion

        #region Shift-JIS

        /// <summary>
        /// パス文字列の文字コード Shift-JIS ZIP 書庫を書庫と同じディレクトリに同じ名前で解凍します。
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void ExtractFromShiftJISZipFile(this string value) => value.ExtractFromShiftJISZipFile(null);

        /// <summary>
        /// パス文字列の文字コード Shift-JIS ZIP 書庫を指定したディレクトリに解凍します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">解凍先のディレクトリパス。</param>
        public static void ExtractFromShiftJISZipFile(this string value, string? destFilePath) => value.ExtractFromZipFile(destFilePath, CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        #endregion

        #region EUC

        /// <summary>
        /// パス文字列の文字コード EUC ZIP 書庫を書庫と同じディレクトリに同じ名前で解凍します。
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void ExtractFromEUCZipFile(this string value) => value.ExtractFromEUCZipFile(null);

        /// <summary>
        /// パス文字列の文字コード EUC ZIP 書庫を指定したディレクトリに解凍します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">解凍先のディレクトリパス。</param>
        public static void ExtractFromEUCZipFile(this string value, string? destFilePath) => value.ExtractFromZipFile(destFilePath, CharacterEncodingFactory.EUC.CharacterEncoding);

        #endregion

        #region UTF-8

        /// <summary>
        /// パス文字列の文字コード UTF-8 ZIP 書庫を書庫と同じディレクトリに同じ名前で解凍します。
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void ExtractFromUTF8ZipFile(this string value) => value.ExtractFromUTF8ZipFile(null);

        /// <summary>
        /// パス文字列の文字コード UTF-8 ZIP 書庫を指定したディレクトリに解凍します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">解凍先のディレクトリパス。</param>
        public static void ExtractFromUTF8ZipFile(this string value, string? destFilePath) => value.ExtractFromZipFile(destFilePath, CharacterEncodingFactory.UTF8.CharacterEncoding);

        #endregion

        #region Extract

        /// <summary>
        /// パス文字列の ZIP 書庫を書庫と同じディレクトリに同じ名前で解凍します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">エンコーダ。</param>
        public static void ExtractFromZipFile(this string value, Encoding enc) => value.ExtractFromZipFile(null, enc);

        /// <summary>
        /// パス文字列の ZIP 書庫を指定したディレクトリに解凍します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">解凍先のディレクトリパス。</param>
        /// <param name="enc">エンコーダ。</param>
        public static void ExtractFromZipFile(this string value, string? destFilePath, Encoding enc)
        {
            if (destFilePath is null) throw new Exception($"{nameof(destFilePath)} が不正です。");

            destFilePath ??= value.GetDirectoryName()?.ConcatDirectorySeparator() + value.GetFileNameWithoutExtension();
            ZipFile.ExtractToDirectory(value, destFilePath, enc);
        }

        #endregion

    }
}
