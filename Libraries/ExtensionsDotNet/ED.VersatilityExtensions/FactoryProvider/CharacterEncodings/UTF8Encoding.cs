namespace ED.VersatilityExtensions.FactoryProvider.CharacterEncodings
{

    /// <summary>
    /// UTF-8 のエンコーディングクラスを表します。
    /// </summary>
    public class UTF8Encoding : AbstractCharacterEncoding
    {

        #region Constructor

        /// <summary>
        /// UTF-8 のエンコーディングクラスのインスタンスを生成します。
        /// </summary>
        internal UTF8Encoding() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// UTF-8 の文字コードを取得します。
        /// </summary>
        protected override string CharacterCode => "utf-8";

        #endregion

    }
}
