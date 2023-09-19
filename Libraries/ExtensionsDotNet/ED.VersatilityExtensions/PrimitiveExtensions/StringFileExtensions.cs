using ED.VersatilityExtensions.FactoryProvider.CharacterEncodings;
using System.Text;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// ファイル操作に関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringFileExtensions
    {

        // ↓ Extension↓

        #region Create File Info

        /// <summary>
        /// パス文字列から <see cref="FileInfo"/> を生成します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="FileInfo"/>。</returns>
        public static FileInfo CreateFileInfo(this string value) => new(value);

        #endregion

        #region Copy

        /// <summary>
        /// パス文字列のファイルを指定したパスへコピーします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">コピー先ファイルパス。</param>
        public static void FileCopyTo(this string value, string destFilePath) => value.FileCopyTo(destFilePath, false);

        /// <summary>
        /// パス文字列のファイルを指定したパスへコピーします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">コピー先ファイルパス。</param>
        /// <param name="overwrite">ファイルが存在する時に上書きする場合は true。それ以外の場合は false。</param>
        public static void FileCopyTo(this string value, string destFilePath, bool overwrite) => File.Copy(value, destFilePath, overwrite);

        #endregion

        #region Move

        /// <summary>
        /// パス文字列のファイルを指定したパスへ移動します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">移動先ファイルパス。</param>
        public static void FileMoveTo(this string value, string destFilePath) => File.Move(value, destFilePath);

        #endregion

        #region Rename

        /// <summary>
        /// パス文字列のファイルを同一ディレクトリのままリネームします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="destFilePath">新しいファイル名。</param>
        public static void FileRename(this string value, string newFileName) => File.Move(value, value.GetDirectoryName() + Path.DirectorySeparatorChar + newFileName);

        #endregion

        #region Delete

        /// <summary>
        /// パス文字列のファイルを削除します。
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void FileDelete(this string value) => File.Delete(value);

        #endregion

        #region Get File Size

        /// <summary>
        /// パス文字列のファイルサイズを取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ファイルサイズ。</returns>
        public static long GetFileSize(this string value)
        {
            var f = new FileInfo(value);
            return f.Length;
        }

        #endregion

        #region Read File

        /// <summary>
        /// パス文字列のファイルを文字コード Shift-JIS で読み込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ファイルの全ての文字列。</returns>
        public static string ReadFileShiftJIS(this string value) => value.ReadFile(CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルを文字コード JIS で読み込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ファイルの全ての文字列。</returns>
        public static string ReadFileJIS(this string value) => value.ReadFile(CharacterEncodingFactory.JIS.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルを文字コード EUC で読み込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ファイルの全ての文字列。</returns>
        public static string ReadFileEUC(this string value) => value.ReadFile(CharacterEncodingFactory.EUC.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルを文字コード UTF-8 で読み込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ファイルの全ての文字列。</returns>
        public static string ReadFileUTF8(this string value) => value.ReadFile(CharacterEncodingFactory.UTF8.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルを読み込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <returns>ファイルの全ての文字列。</returns>
        public static string ReadFile(this string value, Encoding enc)
        {
            using var reader = new StreamReader(value, enc);
            return reader.ReadToEnd();
        }

        #endregion

        #region Read File Byte

        /// <summary>
        /// パス文字列のファイルをバイトシーケンスに読み込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ファイルの全てのバイトシーケンス。。</returns>
        public static byte[] ReadFileByte(this string value) => File.ReadAllBytes(value);

        #endregion

        #region Read Line File

        /// <summary>
        /// パス文字列のファイルを文字コード Shift-JIS で 1 行ずつ読み込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ファイルの全ての文字列 1 行ごとのコレクション。</returns>
        public static IEnumerable<string> ReadLineFileShiftJIS(this string value) => value.ReadLineFile(CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルを文字コード JIS で 1 行ずつ読み込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ファイルの全ての文字列 1 行ごとのコレクション。</returns>
        public static IEnumerable<string> ReadLineFileJIS(this string value) => value.ReadLineFile(CharacterEncodingFactory.JIS.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルを文字コード EUC で 1 行ずつ読み込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ファイルの全ての文字列 1 行ごとのコレクション。</returns>
        public static IEnumerable<string> ReadLineFileEUC(this string value) => value.ReadLineFile(CharacterEncodingFactory.EUC.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルを文字コード UTF-8 で 1 行ずつ読み込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ファイルの全ての文字列 1 行ごとのコレクション。</returns>
        public static IEnumerable<string> ReadLineFileUTF8(this string value) => value.ReadLineFile(CharacterEncodingFactory.UTF8.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルを 1 行ずつ読み込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <returns>ファイルの全ての文字列 1 行ごとのコレクション。</returns>
        public static IEnumerable<string> ReadLineFile(this string value, Encoding enc)
        {
            var list = new List<string>();

            using var reader = new StreamReader(value, enc);
            while (reader.Peek() > -1)
            {
                var line = reader.ReadLine();
                if (line is not null) list.Add(line);
            }

            return list;
        }

        #endregion

        #region Write File

        #region Append

        /// <summary>
        /// パス文字列のファイルにバイトシーケンスを追記書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="binaryText">書き込む文字列。</param>
        public static void AppendFile(this string value, byte[] binaryText) => binaryText.WriteFile(value, FileMode.Append);

        /// <summary>
        /// パス文字列のファイルに文字コード Shift-JIS で文字列を追記書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        public static void AppendFileShiftJIS(this string value, string text) => value.AppendFile(text, CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字コード JIS で文字列を追記書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        public static void AppendFileJIS(this string value, string text) => value.AppendFile(text, CharacterEncodingFactory.JIS.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字コード EUC で文字列を追記書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        public static void AppendFileEUC(this string value, string text) => value.AppendFile(text, CharacterEncodingFactory.EUC.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字コード UTF-8 で文字列を追記書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        public static void AppendFileUTF8(this string value, string text) => value.AppendFile(text, CharacterEncodingFactory.UTF8.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字列を追記書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        /// <param name="enc">エンコーダ。</param>
        public static void AppendFile(this string value, string text, Encoding enc) => value.WriteFile(text, true, enc);

        #endregion

        #region Overwrite

        /// <summary>
        /// パス文字列のファイルにバイトシーケンスを上書き書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="binaryText">書き込む文字列。</param>
        public static void OverwriteFile(this string value, byte[] binaryText) => binaryText.WriteFile(value, FileMode.Append);

        /// <summary>
        /// パス文字列のファイルに文字コード Shift-JIS で文字列を上書き書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        public static void OverwriteFileShiftJIS(this string value, string text) => value.OverwriteFile(text, CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字コード JIS で文字列を上書き書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        public static void OverwriteFileJIS(this string value, string text) => value.OverwriteFile(text, CharacterEncodingFactory.JIS.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字コード EUC で文字列を上書き書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        public static void OverwriteFileEUC(this string value, string text) => value.OverwriteFile(text, CharacterEncodingFactory.EUC.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字コード UTF-8 で文字列を上書き書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        public static void OverwriteFileUTF8(this string value, string text) => value.OverwriteFile(text, CharacterEncodingFactory.UTF8.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字列を上書き書き込みします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        /// <param name="enc">エンコーダ。</param>
        public static void OverwriteFile(this string value, string text, Encoding enc) => value.WriteFile(text, false, enc);

        #endregion

        #region Write

        /// <summary>
        /// パス文字列のファイルにバイトシーケンスを書き込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="binaryText">書き込む文字列。</param>
        /// <param name="isAppend">追記書き込みをする場合は true。それ以外の場合は false。</param>
        public static void WriteFile(this string value, byte[] binaryText, bool isAppend)
        {
            var mode = isAppend ? FileMode.Append : FileMode.Create;
            binaryText.WriteFile(value, mode);
        }

        /// <summary>
        /// パス文字列のファイルに文字コード Shift-JIS で文字列を書き込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        /// <param name="isAppend">追記書き込みをする場合は true。それ以外の場合は false。</param>
        public static void WriteFileShiftJIS(this string value, string text, bool isAppend) => value.WriteFile(text, isAppend, CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字コード JIS で文字列を書き込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        /// <param name="isAppend">追記書き込みをする場合は true。それ以外の場合は false。</param>
        public static void WriteFileJIS(this string value, string text, bool isAppend) => value.WriteFile(text, isAppend, CharacterEncodingFactory.JIS.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字コード EUC で文字列を書き込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        /// <param name="isAppend">追記書き込みをする場合は true。それ以外の場合は false。</param>
        public static void WriteFileEUC(this string value, string text, bool isAppend) => value.WriteFile(text, isAppend, CharacterEncodingFactory.EUC.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字コード UTF-8 で文字列を書き込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        /// <param name="isAppend">追記書き込みをする場合は true。それ以外の場合は false。</param>
        public static void WriteFileUTF8(this string value, string text, bool isAppend) => value.WriteFile(text, isAppend, CharacterEncodingFactory.UTF8.CharacterEncoding);

        /// <summary>
        /// パス文字列のファイルに文字列を書き込みます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="text">書き込む文字列。</param>
        /// <param name="isAppend">追記書き込みをする場合は true。それ以外の場合は false。</param>
        /// <param name="enc">エンコーダ。</param>
        public static void WriteFile(this string value, string text, bool isAppend, Encoding enc)
        {
            using var writer = new StreamWriter(value, isAppend, enc);
            writer.Write(text);
        }

        #endregion

        #endregion

    }

}
