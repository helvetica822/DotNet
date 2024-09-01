namespace ED.VersatilityExtensions.CollectionExtensions.Mapper
{

    /// <summary>
    /// クラス内で単一のキーとするプロパティを示す属性を表します。
    ///     <para>このクラスは継承できません。</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class KeyProperty : Attribute
    {

        #region Public Property

        /// <summary>
        /// プロパティ名称を取得または設定します。
        /// </summary>
        public string PropertyName { get; init; }

        #endregion

        #region Constructor

        /// <summary>
        /// クラス内で単一のキーとするプロパティを示すインスタンスを生成します。
        /// </summary>
        public KeyProperty() : this("Key") { }

        /// <summary>
        /// クラス内で単一のキーとするプロパティを示すインスタンスを生成します。
        /// </summary>
        /// <param name="propertyName">プロパティ名称。</param>
        public KeyProperty(string propertyName) => this.PropertyName = propertyName;

        #endregion

    }
}
