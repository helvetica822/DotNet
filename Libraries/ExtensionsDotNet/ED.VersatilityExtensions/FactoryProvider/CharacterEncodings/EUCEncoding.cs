namespace ED.VersatilityExtensions.FactoryProvider.CharacterEncodings
{

    /// <summary>
    /// EUC のエンコーディングクラスを表します。
    /// </summary>
    public class EUCEncoding : AbstractCharacterEncoding
    {

        #region Constructor

        /// <summary>
        /// EUC のエンコーディングクラスのインスタンスを生成します。
        /// </summary>
        internal EUCEncoding() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// EUC の文字コードを取得します。
        /// </summary>
        protected override string CharacterCode => "euc-jp";

        #endregion

    }
}
