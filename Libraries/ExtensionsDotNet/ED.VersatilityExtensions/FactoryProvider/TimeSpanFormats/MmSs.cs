namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 「mm:ss」の時間間隔フォーマットを表します。
    /// </summary>
    public class MmSs : AbstractTimeSpanFormat
    {

        #region Constructor

        /// <summary>
        /// 「mm:ss」の時間間隔フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal MmSs() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「mm:ss」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => @"mm\:ss";

        /// <summary>
        /// 「m:s」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => @"m\:s";

        #endregion

    }
}
