using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atd.Model;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;


namespace Atd.DAL
{
    public class ATUserInforDAL
    {



      //SqlectionStringBuilder scsb = new SqlConnectionStringBuilder();

        //查是否登录成功
        //判断用户是否登录成功
        /// <summary>
        /// 该方法是根据账号去去数据库查询，返回的是对象
        /// </summary>
        /// <param name="loginName">登录的账号</param>
        /// <returns>ATUserInfor对象</returns>
        public ATUserInfor IsLonginByLoginName(string loginName)
        {
            string sql = "select *from ATUserInfor where LoginUserName=@LoginUserName";
           DataTable dt =  SqlHelper.ExecuteTable(sql, new SqlParameter("@LoginUserName", loginName));
            ATUserInfor user = null;
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                     user = RowToATUserInfor(dr);
                }
            }
            return user;
        }

       //关系转对象
        private ATUserInfor RowToATUserInfor(DataRow dr)
        {
            ATUserInfor user = new ATUserInfor();
            user.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            user.LoginIP = dr["LoginIP"].ToString();
          //  user.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
            user.LoginUserName = dr["LoginUserName"].ToString();
            user.UserPwd = dr["UserPwd"].ToString();
            user.UserID = Convert.ToInt32(dr["UserID"]);
            user.UserName = dr["UserName"].ToString();
            return user;
        }
    }
}
