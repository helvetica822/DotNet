using ED.VersatilityExtensions.FactoryProvider.CharacterEncodings;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// データ型・基数変換に関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringConvertExtensions
    {

        // ↓ Extension↓

        #region Convert Data Type

        #region ToShort

        /// <summary>
        /// この数値文字列と等価な 16 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="short"/> 型の数値。</returns>
        public static short ToShort(this string value) => value.ToShort(false);

        /// <summary>
        /// 桁区切り記号「,」を含む数値文字列を等価な 16 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="removeDelimiter">桁区切り記号「,」を除去して変換する場合は true。それ以外の場合は false。</param>
        /// <returns><see cref="short"/> 型の数値。</returns>
        public static short ToShort(this string value, bool removeDelimiter) => removeDelimiter ? short.Parse(value, NumberStyles.AllowThousands) : short.Parse(value);

        #endregion

        #region ToInt

        /// <summary>
        /// この数値文字列と等価な 32 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="int"/> 型の数値。</returns>
        public static int ToInt(this string value) => value.ToInt(false);

        /// <summary>
        /// 桁区切り記号「,」を含む数値文字列を等価な 32 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="removeDelimiter">桁区切り記号「,」を除去して変換する場合は true。それ以外の場合は false。</param>
        /// <returns><see cref="int"/> 型の数値。</returns>
        public static int ToInt(this string value, bool removeDelimiter) => removeDelimiter ? int.Parse(value, NumberStyles.AllowThousands) : int.Parse(value);

        #endregion

        #region ToLong

        /// <summary>
        /// この数値文字列と等価な 64 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="long"/> 型の数値。</returns>
        public static long ToLong(this string value) => value.ToLong(false);

        /// <summary>
        /// 桁区切り記号「,」を含む数値文字列を等価な 64 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="removeDelimiter">桁区切り記号「,」を除去して変換する場合は true。それ以外の場合は false。</param>
        /// <returns><see cref="long"/> 型の数値。</returns>
        public static long ToLong(this string value, bool removeDelimiter) => removeDelimiter ? long.Parse(value, NumberStyles.AllowThousands) : long.Parse(value);

        #endregion

        #region ToUShort

        /// <summary>
        /// この数値文字列と等価な 16 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="ushort"/> 型の数値。</returns>
        public static ushort ToUShort(this string value) => value.ToUShort(false);

        /// <summary>
        /// 桁区切り記号「,」を含む数値文字列を等価な 16 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="removeDelimiter">桁区切り記号「,」を除去して変換する場合は true。それ以外の場合は false。</param>
        /// <returns><see cref="ushort"/> 型の数値。</returns>
        public static ushort ToUShort(this string value, bool removeDelimiter) => removeDelimiter ? ushort.Parse(value, NumberStyles.AllowThousands) : ushort.Parse(value);

        #endregion

        #region ToUInt

        /// <summary>
        /// この数値文字列と等価な 32 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="uint"/> 型の数値。</returns>
        public static uint ToUInt(this string value) => value.ToUInt(false);

        /// <summary>
        /// 桁区切り記号「,」を含む数値文字列を等価な 32 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="removeDelimiter">桁区切り記号「,」を除去して変換する場合は true。それ以外の場合は false。</param>
        /// <returns><see cref="uint"/> 型の数値。</returns>
        public static uint ToUInt(this string value, bool removeDelimiter) => removeDelimiter ? uint.Parse(value, NumberStyles.AllowThousands) : uint.Parse(value);

        #endregion

        #region ToULong

        /// <summary>
        /// この数値文字列と等価な 64 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="ulong"/> 型の数値。</returns>
        public static ulong ToULong(this string value) => value.ToULong(false);

        /// <summary>
        /// 桁区切り記号「,」を含む数値文字列を等価な 64 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="removeDelimiter">桁区切り記号「,」を除去して変換する場合は true。それ以外の場合は false。</param>
        /// <returns><see cref="ulong"/> 型の数値。</returns>
        public static ulong ToULong(this string value, bool removeDelimiter) => removeDelimiter ? ulong.Parse(value, NumberStyles.AllowThousands) : ulong.Parse(value);

        #endregion

        #region ToFloat

        /// <summary>
        /// この数値文字列と等価な 32 ビット浮動小数点数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="float"/> 型の数値。</returns>
        public static float ToFloat(this string value) => value.ToFloat(false);

        /// <summary>
        /// 桁区切り記号「,」を含む数値文字列を等価な 32 ビット浮動小数点数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="removeDelimiter">桁区切り記号「,」を除去して変換する場合は true。それ以外の場合は false。</param>
        /// <returns><see cref="float"/> 型の数値。</returns>
        public static float ToFloat(this string value, bool removeDelimiter) => removeDelimiter ? float.Parse(value, NumberStyles.AllowThousands) : float.Parse(value);

        #endregion

        #region ToDouble

        /// <summary>
        /// この数値文字列と等価な 64 ビット浮動小数点数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="double"/> 型の数値。</returns>
        public static double ToDouble(this string value) => value.ToDouble(false);

        /// <summary>
        /// 桁区切り記号「,」を含む数値文字列を等価な 64 ビット浮動小数点数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="removeDelimiter">桁区切り記号「,」を除去して変換する場合は true。それ以外の場合は false。</param>
        /// <returns><see cref="double"/> 型の数値。</returns>
        public static double ToDouble(this string value, bool removeDelimiter) => removeDelimiter ? double.Parse(value, NumberStyles.AllowThousands) : double.Parse(value);

        #endregion

        #region ToDecimal

        /// <summary>
        /// この数値文字列と等価な 128 ビット数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="decimal"/> 型の数値。</returns>
        public static decimal ToDecimal(this string value) => value.ToDecimal(false);

        /// <summary>
        /// 桁区切り記号「,」を含む数値文字列を等価な 128 ビット数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="removeDelimiter">桁区切り記号「,」を除去して変換する場合は true。それ以外の場合は false。</param>
        /// <returns><see cref="decimal"/> 型の数値。</returns>
        public static decimal ToDecimal(this string value, bool removeDelimiter) => removeDelimiter ? decimal.Parse(value, NumberStyles.AllowThousands) : decimal.Parse(value);

        #endregion

        #region ToByte

        /// <summary>
        /// この文字列に格納されている値を、指定した文字コードのバイトシーケンスにエンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="enc">エンコーダ。</param>
        /// <returns>指定した文字コードのバイトシーケンス。</returns>
        public static byte[] ToBytes(this string value, Encoding enc) => enc.GetBytes(value);

        /// <summary>
        /// この文字列に格納されている値を、文字コード Shift-JIS のバイトシーケンスにエンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード Shift-JIS のバイトシーケンス。</returns>
        public static byte[] ToShiftJISBytes(this string value) => value.ToBytes(CharacterEncodingFactory.ShiftJIS.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード JIS のバイトシーケンスにエンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード JIS のバイトシーケンス。</returns>
        public static byte[] ToJISBytes(this string value) => value.ToBytes(CharacterEncodingFactory.JIS.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード EUC のバイトシーケンスにエンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード EUC のバイトシーケンス。</returns>
        public static byte[] ToEUCBytes(this string value) => value.ToBytes(CharacterEncodingFactory.EUC.CharacterEncoding);

        /// <summary>
        /// この文字列に格納されている値を、文字コード UTF-8 のバイトシーケンスにエンコードします。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>文字コード UTF-8 のバイトシーケンス。</returns>
        public static byte[] ToUTF8Bytes(this string value) => value.ToBytes(CharacterEncodingFactory.UTF8.CharacterEncoding);

        #endregion

        #region Parse

        /// <summary>
        /// この文字列を指定したデータ型に変換します。
        /// </summary>
        /// <typeparam name="T">変換先データ型。</typeparam>
        /// <param name="value">文字列。</param>
        /// <returns>文字列を指定したデータ型に変換した値。</returns>
        public static T? Parse<T>(this string value) where T : struct
        {
            var type = typeof(T);
            var converter = TypeDescriptor.GetConverter(type);

            var val = converter.ConvertFrom(value);
            if (val is null) return null;

            return (T)val;
        }

        /// <summary>
        /// この文字列を指定したデータ型に変換します。
        ///     <para>変換に失敗した場合は指定したデータ型のデフォルト値に変換します。</para>
        /// </summary>
        /// <typeparam name="T">変換先データ型。</typeparam>
        /// <param name="value">文字列。</param>
        /// <returns>文字列を指定したデータ型に変換した値。または指定したデータ型のデフォルト値。</returns>
        public static T? TryParseOrDefault<T>(this string value) where T : struct
        {
            return value.CanParse<T>() ? value.Parse<T>() : default;
        }

        /// <summary>
        /// この文字列を指定したデータ型に変換できるか判断します。
        /// </summary>
        /// <typeparam name="T">変換先データ型。</typeparam>
        /// <param name="value">文字列。</param>
        /// <returns>指定したデータ型に変換できる場合は true。それ以外の場合は false。</returns>
        public static bool CanParse<T>(this string value) where T : struct
        {
            var type = typeof(T);
            var converter = TypeDescriptor.GetConverter(type);

            return converter.CanConvertFrom(value.GetType());
        }

        #endregion

        #endregion

        #region Convert From Base Number

        #region ToShort

        /// <summary>
        /// この 16 進数文字列と等価な 32 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="short"/> 型の数値。</returns>
        public static short ToShortFromHexadecimal(this string value) => value.ToShortFromSpecifiedBaseNumber(16);

        /// <summary>
        /// この 8 進数文字列と等価な 32 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="short"/> 型の数値。</returns>
        public static short ToShortFromOctalNumber(this string value) => value.ToShortFromSpecifiedBaseNumber(8);

        /// <summary>
        /// この 2 進数文字列と等価な 32 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="short"/> 型の数値。</returns>
        public static short ToShortFromBinaryNumber(this string value) => value.ToShortFromSpecifiedBaseNumber(2);

        #endregion

        #region ToInt

        /// <summary>
        /// この 16 進数文字列と等価な 32 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="int"/> 型の数値。</returns>
        public static int ToIntFromHexadecimal(this string value) => value.ToIntFromSpecifiedBaseNumber(16);

        /// <summary>
        /// この 8 進数文字列と等価な 32 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="int"/> 型の数値。</returns>
        public static int ToIntFromOctalNumber(this string value) => value.ToIntFromSpecifiedBaseNumber(8);

        /// <summary>
        /// この 2 進数文字列と等価な 32 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="int"/> 型の数値。</returns>
        public static int ToIntFromBinaryNumber(this string value) => value.ToIntFromSpecifiedBaseNumber(2);

        #endregion

        #region ToLong

        /// <summary>
        /// この 16 進数文字列と等価な 64 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="long"/> 型の数値。</returns>
        public static long ToLongFromHexadecimal(this string value) => value.ToLongFromSpecifiedBaseNumber(16);

        /// <summary>
        /// この 8 進数文字列と等価な 64 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="long"/> 型の数値。</returns>
        public static long ToLongFromOctalNumber(this string value) => value.ToLongFromSpecifiedBaseNumber(8);

        /// <summary>
        /// この 2 進数文字列と等価な 64 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="long"/> 型の数値。</returns>
        public static long ToLongFromBinaryNumber(this string value) => value.ToLongFromSpecifiedBaseNumber(2);

        #endregion

        #region ToUShort

        /// <summary>
        /// この 16 進数文字列と等価な 32 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="ushort"/> 型の数値。</returns>
        public static ushort ToUShortFromHexadecimal(this string value) => value.ToUShortFromSpecifiedBaseNumber(16);

        /// <summary>
        /// この 8 進数文字列と等価な 32 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="ushort"/> 型の数値。</returns>
        public static ushort ToUShortFromOctalNumber(this string value) => value.ToUShortFromSpecifiedBaseNumber(8);

        /// <summary>
        /// この 2 進数文字列と等価な 32 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="ushort"/> 型の数値。</returns>
        public static ushort ToUShortFromBinaryNumber(this string value) => value.ToUShortFromSpecifiedBaseNumber(2);

        #endregion

        #region ToUInt

        /// <summary>
        /// この 16 進数文字列と等価な 32 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="uint"/> 型の数値。</returns>
        public static uint ToUIntFromHexadecimal(this string value) => value.ToUIntFromSpecifiedBaseNumber(16);

        /// <summary>
        /// この 8 進数文字列と等価な 32 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="uint"/> 型の数値。</returns>
        public static uint ToUIntFromOctalNumber(this string value) => value.ToUIntFromSpecifiedBaseNumber(8);

        /// <summary>
        /// この 2 進数文字列と等価な 32 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref="uint"/> 型の数値。</returns>
        public static uint ToUIntFromBinaryNumber(this string value) => value.ToUIntFromSpecifiedBaseNumber(2);

        #endregion

        #region ToULong

        /// <summary>
        /// この 16 進数文字列と等価な 64 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref=ulong"/> 型の数値。</returns>
        public static ulong ToULongFromHexadecimal(this string value) => value.ToULongFromSpecifiedBaseNumber(16);

        /// <summary>
        /// この 8 進数文字列と等価な 64 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref=ulong"/> 型の数値。</returns>
        public static ulong ToULongFromOctalNumber(this string value) => value.ToULongFromSpecifiedBaseNumber(8);

        /// <summary>
        /// この 2 進数文字列と等価な 64 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns><see cref=ulong"/> 型の数値。</returns>
        public static ulong ToULongFromBinaryNumber(this string value) => value.ToULongFromSpecifiedBaseNumber(2);

        #endregion

        #region Specified

        /// <summary>
        /// この文字列を指定した基数に基づいて等価な 16 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="baseNumber">基数。</param>
        /// <returns><see cref="ushort"/> 型の数値。</returns>
        public static ushort ToUShortFromSpecifiedBaseNumber(this string value, int baseNumber) => (ushort)value.ToLongFromSpecifiedBaseNumber(baseNumber);

        /// <summary>
        /// この文字列を指定した基数に基づいて等価な 32 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="baseNumber">基数。</param>
        /// <returns><see cref="uint"/> 型の数値。</returns>
        public static uint ToUIntFromSpecifiedBaseNumber(this string value, int baseNumber) => (uint)value.ToLongFromSpecifiedBaseNumber(baseNumber);

        /// <summary>
        /// この文字列を指定した基数に基づいて等価な 64 ビット符号なし整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="baseNumber">基数。</param>
        /// <returns><see cref="ulong"/> 型の数値。</returns>
        public static ulong ToULongFromSpecifiedBaseNumber(this string value, int baseNumber) => (ulong)value.ToLongFromSpecifiedBaseNumber(baseNumber);

        /// <summary>
        /// この文字列を指定した基数に基づいて等価な 16 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="baseNumber">基数。</param>
        /// <returns><see cref="short"/> 型の数値。</returns>
        public static short ToShortFromSpecifiedBaseNumber(this string value, int baseNumber) => (short)value.ToLongFromSpecifiedBaseNumber(baseNumber);

        /// <summary>
        /// この文字列を指定した基数に基づいて等価な 32 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="baseNumber">基数。</param>
        /// <returns><see cref="int"/> 型の数値。</returns>
        public static int ToIntFromSpecifiedBaseNumber(this string value, int baseNumber) => (int)value.ToLongFromSpecifiedBaseNumber(baseNumber);

        /// <summary>
        /// この文字列を指定した基数に基づいて等価な 64 ビット符号付き整数に変換します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="baseNumber">基数。</param>
        /// <returns><see cref="long"/> 型の数値。</returns>
        public static long ToLongFromSpecifiedBaseNumber(this string value, int baseNumber) => Convert.ToInt64(value, Math.Abs(baseNumber));

        #endregion

        #endregion

    }
}
