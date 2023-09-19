namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「hh:mm:ss.fff」の日時フォーマットを表します。
    /// </summary>
    public class HhMmSsFff : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「hh:mm:ss.fff」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal HhMmSsFff() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「hh:mm:ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "hh:mm:ss.fff";

        /// <summary>
        /// 「H:m:s.f」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "h:m:s.f";

        #endregion

    }
}
