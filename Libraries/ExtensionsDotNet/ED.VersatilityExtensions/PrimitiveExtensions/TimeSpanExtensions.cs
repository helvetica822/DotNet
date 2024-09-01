using ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{
    /// <summary>
    /// <see cref="TimeSpan"/> の拡張機能を提供します。
    /// </summary>
    public static class TimeSpanExtensions
    {

        // ↓ Extension↓

        #region FormattedString

        /// <summary>
        /// この時間間隔を指定したフォーマットに基づいた文字列に変換します。
        /// </summary>
        /// <param name="value">時間間隔。</param>
        /// <param name="format">変換フォーマット。</param>
        /// <returns>指定したフォーマットに基づいた文字列。</returns>
        public static string ToFormattedString(this TimeSpan value, AbstractTimeSpanFormat format) => value.ToFormattedString(format, false);

        /// <summary>
        /// この時間間隔を指定したフォーマットに基づいた文字列に変換します。
        /// </summary>
        /// <param name="value">時間間隔。</param>
        /// <param name="format">変換フォーマット。</param>
        /// <param name="isRemoveDelimiter">区切り文字を除去する場合は true。それ以外の場合は false。</param>
        /// <returns>指定したフォーマットに基づいた文字列。</returns>
        public static string ToFormattedString(this TimeSpan value, AbstractTimeSpanFormat format, bool isRemoveDelimiter) => value.ToFormattedString(format, isRemoveDelimiter, true);

        /// <summary>
        /// この時間間隔を指定したフォーマットに基づいた文字列に変換します。
        /// </summary>
        /// <param name="value">時間間隔。</param>
        /// <param name="format">変換フォーマット。</param>
        /// <param name="isRemoveDelimiter">区切り文字を除去する場合は true。それ以外の場合は false。</param>
        /// <param name="padding">0 パディングを含むフォーマットを使用する場合は true。それ以外の場合は false。</param>
        /// <returns>指定したフォーマットに基づいた文字列。</returns>
        public static string ToFormattedString(this TimeSpan value, AbstractTimeSpanFormat format, bool isRemoveDelimiter, bool padding)
        {
            var f = padding ? format.ZeroPaddingFormat : format.NoPaddingFormat;
            var formattedValue = value.ToString(f);
            return isRemoveDelimiter ? RemoveDelimiters(formattedValue) : formattedValue;
        }

        #endregion

        // ↓ Private static method↓

        #region RemoveDelimiters

        /// <summary>
        /// 指定した文字列から時間間隔に含まれる区切り文字を除去します。
        /// </summary>
        /// <param name="value">時間間隔フォーマット文字列。</param>
        /// <returns>区切り文字を除去した文字列。</returns>
        private static string RemoveDelimiters(string value) => value.Replace(":", string.Empty).Replace(".", string.Empty);

        #endregion

    }
}
