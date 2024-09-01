namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 「hh:mm:ss」の時間間隔フォーマットを表します。
    /// </summary>
    public class HhMmSs : AbstractTimeSpanFormat
    {

        #region Constructor

        /// <summary>
        /// 「hh:mm:ss」の時間間隔フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal HhMmSs() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「hh:mm:ss」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => @"hh\:mm\:ss";

        /// <summary>
        /// 「h:m:s」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => @"h\:m\:s";

        #endregion

    }
}
