namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「hh:mm」の日時フォーマットを表します。
    /// </summary>
    public class HhMm : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「hh:mm」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal HhMm() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「hh:mm」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "hh:mm";

        /// <summary>
        /// 「h:m」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "h:m";

        #endregion

    }
}
