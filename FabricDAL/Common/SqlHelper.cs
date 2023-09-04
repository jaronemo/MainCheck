using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FabricCommon;
using Npgsql;


namespace FabricDAL
{
    class SqlHelper
    {
        private static string connStr = GetDecryptedConnectionString();

        private static string GetDecryptedConnectionString()
        {
            string encryptedDbAddress = System.Configuration.ConfigurationManager.AppSettings["DatabaseDatasource"];
            string encryptedDbName = System.Configuration.ConfigurationManager.AppSettings["DatabaseName"];
            string encryptedDbUserName = System.Configuration.ConfigurationManager.AppSettings["DatabaseUsername"];
            string encryptedDbPasswd = System.Configuration.ConfigurationManager.AppSettings["DatabasePassword"];

            // 檢查並去除ENC_前綴
            encryptedDbAddress = encryptedDbAddress.StartsWith("ENC_") ? encryptedDbAddress.Substring(4) : encryptedDbAddress;
            encryptedDbName = encryptedDbName.StartsWith("ENC_") ? encryptedDbName.Substring(4) : encryptedDbName;
            encryptedDbUserName = encryptedDbUserName.StartsWith("ENC_") ? encryptedDbUserName.Substring(4) : encryptedDbUserName;
            encryptedDbPasswd = encryptedDbPasswd.StartsWith("ENC_") ? encryptedDbPasswd.Substring(4) : encryptedDbPasswd;

            // 進行解密
            string dbAddress = EncryptionHelper.Decrypt(encryptedDbAddress);
            string dbName = EncryptionHelper.Decrypt(encryptedDbName);
            string dbUserName = EncryptionHelper.Decrypt(encryptedDbUserName);
            string dbPasswd = EncryptionHelper.Decrypt(encryptedDbPasswd);

            return String.Format("Server={0};Username={1};Password={2};Database={3};Client Encoding=UTF8;", dbAddress, dbUserName, dbPasswd, dbName);
        }

       /* private static string connStr = String.Format("Server={0};Username={1};Password={2};Database={3};Client Encoding=UTF8;",
            System.Configuration.ConfigurationManager.AppSettings["DatabaseDatasource"],
            System.Configuration.ConfigurationManager.AppSettings["DatabaseUsername"],
            System.Configuration.ConfigurationManager.AppSettings["DatabasePassword"],
            System.Configuration.ConfigurationManager.AppSettings["DatabaseName"]);*/
        static NpgsqlConnection conn;

        #region 公共查询代码，返回DataSet，表为0.需要捕获异常,无需关闭连接
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sqlStr">要执行的SQL查询语句</param>
        /// <returns>返回DataSet</returns>
        public static DataSet Query(string sqlStr)
        {
            DataSet dataSet = new DataSet();
            try
            {
                conn = new NpgsqlConnection(connStr);
                conn.Open();

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sqlStr, conn);
                dataAdapter.Fill(dataSet);
                conn.Close();
            }
            catch (Exception exp)
            {
                conn.Close();
                throw new Exception("資料庫錯誤: " + exp.Message);
            }
            return dataSet;
        }
        public static DataSet Query(string sqlStr, NpgsqlParameter[] parameters = null)
        {
            DataSet dataSet = new DataSet();
            try
            {
                conn = new NpgsqlConnection(connStr);
                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand(sqlStr, conn);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                // Add the parameters to the command object
                /* foreach (NpgsqlParameter parameter in parameters)
                 {
                     command.Parameters.Add(parameter);
                 }*/

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
                dataAdapter.Fill(dataSet);
                conn.Close();
            }
            catch (Exception exp)
            {
                conn.Close();
                throw new Exception("資料庫錯誤: " + exp.Message);
            }
            return dataSet;
        }
        #endregion

        #region 公共执行非查询代码，需捕获异常，返回值为受影响行数，无需关闭连接
        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="sqlStr">要执行的非查询SQL语句</param>
        /// <returns>int返回受影响行数</returns>
        public static int Execute(string sqlStr)
        {
            int effectedRowCount = 0;
            try
            {
                conn = new NpgsqlConnection(connStr);
                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand(sqlStr, conn);
                effectedRowCount = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exp)
            {
                conn.Close();
                throw new Exception("数据库错误: " + exp.Message);
            }
            return effectedRowCount;
        }
        #endregion
        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="sqlStr">要执行的非查询SQL语句</param>
        /// <returns>int返回受影响行数</returns>
        /*public static int Execute(string sqlStr)
        {
            int effectedRowCount = 0;
            try
            {
                conn = new NpgsqlConnection(connStr);
                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand(sqlStr, conn);
                effectedRowCount = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exp)
            {
                conn.Close();
                throw new Exception("数据库错误: " + exp.Message);
            }
            return effectedRowCount;
        }*/

        public static int Execute(string sqlStr, NpgsqlParameter[] parameters)
        {
            int effectedRowCount = 0;
            try
            {
                conn = new NpgsqlConnection(connStr);
                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand(sqlStr, conn);
                foreach (NpgsqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                effectedRowCount = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exp)
            {
                conn.Close();
                throw new Exception("資料庫錯誤：: " + exp.Message);
            }
            return effectedRowCount;
        }

        #region ExecuteScalar Method
        /// <summary>
        /// 执行查询语句，返回查询结果的第一行的第一列的值
        /// </summary>
        /// <param name="sqlStr">要执行的SQL查询语句</param>
        /// <param name="parameters">查询参数</param>
        /// <returns>返回查询结果的第一行的第一列的值</returns>
        public static object ExecuteScalar(string sqlStr, NpgsqlParameter[] parameters = null)
        {
            object result = null;
            try
            {
                conn = new NpgsqlConnection(connStr);
                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand(sqlStr, conn);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                result = command.ExecuteScalar();
                conn.Close();
            }
            catch (Exception exp)
            {
                conn.Close();
                throw new Exception("資料庫錯誤: " + exp.Message);
            }
            return result;
        }
        #endregion

    }
}
