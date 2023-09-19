namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「MM」の日時フォーマットを表します。
    /// </summary>
    public class Mm : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「Mm」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Mm() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「MM/」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "MM";

        /// <summary>
        /// 「M/d」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "M";

        #endregion

    }
}
