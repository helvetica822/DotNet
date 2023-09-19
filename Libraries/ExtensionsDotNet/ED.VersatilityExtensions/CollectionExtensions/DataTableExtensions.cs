using ED.VersatilityExtensions.CollectionExtensions.Mapper;
using ED.VersatilityExtensions.ReflectionExtensions;
using System.Data;

namespace ED.VersatilityExtensions.CollectionExtensions
{

    /// <summary>
    /// <see cref="DataTable"/> の拡張機能を提供します。
    /// </summary>
    public static class DataTableExtensions
    {

        #region To

        /// <summary>
        /// <see cref="DataTable"/> を <typeparamref name="T"/> の配列形式に変換します。
        /// </summary>
        /// <typeparam name="T">配列のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <returns><see cref="DataTable"/> を変換した <typeparamref name="T"/> の配列。</returns>
        public static T[] ToArray<T>(this DataTable table) where T : class, new() => table.ToList<T>().ToArray();

        /// <summary>
        /// <see cref="DataTable"/> を <see cref="List{T}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="List{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <returns><see cref="DataTable"/> を変換した <see cref="List{T}"/>。</returns>
        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            var list = new List<T>();

            var mapperItems = CreateMapperItemCollection<T>();

            foreach (DataRow row in table.Rows)
            {
                var item = CreateItemInstanceFromDataRow<T>(row, mapperItems);

                list.Add(item);
            }

            return list;
        }

        /// <summary>
        /// <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="SortedList{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとするプロパティのデータ型。</typeparam>
        /// <typeparam name="U"><see cref="SortedList{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <returns><see cref="DataTable"/> を変換した <see cref="SortedList{T, U}"/>。</returns>
        public static SortedList<T, U> ToSortedList<T, U>(this DataTable table) where T : notnull where U : class, new()
        {
            var list = new SortedList<T, U>();
            var attribute = typeof(U).GetCustomAttributeFirstOrDefault<KeyProperty>() ?? throw new Exception($"{nameof(U)} クラスにソートのキーとする {nameof(KeyProperty)} 属性が付加されていません。");
            var mapperItems = CreateMapperItemCollection<U>();
            var keyInfo = typeof(U).GetProperty(attribute.PropertyName) ?? throw new Exception($"{nameof(U)} クラスにプロパティ {attribute.PropertyName} が存在しません。");

            foreach (DataRow row in table.Rows)
            {
                var columnName = GetMappingNameToList(mapperItems, attribute.PropertyName);
                if (columnName is null) continue;

                var key = (T)Convert.ChangeType(row[columnName], keyInfo.PropertyType);
                var item = CreateItemInstanceFromDataRow(row, mapperItems);

                list.Add(key, item);
            }

            return list;
        }

        /// <summary>
        /// <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="SortedList{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする <see cref="DataColumn"/> のデータ型。</typeparam>
        /// <typeparam name="U"><see cref="SortedList{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <param name="keyColumnName"><see cref="DataColumn"/> 名称。</param>
        /// <returns><see cref="DataTable"/> を変換した <see cref="SortedList{T, U}"/>。</returns>
        public static SortedList<T, U> ToSortedList<T, U>(this DataTable table, string keyColumnName) where T : notnull where U : class, new()
        {
            var list = new SortedList<T, U>();

            var mapperItems = CreateMapperItemCollection<U>();

            foreach (DataRow row in table.Rows)
            {
                var columnName = GetMappingNameToList(mapperItems, keyColumnName);
                if (columnName is null) continue;

                var key = (T)Convert.ChangeType(row[columnName], typeof(T));
                var item = CreateItemInstanceFromDataRow(row, mapperItems);

                list.Add(key, item);
            }

            return list;
        }

        /// <summary>
        /// <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="Dictionary{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>キーとするプロパティのデータ型。</typeparam>
        /// <typeparam name="U"><see cref="Dictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <returns><see cref="DataTable"/> を変換した <see cref="Dictionary{T, U}"/>。</returns>
        public static Dictionary<T, U> ToDictionary<T, U>(this DataTable table) where T : notnull where U : class, new()
        {
            var dic = new Dictionary<T, U>();
            var attribute = typeof(U).GetCustomAttributeFirstOrDefault<KeyProperty>() ?? throw new Exception($"{nameof(U)} クラスにキーとする {nameof(KeyProperty)} 属性が付加されていません。");
            var mapperItems = CreateMapperItemCollection<U>();
            var keyInfo = typeof(U).GetProperty(attribute.PropertyName) ?? throw new Exception($"{nameof(U)} クラスにプロパティ {attribute.PropertyName} が存在しません。");

            foreach (DataRow row in table.Rows)
            {
                var columnName = GetMappingNameToList(mapperItems, attribute.PropertyName);
                if (columnName is null) continue;

                var key = (T)Convert.ChangeType(row[columnName], keyInfo.PropertyType);
                var item = CreateItemInstanceFromDataRow(row, mapperItems);

                dic.Add(key, item);
            }

            return dic;
        }

        /// <summary>
        /// <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="Dictionary{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>キーとする <see cref="DataColumn"/> のデータ型。</typeparam>
        /// <typeparam name="U"><see cref="Dictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <param name="keyColumnName"><see cref="DataColumn"/> 名称。</param>
        /// <returns><see cref="DataTable"/> を変換した <see cref="Dictionary{T, U}"/>。</returns>
        public static Dictionary<T, U> ToDictionary<T, U>(this DataTable table, string keyColumnName) where T : notnull where U : class, new()
        {
            var dic = new Dictionary<T, U>();

            var mapperItems = CreateMapperItemCollection<U>();

            foreach (DataRow row in table.Rows)
            {
                var columnName = GetMappingNameToList(mapperItems, keyColumnName);
                if (columnName is null) continue;

                var key = (T)Convert.ChangeType(row[columnName], typeof(T));
                var item = CreateItemInstanceFromDataRow(row, mapperItems);

                dic.Add(key, item);
            }

            return dic;
        }

