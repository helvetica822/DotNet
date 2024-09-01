namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「ss」の日時フォーマットを表します。
    /// </summary>
    public class Ss : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「ss」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Ss() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「ss」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "ss";

        /// <summary>
        /// 「s」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "s";

        #endregion

    }
}
