using System.Globalization;
using System.Text;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// <see cref="decimal"/> の拡張機能を提供します。
    /// </summary>
    public static class DecimalExtensions
    {

        // ↓ Extension↓

        #region DelimitedString

        /// <summary>
        /// この数値をカンマ記号「,」で区切った整数文字列に変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>カンマ記号「,」で区切った数値文字列。</returns>
        public static string ToDelimitedString(this decimal value) => value.ToDelimitedString(0, true);

        /// <summary>
        /// この数値をカンマ記号「,」、ドット記号「.」で区切った数値文字列に変換します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="decimals">小数点以下の桁数。</param>
        /// <param name="hasZeroPlaceHolder"><paramref name="decimals"/> で指定した小数点以下の桁数の数値が 0 の場合、 0 を表示する場合は true。それ以外の場合は false。</param>
        /// <returns>カンマ記号「,」、ドット記号「.」で区切った数値文字列。</returns>
        public static string ToDelimitedString(this decimal value, int decimals, bool hasZeroPlaceHolder)
        {
            var mainPlaceHolder = hasZeroPlaceHolder ? "0" : "#";

            var decimalsPlaceHolder = new StringBuilder();

            if (decimals != 0)
            {
                _ = decimalsPlaceHolder.Append('.');

                for (int i = 0; i < decimals - 1; i++)
                {
                    _ = decimalsPlaceHolder.Append(mainPlaceHolder);
                }
            }

            var customFormat = "#," + mainPlaceHolder + decimalsPlaceHolder.ToString();

            return value.ToString(customFormat, CultureInfo.CurrentCulture);
        }

        #endregion

        #region Ceiling

        /// <summary>
        /// この数値の小数点以下を切り上げします。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>小数点以下が切り上げられた数値。</returns>
        public static decimal Ceiling(this decimal value) => Math.Ceiling(value);

        /// <summary>
        /// この数値を指定小数点以下になるよう、切り上げします。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="decimals">切り上げ後に表示する小数点以下の最大桁数。指定した桁数の1つ下位の桁で切り上げされます。</param>
        /// <returns>指定小数点以下になるよう切り上げされた数値。</returns>
        public static decimal CeilingSpecifiedDecimals(this decimal value, int decimals)
        {
            var pow = Math.Pow(10, decimals);
            value *= (decimal)pow;

            var c = value.Ceiling();

            return c / (decimal)pow;
        }

        #endregion

        #region Floor

        /// <summary>
        /// この数値の小数点以下を切り捨てします。負数の場合、より小さな数値(負の無限大への丸め)へと丸められます。 例）-1.5 ⇒ -2
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>小数点以下が切り捨てられた数値。</returns>
        public static decimal Floor(this decimal value) => Math.Floor(value);

        /// <summary>
        /// この数値を指定小数点以下になるよう、切り捨てします。負数の場合、より小さな数値(負の無限大への丸め)へと丸められます。 例）-1.5 ⇒ -2
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="decimals">切り捨て後に表示する小数点以下の最大桁数。指定した桁数の1つ下位の桁で切り捨てされます。</param>
        /// <returns>指定小数点以下になるよう切り捨てされた数値。</returns>
        public static decimal FloorSpecifiedDecimals(this decimal value, int decimals)
        {
            var pow = Math.Pow(10, decimals);
            value *= (decimal)pow;

            var c = value.Floor();

            return c / (decimal)pow;
        }

        #endregion

        #region Truncate

        /// <summary>
        /// この数値の小数点以下を切り捨てします。負数の場合、より大きな数値へと丸められます。 例）-1.5 ⇒ -1
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>小数点以下が切り捨てられた数値。</returns>
        public static decimal Truncate(this decimal value) => Math.Truncate(value);

        /// <summary>
        /// この数値を指定小数点以下になるよう、切り捨てします。負数の場合、より大きな数値へと丸められます。 例）-1.5 ⇒ -1
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="decimals">切り捨て後に表示する小数点以下の最大桁数。指定した桁数の1つ下位の桁で切り捨てされます。</param>
        /// <returns>指定小数点以下になるよう切り捨てされた数値。</returns>
        public static decimal TruncateSpecifiedDecimals(this decimal value, int decimals)
        {
            var pow = Math.Pow(10, decimals);
            value *= (decimal)pow;

            var c = value.Truncate();

            return c / (decimal)pow;
        }

        #endregion

        #region Round

        /// <summary>
        /// この数値の小数点以下を四捨五入します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>小数点以下が四捨五入された数値。</returns>
        public static decimal Round(this decimal value) => value.RoundSpecifiedDecimals(0);

        /// <summary>
        /// この数値を指定小数点以下になるよう、四捨五入します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="decimals">四捨五入後に表示する小数点以下の最大桁数。指定した桁数の1つ下位の桁で四捨五入されます。</param>
        /// <returns>指定小数点以下になるよう四捨五入された数値。</returns>
        public static decimal RoundSpecifiedDecimals(this decimal value, int decimals) => Math.Round(value, decimals, MidpointRounding.AwayFromZero);

        #endregion

        #region IsoRound

        /// <summary>
        /// この数値の小数点以下を ISO 丸め(最近接偶数丸め)します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>小数点以下が ISO 丸め(最近接偶数丸め)された数値。</returns>
        public static decimal IsoRound(this decimal value) => value.IsoRoundSpecifiedDecimals(0);

        /// <summary>
        /// この数値を指定小数点以下になるよう、ISO 丸め(最近接偶数丸め)します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <param name="decimals">ISO 丸め(最近接偶数丸め)後に表示する小数点以下の最大桁数。指定した桁数の1つ下位の桁で ISO 丸め(最近接偶数丸め)されます。</param>
        /// <returns>指定小数点以下になるよう ISO 丸め(最近接偶数丸め)された数値。</returns>
        public static decimal IsoRoundSpecifiedDecimals(this decimal value, int decimals) => Math.Round(value, decimals, MidpointRounding.ToEven);

        #endregion

        #region DigitsLength

        /// <summary>
        /// この数値の整数部桁数を取得します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>整数部桁数。</returns>
        public static int GetIntegersDigitsLength(this decimal value) => Math.Abs(value).Truncate().ToString(CultureInfo.CurrentCulture).Length;

        /// <summary>
        /// この数値の小数部桁数を取得します。
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>小数部桁数。</returns>
        public static int GetDecimalsDigitsLength(this decimal value)
        {
            var text = value.ToString(CultureInfo.CurrentCulture);
            var decimalPointIndex = text.IndexOf(".");

            return (decimalPointIndex != -1) ? text[(decimalPointIndex + 1)..].Length : 0;
        }

        #endregion

        #region To Day or Hour or Minute

        /// <summary>
        /// この数値を秒数とみなし、日数に換算します。
        ///     <para>小数点以下の値は切り捨てられます。</para>
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>日数。</returns>
        public static decimal ToDayCount(this decimal value) => (value / (24 * 60 * 60)).Floor();

        /// <summary>
        /// この数値を秒数とみなし、日数に換算した余りを算出します。
        ///     <para>小数点以下の値は切り捨てられます。</para>
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>日数に換算した余り。</returns>
        public static decimal ToDayCountRemainder(this decimal value) => (value % (24 * 60 * 60)).Floor();

        /// <summary>
        /// この数値を秒数とみなし、時間数に換算します。
        ///     <para>小数点以下の値は切り捨てられます。</para>
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>時間数。</returns>
        public static decimal ToHourCount(this decimal value) => (value / (60 * 60)).Floor();

        /// <summary>
        /// この数値を秒数とみなし、時間数に換算した余りを算出します。
        ///     <para>小数点以下の値は切り捨てられます。</para>
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>時間数に換算した余り。</returns>
        public static decimal ToHourCountRemainder(this decimal value) => (value % (60 * 60)).Floor();

        /// <summary>
        /// この数値を秒数とみなし、分数に換算します。
        ///     <para>小数点以下の値は切り捨てられます。</para>
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>分数。</returns>
        public static decimal ToMinuteCount(this decimal value) => (value / 60).Floor();

        /// <summary>
        /// この数値を秒数とみなし、分数に換算した余りを算出します。
        ///     <para>小数点以下の値は切り捨てられます。</para>
        /// </summary>
        /// <param name="value">数値。</param>
        /// <returns>分数に換算した余り。</returns>
        public static decimal ToMinuteCountRemainder(this decimal value) => (value % 60).Floor();

        #endregion

    }
}
