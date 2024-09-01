namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 時間間隔フォーマットの抽象クラスを表します。
    /// </summary>
    public abstract class AbstractTimeSpanFormat
    {

        #region Public Abstract ReadOnly Property

        /// <summary>
        /// 0 パディングを含む時間間隔フォーマットを取得します。
        /// </summary>
        public abstract string ZeroPaddingFormat { get; }

        /// <summary>
        /// 0 パディングを含まない時間間隔フォーマットを取得します。
        /// </summary>
        public abstract string NoPaddingFormat { get; }

        #endregion

        #region Public ReadOnly Property

        /// <summary>
        /// 「\記号(英語環境におけるバックスラッシュ)」を含まない 0 パディングを含む時間間隔フォーマットを取得します。
        /// </summary>
        public string ZeroPaddingFormatNoDelimiter => this.ZeroPaddingFormat.Replace(@"\", string.Empty);

        /// <summary>
        /// 「\記号(英語環境におけるバックスラッシュ)」を含まない 0 パディングを含まない時間間隔フォーマットを取得します。
        /// </summary>
        public string NoPaddingFormatNoDelimiter => this.NoPaddingFormat.Replace(@"\", string.Empty);

        #endregion

    }
}
