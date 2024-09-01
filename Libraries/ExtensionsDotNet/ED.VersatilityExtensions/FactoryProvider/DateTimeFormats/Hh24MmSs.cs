namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「HH:mm:ss」の日時フォーマットを表します。
    /// </summary>
    public class Hh24MmSs : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「HH:mm:ss」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Hh24MmSs() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「HH:mm:ss」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "HH:mm:ss";

        /// <summary>
        /// 「H:m:s」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "H:m:s";

        #endregion

    }
}
