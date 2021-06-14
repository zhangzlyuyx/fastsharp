using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Core.Util
{
    /// <summary>
    /// 转换工具类
    /// </summary>
    public class ConvertUtils
    {
        /// <summary>
        /// 转换为整数
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"> 默认值 </param>
        /// <returns></returns>
        public static int ToInt(string str, int defaultValue = 0)
        {
            int? value = ToIntNullable(str);
            return value != null ? value.Value : defaultValue;
        }

        /// <summary>
        /// 转换为可空整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? ToIntNullable(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            int value;
            if(int.TryParse(str, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 转换为长整型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"> 默认值 </param>
        /// <returns></returns>
        public static long ToLong(string str, long defaultValue = 0L)
        {
            long? value = ToLongNullable(str);
            return value != null ? value.Value : defaultValue;
        }

        /// <summary>
        /// 转换为可空长整型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long? ToLongNullable(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            long value;
            if(long.TryParse(str, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 转换为浮点型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ToDouble(string str, double defaultValue)
        {
            double? value = ToDoubleNullable(str);
            return value != null ? value.Value : defaultValue;
        }

        /// <summary>
        /// 转换可空浮点型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double? ToDoubleNullable(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            double value;
            if (double.TryParse(str, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 转换为数值型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"> 默认值 </param>
        /// <returns></returns>
        public static decimal ToDecimal(string str, decimal defaultValue)
        {
            decimal? value = ToDecimalNullable(str);
            return value != null ? value.Value : defaultValue;
        }

        /// <summary>
        /// 转换为可空数值型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal? ToDecimalNullable(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            decimal value;
            if (decimal.TryParse(str, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 数值型转换为字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static string ToString(decimal value, int? decimals = null)
        {
            if(decimals == null)
            {
                return value.ToString();
            }
            if(decimals.Value < 0)
            {
                decimals = 0;
            }
            return Round(value, decimals.Value, true).ToString();
        }

        /// <summary>
        /// 转换为布尔值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ToBoolean(string str, bool defaultValue)
        {
            bool? value = ToBooleanNullable(str);
            return value != null ? value.Value : defaultValue;
        }

        /// <summary>
        /// 转换为可空布尔型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool? ToBooleanNullable(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            if (str.Equals("1"))
            {
                return true;
            }
            bool value;
            if (bool.TryParse(str, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 转换为时间类型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string str, DateTime defaultValue)
        {
            DateTime? value = ToDateTimeNullable(str);
            return value != null ? value.Value : defaultValue;
        }

        /// <summary>
        /// 转换为可空时间类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNullable(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            DateTime value;
            if (DateTime.TryParseExact(str, DateUtils.DATETIME_FORMAT, null, System.Globalization.DateTimeStyles.None, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 数值四舍五入
        /// </summary>
        /// <param name="inputValue"> 输入值 </param>
        /// <param name="decimals"> 小数点位数</param>
        /// <param name="allowZero"> 是否允许输出零(true允许false不允许,返回0.1的decimals的幂) </param>
        /// <returns></returns>
        public static decimal Round(decimal inputValue, int decimals, bool allowZero = true)
        {
            decimal outputValue = decimal.Round(inputValue, decimals, MidpointRounding.AwayFromZero);
            if (inputValue != decimal.Zero && outputValue == decimal.Zero && !allowZero)
            {
                return (decimal)Math.Pow(0.1, decimals);
            }
            else
            {
                return outputValue;
            }
        }

        /// <summary>
        /// 字节数组转十六进制文本
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="separator"> 分隔符 </param>
        /// <returns></returns>
        public static string BytesToHex(byte[] bytes, string separator = " ")
        {
            if(bytes == null || bytes.Length == 0)
            {
                return string.Empty;
            }
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i > 0)
                {
                    str.Append(separator);
                }
                str.Append(bytes[i].ToString("X2"));
            }
            return str.ToString();
        }

        /// <summary>
        /// 十六进制文本转字节数组
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static byte[] HexToBytes(string hex, string separator = " ")
        {
            if (string.IsNullOrEmpty(hex))
            {
                return new byte[] { };
            }
            if (string.IsNullOrEmpty(separator))
            {
                byte[] buffer = new byte[hex.Length / 2];
                for (int i = 0; i < hex.Length; i += 2)
                {
                    buffer[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                }
                return buffer;
            }
            else
            {
                string[] strs = hex.Split(separator.ToCharArray());
                byte[] buffer = new byte[strs.Length];
                for (int i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = Convert.ToByte(strs[i], 16);
                }
                return buffer;
            }
        }

        /// <summary>
        /// 结构体对象转换成字节数组
        /// </summary>
        /// <typeparam name="T"> 结构体类型 </typeparam>
        /// <param name="structure"> 结构体对象 </param>
        /// <returns></returns>
        public static byte[] StructToBytes<T>(T structure) where T : struct
        {
            //  获取对象的非托管大小（以字节为单位）。
            int size = System.Runtime.InteropServices.Marshal.SizeOf(structure);
            //  通过使用指定的字节数，从进程的非托管内存中分配内存。
            IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(size);
            //  将数据从托管对象封送到非托管内存块。
            System.Runtime.InteropServices.Marshal.StructureToPtr(structure, ptr, false);
            //  定义指定大小的的一维数组
            byte[] buffer = new byte[size];
            //  将非托管内存指针数据复制到一维数组中。
            System.Runtime.InteropServices.Marshal.Copy(ptr, buffer, 0, size);
            //  释放以前从进程的非托管内存中分配的内存。
            System.Runtime.InteropServices.Marshal.FreeHGlobal(ptr);
            //  返回 byte 数组
            return buffer;
        }

        /// <summary>
        /// 将字节数组转换成结构体对象
        /// </summary>
        /// <typeparam name="T"> 结构体类型 </typeparam>
        /// <param name="source"> 字节数组 </param>
        /// <returns></returns>
        public static Result<T> BytesToStruct<T>(byte[] source) where T : struct
        {
            if(source == null || source.Length == 0)
            {
                return new Result<T>(true, "", default(T));
            }
            //  获取对象的非托管大小（以字节为单位）。
            int size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
            //  分配的内存指针。
            IntPtr ptr = IntPtr.Zero;
            try
            {
                //  通过使用指定的字节数，从进程的非托管内存中分配内存。
                ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(size);
                //  将一维的托管 8 位无符号整数数组中的数据复制到非托管内存指针。
                System.Runtime.InteropServices.Marshal.Copy(source, 0, ptr, source.Length);
                //  将数据从非托管内存块封送到新分配的指定类型的托管对象。
                object obj = (T)System.Runtime.InteropServices.Marshal.PtrToStructure(ptr, typeof(T));
                //  验证对象类型
                if (obj != null && obj is T)
                {
                    //  返回结构体对象
                    return new Result<T>(true, string.Empty, (T)obj);
                }
                else
                {
                    return new Result<T>(false, "", default(T));
                }
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(ConvertUtils), ex.Message, ex);
                return new Result<T>(false, ex.Message, default(T));
            }
            finally
            {
                //  释放以前从进程的非托管内存中分配的内存。
                if(ptr != IntPtr.Zero)
                {
                    System.Runtime.InteropServices.Marshal.FreeHGlobal(ptr);
                }
            }
        }

        /// <summary>
        /// 二进制序列化
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Result<System.IO.Stream> BinarySerialize(System.IO.Stream stream, object obj)
        {
            if(stream == null)
            {
                stream = new System.IO.MemoryStream();
            }
            try
            {
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize(stream, obj);
                return new Result<System.IO.Stream>(true, "", stream);
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(ConvertUtils), ex.Message, ex);
                return new Result<System.IO.Stream>(false, ex.Message);
            }
        }

        /// <summary>
        /// 二进制反序列化
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Result<object> BinaryDeserialize(System.IO.Stream stream)
        {
            try
            {
                object obj = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Deserialize(stream);
                return new Result<object>(true, "", obj);
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(ConvertUtils), ex.Message, ex);
                return new Result<object>(false, ex.Message);
            }
        }

        /// <summary>
        /// 二进制序列化克隆
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Result<object> BinaryClone(object obj)
        {
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                //序列化
                var retSer = BinarySerialize(stream, obj);
                if (!retSer.IsSuccess)
                {
                    return new Result<object>(false, retSer.Msg);
                }
                retSer.Data.Seek(0, System.IO.SeekOrigin.Begin);
                //反序列化
                var retDes = BinaryDeserialize(retSer.Data);
                if (!retDes.IsSuccess)
                {
                    return new Result<object>(false, retDes.Msg);
                }
                return new Result<object>(true, "", retDes.Data);
            }
        }

        /// <summary>
        /// XML 序列化
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Result<System.IO.Stream> XmlSerialize(System.IO.Stream stream, object obj)
        {
            if (stream == null)
            {
                stream = new System.IO.MemoryStream();
            }
            try
            {
                new System.Xml.Serialization.XmlSerializer(obj.GetType()).Serialize(stream, obj);
                return new Result<System.IO.Stream>(true, "", stream);
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(ConvertUtils), ex.Message, ex);
                return new Result<System.IO.Stream>(false, ex.Message);
            }
        }

        /// <summary>
        /// XML 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Result<object> XmlDeserialize(System.IO.Stream stream, Type type)
        {
            try
            {
                object obj = new System.Xml.Serialization.XmlSerializer(type).Deserialize(stream);
                return new Result<object>(true, string.Empty, obj);
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(ConvertUtils), ex.Message, ex);
                return new Result<object>(false, ex.Message);
            }
        }

        /// <summary>
        /// XML 序列化克隆
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Result<object> XmlClone(object obj)
        {
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                //序列化
                var retSer = XmlSerialize(stream, obj);
                if (!retSer.IsSuccess)
                {
                    return new Result<object>(false, retSer.Msg);
                }
                retSer.Data.Seek(0, System.IO.SeekOrigin.Begin);
                //反序列化
                var retDes = XmlDeserialize(retSer.Data, obj.GetType());
                if (!retDes.IsSuccess)
                {
                    return new Result<object>(false, retDes.Msg);
                }
                return new Result<object>(true, "", retDes.Data);
            }
        }
    }
}
