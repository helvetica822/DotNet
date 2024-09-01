namespace ED.VersatilityExtensions.FactoryProvider.CharacterEncodings
{

    /// <summary>
    /// JIS のエンコーディングクラスを表します。
    /// </summary>
    public class JISEncoding : AbstractCharacterEncoding
    {

        #region Constructor

        /// <summary>
        /// JIS のエンコーディングクラスのインスタンスを生成します。
        /// </summary>
        internal JISEncoding() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// JIS の文字コードを取得します。
        /// </summary>
        protected override string CharacterCode => "iso-2022-jp";

        #endregion

    }
}
