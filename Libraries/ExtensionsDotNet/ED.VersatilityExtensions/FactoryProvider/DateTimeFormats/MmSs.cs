namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「mm:ss」の日時フォーマットを表します。
    /// </summary>
    public class MmSs : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「mm:ss」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal MmSs() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「mm:ss」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "mm:ss";

        /// <summary>
        /// 「m:s」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "m:s";

        #endregion

    }
}
