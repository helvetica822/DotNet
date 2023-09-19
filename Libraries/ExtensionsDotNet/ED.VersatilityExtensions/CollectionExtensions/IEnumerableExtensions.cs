using System.Data;
using System.Globalization;

namespace ED.VersatilityExtensions.CollectionExtensions
{

    /// <summary>
    /// <see cref="IEnumerable{T}"/> の拡張機能を提供します。
    /// </summary>
    public static class IEnumerableExtensions
    {

        #region To

        /// <summary>
        /// <see cref="IEnumerable{T}"/> を <see cref="DataTable"/> 形式に変換します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="value"><see cref="IEnumerable{T}"/> 。</param>
        /// <returns><see cref="IEnumerable{T}"/> を変換した <see cref="DataTable"/> 。</returns>
        public static DataTable? ToDataTable<T>(this IEnumerable<T> value) where T : class, new()
        {
            if (!value.Any()) return null;

            var table = new DataTable
            {
                Locale = CultureInfo.CurrentCulture
            };

            foreach (var pro in typeof(T).GetProperties())
            {
                _ = table.Columns.Add(pro.Name, pro.PropertyType);
            }

            foreach (var item in value)
            {
                var row = table.NewRow();

                foreach (var pro in typeof(T).GetProperties())
                {
                    row[pro.Name] = typeof(T).GetProperty(pro.Name)?.GetValue(item, null);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        /// <summary>
        /// <see cref="IEnumerable{T}"/> を <see cref="DataSet"/> 形式に変換します。
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="value"><see cref="IEnumerable{T}"/> 。</param>
        /// <returns><see cref="IEnumerable{T}"/> を変換した <see cref="DataSet"/> 。</returns>
        public static DataSet ToDataSet<T>(this IEnumerable<T> value) where T : class, new()
        {
            var ds = new DataSet();

            var table = value.ToDataTable();
            if (table is not null) ds.Tables.Add(table);

            return ds;
        }

        /// <summary>
        /// <see cref="IEnumerable{T}"/> を <see cref="DataView"/> 形式に変換します。
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="value"><see cref="IEnumerable{T}"/> 。</param>
        /// <returns><see cref="IEnumerable{T}"/> を変換した <see cref="DataView"/> 。</returns>
        public static DataView ToDataView<T>(this IEnumerable<T> value) where T : class, new() => new(value.ToDataTable());

        #endregion

        #region Contains

        /// <summary>
        /// 値型 <see cref="IEnumerable{T}"/> に格納されている値が指定した配列いずれかの値を含むか判断します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="value"><see cref="IEnumerable{T}"/> 。</param>
        /// <param name="searchValues">含まれているか判断する値型の値の配列。</param>
        /// <returns>格納されている値が配列の値いずれかを含む場合は true。それ以外の場合は false。</returns>
        public static bool ContainsStructValues<T>(this IEnumerable<T> value, params T[] searchValues) where T : struct
        {
            if (value is null) return false;
            if (searchValues.Length == 0) return false;

            var searchValueList = searchValues.ToList();

            bool contains = value.Contains(searchValueList.First());
            searchValueList.RemoveAt(0);

            foreach (var s in searchValueList)
            {
                contains |= value.Contains(s);
            }

            return false;
        }

        /// <summary>
        /// 参照型 <see cref="IEnumerable{T}"/> に格納されている値が指定した配列いずれかの値を含むか判断します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="value"><see cref="IEnumerable{T}"/> 。</param>
        /// <param name="searchValues">含まれているか判断する参照型の値の配列。</param>
        /// <returns>格納されている値が配列の値いずれかを含む場合は true。それ以外の場合は false。</returns>
        public static bool ContainsClassValues<T>(this IEnumerable<T> value, params T[]? searchValues) where T : class?
        {
            if (value is null) return false;
            if (searchValues is null || searchValues.Length == 0) return false;

            var searchValueList = searchValues.ToList();

            bool contains = value.Contains(searchValueList.First());
            searchValueList.RemoveAt(0);

            foreach (T s in searchValueList)
            {
                contains |= value.Contains(s);
            }

            return false;
        }

        /// <summary>
        /// 参照型 <see cref="IEnumerable{T}"/> に格納されている値が <see cref="null"/> を含むか判断します。
        /// </summary>
        /// <param name="value"><see cref="IEnumerable{T}"/> 。</param>
        /// <returns>格納されている値が <see cref="null"/> を含む場合は true。それ以外の場合は false。</returns>
        public static bool ContainsNull<T>(this IEnumerable<T> value) where T : class => value.ContainsClassValues(null);

        /// <summary>
        /// <see cref="IEnumerable{string}"/> に格納されている文字列が <see cref="string.Empty"/> を含むか判断します。
        /// </summary>
        /// <param name="value"><see cref="IEnumerable{string}"/> 。</param>
        /// <returns>格納されている文字列が <see cref="string.Empty"/> を含む場合は true。それ以外の場合は false。</returns>
        public static bool ContainsEmpty(this IEnumerable<string> value) => value.ContainsClassValues(string.Empty);

        /// <summary>
        /// <see cref="IEnumerable{string}"/> に格納されている文字列が半角空白を含むか判断します。
        /// </summary>
        /// <param name="value"><see cref="IEnumerable{string}"/> 。</param>
        /// <returns>格納されている文字列が半角空白を含む場合は true。それ以外の場合は false。</returns>
        public static bool ContainsHalfWhiteSpace(this IEnumerable<string> value) => value.ContainsClassValues(" ");

        /// <summary>
        /// <see cref="IEnumerable{string}"/> に格納されている文字列が全角空白を含むか判断します。
        /// </summary>
        /// <param name="value"><see cref="IEnumerable{string}"/> 。</param>
        /// <returns>格納されている文字列が全角空白を含む場合は true。それ以外の場合は false。</returns>
        public static bool ContainsFullWhiteSpace(this IEnumerable<string> value) => value.ContainsClassValues("　");

        /// <summary>
        /// <see cref="IEnumerable{string}"/> に格納されている文字列が半角空白または全角空白のいずれかを含むか判断します。
        /// </summary>
        /// <param name="value"><see cref="IEnumerable{string}"/> 。</param>
        /// <returns>格納されている文字列が半角空白または全角空白のいずれかを含む場合は true。それ以外の場合は false。</returns>
        public static bool ContainsWhiteSpace(this IEnumerable<string> value) => value.ContainsClassValues(" ", "　");

        /// <summary>
        /// <see cref="IEnumerable{string}"/> に格納されている文字列が <see cref="null"/> 、 <see cref="string.Empty"/> のいずれかを含むか判断します。
        /// </summary>
        /// <param name="value"><see cref="IEnumerable{string}"/> 。</param>
        /// <returns>格納されている文字列が <see cref="null"/> 、 <see cref="string.Empty"/> のいずれかを含む場合は true。それ以外の場合は false。</returns>
        public static bool ContainsNullOrEmpty(this IEnumerable<string> value) => value.ContainsClassValues(null, string.Empty);

        /// <summary>
        /// <see cref="IEnumerable{string}"/> に格納されている文字列が <see cref="null"/> 、半角空白または全角空白 のいずれかを含むか判断します。
        /// </summary>
        /// <param name="value"><see cref="IEnumerable{string}"/> 。</param>
        /// <returns>格納されている文字列が <see cref="null"/> 、半角空白または全角空白のいずれかを含む場合は true。それ以外の場合は false。</returns>
        public static bool ContainsNullOrWhiteSpace(this IEnumerable<string> value) => value.ContainsClassValues(null, " ", "　");

        /// <summary>
        /// <see cref="IEnumerable{string}"/> に格納されている文字列が <see cref="null"/> 、 <see cref="string.Empty"/> 、半角空白または全角空白 のいずれかを含むか判断します。
        /// </summary>
        /// <param name="value"><see cref="IEnumerable{string}"/> 。</param>
        /// <returns>格納されている文字列が <see cref="null"/> 、 <see cref="string.Empty"/> 、半角空白または全角空白のいずれかを含む場合は true。それ以外の場合は false。</returns>
        public static bool ContainsNullOrEmptyOrWhiteSpace(this IEnumerable<string> value) => value.ContainsClassValues(null, string.Empty, " ", "　");

        #endregion

        #region Remove

        /// <summary>
        /// <see cref="IEnumerable{T}"/> から null の要素を除きます。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="value"><see cref="IEnumerable{T}"/> 。</param>
        /// <returns>null 要素を除いた <see cref="IEnumerable{T}"/> 。</returns>
        public static IEnumerable<T> RemoveNull<T>(this IEnumerable<T> value) where T : class => value.Where(l => l is not null).ToList();

        #endregion

        #region Distinct

        /// <summary>
        /// <see cref="IEnumerable{T}"/> から重複している要素と数を持つ <see cref="IDictionary{T, int}"/> を取得します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="value"><see cref="IEnumerable{T}"/> 。</param>
        /// <returns>重複している要素と数を持つ <see cref="IDictionary{T, int}"/> 。</returns>
        public static IDictionary<T, int> GetDistinctValues<T>(this IEnumerable<T> value) where T : notnull
        {
            var pairs = new Dictionary<T, int>();

            foreach (var l in value)
            {
                if (pairs.ContainsKey(l))
                {
                    pairs[l] = pairs[l]++;
                }
                else
                {
                    pairs.Add(l, 1);
                }
            }

            return pairs.Where(p => p.Value > 1).ToDictionary(p => p.Key, p => p.Value);
        }

        /// <summary>
        /// <see cref="IEnumerable{T}"/> から重複している要素を取り除きます。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <typeparam name="U">ラムダ式のジェネリックスクラス。</typeparam>
        /// <param name="value"><see cref="IEnumerable{T}"/> 。</param>
        /// <param name="keySelector">重複を取り除くキーを持つラムダ式。</param>
        /// <returns>重複を取り除いた <see cref="IEnumerable{T}"/> 。</returns>
        public static IEnumerable<T> Distinct<T, U>(this IEnumerable<T> value, Func<T, U> keySelector)
        {
            var seenKeys = new HashSet<U>();

            foreach (var item in value)
            {
                var key = keySelector(item);
                if (seenKeys.Add(key)) yield return item;
            }
        }

        #endregion

        #region Chunks

        /// <summary>
        /// <see cref="IEnumerable{T}"/> から指定した要素数ごとに取得します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="value"><see cref="IEnumerable{T}"/> 。</param>
        /// <param name="count">要素数。</param>
        /// <returns><see cref="IEnumerable{T}"/> の指定した数の要素。</returns>
        public static IEnumerable<IEnumerable<T>> Chunks<T>(this IEnumerable<T> value, int count)
        {
            while (value.Any())
            {
                yield return value.Take(count);
                value = value.Skip(count);
            }
        }

        #endregion

    }
}
