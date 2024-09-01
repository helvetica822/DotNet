namespace ED.VersatilityExtensions.FactoryProvider.StringMatchingPatterns
{

    /// <summary>
    /// 文字列検索パターンの抽象クラスを表します。
    /// </summary>
    public abstract class AbstractStringMatchingPattern
    {

        // ↓Public abstract method↓

        #region IsMatching

        /// <summary>
        /// 文字列が検索パターンと検索対象文字列の組み合わせに一致するか比較します。
        /// </summary>
        /// <param name="value">基準文字列。</param>
        /// <param name="searchValue">検索対象文字列。</param>
        /// <returns>検索パターンと検索対象文字列の組み合わせに一致する場合は true。それ以外の場合は false。</returns>
        public abstract bool IsMatching(string value, string searchValue);

        #endregion

    }
}
