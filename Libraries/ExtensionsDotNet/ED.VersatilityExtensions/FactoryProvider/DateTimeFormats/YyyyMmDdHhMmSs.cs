namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「yyyy/MM/dd hh:mm:ss」の日時フォーマットを表します。
    /// </summary>
    public class YyyyMmDdHhMmSs : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「yyyy/MM/dd hh:mm:ss」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal YyyyMmDdHhMmSs() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy/MM/dd hh:mm:ss」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "yyyy/MM/dd hh:mm:ss";

        /// <summary>
        /// 「yyyy/M/d h:m:s」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "yyyy/M/d h:m:s";

        #endregion

    }
}
