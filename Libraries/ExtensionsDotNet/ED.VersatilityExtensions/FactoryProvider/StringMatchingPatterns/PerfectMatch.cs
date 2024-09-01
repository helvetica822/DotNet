namespace ED.VersatilityExtensions.FactoryProvider.StringMatchingPatterns
{

    /// <summary>
    /// 完全一致の検索パターンを表します。
    /// </summary>
    public class PerfectMatch : AbstractStringMatchingPattern
    {

        #region Constructor

        /// <summary>
        /// 完全一致の検索パターンクラスのインスタンスを生成します。
        /// </summary>
        internal PerfectMatch() { }

        #endregion

        // ↓Public method↓

        #region IsMatching

        /// <summary>
        /// 文字列が検索パターンと検索対象文字列の組み合わせに完全一致するか比較します。
        /// </summary>
        /// <param name="value">基準文字列。</param>
        /// <param name="searchValue">検索対象文字列。</param>
        /// <returns>検索パターンと検索対象文字列の組み合わせに完全一致する場合は true。それ以外の場合は false。</returns>
        public override bool IsMatching(string value, string searchValue) => value.Equals(searchValue);

        #endregion

    }
}
