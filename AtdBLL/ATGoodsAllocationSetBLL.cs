using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atd.DAL;
using Atd.Model;
using System.Data;

namespace Atd.BLL
{
  public  class ATGoodsAllocationSetBLL
    {

        GoodsAllocationSetDAL dal = new GoodsAllocationSetDAL();

        /// <summary>
        /// 根据文本框输入的信息模糊查询货位信息
        /// </summary>
        /// <param name="text">输入的查询的关键字</param>
        /// <returns>返回的是一个集合</returns>
        public List<ATGoodsALLocationInforSET> GetGAinfByreachText(string text)
        {
            return dal.GetGAinfByreachText(text);
        }

        /// <summary>
        /// 根据ID修改货位的删除标识
        /// </summary>
        /// <param name="id">货位的id</param>
        /// <returns>受影响的行数</returns>
        public bool DeleGASByGASID(string id)
        {
            return dal.DeleGASByGASID(id) > 0 ? true : false;
        }

        /// <summary>
        /// 新增或修货位
        /// </summary>
        /// <param name="atga">货位对象</param>
        /// <param name="temp">标识 1--新增 2--修改</param>
        /// <returns>返回的是成功还是失败</returns>
        public bool SaveGASInfo(ATGoodsALLocationInforSET atga , int temp)
        {
            int r = -1; //每次只能执行一种操作
            if (temp == 1)//新增
            {
                r = dal.AddGASInfByGASinf(atga);
            }
            else if (temp == 2)//修改
            {
                r = dal.UpdateGASInfByGASinf(atga);
            }
            return r > 0;
        }


        /// <summary>
        /// 根据站的ID查对象
        /// </summary>
        /// <param name="id">站的ID</param>
        /// <returns>站的对象</returns>
        public ATGoodsALLocationInforSET GetGASInforByGASID(int deFlag, string id)
        {
            return dal.GetGASInforByGASID(deFlag, id);
        }


        /// <summary>
        /// 根据删除标识去查询所有未删除的货位号
        /// </summary>
        /// <param name="deFlag">删除标识 0--==没有删
        public List<ATGoodsALLocationInforSET> GetGoodsAllocationInfByDeFlag(int DeFlag)
        {
            return dal.GetGoodsAllocationInfByDeFlag(DeFlag);
        }


        /// <summary>
        /// 根据删除标识去查询所有未删除的货位号
        /// </summary>
        /// <param name="deFlag">删除标识 0--==没有删
        public List<ATGoodsALLocationInforSET> GetGoodsAllocationInfByDeFlag2(int DeFlag)
        {
            return dal.GetGoodsAllocationInfByDeFlag2(DeFlag);
        }


        public bool  AddAndfuzhi(string StationID, string BarCodeID, List<ATGoodsALLocationInforSET> atgas)
        {
            int r = -1;
           
                   r= dal.AddAndfuzhi(StationID, BarCodeID, atgas);
           

            return r >0; 
        }

        /// <summary>
        /// 更新关联货位
        /// </summary>
        /// <param name="atbc"></param>
        /// <returns>返回成功与否</returns>
        public bool updateGAS(string StationID, string BarCodeID, List<ATGoodsALLocationInforSET> atgas)
        {
            int r = -1;           
                r = dal.updateGAS(StationID, BarCodeID, atgas);
           
            return r > 0;

        }

        /// <summary>
        /// 将总货位excel表导入数据库
        /// </summary>
        /// <param name="dt2">需要提供DataTable</param>
        /// <returns>返回值</returns>
        public bool InPutAllGAByExcel(DataTable dt2)
        {

            int r = -1;
            r = dal.InPutAllGAByExcel(dt2);
            return r > 0;
        }

        /// <summary>
        /// EXCEL 导入对应条码货位指派 操作
        /// </summary>
        /// <param name="StationID">站ID</param>
        /// <param name="BarCodeID">所选条码ID</param>
        /// <param name="SelectStates">货指派状态0-没有指派 ， 1-已经指派</param>
        /// <param name="dt2">提供的DataTable条件</param>
        /// <returns>返回成功与否</returns>
        public bool InPutBCAndGARelByExcel(string StationID, string BarCodeID, int SelectStates, DataTable dt2)
        {
            int r = -1;
            r = dal.InPutBCAndGARelByExcel( StationID,BarCodeID,SelectStates,dt2);
            return r > 0;
        }


        /// <summary>
        /// 根据站和条码的ID查货位指派的信息,返回的是一个集合
        /// </summary>
        /// <param name="StationID">站的ID</param>
        /// <param name="BarCodeID">条码的ID</param>
        /// <returns>返回值是集合</returns>
        public List<ATGoodsALLocationInforSET> GetGAStatesAndQTYInf(string StationID, string BarCodeID)
        {
            return dal.GetGAStatesAndQTYInf(StationID, BarCodeID);
        }

    }
}
