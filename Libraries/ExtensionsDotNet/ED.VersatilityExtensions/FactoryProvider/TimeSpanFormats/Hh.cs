namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 「hh」の時間間隔フォーマットを表します。
    /// </summary>
    public class Hh : AbstractTimeSpanFormat
    {

        #region Constructor

        /// <summary>
        /// 「hh」の時間間隔フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Hh() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「hh」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "hh";

        /// <summary>
        /// 「h」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "h";

        #endregion

    }
}
