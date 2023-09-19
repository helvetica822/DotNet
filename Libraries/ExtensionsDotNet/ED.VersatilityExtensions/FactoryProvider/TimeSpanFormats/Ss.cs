namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 「ss」の時間間隔フォーマットを表します。
    /// </summary>
    public class Ss : AbstractTimeSpanFormat
    {

        #region Constructor

        /// <summary>
        /// 「ss」の時間間隔フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Ss() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「ss」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "ss";

        /// <summary>
        /// 「s」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "s";

        #endregion

    }
}
