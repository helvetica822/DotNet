namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// <see cref="short"/> の拡張機能を提供します。
    /// </summary>
    public static class ShortExtensions
    {

        // ↓ Extension↓

        #region DelimitedString

        /// <summary>
        /// この数値をカンマ記号「,」で区切った整数文字列に変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>カンマ記号「,」で区切った数値文字列。</returns>
        public static string ToDelimitedString(this short value) => ((decimal)value).ToDelimitedString();

        #endregion

        #region To Hour or Minute

        /// <summary>
        /// この数値を秒数とみなし、時間数に換算します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>時間数。</returns>
        public static short ToHourCount(this short value) => (short)((decimal)value).ToHourCount();

        /// <summary>
        /// この数値を秒数とみなし、時間数に換算した余りを算出します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>時間数に換算した余り。</returns>
        public static short ToHourCountRemainder(this short value) => (short)((decimal)value).ToHourCountRemainder();

        /// <summary>
        /// この数値を秒数とみなし、分数に換算します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>分数。</returns>
        public static short ToMinuteCount(this short value) => (short)((decimal)value).ToMinuteCount();

        /// <summary>
        /// この数値を秒数とみなし、分数に換算した余りを算出します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>分数に換算した余り。</returns>
        public static short ToMinuteCountRemainder(this short value) => (short)((decimal)value).ToMinuteCountRemainder();

        #endregion

        #region Convert From Base Number

        /// <summary>
        /// この数値と等価な 16 進数文字列に変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>16 進数文字列。</returns>
        public static string ToHexadecimal(this short value) => ((long)value).ToHexadecimal();

        /// <summary>
        /// この数値と等価な 8 進数文字列に変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>8 進数文字列。</returns>
        public static string ToOctalNumber(this short value) => ((long)value).ToOctalNumber();

        /// <summary>
        /// この数値と等価な 2 進数文字列に変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>2 進数文字列。</returns>
        public static string ToBinaryNumber(this short value) => ((long)value).ToBinaryNumber();

        /// <summary>
        /// この数値を指定した基数に基づいて変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="baseNumber">基数。</param>
        /// <returns>指定した基数文字列。</returns>
        public static string ToBaseNumber(this short value, short baseNumber) => ((long)value).ToBaseNumber(baseNumber);

        #endregion

        #region Is Even

        /// <summary>
        /// この数値が偶数であるか判断します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>この数値が偶数である場合は true。それ以外の場合は false。</returns>
        public static bool IsEven(this short value) => ((long)value).IsEven();

        #endregion

        #region Is Prime Number

        /// <summary>
        /// この数値が素数であるか判断します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>この数値が素数である場合は true。それ以外の場合は false。</returns>
        public static bool IsPrimeNumber(this short value) => ((long)value).IsPrimeNumber();

        #endregion

        #region GCD, LCD

        /// <summary>
        /// この数値と比較数値から最大公約数を求めます。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="compareValue">比較数値。</param>
        /// <returns>最大公約数。</returns>
        public static short CalculationGCD(this short value, short compareValue) => (short)((long)value).CalculationGCD(compareValue);

        /// <summary>
        /// この数値と比較数値から最小公倍数を求めます。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="compareValue">比較数値。</param>
        /// <returns>最小公倍数。</returns>
        public static short CalculationLCD(this short value, short compareValue) => (short)((long)value).CalculationLCD(compareValue);

        #endregion

    }
}
