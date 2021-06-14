using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Core.Util
{
    /// <summary>
    /// 加密工具类
    /// </summary>
    public class CryptoUtils
    {
        public static Encoding DEFAULT_ENCODING = Encoding.UTF8;

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string EncodeMd5(string data)
        {
            byte[] bytes = DEFAULT_ENCODING.GetBytes(data);
            return EncodeMd5(bytes);
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string EncodeMd5(byte[] data)
        {
            if(data == null)
            {
                return null;
            }
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hash = md5.ComputeHash(data);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string EncodeMd5(System.IO.Stream stream)
        {
            if(stream == null)
            {
                return null;
            }
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string EncodeMd5(System.IO.FileInfo file)
        {
            if(file == null || !file.Exists)
            {
                return null;
            }
            using (System.IO.Stream stream = new System.IO.FileStream(file.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                return EncodeMd5(stream);
            }
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string EncodeSha1(string data)
        {
            byte[] bytes = DEFAULT_ENCODING.GetBytes(data);
            return EncodeSha1(bytes);
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string EncodeSha1(byte[] data)
        {
            if (data == null)
            {
                return null;
            }
            using (System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create())
            {
                byte[] hash = sha1.ComputeHash(data);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string EncodeSha1(System.IO.Stream stream)
        {
            if(stream == null)
            {
                return null;
            }
            using (System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create())
            {
                byte[] hash = sha1.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string EncodeSha256(string data)
        {
            byte[] bytes = DEFAULT_ENCODING.GetBytes(data);
            return EncodeSha256(bytes);
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string EncodeSha256(byte[] data)
        {
            if (data == null)
            {
                return null;
            }
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(data);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string EncodeSha256(System.IO.Stream stream)
        {
            if (stream == null)
            {
                return null;
            }
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
