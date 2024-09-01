using ED.VersatilityExtensions.FactoryProvider.CharacterEncodings;
using System.Text;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// <see cref="byte"/> の拡張機能を提供します。
    /// </summary>
    public static class ByteExtensions
    {

        // ↓ Extension↓

        #region ToBase64String

        /// <summary>
        /// このバイトシーケンスを Base 64 文字列に変換します。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <returns>Base 64 文字列。</returns>
        public static string ToBase64String(this byte[] value) => Convert.ToBase64String(value);

        #endregion

        #region ToRFC2047String

        /// <summary>
        /// このバイトシーケンスを Base 64 形式 RFC2047 文字列に変換します。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <returns>RFC2047 文字列。</returns>
        public static string ToBase64RFC2047String(this byte[] value, Encoding enc)
        {
            var base64 = value.ToBase64String();
            return $"=?{enc.BodyName}?B?{base64}?=";
        }

        #endregion

        #region String

        /// <summary>
        /// このバイトシーケンスを、指定した文字コードの文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <returns>指定した文字コードの文字列。</returns>
        public static string ToEncodingString(this byte[] value, Encoding enc) => value.ToEncodingString(enc, 0);

        /// <summary>
        /// このバイトシーケンスを、指定した文字コードの文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <param name="startIndex">デコードを開始するインデックス。</param>
        /// <returns>指定した文字コードの文字列。</returns>
        public static string ToEncodingString(this byte[] value, Encoding enc, int startIndex) => value.ToEncodingString(enc, startIndex, value.Length);

        /// <summary>
        /// このバイトシーケンスを、指定した文字コードの文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <param name="startIndex">デコードを開始するインデックス。</param>
        /// <param name="length">デコードするバイト数。</param>
        /// <returns>指定した文字コードの文字列。</returns>
        public static string ToEncodingString(this byte[] value, Encoding enc, int startIndex, int length) => enc.GetString(value, startIndex, length);

        /// <summary>
        /// このバイトシーケンスを、文字コード Shift-JIS の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <returns>文字コード Shit-JIS の文字列。</returns>
        public static string ToShiftJISString(this byte[] value) => value.ToShiftJISString(0);

        /// <summary>
        /// このバイトシーケンスを、文字コード Shift-JIS の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="startIndex">デコードを開始するインデックス。</param>
        /// <param name="length">デコードするバイト数。</param>
        /// <returns>文字コード Shit-JIS の文字列。</returns>
        public static string ToShiftJISString(this byte[] value, int startIndex) => value.ToShiftJISString(startIndex, value.Length);

        /// <summary>
        /// このバイトシーケンスを、文字コード Shift-JIS の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="startIndex">デコードを開始するインデックス。</param>
        /// <param name="length">デコードするバイト数。</param>
        /// <returns>文字コード Shit-JIS の文字列。</returns>
        public static string ToShiftJISString(this byte[] value, int startIndex, int length) => CharacterEncodingFactory.ShiftJIS.CharacterEncoding.GetString(value, startIndex, length);

        /// <summary>
        /// このバイトシーケンスを、文字コード JIS の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <returns>文字コード JIS の文字列。</returns>
        public static string ToJISString(this byte[] value) => value.ToJISString(0);

        /// <summary>
        /// このバイトシーケンスを、文字コード JIS の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="startIndex">デコードを開始するインデックス。</param>
        /// <returns>文字コード JIS の文字列。</returns>
        public static string ToJISString(this byte[] value, int startIndex) => value.ToJISString(startIndex, value.Length);

        /// <summary>
        /// このバイトシーケンスを、文字コード JIS の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="startIndex">デコードを開始するインデックス。</param>
        /// <param name="length">デコードするバイト数。</param>
        /// <returns>文字コード JIS の文字列。</returns>
        public static string ToJISString(this byte[] value, int startIndex, int length) => CharacterEncodingFactory.JIS.CharacterEncoding.GetString(value, startIndex, length);

        /// <summary>
        /// このバイトシーケンスを、文字コード EUC の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <returns>文字コード EUC の文字列。</returns>
        public static string ToEUCString(this byte[] value) => value.ToEUCString(0);

        /// <summary>
        /// このバイトシーケンスを、文字コード EUC の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="startIndex">デコードを開始するインデックス。</param>
        /// <param name="length">デコードするバイト数。</param>
        /// <returns>文字コード EUC の文字列。</returns>
        public static string ToEUCString(this byte[] value, int startIndex) => value.ToEUCString(startIndex, value.Length);

        /// <summary>
        /// このバイトシーケンスを、文字コード EUC の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="startIndex">デコードを開始するインデックス。</param>
        /// <param name="length">デコードするバイト数。</param>
        /// <returns>文字コード EUC の文字列。</returns>
        public static string ToEUCString(this byte[] value, int startIndex, int length) => CharacterEncodingFactory.EUC.CharacterEncoding.GetString(value, startIndex, length);

        /// <summary>
        /// このバイトシーケンスを、文字コード UTF-8 の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <returns>文字コード UTF-8 の文字列。</returns>
        public static string ToUTF8String(this byte[] value) => value.ToUTF8String(0);

        /// <summary>
        /// このバイトシーケンスを、文字コード UTF-8 の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="startIndex">デコードを開始するインデックス。</param>
        /// <returns>文字コード UTF-8 の文字列。</returns>
        public static string ToUTF8String(this byte[] value, int startIndex) => value.ToUTF8String(startIndex, value.Length);

        /// <summary>
        /// このバイトシーケンスを、文字コード UTF-8 の文字列にデコードします。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="startIndex">デコードを開始するインデックス。</param>
        /// <param name="length">デコードするバイト数。</param>
        /// <returns>文字コード UTF-8 の文字列。</returns>
        public static string ToUTF8String(this byte[] value, int startIndex, int length) => CharacterEncodingFactory.UTF8.CharacterEncoding.GetString(value, startIndex, length);

        #endregion

        #region Write File

        /// <summary>
        /// このバイトシーケンスを、ファイルへ追記書き込みします。
        ///     <para>ファイルが存在しない場合は新規作成されます。</para>
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="path">ファイルパス。</param>
        public static void AppendFile(this byte[] value, string path) => value.WriteFile(path, FileMode.Append);

        /// <summary>
        /// このバイトシーケンスを、ファイルへ上書き書き込みします。
        ///     <para>ファイルが存在しない場合は新規作成されます。</para>
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="path">ファイルパス。</param>
        public static void OverwriteFile(this byte[] value, string path) => value.WriteFile(path, FileMode.Create);

        /// <summary>
        /// このバイトシーケンスを、ファイルを新規作成して書き込みします。
        ///     <para>ファイルが既に存在している場合は <see cref="IOException"/> がスローされます。</para>
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="path">ファイルパス。</param>
        public static void CreateFile(this byte[] value, string path) => value.WriteFile(path, FileMode.CreateNew);

        /// <summary>
        /// このバイトシーケンスを、ファイルの開き方を指定して書き込みを行います。
        /// </summary>
        /// <param name="value">バイトシーケンス。</param>
        /// <param name="path">ファイルパス。</param>
        /// <param name="mode">ファイルの開き方を示す <see cref="FileMode"/> 列挙体。</param>
        public static void WriteFile(this byte[] value, string path, FileMode mode)
        {
            using var stream = new FileStream(path, mode, FileAccess.Write);
            stream.Write(value, 0, value.Length);
        }

        #endregion

    }
}
