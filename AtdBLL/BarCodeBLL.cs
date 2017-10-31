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
    public class BarCodeBLL
    {
        BarCodeDAL bcdal = new BarCodeDAL();//实例化一个BCdal对象

        /// <summary>
        /// 根据条码名称模糊查询
        /// </summary>
        /// <param name="BarCodeName">条码名称</param>
        /// <returns>返回的是一个集合</returns>
        public List<ATBarCodeInfor> GetBCinfByBCname(string BarCodeName, string StationID)
        {
            return bcdal.GetBCinfByBCname(BarCodeName, StationID);
        }


        /// <summary>
        /// 根据条码ID修改条码的删除标识
        /// </summary>
        /// <param name="id">条码的ID</param>
        /// <returns>返回受影响的行</returns>
        public bool DeletBCInfByBCID(string id)
        {
            return bcdal.DeletBCInfByBCID(id) > 0 ? true : false;
        }

        //条码增加事务
        /// <summary>
        /// 条码增加事务
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="mysqlcon"></param>
        /// <param name="atbc"></param>
        /// <returns></returns>
        public bool AddAndfuzhi(int temp, string mysqlcon, ATBarCodeInfor atbc)
        {
            int r = -1; //只运行一次
            if (temp == 1)//新增
            {
                r = bcdal.AddAndfuzhi(1, mysqlcon, atbc);

            }
            else if (temp == 2)//修改
            {
                r = bcdal.UpdateBarCodeInf(atbc);
            }
            return r > 0;
        }


        /// <summary>
        /// 新增或修改条码
        /// </summary>
        /// <param name="atbc">条码对象</param>
        /// <param name="temp">标识1--新增 2--修改</param>
        /// <returns>返回的是成还是失败</returns>
        public bool SaveBarCodeInf(ATBarCodeInfor atbc, int temp)
        {
            int r = -1; //只运行一次
            if (temp == 1)//新增
            {
                //r= bcdal.AddBarCodeInf(atbc);

            }
            else if (temp == 2)//修改
            {
                r = bcdal.UpdateBarCodeInf(atbc);
            }
            return r > 0;
        }



        /// <summary>
        /// 根据删除标识去查数据库其中的一个表中所有未被删除的记录
        /// </summary>
        /// <param name="deFlag">删除标识</param>
        /// <returns>返回的是集合</returns>
        public List<ATBarCodeInfor> GetBarCodeInfByDeFlag(int deFlag, string StationID)
        {
            return bcdal.GetBarCodeInfByDeFlag(deFlag, StationID);
        }


        /// <summary>
        /// 根据ID和删除标识查对象
        /// </summary>
        /// <param name="DeFlag">条码删除标识</param>
        /// <param name="id">条码ID</param>
        /// <returns>返回的是对象</returns>
        public ATBarCodeInfor GetBCInfByBCSID(int deFlag, string id)
        {
            return bcdal.GetBCInfByBCSID(deFlag, id);
        }

        /// <summary>
        /// 根据站号ID和条码ID获取数据主体货位的选中状态和对应的零件数量
        /// </summary>
        /// <param name="StationID">站号的ID</param>
        /// <param name="BarCodeID">条码的ID</param>
        /// <returns>数据主体</returns>
        public List<string>   GetGANumAndQTY(int deFlag, string StationID)
        {
          return bcdal.GetGANumAndQTY(deFlag, StationID);
        }

        /// <summary>
        /// 将Excel条码数据导入到数据库
        /// </summary>
        /// <param name="DeFlag">未删除标志</param>
        /// <param name="dt2">Excel数据形成的临时表</param>
        public bool ExcelDaoRu(int DeFlag, DataTable dt2)
        {
            int r = -1;
            r= bcdal.ExcelDaoRu(DeFlag, dt2);
            return r > 0;
        }


    }
}
