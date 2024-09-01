namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「yyyy/MM/dd HH:mm:ss.fff」の日時フォーマットを表します。
    /// </summary>
    public class YyyyMmDdHh24MmSsFff : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「yyyy/MM/dd HH:mm:ss.fff」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal YyyyMmDdHh24MmSsFff() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy/MM/dd HH:mm:ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "yyyy/MM/dd HH:mm:ss.fff";

        /// <summary>
        /// 「yyyy/M/d H:m:s.f」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "yyyy/M/d H:m:s.f";

        #endregion

    }
}
