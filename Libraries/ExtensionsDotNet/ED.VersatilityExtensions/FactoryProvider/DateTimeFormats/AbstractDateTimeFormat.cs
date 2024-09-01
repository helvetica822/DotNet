namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 日時フォーマットの抽象クラスを表します。
    /// </summary>
    public abstract class AbstractDateTimeFormat
    {

        #region Public Abstract ReadOnly Property

        /// <summary>
        /// 0 パディングを含む日時フォーマットを取得します。
        /// </summary>
        public abstract string ZeroPaddingFormat { get; }

        /// <summary>
        /// 0 パディングを含まない日時フォーマットを取得します。
        /// </summary>
        public abstract string NoPaddingFormat { get; }

        #endregion

    }
}
