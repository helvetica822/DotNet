using ED.VersatilityExtensions.FactoryProvider.DateTimeFormats;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// <see cref="DateTime"/> の拡張機能を提供します。
    /// </summary>
    public static class DateTimeExtensions
    {

        // ↓ Extension↓

        #region FormattedString

        /// <summary>
        /// この日時を指定したフォーマットに基づいた文字列に変換します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <param name="format">変換フォーマット。</param>
        /// <returns>指定したフォーマットに基づいた文字列。</returns>
        public static string ToFormattedString(this DateTime value, AbstractDateTimeFormat format) => value.ToFormattedString(format, false);

        /// <summary>
        /// この日時を指定したフォーマットに基づいた文字列に変換します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <param name="format">変換フォーマット。</param>
        /// <param name="isRemoveDelimiter">区切り文字を除去する場合は true。それ以外の場合は false。</param>
        /// <returns>指定したフォーマットに基づいた文字列。</returns>
        public static string ToFormattedString(this DateTime value, AbstractDateTimeFormat format, bool isRemoveDelimiter) => value.ToFormattedString(format, isRemoveDelimiter, true);

        /// <summary>
        /// この日時を指定したフォーマットに基づいた文字列に変換します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <param name="format">変換フォーマット。</param>
        /// <param name="isRemoveDelimiter">区切り文字を除去する場合は true。それ以外の場合は false。</param>
        /// <param name="padding">0 パディングを含むフォーマットを使用する場合は true。それ以外の場合は false。</param>
        /// <returns>指定したフォーマットに基づいた文字列。</returns>
        public static string ToFormattedString(this DateTime value, AbstractDateTimeFormat format, bool isRemoveDelimiter, bool padding)
        {
            var f = padding ? format.ZeroPaddingFormat : format.NoPaddingFormat;
            var formattedValue = value.ToString(f);
            return isRemoveDelimiter ? RemoveDelimiters(formattedValue) : formattedValue;
        }

        #endregion

        #region Is Leap Year

        /// <summary>
        /// この日時が閏年であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>閏年である場合は true。それ以外の場合は false。</returns>
        public static bool IsLeapYear(this DateTime value) => DateTime.DaysInMonth(value.Year, 2) == 29;

        #endregion

        #region Day Of Month

        /// <summary>
        /// この日時が持つ年月の日数を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>日数。</returns>
        public static int GetDaysInMonth(this DateTime value) => DateTime.DaysInMonth(value.Year, value.Month);

        /// <summary>
        /// この日時の月初日の日時を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>月初日の日時。</returns>
        public static DateTime GetFirstDateTimeOfMonth(this DateTime value) => new(value.Year, value.Month, 1);

        /// <summary>
        /// この日時の月末日の日時を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>月末日の日時。</returns>
        public static DateTime GetLastDateTimeOfMonth(this DateTime value) => new DateTime(value.Year, value.Month + 1, 1).AddDays(-1);

        #endregion

        #region Fiscal Year

        /// <summary>
        /// この日時の年度を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>年度。</returns>
        public static int GetFiscalYear(this DateTime value)
        {
            var year = value.Year;
            var month = value.Month;

            return (month >= 1 && month <= 3) ? year + 1 : year;
        }

        /// <summary>
        /// この日時の年度が日時の年の翌年として扱われる 1 月～ 3 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>年度が日時の年の翌年として扱われる 1 月～ 3 月である場合は true。それ以外の場合は false。</returns>
        public static bool IsJanToMarOfFiscalYear(this DateTime value)
        {
            var month = value.Month;
            return month >= 1 && month <= 3;
        }

        /// <summary>
        /// この日時と比較日時が同一年度か判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <param name="compareValue">比較日時。</param>
        /// <returns>この日時と比較日時が同一年度の場合は true。それ以外の場合は false。</returns>
        public static bool IsSameFiscalYear(this DateTime value, DateTime compareValue) => value.GetFiscalYear() == compareValue.GetFiscalYear();

        /// <summary>
        /// 年度の開始日時を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>年度の開始日時。</returns>
        public static DateTime GetStartDateTimeOfFiscalYear(this DateTime value)
        {
            var year = value.Year;
            if (value.IsJanToMarOfFiscalYear()) year--;

            return new DateTime(year, 4, 1);
        }

        /// <summary>
        /// 年度の終了日時を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>年度の終了日時。</returns>
        public static DateTime GetEndDateTimeOfFiscalYear(this DateTime value)
        {
            var year = value.Year;
            if (!value.IsJanToMarOfFiscalYear()) year++;

            return new DateTime(year, 3, 1);
        }

        #endregion

        #region Last or Next

        /// <summary>
        /// この日時の翌日を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>翌日の日時。</returns>
        public static DateTime GetTomorrow(this DateTime value) => value.AddDays(1);

        /// <summary>
        /// この日時の昨日を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>昨日の日時。</returns>
        public static DateTime GetYesterday(this DateTime value) => value.AddDays(-1);

        /// <summary>
        /// この日時の翌週を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>翌週の日時。</returns>
        public static DateTime GetNextWeek(this DateTime value) => value.AddDays(7);

        /// <summary>
        /// この日時の前週を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>前週の日時。</returns>
        public static DateTime GetLastWeek(this DateTime value) => value.AddDays(-7);

        /// <summary>
        /// この日時の翌月を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>翌月の日時。</returns>
        public static DateTime GetNextMonth(this DateTime value) => value.AddMonths(1);

        /// <summary>
        /// この日時の前月を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>前月の日時。</returns>
        public static DateTime GetLastMonth(this DateTime value) => value.AddMonths(-1);

        /// <summary>
        /// この日時の翌年を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>翌年の日時。</returns>
        public static DateTime GetNextYear(this DateTime value) => value.AddYears(1);

        /// <summary>
        /// この日時の前年を取得します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>前年の日時。</returns>
        public static DateTime GetLastYear(this DateTime value) => value.AddYears(-1);

        #endregion

        #region Day Of Week

        /// <summary>
        /// この日時の曜日が日曜日であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時の曜日が日曜日である場合 true。それ以外の場合は false。</returns>
        public static bool IsSunday(this DateTime value) => value.IsDayOfWeek(DayOfWeek.Sunday);

        /// <summary>
        /// この日時の曜日が月曜日であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時の曜日が月曜日である場合 true。それ以外の場合は false。</returns>
        public static bool IsMonday(this DateTime value) => value.IsDayOfWeek(DayOfWeek.Monday);

        /// <summary>
        /// この日時の曜日が火曜日であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時の曜日が火曜日である場合 true。それ以外の場合は false。</returns>
        public static bool IsTuesday(this DateTime value) => value.IsDayOfWeek(DayOfWeek.Tuesday);

        /// <summary>
        /// この日時の曜日が水曜日であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時の曜日が水曜日である場合 true。それ以外の場合は false。</returns>
        public static bool IsWednesday(this DateTime value) => value.IsDayOfWeek(DayOfWeek.Wednesday);

        /// <summary>
        /// この日時の曜日が木曜日であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時の曜日が木曜日である場合 true。それ以外の場合は false。</returns>
        public static bool IsThursday(this DateTime value) => value.IsDayOfWeek(DayOfWeek.Thursday);

        /// <summary>
        /// この日時の曜日が金曜日であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時の曜日が金曜日である場合 true。それ以外の場合は false。</returns>
        public static bool IsFriday(this DateTime value) => value.IsDayOfWeek(DayOfWeek.Friday);

        /// <summary>
        /// この日時の曜日が土曜日であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時の曜日が土曜日である場合 true。それ以外の場合は false。</returns>
        public static bool IsSaturday(this DateTime value) => value.IsDayOfWeek(DayOfWeek.Saturday);

        /// <summary>
        /// この日時の曜日が指定した曜日に一致するか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <param name="dayOfWeek">曜日。</param>
        /// <returns>この日時の曜日が指定した曜日に一致する場合 true。それ以外の場合は false。</returns>
        public static bool IsDayOfWeek(this DateTime value, DayOfWeek dayOfWeek) => value.DayOfWeek == dayOfWeek;

        #endregion

        #region What Month

        /// <summary>
        /// この日時が 1 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 1 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsJanuary(this DateTime value) => value.IsWhatMonth(1);

        /// <summary>
        /// この日時が 2 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 2 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsFebruary(this DateTime value) => value.IsWhatMonth(2);

        /// <summary>
        /// この日時が 3 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 3 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsMarch(this DateTime value) => value.IsWhatMonth(3);

        /// <summary>
        /// この日時が 4 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 4 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsApril(this DateTime value) => value.IsWhatMonth(4);

        /// <summary>
        /// この日時が 5 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 5 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsMay(this DateTime value) => value.IsWhatMonth(5);

        /// <summary>
        /// この日時が 6 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 6 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsJune(this DateTime value) => value.IsWhatMonth(6);

        /// <summary>
        /// この日時が 7 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 7 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsJuly(this DateTime value) => value.IsWhatMonth(7);

        /// <summary>
        /// この日時が 8 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 8 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsAugust(this DateTime value) => value.IsWhatMonth(8);

        /// <summary>
        /// この日時が 9 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 9 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsSeptember(this DateTime value) => value.IsWhatMonth(9);

        /// <summary>
        /// この日時が 10 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 10 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsOctober(this DateTime value) => value.IsWhatMonth(10);

        /// <summary>
        /// この日時が 11 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 11 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsNovember(this DateTime value) => value.IsWhatMonth(11);

        /// <summary>
        /// この日時が 12 月であるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <returns>この日時が 12 月である場合 true。それ以外の場合は false。</returns>
        public static bool IsDecember(this DateTime value) => value.IsWhatMonth(12);

        /// <summary>
        /// この日時の月が指定した月に一致するか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <param name="month">月。</param>
        /// <returns>この日時の月が指定した月に一致する場合 true。それ以外の場合は false。</returns>
        public static bool IsWhatMonth(this DateTime value, int month) => value.Month == month;

        #endregion

        #region Range

        /// <summary>
        /// この日時が指定した範囲内にあるか判断します。
        /// </summary>
        /// <param name="value">日時。</param>
        /// <param name="from">開始日時。</param>
        /// <param name="to">終了日時。</param>
        /// <returns>この日時が指定した範囲内にある場合は true。それ以外の場合は false。</returns>
        public static bool IsInRange(this DateTime value, DateTime from, DateTime to) => value >= from && value <= to;

        #endregion

        // ↓ Private static method↓

        #region RemoveDelimiters

        /// <summary>
        /// 指定した文字列から日時に含まれる区切り文字を除去します。
        /// </summary>
        /// <param name="value">日時フォーマット文字列。</param>
        /// <returns>区切り文字を除去した文字列。</returns>
        private static string RemoveDelimiters(string value) => value.Replace("/", string.Empty).Replace(" ", string.Empty).Replace(":", string.Empty).Replace(".", string.Empty);

        #endregion

    }
}
