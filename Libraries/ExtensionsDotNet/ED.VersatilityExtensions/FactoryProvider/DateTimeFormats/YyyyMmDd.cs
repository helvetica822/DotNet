namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「yyyy/MM/dd」の日時フォーマットを表します。
    /// </summary>
    public class YyyyMmDd : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「yyyy/Mm/dd」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal YyyyMmDd() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy/MM/dd」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "yyyy/MM/dd";

        /// <summary>
        /// 「yyyy/M/d」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "yyyy/M/d";

        #endregion

    }
}
