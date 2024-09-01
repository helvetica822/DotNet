namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「HH」の日時フォーマットを表します。
    /// </summary>
    public class Hh24 : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「HH」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Hh24() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「HH」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "HH";

        /// <summary>
        /// 「H」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "H";

        #endregion

    }
}
