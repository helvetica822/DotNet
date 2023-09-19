namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 「mm」の時間間隔フォーマットを表します。
    /// </summary>
    public class Mm : AbstractTimeSpanFormat
    {

        #region Constructor

        /// <summary>
        /// 「mm」の時間間隔フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Mm() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「mm」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "mm";

        /// <summary>
        /// 「m」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "m";

        #endregion

    }
}
