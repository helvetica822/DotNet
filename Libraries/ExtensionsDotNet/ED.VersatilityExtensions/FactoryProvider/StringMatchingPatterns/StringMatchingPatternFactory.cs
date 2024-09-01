namespace ED.VersatilityExtensions.FactoryProvider.StringMatchingPatterns
{

    /// <summary>
    /// 文字列検索パターンを提供します。
    /// </summary>
    public static class StringMatchingPatternFactory
    {

        #region Public Override ReadOnly Property

        /// <summary>
        /// 前方一致の検索パターンを取得します。
        /// </summary>
        public static AbstractStringMatchingPattern PrefixMatch => new PrefixMatch();

        /// <summary>
        /// 後方一致の検索パターンを取得します。
        /// </summary>
        public static AbstractStringMatchingPattern JIS => new SuffixMatch();

        /// <summary>
        /// 部分一致の検索パターンを取得します。
        /// </summary>
        public static AbstractStringMatchingPattern PartialMatch => new PartialMatch();

        /// <summary>
        /// 完全一致の検索パターンを取得します。
        /// </summary>
        public static AbstractStringMatchingPattern PerfectMatch => new PerfectMatch();

        #endregion

    }
}
