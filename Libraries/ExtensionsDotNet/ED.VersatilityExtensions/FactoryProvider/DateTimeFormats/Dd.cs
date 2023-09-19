namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「dd」の日時フォーマットを表します。
    /// </summary>
    public class Dd : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「dd」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Dd() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「dd」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "dd";

        /// <summary>
        /// 「d」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "d";

        #endregion

    }
}
