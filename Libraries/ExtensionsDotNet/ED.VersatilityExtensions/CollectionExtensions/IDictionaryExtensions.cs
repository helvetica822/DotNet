namespace ED.VersatilityExtensions.CollectionExtensions
{

    /// <summary>
    /// <see cref="IDictionary{TKey, TValue}"/> の拡張機能を提供します。
    /// </summary>
    public static class IDictionaryExtensions
    {

        #region Add or Set

        /// <summary>
        /// <see cref="IDictionary{TKey, TValue}"/> に指定したキーが存在する場合は要素を上書き、存在しない場合は要素を追加します。
        /// </summary>
        /// <typeparam name="TKey"><see cref="IDictionary{TKey, TValue}"/> のキーのジェネリックスクラス。</typeparam>
        /// <typeparam name="TValue"><see cref="IDictionary{TKey, TValue}"/> の値のジェネリックスクラス。</typeparam>
        /// <param name="dic"><see cref="IDictionary{TKey, TValue}"/> 。</param>
        /// <param name="key">キー。</param>
        /// <param name="value">要素。</param>
        public static void AddOrSet<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue value)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }

        #endregion

    }
}
