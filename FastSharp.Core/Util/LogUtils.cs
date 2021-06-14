using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Core.Util
{
    /// <summary>
    /// 日志工具类
    /// </summary>
    public class LogUtils
    {
        public static void Error(Type type, string s, params object[] args)
        {
            System.Diagnostics.Trace.TraceError(s, args);
        }

        public static void Error(Type type, string s, Exception e, params object[] args)
        {
            System.Diagnostics.Trace.TraceError(s, args);
        }
    }
}
