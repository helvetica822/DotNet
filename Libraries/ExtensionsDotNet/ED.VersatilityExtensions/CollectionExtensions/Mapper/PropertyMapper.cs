using System.Data;

namespace ED.VersatilityExtensions.CollectionExtensions.Mapper
{

    /// <summary>
    /// プロパティ名称とマッピング先項目名称を紐付ける属性を表します。
    ///     <para>このクラスは継承できません。</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class PropertyMapper : Attribute
    {

        #region Public Property

        /// <summary>
        /// マッピング先項目名称を取得または設定します。
        /// </summary>
        public string? MappingName { get; init; }

        /// <summary>
        /// マッピング処理の対象外とするか示す値を取得します。
        /// </summary>
        public bool Ignore { get; init; }

        #endregion

        #region Constructor

        /// <summary>
        /// プロパティ名称とマッピング先項目名称を紐付ける属性のインスタンスを生成します。
        /// </summary>
        public PropertyMapper() { }

        /// <summary>
        /// プロパティ名称とマッピング先項目名称を紐付ける属性のインスタンスを生成します。
        /// </summary>
        /// <param name="mappingName">マッピング先項目名称。</param>
        public PropertyMapper(string mappingName) => (this.MappingName, this.Ignore) = (mappingName, false);

        /// <summary>
        /// 型なしの <see cref="DataTable"/> によって自動生成されるプロパティ名称とマッピング先項目名称を紐付ける属性のインスタンスを生成します。
        /// </summary>
        /// <param name="index">型なしの <see cref="DataTable"/> によって自動生成される「Column***」列のインデックス。</param>
        public PropertyMapper(int index) => (this.MappingName, this.Ignore) = ("Column" + index.ToString(), false);

        /// <summary>
        /// プロパティ名称とマッピング先項目名称を紐付ける属性のインスタンスを生成します。
        /// </summary>
        /// <param name="ignore">マッピング処理の対象外とするか示す値。</param>
        public PropertyMapper(bool ignore) => (this.MappingName, this.Ignore) = (null, ignore);

        #endregion

    }
}
