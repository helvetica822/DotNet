using System.Reflection;

namespace ED.VersatilityExtensions.ReflectionExtensions
{

    /// <summary>
    /// <see cref="MemberInfo"/> の拡張機能を提供します。
    /// </summary>
    public static class MemberInfoExtensions
    {

        #region GetCustomAttributes

        /// <summary>
        /// 現在のメンバーに適用されているすべての属性 <see cref="T"/> を返します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="info"><see cref="MemberInfo"/>。</param>
        /// <returns>適用されているすべての属性 <see cref="T"/>。</returns>
        public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo info) where T : class, new() => (T[])info.GetCustomAttributes(typeof(T), true);

        /// <summary>
        /// 現在のメンバーに適用されている属性 <see cref="T"/> の最初の要素を返します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="info"><see cref="MemberInfo"/>。</param>
        /// <returns>適用されている属性 <see cref="T"/> の最初の要素。</returns>
        public static T GetCustomAttributeFirst<T>(this MemberInfo info) where T : class, new() => (T)info.GetCustomAttributes(typeof(T), true).First();

        /// <summary>
        /// 現在のメンバーに適用されている属性 <see cref="T"/> の最初の要素を返します。シーケンスに要素が含まれていない場合は既定値を返します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="info"><see cref="MemberInfo"/>。</param>
        /// <returns>適用されている属性 <see cref="T"/> の最初の要素。シーケンスに要素が含まれていない場合は既定値を返します。</returns>
        public static T? GetCustomAttributeFirstOrDefault<T>(this MemberInfo info) where T : class, new()
        {
            var attribute = info.GetCustomAttributes(typeof(T), true).FirstOrDefault();
            return (attribute is null) ? null : (T)attribute;
        }

        /// <summary>
        /// 現在のメンバーに適用されている属性 <see cref="T"/> の最後の要素を返します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="info"><see cref="MemberInfo"/>。</param>
        /// <returns>適用されている属性 <see cref="T"/> の最後の要素。</returns>
        public static T GetCustomAttributeLast<T>(this MemberInfo info) where T : class, new() => (T)info.GetCustomAttributes(typeof(T), true).Last();

        /// <summary>
        /// 現在のメンバーに適用されている属性 <see cref="T"/> の最後の要素を返します。シーケンスに要素が含まれていない場合は既定値を返します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="info"><see cref="MemberInfo"/>。</param>
        /// <returns>適用されている属性 <see cref="T"/> の最後の要素。シーケンスに要素が含まれていない場合は既定値を返します。</returns>
        public static T? GetCustomAttributeLastOrDefault<T>(this MemberInfo info) where T : class, new()
        {
            var attribute = info.GetCustomAttributes(typeof(T), true).LastOrDefault();
            return (attribute is null) ? null : (T)attribute;
        }

        /// <summary>
        /// 現在のメンバーに適用されている属性 <see cref="T"/> の指定したインデックスにある要素を返します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="info"><see cref="MemberInfo"/>。</param>
        /// <param name="index">インデックス。</param>
        /// <returns>適用されている属性 <see cref="T"/> の指定したインデックスにある要素。</returns>
        public static T GetCustomAttributeElementAt<T>(this MemberInfo info, int index) where T : class, new() => (T)info.GetCustomAttributes(typeof(T), true)[index];

        /// <summary>
        /// 現在のメンバーに適用されている属性 <see cref="T"/> の指定したインデックスにある要素を返します。シーケンスに要素が含まれていない場合は既定値を返します。
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> のジェネリックスクラス。</typeparam>
        /// <param name="info"><see cref="MemberInfo"/>。</param>
        /// <param name="index">インデックス。</param>
        /// <returns>適用されている属性 <see cref="T"/> の指定したインデックスにある要素。シーケンスに要素が含まれていない場合は既定値を返します。</returns>
        public static T? GetCustomAttributeElementAtOrDefault<T>(this MemberInfo info, int index) where T : class, new()
        {
            var attribute = info.GetCustomAttributes(typeof(T), true)[index];
            return (attribute is null) ? null : (T)attribute;
        }

        #endregion

    }
}
