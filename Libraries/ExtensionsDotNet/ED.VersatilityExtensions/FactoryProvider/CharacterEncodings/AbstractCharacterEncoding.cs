using System.Text;

namespace ED.VersatilityExtensions.FactoryProvider.CharacterEncodings
{

    /// <summary>
    /// 文字コードエンコーディングの抽象クラスを表します。
    /// </summary>
    public abstract class AbstractCharacterEncoding
    {

        #region Public Abstract ReadOnly Property

        /// <summary>
        /// 文字コードを取得します。
        /// </summary>
        protected abstract string CharacterCode { get; }

        #endregion

        #region Public ReadOnly Property

        /// <summary>
        /// 文字コードエンコーディングを取得します。
        /// </summary>
        public Encoding CharacterEncoding => Encoding.GetEncoding(this.CharacterCode);

        #endregion

    }
}
