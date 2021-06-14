using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Core.Util
{
    /// <summary>
    /// 反射工具类
    /// </summary>
    public class ReflectUtils
    {
        /// <summary>
        /// 获取对象属性
        /// </summary>
        /// <param name="obj"> 对象 </param>
        /// <param name="propertyName"> 属性名 </param>
        /// <returns></returns>
        public static System.Reflection.PropertyInfo GetPropertyInfo(object obj, string propertyName)
        {
            if(obj == null || string.IsNullOrEmpty(propertyName))
            {
                return null;
            }
            return obj.GetType().GetProperty(propertyName);
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"> 属性名 </param>
        /// <returns></returns>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            System.Reflection.PropertyInfo propertyInfo = GetPropertyInfo(obj, propertyName);
            if (propertyInfo == null)
            {
                return null;
            }
            return propertyInfo.GetValue(obj, null);
        }

        /// <summary>
        /// 获取成员自定义特性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"> 对象成员 </param>
        /// <returns></returns>
        public static T GetAttribute<T>(System.Reflection.MemberInfo element) where T : Attribute
        {
            if(element == null)
            {
                return null;
            }
            return Attribute.GetCustomAttribute(element, typeof(T)) as T;
        }
    }
}
