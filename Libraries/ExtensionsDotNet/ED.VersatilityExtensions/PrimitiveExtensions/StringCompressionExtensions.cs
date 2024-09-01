using ED.VersatilityExtensions.FactoryProvider.CharacterEncodings;
using System.IO.Compression;
using System.Text;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// 圧縮処理に関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringCompressionExtensions
    {

        // ↓ Extension↓

        #region Fastest

        #region JIS

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void FastestCompressionToJISZipFile(this string value) => value.FastestCompressionToJISZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void FastestCompressionToJISZipFile(this string value, bool includeBaseDirectory) => value.FastestCompressionToJISZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード JIS の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void FastestCompressionToJISZipFile(this string value, string destFilePath) => value.FastestCompressionToJISZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード JIS の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void FastestCompressionToJISZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.Fastest, includeBaseDirectory, CharacterEncodingFactory.JIS.CharacterEncoding);

        #endregion

        #region Shift-JIS

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード Shift-JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void FastestCompressionToShiftJISZipFile(this string value) => value.FastestCompressionToShiftJISZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード Shift-JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void FastestCompressionToShiftJISZipFile(this string value, bool includeBaseDirectory) => value.FastestCompressionToShiftJISZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード Shift-JIS の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void FastestCompressionToShiftJISZipFile(this string value, string destFilePath) => value.FastestCompressionToShiftJISZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード Shift-JIS の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void FastestCompressionToShiftJISZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.Fastest, includeBaseDirectory, CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        #endregion

        #region EUC

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード EUC の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void FastestCompressionToEUCZipFile(this string value) => value.FastestCompressionToEUCZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード EUC の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void FastestCompressionToEUCZipFile(this string value, bool includeBaseDirectory) => value.FastestCompressionToEUCZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード EUC の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void FastestCompressionToEUCZipFile(this string value, string destFilePath) => value.FastestCompressionToEUCZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード EUC の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void FastestCompressionToEUCZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.Fastest, includeBaseDirectory, CharacterEncodingFactory.EUC.CharacterEncoding);

        #endregion

        #region UTF-8

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード UTF-8 の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void FastestCompressionToUTF8ZipFile(this string value) => value.FastestCompressionToUTF8ZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード UTF-8 の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void FastestCompressionToUTF8ZipFile(this string value, bool includeBaseDirectory) => value.FastestCompressionToUTF8ZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード UTF-8 の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void FastestCompressionToUTF8ZipFile(this string value, string destFilePath) => value.FastestCompressionToUTF8ZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリを速度重視で文字コード UTF-8 の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void FastestCompressionToUTF8ZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.Fastest, includeBaseDirectory, CharacterEncodingFactory.UTF8.CharacterEncoding);

        #endregion

        #endregion

        #region NoCompression

        #region JIS

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void NoCompressionCompressionToJISZipFile(this string value) => value.NoCompressionCompressionToJISZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void NoCompressionCompressionToJISZipFile(this string value, bool includeBaseDirectory) => value.NoCompressionCompressionToJISZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード JIS の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void NoCompressionCompressionToJISZipFile(this string value, string destFilePath) => value.NoCompressionCompressionToJISZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード JIS の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void NoCompressionCompressionToJISZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.NoCompression, includeBaseDirectory, CharacterEncodingFactory.JIS.CharacterEncoding);

        #endregion

        #region Shift-JIS

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード Shift-JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void NoCompressionCompressionToShiftJISZipFile(this string value) => value.NoCompressionCompressionToShiftJISZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード Shift-JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void NoCompressionCompressionToShiftJISZipFile(this string value, bool includeBaseDirectory) => value.NoCompressionCompressionToShiftJISZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード Shift-JIS の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void NoCompressionCompressionToShiftJISZipFile(this string value, string destFilePath) => value.NoCompressionCompressionToShiftJISZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード Shift-JIS の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void NoCompressionCompressionToShiftJISZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.NoCompression, includeBaseDirectory, CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        #endregion

        #region EUC

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード EUC の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void NoCompressionCompressionToEUCZipFile(this string value) => value.NoCompressionCompressionToEUCZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード EUC の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void NoCompressionCompressionToEUCZipFile(this string value, bool includeBaseDirectory) => value.NoCompressionCompressionToEUCZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード EUC の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void NoCompressionCompressionToEUCZipFile(this string value, string destFilePath) => value.NoCompressionCompressionToEUCZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード EUC の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void NoCompressionCompressionToEUCZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.NoCompression, includeBaseDirectory, CharacterEncodingFactory.EUC.CharacterEncoding);

        #endregion

        #region UTF-8

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード UTF-8 の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void NoCompressionCompressionToUTF8ZipFile(this string value) => value.NoCompressionCompressionToUTF8ZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード UTF-8 の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void NoCompressionCompressionToUTF8ZipFile(this string value, bool includeBaseDirectory) => value.NoCompressionCompressionToUTF8ZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード UTF-8 の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void NoCompressionCompressionToUTF8ZipFile(this string value, string destFilePath) => value.NoCompressionCompressionToUTF8ZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリをファイルに対する圧縮は行わず、文字コード UTF-8 の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void NoCompressionCompressionToUTF8ZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.NoCompression, includeBaseDirectory, CharacterEncodingFactory.UTF8.CharacterEncoding);

        #endregion

        #endregion

        #region Optimal

        #region JIS

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void OptimalCompressionToJISZipFile(this string value) => value.OptimalCompressionToJISZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void OptimalCompressionToJISZipFile(this string value, bool includeBaseDirectory) => value.OptimalCompressionToJISZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード JIS の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void OptimalCompressionToJISZipFile(this string value, string? destFilePath) => value.OptimalCompressionToJISZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード JIS の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void OptimalCompressionToJISZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.Optimal, includeBaseDirectory, CharacterEncodingFactory.JIS.CharacterEncoding);

        #endregion

        #region Shift-JIS

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード Shift-JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void OptimalCompressionToShiftJISZipFile(this string value) => value.OptimalCompressionToShiftJISZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード Shift-JIS の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void OptimalCompressionToShiftJISZipFile(this string value, bool includeBaseDirectory) => value.OptimalCompressionToShiftJISZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード Shift-JIS の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void OptimalCompressionToShiftJISZipFile(this string value, string? destFilePath) => value.OptimalCompressionToShiftJISZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード Shift-JIS の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void OptimalCompressionToShiftJISZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.Optimal, includeBaseDirectory, CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        #endregion

        #region EUC

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード EUC の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void OptimalCompressionToEUCZipFile(this string value) => value.OptimalCompressionToEUCZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード EUC の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void OptimalCompressionToEUCZipFile(this string value, bool includeBaseDirectory) => value.OptimalCompressionToEUCZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード EUC の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void OptimalCompressionToEUCZipFile(this string value, string? destFilePath) => value.OptimalCompressionToEUCZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード EUC の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void OptimalCompressionToEUCZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.Optimal, includeBaseDirectory, CharacterEncodingFactory.EUC.CharacterEncoding);

        #endregion

        #region UTF-8

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード UTF-8 の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void OptimalCompressionToUTF8ZipFile(this string value) => value.OptimalCompressionToUTF8ZipFile(false);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード UTF-8 の ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void OptimalCompressionToUTF8ZipFile(this string value, bool includeBaseDirectory) => value.OptimalCompressionToUTF8ZipFile(null, includeBaseDirectory);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード UTF-8 の ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        public static void OptimalCompressionToUTF8ZipFile(this string value, string? destFilePath) => value.OptimalCompressionToUTF8ZipFile(destFilePath, false);

        /// <summary>
        /// パス文字列のディレクトリを時間がかかる場合でも最適な圧縮率で文字コード UTF-8 の ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        public static void OptimalCompressionToUTF8ZipFile(this string value, string? destFilePath, bool includeBaseDirectory) => value.CompressionToZipFile(destFilePath, CompressionLevel.Optimal, includeBaseDirectory, CharacterEncodingFactory.UTF8.CharacterEncoding);

        #endregion

        #endregion

        #region Compression

        /// <summary>
        /// パス文字列のディレクトリを ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="level">圧縮レベル。</param>
        /// <param name="enc">エンコーダ。</param>
        public static void CompressionToZipFile(this string value, CompressionLevel level, Encoding enc) => value.CompressionToZipFile(level, false, enc);

        /// <summary>
        /// パス文字列のディレクトリを ZIP 書庫に圧縮します。
        ///     <para>アーカイブのルートディレクトリと同じ名前、同じディレクトリに ZIP 書庫が作成されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="level">圧縮レベル。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートディレクトリを含める場合は true。それ以外の場合は false。</param>
        /// <param name="enc">エンコーダ。</param>
        public static void CompressionToZipFile(this string value, CompressionLevel level, bool includeBaseDirectory, Encoding enc) => value.CompressionToZipFile(null, level, includeBaseDirectory, enc);

        /// <summary>
        /// パス文字列のディレクトリを ZIP 書庫に圧縮します。
        ///     <para>ZIP 書庫にアーカイブのルートディレクトリは含まれません。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="level">圧縮レベル。</param>
        /// <param name="enc">エンコーダ。</param>
        public static void CompressionToZipFile(this string value, string? destFilePath, CompressionLevel level, Encoding enc) => value.CompressionToZipFile(destFilePath, level, false, enc);

        /// <summary>
        /// パス文字列のディレクトリを ZIP 書庫に圧縮します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">圧縮した ZIP 書庫のパス。</param>
        /// <param name="level">圧縮レベル。</param>
        /// <param name="includeBaseDirectory">アーカイブのルートにあるディレクトリを含める場合は true。それ以外の場合は false。</param>
        /// <param name="enc">エンコーダ。</param>
        public static void CompressionToZipFile(this string value, string? destFilePath, CompressionLevel level, bool includeBaseDirectory, Encoding enc)
        {
            destFilePath ??= GetZipFilePathOfCurrentDirectory(value);

            if (destFilePath is null) throw new Exception($"{nameof(destFilePath)} が不正です。");

            var extension = destFilePath.GetExtension();
            if (extension is null || extension.ToLower() != ".zip") destFilePath = destFilePath.GetDirectoryName()?.ConcatDirectorySeparator() + destFilePath.GetFileNameWithoutExtension() + ".zip";

            ZipFile.CreateFromDirectory(value, destFilePath, level, includeBaseDirectory, enc);
        }

        #endregion

        // ↓ Private method↓

        #region Get Zip File Path

        /// <summary>
        /// 同一ディレクトリに ZIP 書庫を作成する場合のパスを取得します。
        /// </summary>
        /// <param name="value">アーカイブディレクトリパス。</param>
        /// <returns>同一ディレクトリに ZIP 書庫を作成する場合のパス。</returns>
        private static string? GetZipFilePathOfCurrentDirectory(string value)
        {
            var destFilePath = value.GetDirectoryName();
            if (destFilePath is null) return null;

            var zipFileName = string.Empty;

            if (value.ExistsDirectory()) zipFileName = value.GetFileName();

            return destFilePath.ConcatDirectorySeparator() + zipFileName;
        }

        #endregion

    }
}
