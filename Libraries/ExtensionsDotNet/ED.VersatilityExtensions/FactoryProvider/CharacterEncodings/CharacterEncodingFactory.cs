using System.Text;

namespace ED.VersatilityExtensions.FactoryProvider.CharacterEncodings
{

    /// <summary>
    /// 文字コードエンコーディングを提供します。
    /// </summary>
    public static class CharacterEncodingFactory
    {

        #region Public Override ReadOnly Property

        /// <summary>
        /// Shift-JIS の文字コードを取得します。
        /// </summary>
        public static AbstractCharacterEncoding ShiftJIS => new ShiftJISEncoding();

        /// <summary>
        /// JIS の文字コードを取得します。
        /// </summary>
        public static AbstractCharacterEncoding JIS => new JISEncoding();

        /// <summary>
        /// EUC の文字コードを取得します。
        /// </summary>
        public static AbstractCharacterEncoding EUC => new EUCEncoding();

        /// <summary>
        /// UTF-8 の文字コードを取得します。
        /// </summary>
        public static AbstractCharacterEncoding UTF8 => new UTF8Encoding();

        #endregion

        // ↓Public static method↓

        #region CreateEncoding

        /// <summary>
        /// 指定された文字コードから <see cref="Encoding"/> オブジェクトを生成します。
        /// </summary>
        /// <param name="characterCode">文字コード。</param>
        /// <returns>指定された文字コードの <see cref="Encoding"/> オブジェクト。</returns>
        public static Encoding CreateEncoding(string characterCode) => Encoding.GetEncoding(characterCode);

        #endregion

    }
}
