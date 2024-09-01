namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 「mm:ss.fff」の時間間隔フォーマットを表します。
    /// </summary>
    public class MmSsFff : AbstractTimeSpanFormat
    {

        #region Constructor

        /// <summary>
        /// 「mm:ss.fff」の時間間隔フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal MmSsFff() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「mm:ss.fff」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => @"mm\:ss\.fff";

        /// <summary>
        /// 「m:s.f」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => @"m\:s\.f";

        #endregion

    }
}
