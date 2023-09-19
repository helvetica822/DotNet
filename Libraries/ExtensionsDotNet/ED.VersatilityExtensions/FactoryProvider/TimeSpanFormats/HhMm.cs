namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 「hh:mm」の時間間隔フォーマットを表します。
    /// </summary>
    public class HhMm : AbstractTimeSpanFormat
    {

        #region Constructor

        /// <summary>
        /// 「hh:mm」の時間間隔フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal HhMm() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「hh:mm」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => @"hh\:mm";

        /// <summary>
        /// 「h:m」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => @"h\:m";

        #endregion

    }
}
