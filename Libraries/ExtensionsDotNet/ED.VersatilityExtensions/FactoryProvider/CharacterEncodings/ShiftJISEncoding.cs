namespace ED.VersatilityExtensions.FactoryProvider.CharacterEncodings
{

    /// <summary>
    /// Shift-JIS のエンコーディングクラスを表します。
    /// </summary>
    public class ShiftJISEncoding : AbstractCharacterEncoding
    {

        #region Constructor

        /// <summary>
        /// Shift-JIS のエンコーディングクラスのインスタンスを生成します。
        /// </summary>
        internal ShiftJISEncoding() { }

        #endregion

        #region Public Override ReadOnly Property

        /// <summary>
        /// Shift-JIS の文字コードを取得します。
        /// </summary>
        protected override string CharacterCode => "Shift-JIS";

        #endregion

    }
}
