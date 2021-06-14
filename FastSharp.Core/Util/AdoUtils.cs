using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Core.Util
{
    /// <summary>
    /// ADO.NET 工具类
    /// </summary>
    public class AdoUtils
    {
        public static string ERROR_INVALIDATE_CONNECTION = "无效的数据库连接!";

        public static string ERROR_INVALIDATE_TRANSACTION = "无效的数据库事务!";

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <param name="connection"> 数据库连接 </param>
        /// <returns></returns>
        public static Result<System.Data.IDbConnection> OpenConnection(System.Data.IDbConnection connection)
        {
            if (connection == null)
            {
                return new Result<System.Data.IDbConnection>(false, ERROR_INVALIDATE_CONNECTION);
            }
            try
            {
                //直接打开状态
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    return new Result<System.Data.IDbConnection>(true, string.Empty, connection);
                }
                //执行打开
                connection.Open();
                return new Result<System.Data.IDbConnection>(true, string.Empty, connection);
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(AdoUtils), ex.Message, ex);
                return new Result<System.Data.IDbConnection>(false, ex.Message, connection);
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="connection"> 数据库连接 </param>
        /// <returns></returns>
        public static Result<System.Data.IDbConnection> CloseConnection(System.Data.IDbConnection connection)
        {
            if (connection == null)
            {
                return new Result<System.Data.IDbConnection>(false, ERROR_INVALIDATE_CONNECTION);
            }
            try
            {
                //直接关闭状态
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    return new Result<System.Data.IDbConnection>(true, string.Empty, connection);
                }
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    return new Result<System.Data.IDbConnection>(true, string.Empty, connection);
                }
                return new Result<System.Data.IDbConnection>(true, string.Empty, connection);
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(AdoUtils), ex.Message, ex);
                return new Result<System.Data.IDbConnection>(false, ex.Message, connection);
            }
        }

        /// <summary>
        /// 开始数据库事务
        /// </summary>
        /// <param name="connection"> 数据库连接 </param>
        /// <param name="level"> 事务级别 </param>
        /// <returns></returns>
        public static Result<System.Data.IDbTransaction> BeginTransaction(System.Data.IDbConnection connection, System.Data.IsolationLevel? level = null)
        {
            if (connection == null)
            {
                return new Result<System.Data.IDbTransaction>(false, ERROR_INVALIDATE_TRANSACTION);
            }
            System.Data.IDbTransaction transaction = null;
            try
            {
                //打开事务
                transaction = level != null ? connection.BeginTransaction(level.Value) : connection.BeginTransaction();

                return new Result<System.Data.IDbTransaction>(true, string.Empty, transaction);
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(AdoUtils), ex.Message, ex);
                return new Result<System.Data.IDbTransaction>(false, ex.Message, transaction);
            }
        }

        /// <summary>
        /// 提交数据库事务
        /// </summary>
        /// <param name="transaction"> 数据库事务 </param>
        /// <returns></returns>
        public static Result<System.Data.IDbTransaction> CommitTransaction(System.Data.IDbTransaction transaction)
        {
            if (transaction == null)
            {
                return new Result<System.Data.IDbTransaction>(false, ERROR_INVALIDATE_TRANSACTION);
            }
            try
            {
                transaction.Commit();
                return new Result<System.Data.IDbTransaction>(true, string.Empty, transaction);
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(AdoUtils), ex.Message, ex);
                return new Result<System.Data.IDbTransaction>(false, ex.Message, transaction);
            }
        }

        /// <summary>
        /// 回滚数据库事务
        /// </summary>
        /// <param name="transaction"> 数据库事务 </param>
        /// <returns></returns>
        public static Result<System.Data.IDbTransaction> RollbackTransaction(System.Data.IDbTransaction transaction)
        {
            if (transaction == null)
            {
                return new Result<System.Data.IDbTransaction>(false, ERROR_INVALIDATE_TRANSACTION);
            }
            try
            {
                transaction.Rollback();
                return new Result<System.Data.IDbTransaction>(true, string.Empty, transaction);
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(AdoUtils), ex.Message, ex);
                return new Result<System.Data.IDbTransaction>(false, ex.Message, transaction);
            }
        }

        /// <summary>
        /// 创建数据库命令
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static System.Data.IDbCommand CreateCommand(System.Data.IDbConnection connection, System.Data.IDbTransaction transaction, int? commandTimeout, System.Data.CommandType? commandType, string commandText, params System.Data.IDbDataParameter[] parameters)
        {
            System.Data.IDbCommand command = connection.CreateCommand();
            //命令事务
            command.Transaction = transaction;
            //命令类型
            if (commandType != null)
            {
                command.CommandType = commandType.Value;
            }
            //命令文本
            command.CommandText = commandText;
            //命令参数
            if (parameters != null && parameters.Length > 0)
            {
                foreach (System.Data.IDbDataParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            //命令超时
            if (commandTimeout != null)
            {
                command.CommandTimeout = commandTimeout.Value;
            }
            return command;
        }

        /// <summary>
        /// 执行SQL语句返回受影响行数
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Result<int> ExecuteNonQuery(System.Data.IDbConnection connection, System.Data.IDbTransaction transaction, int? commandTimeout, System.Data.CommandType? commandType, string commandText, params System.Data.IDbDataParameter[] parameters)
        {
            try
            {
                using (System.Data.IDbCommand command = CreateCommand(connection, transaction, commandTimeout, commandType, commandText, parameters))
                {
                    //执行命令
                    int value = command.ExecuteNonQuery();
                    return new Result<int>(true, string.Empty, value);
                }
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(AdoUtils), ex.Message, ex);
                return new Result<int>(false, ex.Message);
            }
        }

        /// <summary>
        /// 执行SQL查询，返回结果集的第一行的第一列
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Result<object> ExecuteScalar(System.Data.IDbConnection connection, System.Data.IDbTransaction transaction, int? commandTimeout, System.Data.CommandType? commandType, string commandText, params System.Data.IDbDataParameter[] parameters)
        {
            try
            {
                using (System.Data.IDbCommand command = CreateCommand(connection, transaction, commandTimeout, commandType, commandText, parameters))
                {
                    //执行命令
                    object value = command.ExecuteScalar();
                    return new Result<object>(true, string.Empty, value);
                }
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(AdoUtils), ex.Message, ex);
                return new Result<object>(false, ex.Message);
            }
        }

        /// <summary>
        /// 执行SQL只进流读取
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Result<System.Data.IDataReader> ExecuteReader(System.Data.IDbConnection connection, System.Data.IDbTransaction transaction, int? commandTimeout, System.Data.CommandType? commandType, string commandText, params System.Data.IDbDataParameter[] parameters)
        {
            try
            {
                using (System.Data.IDbCommand command = CreateCommand(connection, transaction, commandTimeout, commandType, commandText, parameters))
                {
                    //执行命令
                    System.Data.IDataReader value = command.ExecuteReader();
                    return new Result<System.Data.IDataReader>(true, string.Empty, value);
                }
            }
            catch (Exception ex)
            {
                LogUtils.Error(typeof(AdoUtils), ex.Message, ex);
                return new Result<System.Data.IDataReader>(false, ex.Message);
            }
        }

        /// <summary>
        /// 填充DataSet数据集
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="adapter"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Result<System.Data.DataSet> FillDataSet(System.Data.IDbConnection connection, System.Data.IDbTransaction transaction, System.Data.IDbDataAdapter adapter, int? commandTimeout, System.Data.CommandType? commandType, string commandText, params System.Data.IDbDataParameter[] parameters)
        {
            System.Data.DataSet dataSet = new System.Data.DataSet();
            try
            {
                adapter.SelectCommand = CreateCommand(connection, transaction, commandTimeout, commandType, commandText, parameters);
                adapter.Fill(dataSet);
                return new Result<System.Data.DataSet>(true, string.Empty, dataSet);
            }
            catch (Exception ex)
            {
                using (dataSet) { }
                LogUtils.Error(typeof(AdoUtils), ex.Message, ex);
                return new Result<System.Data.DataSet>(false, ex.Message);
            } 
        }

        /// <summary>
        /// 填充DataTable数据集
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="adapter"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Result<System.Data.DataTable> FillDataTable(System.Data.IDbConnection connection, System.Data.IDbTransaction transaction, System.Data.IDbDataAdapter adapter, int? commandTimeout, System.Data.CommandType? commandType, string commandText, params System.Data.IDbDataParameter[] parameters)
        {
            System.Data.DataSet dataSet = new System.Data.DataSet();
            try
            {
                adapter.SelectCommand = CreateCommand(connection, transaction, commandTimeout, commandType, commandText, parameters);
                adapter.Fill(dataSet);
                if(dataSet.Tables.Count > 0)
                {
                    return new Result<System.Data.DataTable>(true, string.Empty, dataSet.Tables[0]);
                }
                else
                {
                    return new Result<System.Data.DataTable>(false, "填充数据集失败!");
                }
            }
            catch (Exception ex)
            {
                using (dataSet) { }
                LogUtils.Error(typeof(AdoUtils), ex.Message, ex);
                return new Result<System.Data.DataTable>(false, ex.Message);
            }
        }
    }
}
