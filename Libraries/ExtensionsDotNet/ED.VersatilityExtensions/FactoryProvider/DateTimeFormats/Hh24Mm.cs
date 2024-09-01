namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「HH:mm」の日時フォーマットを表します。
    /// </summary>
    public class Hh24Mm : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「HH:mm」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Hh24Mm() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「HH:mm」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "HH:mm";

        /// <summary>
        /// 「H:m」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "H:m";

        #endregion

    }
}
