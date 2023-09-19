namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// ファイルパスに関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringPathExtensions
    {

        // ↓ Extension↓

        #region Path

        /// <summary>
        /// パス文字列が絶対パスであるか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>絶対パスである場合は true。それ以外の場合は false。</returns>
        public static bool IsAbsolutePath(this string value) => Path.IsPathRooted(value);

        /// <summary>
        /// パス文字列から親ディレクトリ名を取得します。
        ///     <para>文字列がパス文字列ではない場合は <see cref="null"/> が返却されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ディレクトリ名。</returns>
        public static string? GetParentDirectoryName(this string value)
        {
            var path = value.GetDirectoryName()?.GetFileName();
            return string.IsNullOrEmpty(path) ? null : path;
        }

        /// <summary>
        /// パス文字列からディレクトリ名を取得します。
        ///     <para>文字列がパス文字列ではない場合は <see cref="null"/> が返却されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ディレクトリ名。</returns>
        public static string? GetDirectoryName(this string value)
        {
            var path = Path.GetDirectoryName(value);
            return string.IsNullOrEmpty(path) ? null : path;
        }

        /// <summary>
        /// パス文字列から拡張子を小文字で取得します。
        ///     <para>文字列がパス文字列ではない場合は <see cref="null"/> が返却されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>小文字の拡張子。</returns>
        public static string? GetLowerCaseExtension(this string value)
        {
            var ex = value.GetExtension();
            return string.IsNullOrEmpty(ex) ? null : ex.ToLower();
        }

        /// <summary>
        /// パス文字列から拡張子を大文字で取得します。
        ///     <para>文字列がパス文字列ではない場合は <see cref="null"/> が返却されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>大文字の拡張子。</returns>
        public static string? GetUpperCaseExtension(this string value)
        {
            var ex = value.GetExtension();
            return string.IsNullOrEmpty(ex) ? null : ex.ToUpper();
        }

        /// <summary>
        /// パス文字列から拡張子を取得します。
        ///     <para>文字列がパス文字列ではない場合は <see cref="null"/> が返却されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>拡張子。</returns>
        public static string? GetExtension(this string value)
        {
            var path = Path.GetExtension(value);
            return string.IsNullOrEmpty(path) ? null : path;
        }

        /// <summary>
        /// パス文字列から拡張子を含んだファイル名を取得します。
        ///     <para>文字列がパス文字列ではない場合は <see cref="null"/> が返却されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>拡張子を含んだファイル名。</returns>
        public static string? GetFileName(this string value)
        {
            var path = Path.GetFileName(value);
            return string.IsNullOrEmpty(path) ? null : path;
        }

        /// <summary>
        /// パス文字列から拡張子を含まないファイル名を取得します。
        ///     <para>文字列がパス文字列ではない場合は <see cref="null"/> が返却されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>拡張子を含まないファイル名。</returns>
        public static string? GetFileNameWithoutExtension(this string value)
        {
            var path = Path.GetFileNameWithoutExtension(value);
            return string.IsNullOrEmpty(path) ? null : path;
        }

        /// <summary>
        /// パス文字列からルートパスを取得します。
        ///     <para>文字列がパス文字列ではない場合は <see cref="null"/> が返却されます。</para>
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ルートパス。</returns>
        public static string? GetPathRoot(this string value)
        {
            var path = Path.GetPathRoot(value);
            return string.IsNullOrEmpty(path) ? null : path;
        }

        /// <summary>
        /// パス文字列が存在するファイルのパスであるか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>存在するファイルのパスである場合は true。それ以外の場合は false。</returns>
        public static bool ExistsFile(this string value) => File.Exists(value);

        /// <summary>
        /// パス文字列が存在するディレクトリのパスであるか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>存在するディレクトリのパスである場合は true。それ以外の場合は false。</returns>
        public static bool ExistsDirectory(this string value) => Directory.Exists(value);

        #endregion

    }
}
