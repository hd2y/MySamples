using System;
using System.Linq;
// ReSharper disable MemberCanBePrivate.Global

namespace MyBlog.Infrastructure.Core.Extensions
{
    /// <summary>
    /// 泛型类型扩展方法
    /// </summary>
    public static class GenericTypeExtensions
    {
        /// <summary>
        /// 获取泛型类型名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetGenericTypeName(this Type type)
        {
            var typeName = string.Empty;

            if (type.IsGenericType)
            {
                var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());
                typeName = $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
            }
            else
            {
                typeName = type.Name;
            }

            return typeName;
        }

        /// <summary>
        /// 获取泛型类型名
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetGenericTypeName(this object obj)
        {
            return obj.GetType().GetGenericTypeName();
        }
    }
}