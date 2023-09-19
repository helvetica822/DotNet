namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「mm:ss.fff」の日時フォーマットを表します。
    /// </summary>
    public class MmSsFff : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「mm:ss.fff」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal MmSsFff() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「mm:ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "mm:ss.fff";

        /// <summary>
        /// 「m:s.f」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "m:s.f";

        #endregion

    }
}
