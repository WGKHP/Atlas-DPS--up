using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atd.DAL;
using Atd.Model;

namespace Atd.BLL
{
   public class ATUserInforBLL
    {
        ATUserInforDAL dal = new ATUserInforDAL();

        public bool Islongin (string loginName,string loginPwd,out string msg)
        {
            bool flag = false;
            ATUserInfor user = dal.IsLonginByLoginName(loginName);

           if (user!=null)
            {
                if (loginPwd==user.UserPwd)
                {
                    flag = true;
                    msg = "登录成功";
                }
                else
                {
                    msg = "登录失败,请检查密码";
                }
            }
           else
            {
                msg = "账号不存在";
            }
            return flag;
        }
    }
}