        /// <summary>
        /// <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="Dictionary{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとするプロパティのデータ型。</typeparam>
        /// <typeparam name="U"><see cref="Dictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <returns><see cref="DataTable"/> を変換した <see cref="Dictionary{T, U}"/>。</returns>
        public static SortedDictionary<T, U> ToSortedDictionary<T, U>(this DataTable table) where T : notnull where U : class, new()
        {
            var dic = new SortedDictionary<T, U>();
            var attribute = typeof(U).GetCustomAttributeFirstOrDefault<KeyProperty>() ?? throw new Exception($"{nameof(U)} クラスにキーとする {nameof(KeyProperty)} 属性が付加されていません。");
            var mapperItems = CreateMapperItemCollection<U>();
            var keyInfo = typeof(U).GetProperty(attribute.PropertyName) ?? throw new Exception($"{nameof(U)} クラスにプロパティ {attribute.PropertyName} が存在しません。");

            foreach (DataRow row in table.Rows)
            {
                var columnName = GetMappingNameToList(mapperItems, attribute.PropertyName);
                if (columnName is null) continue;

                var key = (T)Convert.ChangeType(row[columnName], keyInfo.PropertyType);
                var item = CreateItemInstanceFromDataRow(row, mapperItems);

                dic.Add(key, item);
            }

            return dic;
        }

        /// <summary>
        /// <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="Dictionary{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする <see cref="DataColumn"/> のデータ型。</typeparam>
        /// <typeparam name="U"><see cref="Dictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <param name="keyColumnName"><see cref="DataColumn"/> 名称。</param>
        /// <returns><see cref="DataTable"/> を変換した <see cref="Dictionary{T, U}"/>。</returns>
        public static SortedDictionary<T, U> ToSortedDictionary<T, U>(this DataTable table, string keyColumnName) where T : notnull where U : class, new()
        {
            var dic = new SortedDictionary<T, U>();

            var mapperItems = CreateMapperItemCollection<U>();

            foreach (DataRow row in table.Rows)
            {
                var columnName = GetMappingNameToList(mapperItems, keyColumnName);
                if (columnName is null) continue;

                var key = (T)Convert.ChangeType(row[columnName], typeof(T));
                var item = CreateItemInstanceFromDataRow(row, mapperItems);

                dic.Add(key, item);
            }

            return dic;
        }

        /// <summary>
        /// <see cref="DataTable"/> を <see cref="DataSet"/> 形式に変換します。
        /// </summary>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <returns><see cref="DataTable"/> を変換した <see cref="DataSet"/>。</returns>
        public static DataSet ToDataSet(this DataTable table)
        {
            var ds = new DataSet();
            ds.Tables.Add(table);

            return ds;
        }

        /// <summary>
        /// <see cref="DataTable"/> を <see cref="DataView"/> 形式に変換します。
        /// </summary>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <returns><see cref="DataTable"/> を変換した <see cref="DataView"/>。</returns>
        public static DataView ToDataView(this DataTable table) => new(table);

        #endregion

        // ↓Private static method↓

        #region CreatePropertyMapperItemCollection

        /// <summary>
        /// プロパティの <see cref="PropertyMapper"/> 属性からマッピング項目のコレクションを生成します。
        /// </summary>
        /// <typeparam name="T">ジェネリックスクラス。</typeparam>
        /// <returns>プロパティの名称とマッピングする項目情報オブジェクトのコレクション。</returns>
        private static PropertyMapperItemCollection<T> CreateMapperItemCollection<T>() where T : class, new() => new();

        #endregion

        #region MappingName

        /// <summary>
        /// <see cref="List{T}"/> へのマッピングに実際に使用する項目名称を取得します。
        /// </summary>
        /// <typeparam name="T"><see cref="List{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="mapperItems">プロパティの名称とマッピングする項目情報オブジェクトのコレクション。</param>
        /// <param name="propertyName">プロパティ名称。</param>
        /// <returns>マッピングに実際に使用する項目名称。</returns>
        private static string? GetMappingNameToList<T>(PropertyMapperItemCollection<T> mapperItems, string propertyName) where T : class, new()
        {
            var mapper = mapperItems.Item(propertyName);
            if (mapper is not null && mapper.Ignore) return null;

            return (mapper is null || mapper.MappingName is null) ? propertyName : mapper.MappingName;
        }

        #endregion

        #region CreateItemInstanceFromDataRow

        /// <summary>
        /// <see cref="DataRow"/> からジェネリックスクラス <typeparamref name="T"/> に変換したインスタンスを生成します。
        /// </summary>
        /// <typeparam name="T">ジェネリックスクラス。</typeparam>
        /// <param name="row"><see cref="DataRow"/>。</param>
        /// <param name="mapperItems">プロパティの名称とマッピングする項目情報オブジェクトのコレクション。</param>
        /// <returns></returns>
        private static T CreateItemInstanceFromDataRow<T>(DataRow row, PropertyMapperItemCollection<T> mapperItems) where T : class, new()
        {
            var item = new T();

            foreach (var pro in item.GetType().GetProperties())
            {
                var columnName = GetMappingNameToList(mapperItems, pro.Name);
                if (columnName is null) continue;

                pro.SetValue(item, Convert.ChangeType(row[columnName], pro.PropertyType));
            }

            return item;
        }

        #endregion

    }
}
