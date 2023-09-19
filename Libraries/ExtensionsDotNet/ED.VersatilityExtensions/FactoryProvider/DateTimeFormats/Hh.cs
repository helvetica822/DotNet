namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「hh」の日時フォーマットを表します。
    /// </summary>
    public class Hh : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「hh」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Hh() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「hh」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "hh";

        /// <summary>
        /// 「h」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "h";

        #endregion

    }
}
