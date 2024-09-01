namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「yyyy/MM/dd HH」の日時フォーマットを表します。
    /// </summary>
    public class YyyyMmDdHh : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「yyyy/Mm/dd HH」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal YyyyMmDdHh() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy/MM/dd HH」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "yyyy/MM/dd hh";

        /// <summary>
        /// 「yyyy/M/d h」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "yyyy/M/d h";

        #endregion

    }
}
