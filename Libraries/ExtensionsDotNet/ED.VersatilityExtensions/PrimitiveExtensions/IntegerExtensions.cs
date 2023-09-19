namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// <see cref="int"/> の拡張機能を提供します。
    /// </summary>
    public static class IntegerExtensions
    {

        // ↓ Extension↓

        #region DelimitedString

        /// <summary>
        /// この数値をカンマ記号「,」で区切った整数文字列に変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>カンマ記号「,」で区切った数値文字列。</returns>
        public static string ToDelimitedString(this int value) => ((decimal)value).ToDelimitedString();

        #endregion

        #region To Day or Hour or Minute

        /// <summary>
        /// この数値を秒数とみなし、日数に換算します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>日数。</returns>
        public static int ToDayCount(this int value) => (int)((decimal)value).ToDayCount();

        /// <summary>
        /// この数値を秒数とみなし、日数に換算した余りを算出します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>日数に換算した余り。</returns>
        public static int ToDayCountRemainder(this int value) => (int)((decimal)value).ToDayCountRemainder();

        /// <summary>
        /// この数値を秒数とみなし、時間数に換算します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>時間数。</returns>
        public static int ToHourCount(this int value) => (int)((decimal)value).ToHourCount();

        /// <summary>
        /// この数値を秒数とみなし、時間数に換算した余りを算出します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>時間数に換算した余り。</returns>
        public static int ToHourCountRemainder(this int value) => (int)((decimal)value).ToHourCountRemainder();

        /// <summary>
        /// この数値を秒数とみなし、分数に換算します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>分数。</returns>
        public static int ToMinuteCount(this int value) => (int)((decimal)value).ToMinuteCount();

        /// <summary>
        /// この数値を秒数とみなし、分数に換算した余りを算出します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>分数に換算した余り。</returns>
        public static int ToMinuteCountRemainder(this int value) => (int)((decimal)value).ToMinuteCountRemainder();

        #endregion

        #region Convert From Base Number

        /// <summary>
        /// この数値と等価な 16 進数文字列に変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>16 進数文字列。</returns>
        public static string ToHexadecimal(this int value) => ((long)value).ToHexadecimal();

        /// <summary>
        /// この数値と等価な 8 進数文字列に変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>8 進数文字列。</returns>
        public static string ToOctalNumber(this int value) => ((long)value).ToOctalNumber();

        /// <summary>
        /// この数値と等価な 2 進数文字列に変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>2 進数文字列。</returns>
        public static string ToBinaryNumber(this int value) => ((long)value).ToBinaryNumber();

        /// <summary>
        /// この数値を指定した基数に基づいて変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="baseNumber">基数。</param>
        /// <returns>指定した基数文字列。</returns>
        public static string ToBaseNumber(this int value, int baseNumber) => ((long)value).ToBaseNumber(baseNumber);

        #endregion

        #region Is Even

        /// <summary>
        /// この数値が偶数であるか判断します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>この数値が偶数である場合は true。それ以外の場合は false。</returns>
        public static bool IsEven(this int value) => ((long)value).IsEven();

        #endregion

        #region Is Prime Number

        /// <summary>
        /// この数値が素数であるか判断します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>この数値が素数である場合は true。それ以外の場合は false。</returns>
        public static bool IsPrimeNumber(this int value) => ((long)value).IsPrimeNumber();

        #endregion

        #region GCD, LCD

        /// <summary>
        /// この数値と比較数値から最大公約数を求めます。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="compareValue">比較数値。</param>
        /// <returns>最大公約数。</returns>
        public static int CalculationGCD(this int value, int compareValue) => (int)((long)value).CalculationGCD(compareValue);

        /// <summary>
        /// この数値と比較数値から最小公倍数を求めます。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="compareValue">比較数値。</param>
        /// <returns>最小公倍数。</returns>
        public static int CalculationLCD(this int value, int compareValue) => (int)((long)value).CalculationLCD(compareValue);

        #endregion

    }
}
