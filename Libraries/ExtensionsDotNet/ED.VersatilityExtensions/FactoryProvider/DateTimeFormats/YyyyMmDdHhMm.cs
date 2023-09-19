namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「yyyy/MM/dd hh:mm」の日時フォーマットを表します。
    /// </summary>
    public class YyyyMmDdHhMm : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「yyyy/MM/dd hh:mm」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal YyyyMmDdHhMm() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy/MM/dd hh:mm」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "yyyy/MM/dd hh:mm";

        /// <summary>
        /// 「yyyy/M/d h:m」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "yyyy/M/d h:m";

        #endregion

    }
}
