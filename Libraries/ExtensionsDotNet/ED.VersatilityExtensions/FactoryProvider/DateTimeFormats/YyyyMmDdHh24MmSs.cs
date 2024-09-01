namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「yyyy/MM/dd HH:mm:ss」の日時フォーマットを表します。
    /// </summary>
    public class YyyyMmDdHh24MmSs : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「yyyy/MM/dd HH:mm:ss」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal YyyyMmDdHh24MmSs() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy/MM/dd HH:mm:ss」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "yyyy/MM/dd HH:mm:ss";

        /// <summary>
        /// 「yyyy/M/d H:m:s」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "yyyy/M/d H:m:s";

        #endregion

    }
}
