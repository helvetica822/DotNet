namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「ss.fff」の日時フォーマットを表します。
    /// </summary>
    public class SsFff : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「ss.fff」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal SsFff() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "ss.fff";

        /// <summary>
        /// 「s.f」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "s.f";

        #endregion

    }
}
