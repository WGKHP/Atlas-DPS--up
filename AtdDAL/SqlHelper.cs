using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Data;
using System.Xml.Linq;
using System.Xml;
using System.Net;

namespace Atd.DAL
{

    public class SqlHelper
    {
        
                
        //"Data Source = WG ; Initial Catalog = cangkuDB; Integrated Security = True"
        //连接数据库
        // public static string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\AtlasDPS\\cangkudDB.mdf;Integrated Security=True;Connect Timeout=30";
        //public static string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\C# TEST\\Atlas DPS\\AtdUI\\bin\\x86\\Debug\\cangkudDB.mdf;Integrated Security=True;Connect Timeout=30";
        //public static string str ;
       static string sss()
        {
            string sc = GetHostName.gethostname();
            //string HostName = Dns.GetHostName();
            //sc = "Data Source =" + HostName + " ; Initial Catalog = cangkuDB; Integrated Security = True";
            return sc;
        }

       static string str =sss();//连接字符串
       


        /// <summary>
        /// 增删改都可以
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句中的参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExcuteNonQuery(string sql, params SqlParameter[] ps)
        {
           
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 查询首行首列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">参数</param>
        /// <returns>首行首列object</returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 查询的
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] ps)
        {
            SqlConnection conn = new SqlConnection(str);
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }

                try
                {
                    conn.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 查询的是一个表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句中的参数</param>
        /// <returns>返回的是一个表</returns>
        public static DataTable ExecuteTable(string sql, params SqlParameter[] ps)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, str))
            {
                if (ps != null)
                {
                    sda.SelectCommand.Parameters.AddRange(ps);
                }

                sda.Fill(dt);
            }
            return dt;
        }

    }
}
