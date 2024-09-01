using ED.VersatilityExtensions.ReflectionExtensions;
using System.Collections;

namespace ED.VersatilityExtensions.CollectionExtensions.Mapper
{

    /// <summary>
    /// プロパティの名称とマッピングする項目情報オブジェクトのコレクションを表します。
    ///     <para>このクラスは継承できません。</para>
    /// </summary>
    internal sealed class PropertyMapperItemCollection<T> : IEnumerable<PropertyMapperItem> where T : class, new()
    {

        #region Private Variable

        /// <summary>
        /// プロパティ名称とマッピング先項目名称を紐付けるオブジェクトのコレクションを表します。
        /// </summary>
        private readonly List<PropertyMapperItem> _items = new();

        #endregion

        #region Internal Property

        /// <summary>
        /// プロパティ名称とマッピング先項目名称を紐付けるオブジェクトのコレクションを取得します。
        /// </summary>
        internal IEnumerable<PropertyMapperItem> Items => this._items;

        /// <summary>
        /// 指定したプロパティ名称を持つ、プロパティ名称とマッピング先項目名称を紐付けるオブジェクトを取得します。
        /// </summary>
        /// <param name="propertyName">プロパティ名称。</param>
        /// <returns>プロパティ名称とマッピング先項目名称を紐付けるオブジェクト。</returns>
        internal PropertyMapperItem? Item(string propertyName) => this._items.FirstOrDefault(item => item.PropertyName == propertyName);

        #endregion

        #region Constructor

        /// <summary>
        /// プロパティの名称とマッピングする項目情報オブジェクトのコレクションのインスタンスを生成します。
        /// </summary>
        internal PropertyMapperItemCollection() => this.CreateItemCollection();

        #endregion

        // ↓Private method↓

        #region CreateCollection

        /// <summary>
        /// プロパティの名称とマッピングする項目情報オブジェクトのコレクションを生成します。
        /// </summary>
        private void CreateItemCollection()
        {
            var item = new T();

            IEnumerable<string> propertiesName = item.GetType().GetPropertiesName();

            foreach (var propertyName in propertiesName)
            {
                this._items.Add(this.CreatePropertyMapperItem(item, propertyName));
            }
        }

        #endregion

        #region PropertyMapperItem

        /// <summary>
        /// プロパティ名称とマッピング先項目名称を紐付けるオブジェクトを生成します。
        /// </summary>
        /// <param name="item">マッピング情報を取得するジェネリックスクラス。</param>
        /// <param name="propertyName">プロパティ名称。</param>
        /// <returns>プロパティ名称とマッピング先項目名称を紐付けるオブジェクト。</returns>
        private PropertyMapperItem CreatePropertyMapperItem(T item, string propertyName)
        {
            PropertyMapper? attribute = item.GetType().GetPropertyCustomAttributeFirstOrDefault<PropertyMapper>(propertyName);
            var ignore = attribute is not null && attribute.Ignore;

            return new PropertyMapperItem(propertyName, attribute?.MappingName, ignore);
        }

        #endregion

        // ↓IEnumerable method↓

        #region IEnumerator

        /// <summary>
        /// <see cref="PropertyMapperItemCollection{T}"/> を反復処理する列挙子を返します。
        /// </summary>
        /// <returns>列挙子。</returns>
        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// <see cref="PropertyMapperItemCollection{T}"/> を反復処理する列挙子を返します。
        /// </summary>
        /// <returns>列挙子。</returns>
        IEnumerator<PropertyMapperItem> IEnumerable<PropertyMapperItem>.GetEnumerator()
        {
            foreach (var item in this._items)
            {
                yield return item;
            }
        }

        #endregion

    }
}
