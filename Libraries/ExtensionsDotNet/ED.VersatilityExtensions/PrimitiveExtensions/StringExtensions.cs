using ED.VersatilityExtensions.FactoryProvider.StringMatchingPatterns;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringExtensions
    {

        // ↓ Extension↓

        #region Null or Empty or WhiteSpace

        /// <summary>
        /// この文字列に格納されている値が <see cref="string.Empty"/> であるか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>格納されている値が <see cref="string.Empty"/> である場合は true。それ以外の場合は false。</returns>
        public static bool IsEmpty(this string value) => value == string.Empty;

        /// <summary>
        /// この文字列に格納されている値が <see cref="null"/> であるか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>格納されている値が <see cref="null"/> である場合は true。それ以外の場合は false。</returns>
        public static bool IsNull(this string value) => value is null;

        /// <summary>
        /// この文字列に格納されている値が <see cref="null"/> 、 <see cref="string.Empty"/> のいずれかであるか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>格納されている値が <see cref="null"/> 、 <see cref="string.Empty"/> のいずれかである場合は true。それ以外の場合は false。</returns>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// この文字列に格納されている値が半角空白であるか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>格納されている値が半角空白である場合は true。それ以外の場合は false。</returns>
        public static bool IsAllHalfWhiteSpace(this string value) => Regex.IsMatch(value, @"^[ ]*$");

        /// <summary>
        /// この文字列に格納されている値が全角空白であるか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>格納されている値が全角空白である場合は true。それ以外の場合は false。</returns>
        public static bool IsAllFullWhiteSpace(this string value) => Regex.IsMatch(value, @"^[　]*$");

        /// <summary>
        /// この文字列に格納されている値が半角空白または全角空白であるか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>格納されている値が半角空白または全角空白である場合は true。それ以外の場合は false。</returns>
        public static bool IsWhiteSpace(this string value) => value.Trim() == string.Empty;

        /// <summary>
        /// この文字列に格納されている値が <see cref="null"/> 、 <see cref="string.Empty"/> 、半角空白、全角空白のいずれかであるか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>格納されている値が <see cref="null"/> 、 <see cref="string.Empty"/> 、半角空白、全角空白のいずれかである場合は true。それ以外の場合は false。</returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string value) => value.IsEmpty() || value.IsNull() || value.IsWhiteSpace();

        #endregion

        #region Substring

        /// <summary>
        /// このインスタンスの部分文字列を右から取得します。部分文字列は、文字列中の指定した文字位置で開始し、文字列の開始まで続きます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="startIndex">このインスタンスから部分文字列の 0 から始まる開始位置。</param>
        /// <returns>このインスタンスの <paramref name="startIndex"/> で始まる右からの部分文字列と等価な文字列。または、<paramref name="startIndex"/> がこのインスタンスの長さと等しい場合は <see cref="string.Empty"/>。</returns>
        public static string SubstringRight(this string value, int startIndex) => value.SubstringRight(startIndex, value.Length - startIndex);

        /// <summary>
        /// このインスタンスの部分文字列を右から取得します。部分文字列は、文字列中の指定した文字位置で開始し、指定した文字数の文字列です。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="startIndex">このインスタンスから部分文字列の 0 から始まる開始位置。</param>
        /// <param name="length">部分文字列のバイト数。</param>
        /// <returns>このインスタンスの <paramref name="startIndex"/> から始まる長さ <paramref name="length"/> の右からの部分文字列と等価な文字列。または、<paramref name="startIndex"/> がこのインスタンスの長さと等しく、<paramref name="length"/> が 0 の場合は <see cref="string.Empty"/>。</returns>
        public static string SubstringRight(this string value, int startIndex, int length) => value.Substring(value.Length - startIndex, length);

        #endregion

        #region Padding

        #region Left

        /// <summary>
        /// 指定した桁数になるようにこの文字列の左から 0 で埋めます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="length">桁数。</param>
        /// <returns>左から 0 で埋めた文字列。</returns>
        public static string PaddingZeroToLeft(this string value, int length) => value.PaddingCharToLeft(length, '0');

        /// <summary>
        /// 指定した桁数になるようにこの文字列の左から半角空白で埋めます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="length">桁数。</param>
        /// <returns>左から半角空白で埋めた文字列。</returns>
        public static string PaddingHalfSpaceToLeft(this string value, int length) => value.PaddingCharToLeft(length, ' ');

        /// <summary>
        /// 指定した桁数になるようにこの文字列の左から指定した文字で埋めます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="length">桁数。</param>
        /// <param name="paddingChar">埋める文字。</param>
        /// <returns>左から指定した文字で埋めた文字列。</returns>
        public static string PaddingCharToLeft(this string value, int length, char paddingChar) => value.PadLeft(length, paddingChar);

        #endregion

        #region Right

        /// <summary>
        /// 指定した桁数になるようにこの文字列の右から 0 で埋めます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="length">桁数。</param>
        /// <returns>右から 0 で埋めた文字列。</returns>
        public static string PaddingZeroToRight(this string value, int length) => value.PaddingCharToRight(length, '0');

        /// <summary>
        /// 指定した桁数になるようにこの文字列の右から半角空白で埋めます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="length">桁数。</param>
        /// <returns>右から半角空白で埋めた文字列。</returns>
        public static string PaddingHalfSpaceToRight(this string value, int length) => value.PaddingCharToRight(length, ' ');

        /// <summary>
        /// 指定した桁数になるようにこの文字列の右から指定した文字で埋めます。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="length">桁数。</param>
        /// <param name="paddingChar">埋める文字。</param>
        /// <returns>右から指定した文字で埋めた文字列。</returns>
        public static string PaddingCharToRight(this string value, int length, char paddingChar) => value.PadRight(length, paddingChar);

        #endregion

        #endregion

        #region SurrogatePairChararacter

        /// <summary>
        /// この文字列に格納されている値にサロゲートペア文字が含まれているか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>格納されている値にサロゲートペア文字が含まれている場合は true。それ以外の場合は false。</returns>
        public static bool IsContainsSurrogatePair(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            var info = new StringInfo(value);
            return info.LengthInTextElements < value.Length;
        }

        #endregion

        #region Compare

        /// <summary>
        /// この文字列と指定した比較文字列を全角・半角の区別をせずに比較して一致するか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="compareValue">比較文字列。</param>
        /// <returns>一致する場合は true。それ以外の場合は false。</returns>
        public static bool CompareIgnoreWidth(this string value, string compareValue) => value.Compare(compareValue, CompareOptions.IgnoreWidth);

        /// <summary>
        /// この文字列と指定した比較文字列を平仮名・片仮名の区別をせずに比較して一致するか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="compareValue">比較文字列。</param>
        /// <returns>一致する場合は true。それ以外の場合は false。</returns>
        public static bool CompareIgnoreKanaType(this string value, string compareValue) => value.Compare(compareValue, CompareOptions.IgnoreKanaType);

        /// <summary>
        /// この文字列と指定した比較文字列を大文字・小文字の区別をせずに比較して一致するか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="compareValue">比較文字列。</param>
        /// <returns>一致する場合は true。それ以外の場合は false。</returns>
        public static bool CompareIgnoreCase(this string value, string compareValue) => value.Compare(compareValue, CompareOptions.IgnoreCase);

        /// <summary>
        /// この文字列と指定した比較文字列を全角・半角、平仮名・片仮名の区別をせずに比較して一致するか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="compareValue">比較文字列。</param>
        /// <returns>一致する場合は true。それ以外の場合は false。</returns>
        public static bool CompareIgnoreWidthAndKanaType(this string value, string compareValue) => value.Compare(compareValue, CompareOptions.IgnoreWidth, CompareOptions.IgnoreKanaType);

        /// <summary>
        /// この文字列と指定した比較文字列を全角・半角、大文字・小文字の区別をせずに比較して一致するか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="compareValue">比較文字列。</param>
        /// <returns>一致する場合は true。それ以外の場合は false。</returns>
        public static bool CompareIgnoreWidthAndCase(this string value, string compareValue) => value.Compare(compareValue, CompareOptions.IgnoreWidth, CompareOptions.IgnoreCase);

        /// <summary>
        /// この文字列と指定した比較文字列を文字列比較オプションに基づいてに比較して一致するか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="compareValue">比較文字列。</param>
        /// <param name="options">文字列比較オプション。</param>
        /// <returns>一致する場合は true。それ以外の場合は false。</returns>
        public static bool Compare(this string value, string compareValue, params CompareOptions[] options)
        {
            var option = ConcatCompareOptions(options);
            var compare = CultureInfo.CurrentCulture.CompareInfo;

            return compare.Compare(value, compareValue, option) == 0;
        }

        #endregion

        #region IsMatching

        /// <summary>
        /// この文字列が検索パターンと検索対象文字列の組み合わせに一致するか比較します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="searchValue">検索対象文字列。</param>
        /// <param name="pattern">文字列検索パターン。</param>
        /// <returns>検索パターンと検索対象文字列の組み合わせに一致する場合は true。それ以外の場合は false。</returns>
        public static bool IsMatching(this string value, string searchValue, AbstractStringMatchingPattern pattern) => pattern.IsMatching(value, searchValue);

        #endregion

        #region Enclose

        /// <summary>
        /// この文字列をシングルクォーテーションで囲んだ文字列を取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>シングルクォーテーションで囲んだ文字列。</returns>
        public static string EncloseInSingleQuotes(this string value) => "'" + value + "'";

        /// <summary>
        /// この文字列をダブルクォーテーションで囲んだ文字列を取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>ダブルクォーテーションで囲んだ文字列。</returns>
        public static string EncloseInDoubleQuotes(this string value) => @"""" + value + @"""";

        #endregion

        #region Format

        /// <summary>
        /// この文字列の指定された形式に基づいてオブジェクトの値を文字列に変換し、挿入します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="args">挿入するオブジェクトの配列。</param>
        /// <returns>指定された形式に基づいて変換された文字列。</returns>
        public static string Formatting(this string value, params object[] args) => string.Format(value, args);

        #endregion

        #region Concat

        /// <summary>
        /// この文字列を指定した回数連結します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="count">連結する回数。</param>
        /// <returns>指定した回数連結した文字列。</returns>
        public static string RepeatConcat(this string value, int count)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                _ = sb.Append(value);
            }

            return sb.ToString();
        }

        #endregion

        #region Char Count

        /// <summary>
        /// この文字列の文字と出現回数を持つ <see cref="IDictionary{string, int}"/> を取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字と出現回数を持つ <see cref="IDictionary{string, int}"/> 。</returns>
        public static IDictionary<string, int> GetCharCountPairs(this string value)
        {
            var pairs = new Dictionary<string, int>();

            foreach (var v in value)
            {
                var c = v.ToString();

                if (pairs.ContainsKey(c))
                {
                    pairs[c]++;
                }
                else
                {
                    pairs.Add(c, 1);
                }
            }

            return pairs;
        }

        #endregion

        // ↓ Private method↓

        #region Compare

        /// <summary>
        /// 文字列比較に使用する文字列比較オプションを結合します。
        /// </summary>
        /// <param name="options">文字列比較オプションのコレクション。</param>
        /// <returns>連結した文字列比較オプション。</returns>
        private static CompareOptions ConcatCompareOptions(CompareOptions[] options)
        {
            var optionsList = options.ToList();

            var option = optionsList.First();
            optionsList.RemoveAt(0);

            foreach (var o in optionsList)
            {
                option |= o;
            }

            return option;
        }

        #endregion

    }
}
