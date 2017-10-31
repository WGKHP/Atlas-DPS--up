using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atd.DAL;
using Atd.Model;

namespace Atd.BLL
{
   public  class StationBLL
    {

        StationDAL dal = new StationDAL();

        /// <summary>
        /// 根据搜索条件去查站的信息
        /// </summary>
        /// <param name="text">搜索条件</param>
        /// <returns>返回的是一个集合</returns>
        public List<ATStationSetInfor> GetSTinfBytext(string text)
        {
            return dal.GetSTinfBytext(text);
        }

        /// <summary>
        /// 获取站的号和名称
        /// </summary>
        /// <param name="deFlag"></param>
        /// <returns></returns>
        public List<ATStationSetInfor> GetStationInforByDeFlag2(int deFlag)
        {
            return dal.GetStationInforByDeFlag2(deFlag);
        }

        
        /// <summary>
        /// 根据ID修改站的删除标识
        /// </summary>
        /// <param name="id">站的id</param>
        /// <returns>受影响的行数</returns>
        public bool DeleStaBySatID(string  id)
        {
           return  dal.DeleStaBySatID(id) > 0 ? true : false;
        }


        /// <summary>
        /// 新增或修改站
        /// </summary>
        /// <param name="atsa">站对象</param>
        /// <param name="temp">标识 1--新增 2--修改</param>
        /// <returns>返回的是成功还是失败</returns>
        public bool SaveStatInfo(ATStationSetInfor atsa,int temp)
        {
            int r = -1; //每次只能执行一种操作
            if (temp==1)//新增
            {
                r=dal.AddSatInfBysatinf(atsa);
            }
            else if (temp==2)//修改
            {
                r=dal.UpdateSatInfBysatinf(atsa);
            }
            return r > 0;
        }

        /// <summary>
        /// 根据删除标识去查询所有未删除的站
        /// </summary>
        /// <param name="deFlag">删除标识 0--==没有删除，1--删除</param>
        /// <returns>返回的所有的站的集合</returns>
        public List<ATStationSetInfor> GetStationInforByDeFlag(int deFlag)
        {
            return dal.GetStationInforByDeFlag(deFlag);
        }
        /// <summary>
        /// 根据站的ID查对象
        /// </summary>
        /// <param name="id">站的ID</param>
        /// <returns>站的对象</returns>
        public ATStationSetInfor GetStationInforByStationID(int deFlag,string id)
        {
            return dal.GetStationInforByStationID(deFlag, id);
        }
    }
}
