namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「yyyy/Mm/dd HH」の日時フォーマットを表します。
    /// </summary>
    public class YyyyMmDdHh24 : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「yyyy/Mm/dd HH」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal YyyyMmDdHh24() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy/Mm/dd HH」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "yyyy/Mm/dd HH";

        /// <summary>
        /// 「yyyy/M/d H」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "yyyy/M/d H";

        #endregion

    }
}
