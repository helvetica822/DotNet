namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「yyyy/MM/dd HH:mm」の日時フォーマットを表します。
    /// </summary>
    public class YyyyMmDdHh24Mm : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「yyyy/MM/dd HH:mm」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal YyyyMmDdHh24Mm() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy/MM/dd HH:mm」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "yyyy/MM/dd HH:mm";

        /// <summary>
        /// 「yyyy/M/d H:m」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "yyyy/M/d H:m";

        #endregion

    }
}
