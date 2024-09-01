namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 「fff」の時間間隔フォーマットを表します。
    /// </summary>
    public class Fff : AbstractTimeSpanFormat
    {

        #region Constructor

        /// <summary>
        /// 「fff」の時間間隔フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Fff() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「fff」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "fff";

        /// <summary>
        /// 「f」の時間間隔フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "f";

        #endregion

    }
}
