namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 「yyyy」の日時フォーマットを表します。
    /// </summary>
    public class Yyyy: AbstractDateTimeFormat
    {

        #region Constructor

        /// <summary>
        /// 「yyyy」の日時フォーマットクラスのインスタンスを生成します。
        /// </summary>
        internal Yyyy() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy」の日時フォーマットを取得します。
        /// </summary>
        public override string ZeroPaddingFormat => "yyyy";

        /// <summary>
        /// 「yyyy」の日時フォーマットを取得します。
        /// </summary>
        public override string NoPaddingFormat => this.ZeroPaddingFormat;

        #endregion

    }
}
