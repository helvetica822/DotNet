namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「yyyy/MM」の日時フォーマットを表します。
    /// </summary>
    public class YyyyMm : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「yyyy/Mm」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal YyyyMm() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy/MM/」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "yyyy/MM";

        /// <summary>
        /// 「yyyy/M/d」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "yyyy/M";

        #endregion

    }
}
