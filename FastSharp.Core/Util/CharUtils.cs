using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Core.Util
{
    public class CharUtils
    {
        /// <summary>
        /// 字符-空格
        /// </summary>
        public static readonly char CHAR_SPACE = ' ';

        /// <summary>
        /// 字符-制表符
        /// </summary>
        public static readonly char CHAR_TAB = (char)System.ConsoleKey.Tab;

        /// <summary>
        /// 是否为空白字符
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsBlankChar(char c)
        {
            return char.IsWhiteSpace(c) || c == CHAR_SPACE || c == '\ufeff' || c == '\u202a';
        }
    }
}
