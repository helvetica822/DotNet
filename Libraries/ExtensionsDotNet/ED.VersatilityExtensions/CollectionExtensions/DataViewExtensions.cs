using System.Data;

namespace ED.VersatilityExtensions.CollectionExtensions
{

    /// <summary>
    /// <see cref="DataView"/> の拡張機能を提供します。
    /// </summary>
    public static class DataViewExtensions
    {

        #region To

        /// <summary>
        /// <see cref="DataView"/> 内に存在する <see cref="DataTable"/> を配列形式に変換します。
        /// </summary>
        /// <typeparam name="T">配列のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataView"/>。</param>
        /// <returns><see cref="DataView"/> 内に存在する <see cref="DataTable"/> を変換した配列。</returns>
        public static T[]? ToArray<T>(this DataView dv) where T : class, new() => dv.Table?.ToArray<T>();

        /// <summary>
        /// <see cref="DataView"/> 内に存在する <see cref="DataTable"/> を <see cref="List{T}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="List{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataView"/>。</param>
        /// <returns><see cref="DataView"/> 内に存在する <see cref="DataTable"/> を変換した <see cref="List{T}"/>。</returns>
        public static List<T>? ToList<T>(this DataView dv) where T : class, new() => dv.Table?.ToList<T>();

        /// <summary>
        /// <see cref="DataView"/> 内に存在する <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="SortedList{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="SortedList{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataView"/>。</param>
        /// <returns><see cref="DataView"/> 内に存在する <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="SortedList{T, U}"/>。</returns>
        public static SortedList<T, U>? ToSortedList<T, U>(this DataView dv) where T : notnull where U : class, new() => dv.Table?.ToSortedList<T, U>();

        /// <summary>
        /// <see cref="DataView"/> 内に存在する <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="SortedList{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="SortedList{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <param name="keyColumnName"><see cref="DataColumn"/> 名称。</param>
        /// <returns><see cref="DataView"/> 内に存在する <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="SortedList{T, U}"/>。</returns>
        public static SortedList<T, U>? ToSortedList<T, U>(this DataView dv, string keyColumnName) where T : notnull where U : class, new() => dv.Table?.ToSortedList<T, U>(keyColumnName);

        /// <summary>
        /// <see cref="DataView"/> 内に存在する <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="Dictionary{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="Dictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataView"/>。</param>
        /// <returns><see cref="DataView"/> 内に存在する <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="Dictionary{T, U}"/>。</returns>
        public static Dictionary<T, U>? ToDictionary<T, U>(this DataView dv) where T : notnull where U : class, new() => dv.Table?.ToDictionary<T, U>();

        /// <summary>
        /// <see cref="DataView"/> 内に存在する <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="Dictionary{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="Dictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <param name="keyColumnName"><see cref="DataColumn"/> 名称。</param>
        /// <returns><see cref="DataView"/> 内に存在する <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="Dictionary{T, U}"/>。</returns>
        public static Dictionary<T, U>? ToDictionary<T, U>(this DataView dv, string keyColumnName) where T : notnull where U : class, new() => dv.Table?.ToDictionary<T, U>(keyColumnName);

        /// <summary>
        /// <see cref="DataView"/> 内に存在する <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="SortedDictionary{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="SortedDictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataView"/>。</param>
        /// <returns><see cref="DataView"/> 内に存在する <see cref="DataTable"/> を <typeparamref name="U"/> クラスの <see cref="KeyProperty"/> 属性を持つプロパティをキーとした <see cref="SortedDictionary{T, U}"/>。</returns>
        public static SortedDictionary<T, U>? ToSortedDictionary<T, U>(this DataView dv) where T : notnull where U : class, new() => dv.Table?.ToSortedDictionary<T, U>();

        /// <summary>
        /// <see cref="DataView"/> 内に存在する <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="SortedDictionary{T, U}"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="U"/>ソートキーとする</typeparam>
        /// <typeparam name="U"><see cref="SortedDictionary{T, U}"/> のジェネリックスクラス。</typeparam>
        /// <param name="table"><see cref="DataTable"/>。</param>
        /// <param name="keyColumnName"><see cref="DataColumn"/> 名称。</param>
        /// <returns><see cref="DataView"/> 内に存在する <see cref="DataTable"/> を指定した名称の <see cref="DataColumn"/> の値をキーとした <see cref="SortedDictionary{T, U}"/>。</returns>
        public static SortedDictionary<T, U>? ToSortedDictionary<T, U>(this DataView dv, string keyColumnName) where T : notnull where U : class, new() => dv.Table?.ToSortedDictionary<T, U>(keyColumnName);

        #endregion

    }
}
