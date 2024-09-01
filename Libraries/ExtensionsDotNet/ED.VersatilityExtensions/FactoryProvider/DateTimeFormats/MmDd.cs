namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「MM/dd」の日時フォーマットを表します。
    /// </summary>
    public class MmDd : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「Mm/dd」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal MmDd() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「MM/dd」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "MM/dd";

        /// <summary>
        /// 「M/d」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "M/d";

        #endregion

    }
}
