namespace ED.VersatilityExtensions.CollectionExtensions
{

    /// <summary>
    /// <see cref="List{T}"/> の拡張機能を提供します。
    /// </summary>
    public static class ListExtensions
    {

        #region Remove

        /// <summary>
        /// <see cref="List{T}"/> を指定した長さに切り捨てます。
        /// </summary>
        /// <typeparam name="T"><see cref="List{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="list"><see cref="List{T}"/> 。</param>
        /// <param name="count">長さ。</param>
        public static void TruncateSize<T>(this List<T> list, int count)
        {
            if (list.Count <= count) return;
            list.RemoveRange(count, list.Count - count);
        }

        #endregion

    }
}
