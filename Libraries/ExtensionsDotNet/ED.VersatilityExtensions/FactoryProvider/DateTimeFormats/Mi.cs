namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「mm」の日時フォーマットを表します。
    /// </summary>
    public class Mi : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「mm」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Mi() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「mm」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "mm";

        /// <summary>
        /// 「m」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "m";

        #endregion

    }
}
