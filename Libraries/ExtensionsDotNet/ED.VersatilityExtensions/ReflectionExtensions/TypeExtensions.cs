using System.Reflection;

namespace ED.VersatilityExtensions.ReflectionExtensions
{

    /// <summary>
    /// <see cref="Type"/> の拡張機能を提供します。
    /// </summary>
    public static class TypeExtensions
    {

        #region PropertiesName

        /// <summary>
        /// 現在の <see cref="Type"/> のすべてのパブリックプロパティ名称を返します。
        /// </summary>
        /// <param name="t"><see cref="Type"/>。</param>
        /// <returns>プロパティ名称全てのコレクション。</returns>
        public static IEnumerable<string> GetPropertiesName(this Type t)
        {
            var propertiesName = new List<string>();

            foreach (var p in t.GetProperties())
            {
                propertiesName.Add(p.Name);
            }

            return propertiesName;
        }

        #endregion

        #region GetCustomAttributes

        /// <summary>
        /// すべてのメンバーに適用されているすべての属性 <see cref="T"/> をメンバー名をキーとした <see cref="Dictionary{string, IEnumerable{T}}"/> で返します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="t"><see cref="Type"/>。</param>
        /// <returns>すべてのメンバーに適用されているすべての属性 <see cref="T"/> をメンバー名をキーとした <see cref="Dictionary{string, IEnumerable{T}}"/>。</returns>
        public static Dictionary<string, IEnumerable<T>> GetPropertiesCustomAttributesToDictionary<T>(this Type t) where T : class, new()
        {
            var dic = new Dictionary<string, IEnumerable<T>>();

            foreach(var p in t.GetProperties())
            {
                dic.Add(p.Name, p.GetCustomAttributes<T>());
            }

            return dic;
        }

        /// <summary>
        /// 指定したメンバーに適用されているすべての属性 <see cref="T"/> を返します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="t"><see cref="Type"/>。</param>
        /// <param name="propertyName">プロパティ名称。</param>
        /// <returns>適用されているすべての属性 <see cref="T"/>。</returns>
        public static IEnumerable<T>? GetPropertyCustomAttributes<T>(this Type t, string propertyName) where T : class, new() => t.GetProperty(propertyName)?.GetCustomAttributes<T>();

        /// <summary>
        /// 指定したメンバーに適用されている属性 <see cref="T"/> の最初の要素を返します。
        /// </summary>
        /// <typeparam name="T">ジェネリックスクラス。</typeparam>
        /// <param name="t"><see cref="Type"/>。</param>
        /// <param name="propertyName">プロパティ名称。</param>
        /// <returns>適用されている属性 <see cref="T"/> の最初の要素。</returns>
        public static T? GetPropertyCustomAttributeFirst<T>(this Type t, string propertyName) where T : class, new() => t.GetProperty(propertyName)?.GetCustomAttributeFirst<T>();

        /// <summary>
        /// 指定したメンバーに適用されている属性 <see cref="T"/> の最初の要素を返します。シーケンスに要素が含まれていない場合は既定値を返します。
        /// </summary>
        /// <typeparam name="T">ジェネリックスクラス。</typeparam>
        /// <param name="t"><see cref="Type"/>。</param>
        /// <param name="propertyName">プロパティ名称。</param>
        /// <returns>適用されている属性 <see cref="T"/> の最初の要素。シーケンスに要素が含まれていない場合は既定値を返します。</returns>
        public static T? GetPropertyCustomAttributeFirstOrDefault<T>(this Type t, string propertyName) where T : class, new() => t.GetProperty(propertyName)?.GetCustomAttributeFirstOrDefault<T>();

        /// <summary>
        /// 指定したメンバーに適用されている属性 <see cref="T"/> の最後の要素を返します。
        /// </summary>
        /// <typeparam name="T">ジェネリックスクラス。</typeparam>
        /// <param name="t"><see cref="Type"/>。</param>
        /// <param name="propertyName">プロパティ名称。</param>
        /// <returns>適用されている属性 <see cref="T"/> の最後の要素。</returns>
        public static T? GetPropertyCustomAttributeLast<T>(this Type t, string propertyName) where T : class, new() => t.GetProperty(propertyName)?.GetCustomAttributeLast<T>();

        /// <summary>
        /// 指定したメンバーに適用されている属性 <see cref="T"/> の最後の要素を返します。シーケンスに要素が含まれていない場合は既定値を返します。
        /// </summary>
        /// <typeparam name="T">ジェネリックスクラス。</typeparam>
        /// <param name="t"><see cref="Type"/>。</param>
        /// <param name="propertyName">プロパティ名称。</param>
        /// <returns>適用されている属性 <see cref="T"/> の最後の要素。シーケンスに要素が含まれていない場合は既定値を返します。</returns>
        public static T? GetPropertyCustomAttributeLastOrDefault<T>(this Type t, string propertyName) where T : class, new() => t.GetProperty(propertyName)?.GetCustomAttributeLastOrDefault<T>();

        /// <summary>
        /// 指定したメンバーに適用されている属性 <see cref="T"/> の指定したインデックスにある要素を返します。
        /// </summary>
        /// <typeparam name="T">ジェネリックスクラス。</typeparam>
        /// <param name="t"><see cref="Type"/>。</param>
        /// <param name="propertyName">プロパティ名称。</param>
        /// <param name="index">インデックス。</param>
        /// <returns>適用されている属性 <see cref="T"/> の指定したインデックスにある要素。</returns>
        public static T? GetPropertyCustomAttributeElementAt<T>(this Type t, string propertyName, int index) where T : class, new() => t.GetProperty(propertyName)?.GetCustomAttributeElementAt<T>(index);

        /// <summary>
        /// 指定したメンバーに適用されている属性 <see cref="T"/> の指定したインデックスにある要素を返します。シーケンスに要素が含まれていない場合は既定値を返します。
        /// </summary>
        /// <typeparam name="T">ジェネリックスクラス。</typeparam>
        /// <param name="t"><see cref="Type"/>。</param>
        /// <param name="propertyName">プロパティ名称。</param>
        /// <param name="index">インデックス。</param>
        /// <returns>適用されている属性 <see cref="T"/> の指定したインデックスにある要素。シーケンスに要素が含まれていない場合は既定値を返します。</returns>
        public static T? GetPropertyCustomAttributeElementAtOrDefault<T>(this Type t, string propertyName, int index) where T : class, new() => t.GetProperty(propertyName)?.GetCustomAttributeElementAtOrDefault<T>(index);

        #endregion

        #region GetBackingField

        /// <summary>
        /// 指定したプロパティのバッキングフィールドを取得します。
        /// </summary>
        /// <param name="t"><see cref="Type"/>。</param>
        /// <param name="propertyName">プロパティ名。</param>
        /// <returns>バッキングフィールドの <see cref="FieldInfo"/>。</returns>
        public static FieldInfo? GetBackingField(this Type t, string propertyName)
        {
            var firstCharacter = propertyName[0].ToString().ToLower();
            var fieldName = $"_{firstCharacter}{new string(propertyName.ToCharArray(1, propertyName.Length - 1))}";
            return t.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
        }

        #endregion

    }
}
