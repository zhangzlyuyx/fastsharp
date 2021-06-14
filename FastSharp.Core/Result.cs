using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Core
{
    /// <summary>
    /// 泛型通用结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Result<T>
    {
        /// <summary>
        /// 成功代码
        /// </summary>
        public static readonly string CODE_SUCCESS = "success";
        /// <summary>
        /// 错误代码
        /// </summary>
        public static readonly string CODE_ERROR = "error";
        /// <summary>
        /// 拒绝代码
        /// </summary>
        public static readonly string CODE_DENIED = "denied";
        /// <summary>
        /// 成功状态
        /// </summary>
        public static readonly int STATUS_SUCCESS = 200;
        /// <summary>
        /// 错误状态
        /// </summary>
        public static readonly int STATUS_ERROR = 400;
        /// <summary>
        /// 拒绝状态
        /// </summary>
        public static readonly int STATUS_DENIED = 401;

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 警告信息
        /// </summary>
        public string Warning { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        public Result()
        {
            this.Success(string.Empty);
        }

        public Result(bool code, String msg)
        {
            if (code)
            {
                this.Success(msg);
            }
            else
            {
                this.Error(msg);
            }
        }

        public Result(bool code, String msg, T data)
        {
            if (code)
            {
                this.Success(msg, data);
            }
            else
            {
                this.Error(msg, data);
            }
        }

        public Result(bool code, String msg, T data, string warning)
        {
            if (code)
            {
                this.Success(msg, data);
            }
            else
            {
                this.Error(msg, data);
            }
            this.Warning = warning;
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess
        {
            get { return this.Code == CODE_SUCCESS; }
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Result<T> Error(string msg)
        {
            this.Code = CODE_ERROR;
            this.Status = STATUS_ERROR;
            this.Msg = msg;
            return this;
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Result<T> Error(string msg, T data)
        {
            this.Code = CODE_ERROR;
            this.Status = STATUS_ERROR;
            this.Msg = msg;
            this.Data = data;
            return this;
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Result<T> Success(string msg)
        {
            this.Code = CODE_SUCCESS;
            this.Status = STATUS_SUCCESS;
            this.Msg = msg;
            return this;
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Result<T> Success(string msg, T data)
        {
            this.Code = CODE_SUCCESS;
            this.Status = STATUS_SUCCESS;
            this.Msg = msg;
            this.Data = data;
            return this;
        }
    }
}
