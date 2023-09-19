namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 「ss.fff」の時間間隔フォーマットを表します。
    /// </summary>
    public class SsFff : AbstractTimeSpanFormat
    {

        #region Constructor

        /// <summary>
        /// 「ss.fff」の時間間隔フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal SsFff() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「ss.fff」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => @"ss\.fff";

        /// <summary>
        /// 「s.f」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => @"s\.f";

        #endregion

    }
}
