namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「hh:mm:ss」の日時フォーマットを表します。
    /// </summary>
    public class HhMmSs : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「hh:mm:ss」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal HhMmSs() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「hh:mm:ss」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "hh:mm:ss";

        /// <summary>
        /// 「h:m:s」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "h:m:s";

        #endregion

    }
}
