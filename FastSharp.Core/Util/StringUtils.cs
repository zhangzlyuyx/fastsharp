using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Core.Util
{
    /// <summary>
    /// 字符串工具类
    /// </summary>
    public class StringUtils
    {
        /// <summary>
        /// 空字符
        /// </summary>
        public static readonly string STRING_EMPTY = string.Empty;
        /// <summary>
        /// 空JSON
        /// </summary>
        public static readonly string STRING_EMPTY_JSON = "{}";
        /// <summary>
        /// SPACE 空格
        /// </summary>
        public static readonly string STRING_SPACE = " ";
        /// <summary>
        /// TAB制表符
        /// </summary>
        public static readonly string STRING_TAB = "   ";
        /// <summary>
        /// 10个数字
        /// </summary>
        public static readonly string STRING_NUMBERS = "0123456789";
        /// <summary>
        /// 26个字母
        /// </summary>
        public static readonly string STRING_LETTERS = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// 是否为空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(string str)
        {
            return str == null || str.Length == 0;
        }

        /// <summary>
        /// 是否为非空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(string str)
        {
            return !IsEmpty(str);
        }

        /// <summary>
        /// 是否为空白字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBlank(string str)
        {
            int length;

            if (str == null || ((length = str.Length) == 0))
            {
                return true;
            }

            for (int i = 0; i < length; i++)
            {
                // 只要有一个非空字符即为非空字符串
                if (false == CharUtils.IsBlankChar(str[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 判断是否为非空白字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotBlank(string str)
        {
            return !IsBlank(str);
        }

        /// <summary>
        /// 去除首位空白字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Trim(string str)
        {
            return str == null ? null : str.Trim();
        }

        /// <summary>
        /// 去除头部空白符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimStart(string str)
        {
            return str == null ? null : str.TrimStart();
        }

        /// <summary>
        /// 去除前缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="trimChars"></param>
        /// <returns></returns>
        public static string TrimStart(string str, params char[] trimChars)
        {
            return str == null ? null : str.TrimStart(trimChars);
        }

        /// <summary>
        /// 去除尾部空白符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimEnd(string str)
        {
            return str == null ? null : str.TrimEnd();
        }

        /// <summary>
        /// 去除后缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="trimChars"></param>
        /// <returns></returns>
        public static string TrimEnd(string str, params char[] trimChars)
        {
            return str == null ? null : str.TrimEnd(trimChars);
        }

        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Format(string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// 分隔字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="separator">分隔符</param>
        /// <param name="removeEmptyEntries">是否移除空元素</param>
        /// <returns></returns>
        public static string[] Split(string str, string separator, bool removeEmptyEntries)
        {
            if(str == null || str.Length == 0)
            {
                return new string[] { };
            }
            return str.Split(separator.ToCharArray(), removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }

        /// <summary>
        /// 连接字符
        /// </summary>
        /// <param name="separator"> 分隔符 </param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string Join(string separator, params string[] values)
        {
            return string.Join(separator, values);
        }

        /// <summary>
        /// 随机GUID
        /// </summary>
        /// <returns></returns>
        public static string RandomGuid()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 随机字符串
        /// </summary>
        /// <param name="baseStr"> 随机字符选取的样本 </param>
        /// <param name="length"> 字符串的长度 </param>
        /// <returns></returns>
        public static string RandomString(string baseStr, int length)
        {
            StringBuilder sb = new StringBuilder();
            if (length < 1)
            {
                length = 1;
            }
            int baseLength = baseStr.Length;
            for (int i = 0; i < length; i++)
            {
                int number = new Random(Guid.NewGuid().GetHashCode()).Next(0, baseLength - 1);
                sb.Append(baseStr[number]);
            }
            return sb.ToString();
        }
    }
}
