namespace ED.VersatilityExtensions.CollectionExtensions.Mapper
{

    /// <summary>
    /// プロパティ名称とマッピング先項目名称を紐付けるオブジェクトを表します。
    ///     <para>このクラスは継承できません。</para>
    /// </summary>
    internal sealed class PropertyMapperItem
    {

        #region Internal Property

        /// <summary>
        /// プロパティ名称を取得または設定します。
        /// </summary>
        internal string PropertyName { get; init; }

        /// <summary>
        /// マッピング先項目名称を取得します。
        /// </summary>
        internal string? MappingName { get; init; }

        /// <summary>
        /// マッピング処理の対象外とするか示す値を取得します。
        /// </summary>
        internal bool Ignore { get; init; }

        #endregion

        #region Constructor

        /// <summary>
        /// プロパティ名称とマッピング先項目名称を紐付けるオブジェクトのインスタンスを生成します。
        /// </summary>
        /// <param name="propertyName">プロパティ名称。</param>
        /// <param name="mappingName">マッピング先項目名称。</param>
        /// <param name="ignore">マッピング処理の対象外とするか示す値。</param>
        internal PropertyMapperItem(string propertyName, string? mappingName, bool ignore) => (this.PropertyName, this.MappingName, this.Ignore) = (propertyName, mappingName, ignore);

        #endregion

    }
}
