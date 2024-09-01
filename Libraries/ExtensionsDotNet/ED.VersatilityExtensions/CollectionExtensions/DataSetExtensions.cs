using System.Data;

namespace ED.VersatilityExtensions.CollectionExtensions
{

    /// <summary>
    /// <see cref="DataSet"/> の拡張機能を提供します。
    /// </summary>
    public static class DataSetExtensions
    {

        #region To

        /// <summary>
        /// <see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を変換した配列を持つ <typeparamref name="T"/> の 2 次元配列形式に変換します。
        /// </summary>
        /// <typeparam name="T">配列のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataSet"/>。</param>
        /// <returns><see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を変換した配列を持つ <typeparamref name="T"/> の 2 次元配列。</returns>
        public static T[][] ToTwoDimensionalArray<T>(this DataSet ds) where T : class, new()
        {
            var array = new T[ds.Tables.Count][];

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                array[i] = ds.Tables[i].ToList<T>().ToArray();
            }

            return array;
        }

        /// <summary>
        /// <see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を変換した <see cref="List{T}"/> を持つ <see cref="List{List{T}}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="List{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataSet"/>。</param>
        /// <returns><see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を変換した <see cref="List{T}"/> を持つ <see cref="List{List{T}}"/>。</returns>
        public static List<List<T>> ToLists<T>(this DataSet ds) where T : class, new()
        {
            var list = new List<List<T>>();

            foreach (DataTable table in ds.Tables)
            {
                list.Add(table.ToList<T>());
            }

            return list;
        }

        /// <summary>
        /// <see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="SortedList{T, U}"/> を持つ <see cref="List{SortedList{T, U}}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="SortedList{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataSet"/>。</param>
        /// <returns><see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="SortedList{T, U}"/> を持つ <see cref="List{SortedList{T, U}}"/>。</returns>
        public static List<SortedList<T, U>> ToSortedLists<T, U>(this DataSet ds) where T : notnull where U : class, new()
        {
            var list = new List<SortedList<T, U>>();

            foreach (DataTable table in ds.Tables)
            {
                list.Add(table.ToSortedList<T, U>());
            }

            return list;
        }

        /// <summary>
        /// <see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="SortedList{T, U}"/> を持つ <see cref="List{SortedList{T, U}}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="SortedList{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <param name="keyColumnName"><see cref="DataColumn"/> 名称。</param>
        /// <returns><see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="SortedList{T, U}"/> を持つ <see cref="List{SortedList{T, U}}"/>。</returns>
        public static List<SortedList<T, U>> ToSortedLists<T, U>(this DataSet ds, string keyColumnName) where T : notnull where U : class, new()
        {
            var list = new List<SortedList<T, U>>();

            foreach (DataTable table in ds.Tables)
            {
                list.Add(table.ToSortedList<T, U>(keyColumnName));
            }

            return list;
        }

        /// <summary>
        /// <see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="Dictionary{T, U}"/> を持つ <see cref="List{Dictionary{T, U}}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="Dictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataSet"/>。</param>
        /// <returns><see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="Dictionary{T, U}"/> を持つ <see cref="List{Dictionary{T, U}}"/>。</returns>
        public static List<Dictionary<T, U>> ToDictionaries<T, U>(this DataSet ds) where T : notnull where U : class, new()
        {
            var list = new List<Dictionary<T, U>>();

            foreach (DataTable table in ds.Tables)
            {
                list.Add(table.ToDictionary<T, U>());
            }

            return list;
        }

        /// <summary>
        /// <see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="Dictionary{T, U}"/> を持つ <see cref="List{Dictionary{T, U}}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="Dictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <param name="keyColumnName"><see cref="DataColumn"/> 名称。</param>
        /// <returns><see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="Dictionary{T, U}"/> を持つ <see cref="List{Dictionary{T, U}}"/>。</returns>
        public static List<Dictionary<T, U>> ToDictionaries<T, U>(this DataSet ds, string keyColumnName) where T : notnull where U : class, new()
        {
            var list = new List<Dictionary<T, U>>();

            foreach (DataTable table in ds.Tables)
            {
                list.Add(table.ToDictionary<T, U>(keyColumnName));
            }

            return list;
        }

        /// <summary>
        /// <see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="SortedDictionary{T, U}"/> を持つ <see cref="List{SortedDictionary{T, U}}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="SortedDictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataSet"/>。</param>
        /// <returns><see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="SortedDictionary{T, U}"/> を持つ <see cref="List{SortedDictionary{T, U}}"/>。</returns>
        public static List<SortedDictionary<T, U>> ToSortedDictionaries<T, U>(this DataSet ds) where T : notnull where U : class, new()
        {
            var list = new List<SortedDictionary<T, U>>();

            foreach (DataTable table in ds.Tables)
            {
                list.Add(table.ToSortedDictionary<T, U>());
            }

            return list;
        }

        /// <summary>
        /// <see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="SortedDictionary{T, U}"/> を持つ <see cref="List{SortedDictionary{T, U}}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="SortedDictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <param name="keyColumnName"><see cref="DataColumn"/> 名称。</param>
        /// <returns><see cref="DataSet"/> 内に存在するすべての <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="SortedDictionary{T, U}"/> を持つ <see cref="List{SortedDictionary{T, U}}"/>。</returns>
        public static List<SortedDictionary<T, U>> ToSortedDictionaries<T, U>(this DataSet ds, string keyColumnName) where T : notnull where U : class, new()
        {
            var list = new List<SortedDictionary<T, U>>();

            foreach (DataTable table in ds.Tables)
            {
                list.Add(table.ToSortedDictionary<T, U>(keyColumnName));
            }

            return list;
        }

        /// <summary>
        /// <see cref="DataSet"/> 内の指定したインデックスに存在する <see cref="DataTable"/> を <see cref="DataView"/> 形式に変換します。
        /// </summary>
        /// <param name="table"><see cref="DataSet"/>。</param>
        /// <param name="index"><see cref="DataView"/> 形式に変換する <see cref="DataTable"/> のインデックス。</param>
        /// <returns><see cref="DataSet"/> 内の指定したインデックスに存在する <see cref="DataTable"/> を変換した <see cref="DataView"/>。</returns>
        public static DataView ToDataView(this DataSet ds, int index) => new(ds.Tables[index]);

        #endregion

    }
}
