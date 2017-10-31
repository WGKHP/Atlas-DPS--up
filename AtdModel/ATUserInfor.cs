using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atd.Model
{
   public  class ATUserInfor
    {
       /* USE[cangkudDB]
       GO

SELECT[UserID]
      ,[UserName]
      ,[LoginUserName]
      ,[UserPwd]
      ,[LastLoginTime]
      ,[DelFlag]
      ,[LoginIP]
        FROM[dbo].[ATUserInfor]
        GO*/


        private int _UserID; //用户ID字段
        public int UserID //用户ID属性
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private string _UserName;//用户名字段
        public string UserName//用户名属性
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _LoginUserName;//用户名登录名字段
        public string LoginUserName//用户名登录名属性
        {
            get { return _LoginUserName; }
            set { _LoginUserName = value; }
        }
        private string _UserPwd;
        public  string UserPwd
        {
            get { return _UserPwd; }
            set { _UserPwd = value; }
        }
        private DateTime _LastLoginTime;
        public DateTime LastLoginTime
        {
            get { return _LastLoginTime; }
            set { _LastLoginTime = value; }
        }
        private string _LoginIP;
        public string LoginIP
        {
            get { return _LoginIP; }
            set { _LoginIP = value; }
        }
        private int _DelFlag;
        public int DelFlag
        {
            get { return _DelFlag; }
            set { _DelFlag = value; }
        }      
    }
}
