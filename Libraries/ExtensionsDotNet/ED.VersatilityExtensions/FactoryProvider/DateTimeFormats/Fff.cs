namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「fff」の日時フォーマットを表します。
    /// </summary>
    public class Fff : AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「fff」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Fff() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「fff」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "fff";

        /// <summary>
        /// 「f」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => "f";

        #endregion

    }
}
