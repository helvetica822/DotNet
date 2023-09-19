namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「HH:mm:ss.fff」の日時フォーマットを表します。
    /// </summary>
    public class Hh24MmSsFff : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「HH:mm:ss.fff」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Hh24MmSsFff() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「HH:mm:ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "HH:mm:ss.fff";

        /// <summary>
        /// 「H:m:s.f」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "H:m:s.f";

        #endregion

    }
}
