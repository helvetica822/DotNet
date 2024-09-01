namespace ED.VersatilityExtensions.CollectionExtensions
{

    /// <summary>
    /// <see cref="IList{T}"/> の拡張機能を提供します。
    /// </summary>
    public static class IListExtensions
    {

        #region Set Range

        /// <summary>
        /// この <see cref="IList{short}"/> に開始値から終了値まで連続した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{short}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        public static void SetRange(this IList<short> value, short start, short end) => value.SetRange(start, end, 1);

        /// <summary>
        /// この <see cref="IList{short}"/> に開始値から終了値までステップ数ごとに反復した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{short}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        /// <param name="step">ステップ数。</param>
        public static void SetRange(this IList<short> value, short start, short end, short step)
        {
            value ??= new List<short>();
            if (value.Count == 0) value.Clear();

            for (short i = start; i <= end; i += step) value.Add(i);
        }

        /// <summary>
        /// この <see cref="IList{int}"/> に開始値から終了値まで連続した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{int}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        public static void SetRange(this IList<int> value, int start, int end) => value.SetRange(start, end, 1);

        /// <summary>
        /// この <see cref="IList{int}"/> に開始値から終了値までステップ数ごとに反復した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{int}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        /// <param name="step">ステップ数。</param>
        public static void SetRange(this IList<int> value, int start, int end, int step)
        {
            value ??= new List<int>();
            if (value.Count == 0) value.Clear();

            for (int i = start; i <= end; i += step) value.Add(i);
        }

        /// <summary>
        /// この <see cref="IList{long}"/> に開始値から終了値まで連続した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{long}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        public static void SetRange(this IList<long> value, long start, long end) => value.SetRange(start, end, 1);

        /// <summary>
        /// この <see cref="IList{long}"/> に開始値から終了値までステップ数ごとに反復した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{long}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        /// <param name="step">ステップ数。</param>
        public static void SetRange(this IList<long> value, long start, long end, long step)
        {
            value ??= new List<long>();
            if (value.Count == 0) value.Clear();

            for (long i = start; i <= end; i += step) value.Add(i);
        }

        /// <summary>
        /// この <see cref="IList{float}"/> に開始値から終了値まで 0.1 ごとの連続した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{float}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        public static void SetRange(this IList<float> value, float start, float end) => value.SetRange(start, end, 0.1f);

        /// <summary>
        /// この <see cref="IList{float}"/> に開始値から終了値までステップ数ごとに反復した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{float}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        /// <param name="step">ステップ数。</param>
        public static void SetRange(this IList<float> value, float start, float end, float step)
        {
            value ??= new List<float>();
            if (value.Count == 0) value.Clear();

            for (float i = start; i <= end; i += step) value.Add(i);
        }

        /// <summary>
        /// この <see cref="IList{double}"/> に開始値から終了値まで 0.1 ごとの連続した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{double}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        public static void SetRange(this IList<double> value, double start, double end) => value.SetRange(start, end, 0.1D);

        /// <summary>
        /// この <see cref="IList{double}"/> に開始値から終了値までステップ数ごとに反復した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{double}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        /// <param name="step">ステップ数。</param>
        public static void SetRange(this IList<double> value, double start, double end, double step)
        {
            value ??= new List<double>();
            if (value.Count == 0) value.Clear();

            for (double i = start; i <= end; i += step) value.Add(i);
        }

        /// <summary>
        /// この <see cref="IList{decimal}"/> に開始値から終了値まで 0.1 ごとの連続した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{decimal}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        public static void SetRange(this IList<decimal> value, decimal start, decimal end) => value.SetRange(start, end, 0.1M);

        /// <summary>
        /// この <see cref="IList{decimal}"/> に開始値から終了値までステップ数ごとに反復した値を設定します。
        /// </summary>
        /// <param name="value"><see cref="IList{decimal}"/> 。</param>
        /// <param name="start">開始値。</param>
        /// <param name="end">終了値。</param>
        /// <param name="step">ステップ数。</param>
        public static void SetRange(this IList<decimal> value, decimal start, decimal end, decimal step)
        {
            value ??= new List<decimal>();
            if (value.Count == 0) value.Clear();

            for (decimal i = start; i <= end; i += step) value.Add(i);
        }

        #endregion

        #region Exists

        /// <summary>
        /// <see cref="IList{T}"/> の指定したインデックスに要素が存在するか判断します。
        /// </summary>
        /// <typeparam name="T"><see cref="IList{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="value"><see cref="IList{T}"/> 。</param>
        /// <param name="index">インデックス。</param>
        /// <returns>指定したインデックスに要素が存在する場合は true。それ以外の場合は false。</returns>
        public static bool ExistsIndex<T>(this IList<T> value, int index) => index < value.Count;

        /// <summary>
        /// <see cref="IList{T}"/> の指定したインデックスに要素が存在するか判断します。
        /// </summary>
        /// <typeparam name="T"><see cref="IList{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="value"><see cref="IList{T}"/> 。</param>
        /// <param name="index">インデックス。</param>
        /// <param name="nullable">null を要素ありとみなす場合は true。それ以外の場合は false。</param>
        /// <returns>指定したインデックスに要素が存在する場合は true。それ以外の場合は false。</returns>
        public static bool ExistsIndex<T>(this IList<T> value, int index, bool nullable)
        {
            if (value.ExistsIndex(index))
            {
                var v = value[index];

                return nullable || v is not null;
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}
