namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// ディレクトリ操作に関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringDirectoryExtensions
    {

        // ↓ Extension↓

        #region Directory Separator

        /// <summary>
        /// パス文字列の末尾がセパレータ文字列であるか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>末尾がセパレータ文字列である場合は true。それ以外の場合は false。</returns>
        public static bool IsLastCharDirectorySeparator(this string value) => value[^1] == Path.DirectorySeparatorChar;

        /// <summary>
        /// パス文字列の末尾にセパレータ文字列を連結します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>末尾にセパレータ文字列を連結したパス文字列。</returns>
        public static string ConcatDirectorySeparator(this string value) => value.IsLastCharDirectorySeparator() ? value : value + Path.DirectorySeparatorChar;

        #endregion

        #region Create Directory Info

        /// <summary>
        /// パス文字列から <see cref="DirectoryInfo"/> を生成します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="DirectoryInfo"/>。</returns>
        public static DirectoryInfo CreateDirectoryInfo(this string value) => new(value);

        #endregion

        #region Get Sub Directories

        /// <summary>
        /// パス文字列のディレクトリ以下にあるサブディレクトリパスを全て取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>サブディレクトリ全てのディレクトリパスのコレクション。</returns>
        public static IEnumerable<string> GetAllSubDirectoriesPath(this string value) => value.GetAllSubDirectoriesPath("*");

        /// <summary>
        /// パス文字列のディレクトリ以下にあるサブディレクトリパスを検索パターンに基づいて取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="searchPattern">検索パターン。</param>
        /// <returns>検索パターンに基づくサブディレクトリのディレクトリパスのコレクション。</returns>
        public static IEnumerable<string> GetAllSubDirectoriesPath(this string value, string searchPattern)
        {
            var list = new List<string>();

            foreach (var d in value.GetAllSubDirectories(searchPattern))
            {
                list.Add(d.FullName);
            }

            return list;
        }

        /// <summary>
        /// パス文字列のディレクトリ以下にあるサブディレクトリを全て取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>サブディレクトリ全てのディレクトリ情報のコレクション。</returns>
        public static IEnumerable<DirectoryInfo> GetAllSubDirectories(this string value) => value.GetAllSubDirectories("*");

        /// <summary>
        /// パス文字列のディレクトリ以下にあるサブディレクトリを検索パターンに基づいて取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="searchPattern">検索パターン。</param>
        /// <returns>検索パターンに基づくサブディレクトリのディレクトリ情報のコレクション。</returns>
        public static IEnumerable<DirectoryInfo> GetAllSubDirectories(this string value, string searchPattern) => value.CreateDirectoryInfo().GetDirectories(searchPattern, SearchOption.AllDirectories);

        /// <summary>
        /// パス文字列のディレクトリにあるサブディレクトリパスを全て取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>サブディレクトリ全てのディレクトリパスのコレクション。</returns>
        public static IEnumerable<string> GetSubDirectoriesPathOfCurrent(this string value) => value.GetSubDirectoriesPathOfCurrent("*");

        /// <summary>
        /// パス文字列のディレクトリにあるサブディレクトリパスを検索パターンに基づいて取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="searchPattern">検索パターン。</param>
        /// <returns>検索パターンに基づくサブディレクトリのディレクトリパスのコレクション。</returns>
        public static IEnumerable<string> GetSubDirectoriesPathOfCurrent(this string value, string searchPattern)
        {
            var list = new List<string>();

            foreach (var d in value.GetSubDirectoriesOfCurrent(searchPattern))
            {
                list.Add(d.FullName);
            }

            return list;
        }

        /// <summary>
        /// パス文字列のディレクトリにあるサブディレクトリを全て取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>サブディレクトリ全てのディレクトリ情報のコレクション。</returns>
        public static IEnumerable<DirectoryInfo> GetSubDirectoriesOfCurrent(this string value) => value.GetSubDirectoriesOfCurrent("*");

        /// <summary>
        /// パス文字列のディレクトリにあるサブディレクトリを検索パターンに基づいて取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="searchPattern">検索パターン。</param>
        /// <returns>検索パターンに基づくサブディレクトリのディレクトリ情報のコレクション。</returns>
        public static IEnumerable<DirectoryInfo> GetSubDirectoriesOfCurrent(this string value, string searchPattern) => value.CreateDirectoryInfo().GetDirectories(searchPattern, SearchOption.TopDirectoryOnly);

        #endregion

        #region Get Files

        /// <summary>
        /// パス文字列のディレクトリ以下にあるファイルパスを全て取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>サブディレクトリ全てのファイルパスのコレクション。</returns>
        public static IEnumerable<string> GetAllFilesPath(this string value) => value.GetAllFilesPath("*");

        /// <summary>
        /// パス文字列のディレクトリ以下にあるファイルパスを検索パターンに基づいて取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="searchPattern">検索パターン。</param>
        /// <returns>検索パターンに基づくサブディレクトリのファイルパスのコレクション。</returns>
        public static IEnumerable<string> GetAllFilesPath(this string value, string searchPattern)
        {
            var list = new List<string>();

            foreach (var f in value.GetAllFiles(searchPattern))
            {
                list.Add(f.FullName);
            }

            return list;
        }

        /// <summary>
        /// パス文字列のディレクトリ以下にあるファイルを全て取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>サブディレクトリ全てのファイル情報のコレクション。</returns>
        public static IEnumerable<FileInfo> GetAllFiles(this string value) => value.GetAllFiles("*");

        /// <summary>
        /// パス文字列のディレクトリ以下にあるファイルを検索パターンに基づいて取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="searchPattern">検索パターン。</param>
        /// <returns>検索パターンに基づくサブディレクトリのファイル情報のコレクション。</returns>
        public static IEnumerable<FileInfo> GetAllFiles(this string value, string searchPattern) => value.CreateDirectoryInfo().GetFiles(searchPattern, SearchOption.AllDirectories);

        /// <summary>
        /// パス文字列のディレクトリにあるファイルパスを全て取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>サブディレクトリ全てのファイルパスのコレクション。</returns>
        public static IEnumerable<string> GetFilesPathOfCurrent(this string value) => value.GetFilesPathOfCurrent("*");

        /// <summary>
        /// パス文字列のディレクトリにあるファイルパスを検索パターンに基づいて取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="searchPattern">検索パターン。</param>
        /// <returns>検索パターンに基づくサブディレクトリのファイルパスのコレクション。</returns>
        public static IEnumerable<string> GetFilesPathOfCurrent(this string value, string searchPattern)
        {
            var list = new List<string>();

            foreach (var f in value.GetFilesOfCurrent(searchPattern))
            {
                list.Add(f.FullName);
            }

            return list;
        }

        /// <summary>
        /// パス文字列のディレクトリにあるファイルを全て取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>サブディレクトリ全てのファイル情報のコレクション。</returns>
        public static IEnumerable<FileInfo> GetFilesOfCurrent(this string value) => value.GetFilesOfCurrent("*");

        /// <summary>
        /// パス文字列のディレクトリにあるファイルを検索パターンに基づいて取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="searchPattern">検索パターン。</param>
        /// <returns>検索パターンに基づくサブディレクトリのファイル情報のコレクション。</returns>
        public static IEnumerable<FileInfo> GetFilesOfCurrent(this string value, string searchPattern) => value.CreateDirectoryInfo().GetFiles(searchPattern, SearchOption.TopDirectoryOnly);

        #endregion

        #region Create

        /// <summary>
        /// パス文字列のパスにディレクトリを作成します。
        /// </summary>
        /// <param name="value"></param>
        public static void CreateDirectory(this string value) => _ = Directory.CreateDirectory(value);

        #endregion

        #region Copy

        /// <summary>
        /// パス文字列のディレクトリを指定したパスへコピーします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destDirectoryPath">コピー先ディレクトリパス。</param>
        public static void DirectoryCopyTo(this string value, string destDirectoryPath) => value.DirectoryCopyTo(destDirectoryPath, false);

        /// <summary>
        /// パス文字列のディレクトリを指定したパスへコピーします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destDirectoryPath">コピー先ディレクトリパス。</param>
        /// <param name="overwrite">ファイルが存在する時に上書きする場合は true。それ以外の場合は false。</param>
        public static void DirectoryCopyTo(this string value, string destDirectoryPath, bool overwrite)
        {
            if (!destDirectoryPath.ExistsDirectory()) destDirectoryPath.CreateDirectory();

            destDirectoryPath = destDirectoryPath.ConcatDirectorySeparator();

            foreach (var f in value.GetFilesPathOfCurrent())
            {
                f.FileCopyTo(destDirectoryPath + f.GetFileName(), overwrite);
            }

            foreach (var d in value.GetSubDirectoriesPathOfCurrent())
            {
                d.DirectoryCopyTo(destDirectoryPath + d.GetFileName(), overwrite);
            }
        }

        #endregion

        #region Move

        /// <summary>
        /// パス文字列のディレクトリを指定したパスへ移動します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destDirectoryPath">移動先ディレクトリパス。</param>
        public static void DirectoryMoveTo(this string value, string destDirectoryPath) => Directory.Move(value, destDirectoryPath);

        #endregion

        #region Rename

        /// <summary>
        /// パス文字列のディレクトリを同一親ディレクトリのままリネームします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="newDirectoryName">新しいディレクトリ名。</param>
        public static void DirectoryRename(this string value, string newDirectoryName) => Directory.Move(value, value.GetDirectoryName() + Path.DirectorySeparatorChar + newDirectoryName);

        #endregion

        #region Delete

        /// <summary>
        /// パス文字列のディレクトリを削除します。
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void DirectoryDelete(this string value) => value.DirectoryDelete(false);

        /// <summary>
        /// パス文字列のディレクトリを削除します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="recursive">サブディレクトリ、ファイルも削除する場合は true。それ以外の場合は false。</param>
        public static void DirectoryDelete(this string value, bool recursive) => Directory.Delete(value, recursive);

        /// <summary>
        /// パス文字列の読み取り専用ディレクトリをサブディレクトリ、ファイルも含めて削除します。
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void ReadOnlyDirectoryDelete(this string value)
        {
            var d = value.CreateDirectoryInfo();

            RemoveReadOnlyAttribute(d);

            value.DirectoryDelete(true);
        }

        #endregion

        // ↓ Private method↓

        #region Directory Attribute

        /// <summary>
        /// 指定したディレクトリの全てのサブディレクトリとファイルの読み取り専用を削除します。
        /// </summary>
        /// <param name="d"><see cref="DirectoryInfo"/>。</param>
        private static void RemoveReadOnlyAttribute(DirectoryInfo d)
        {
            if (ContainsFileAttribute(d.Attributes, FileAttributes.ReadOnly)) d.Attributes = FileAttributes.Normal;

            foreach (var f in d.GetFiles())
            {
                if (ContainsFileAttribute(f.Attributes, FileAttributes.ReadOnly)) f.Attributes = FileAttributes.Normal;
            }

            foreach (var dir in d.GetDirectories())
            {
                RemoveReadOnlyAttribute(dir);
            }
        }

        /// <summary>
        /// ファイル属性のうち、指定した属性が含まれているか判断します。
        /// </summary>
        /// <param name="f">ファイル属性。</param>
        /// <param name="hasAttribute">含まれているか検証するファイル属性。</param>
        /// <returns>指定した属性が含まれている場合は true。それ以外の場合は false。</returns>
        private static bool ContainsFileAttribute(FileAttributes f, FileAttributes hasAttribute) => (f & hasAttribute) == hasAttribute;

        #endregion

    }
}
