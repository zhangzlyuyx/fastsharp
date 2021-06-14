using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Core.Util
{
    public class SystemUtils
    {
        /// <summary>
        /// 获取计算机名称
        /// </summary>
        /// <returns></returns>
        public static string GetHostName()
        {
            return Environment.MachineName;
        }
    }
}
