namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 「hh:mm:ss.fff」の時間間隔フォーマットを表します。
    /// </summary>
    public class HhMmSsFff : AbstractTimeSpanFormat
    {

        #region Constructor

        /// <summary>
        /// 「hh:mm:ss.fff」の時間間隔フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal HhMmSsFff() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「hh:mm:ss.fff」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => @"hh\:mm\:ss\.fff";

        /// <summary>
        /// 「h:m:s.f」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => @"h\:m\:s\.f";

        #endregion

    }
}
