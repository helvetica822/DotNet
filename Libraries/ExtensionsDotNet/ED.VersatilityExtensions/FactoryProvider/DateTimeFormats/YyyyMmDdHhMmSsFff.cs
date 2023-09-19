namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「yyyy/MM/dd hh:mm:ss.fff」の日時フォーマットを表します。
    /// </summary>
    public class YyyyMmDdHhMmSsFff : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「yyyy/MM/dd hh:mm:ss.fff」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal YyyyMmDdHhMmSsFff() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy/MM/dd hh:mm:ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "yyyy/MM/dd hh:mm:ss.fff";

        /// <summary>
        /// 「yyyy/M/d h:m:s.f」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "yyyy/M/d h:m:s.f";

        #endregion

    }
}
