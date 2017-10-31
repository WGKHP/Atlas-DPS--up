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
    public class StationDAL
    {
        /// <summary>
        /// 根据搜索条件去查站的信息
        /// </summary>
        /// <param name="text">搜索条件</param>
        /// <returns>返回的是一个集合</returns>
        public List<ATStationSetInfor> GetSTinfBytext(string text)
        {
            string sql = "select * from ATStationSeting where DeFlag=0 and (StationNum like @text or StationName like @text)";
            List<ATStationSetInfor> listst = new List<ATStationSetInfor>();
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@text","%"+ text+"%"));
            if (dt.Rows.Count>0)
            {
                int count = 1;
                foreach (DataRow dr  in dt.Rows)
                {
                    ATStationSetInfor atst = RowToATStationSetInfor(dr);
                    atst.StationCount = count.ToString();
                    listst.Add(atst);
                    count++;  
                }
            }
            return listst;
        }





        /// <summary>
        /// 根据ID修改站的删除标识
        /// </summary>
        /// <param name="id">站的id</param>
        /// <returns>受影响的行数</returns>
        public int  DeleStaBySatID(string  id)
        {
            string sql = "update ATStationSeting set DeFlag=1 where StationID = @StationID ";
            return SqlHelper.ExcuteNonQuery(sql,new SqlParameter("@StationID", id));
        }

/// <summary>
///对数据库进行增加站操作
/// </summary>
/// <param name="atsa">对象</param>
/// <returns>返回</returns>

        // 新增
        public int AddSatInfBysatinf(ATStationSetInfor atsa)
        {
            string sql = "insert into ATStationSeting (StationID,StationNum,StationName,StationIP,StationMac,DeFlag,CreatDateTime,Stationbeizhu) values (@StationID,@StationNum,@StationName,@StationIP,@StationMac,@DeFlag,getdate(),@Stationbeizhu)";
            return AddandUpdateSatInf(1, sql, atsa);
        }
        //修改
        public int UpdateSatInfBysatinf(ATStationSetInfor atsa)
        {
            string sql = "update ATStationSeting set StationNum = @StationNum,StationName = @StationName,StationIP = @StationIP,StationMac = @StationMac,UpDateTime = getdate() ,Stationbeizhu=@Stationbeizhu where StationID = @StationID";
            return AddandUpdateSatInf(2, sql, atsa);
        }

        private int AddandUpdateSatInf(int temp, string sql,ATStationSetInfor atsa )
        {

            SqlParameter[] ps =
           {    new SqlParameter("@StationNum",atsa.StationNum),
                new SqlParameter("@StationName",atsa.StationName),
                new SqlParameter("@StationIP",atsa.StationIP),
                new SqlParameter("@StationMac",atsa.StationMac),
                new SqlParameter("@Stationbeizhu",atsa.Stationbeizhu)
            };
            List<SqlParameter> list = new List<SqlParameter>();
            list.AddRange(ps);
            if (temp==1)//增加
            {
                list.Add(new SqlParameter("@DeFlag", atsa.DeFlag));
                list.Add(new SqlParameter("@StationID", atsa.StationID));
                //list.Add(new SqlParameter("@CreatDateTime", atsa.CreatDateTime));
            }
            else if (temp==2)//修改
            {
                list.Add(new SqlParameter("@StationID", atsa.StationID));
                //list.Add(new SqlParameter("@UpDateTime", atsa.UpDateTime));
            }
            return SqlHelper.ExcuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 根据删除标识去查询所有未删除的站
        /// </summary>
        /// <param name="deFlag">删除标识 0--==没有删除，1--删除</param>
        /// <returns>返回的所有的站的集合</returns>
       public List<ATStationSetInfor> GetStationInforByDeFlag(int deFlag)
        {
           string sql = "select * from ATStationSeting where DeFlag=@DeFlag order by StationNum";
           DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag", deFlag));//用封装好的查表方法 去查询数据库 行成一个临时表
            List<ATStationSetInfor> list = new List<ATStationSetInfor>();//实例化一个集合
            if (dt.Rows.Count>0)//判断表中是否有值
            {
                int count = 1;
                foreach (DataRow dr in dt.Rows) //遍历表的每一行
                {
                    ATStationSetInfor AT = RowToATStationSetInfor(dr);
                    AT.StationCount = count.ToString();
                    list.Add(AT); //将对象添加到集合中
                    count++;
                }
            }
            return list;
        }

        /// <summary>
        /// 获取站的号和名称
        /// </summary>
        /// <param name="deFlag"></param>
        /// <returns></returns>
        public List<ATStationSetInfor> GetStationInforByDeFlag2(int deFlag)
        {
            string sql = "select * from ATStationSeting where DeFlag=@DeFlag order by StationNum";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag", deFlag));//用封装好的查表方法 去查询数据库 行成一个临时表
            List<ATStationSetInfor> list = new List<ATStationSetInfor>();//实例化一个集合
            if (dt.Rows.Count > 0)//判断表中是否有值
            {
               int count = 1;
                foreach (DataRow dr in dt.Rows) //遍历表的每一行
                {
                    ATStationSetInfor AT = RowToATStationSetInfor(dr);
                    AT.StationCount = count.ToString();
                    list.Add(AT); //将对象添加到集合中
                    count++;
                }
            }
            return list;
        }


        ATStationSetInfor ATs= new ATStationSetInfor();


        /// <summary>
        /// 根据站的ID查对象
        /// </summary>
        /// <param name="id">站的ID</param>
        /// <returns>站的对象</returns>
        public ATStationSetInfor GetStationInforByStationID(int deFlag, string  id)
        {
            string sql = "select * from ATStationSeting  where DeFlag=@DeFlag and StationID=@id";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag", deFlag), new SqlParameter("@id", id));
            ATStationSetInfor atss = null;
            if (dt.Rows.Count>0)
            {
                atss = RowToATStationSetInfor(dt.Rows[0]);
            }
            return atss;
        }
        //关系转对象
        private ATStationSetInfor RowToATStationSetInfor(DataRow dr)
        {

            ATStationSetInfor AT = new ATStationSetInfor();//实例化
            AT.StationName = dr["StationName"].ToString();
            AT.StationID = dr["StationID"].ToString();
            AT.StationNum = Convert.ToInt16(dr["StationNum"]);
            AT.StationIP = dr["StationIP"].ToString();//给属性赋值
            AT.StationMac = dr["StationMac"].ToString();
            AT.Stationbeizhu = dr["Stationbeizhu"].ToString();
            if (dr["CreatDateTime"].ToString() != "")
            {
                AT.CreatDateTime = Convert.ToDateTime(dr["CreatDateTime"]);
            }
            if (dr["UpDateTime"].ToString() != "")
            {
                AT.UpDateTime = Convert.ToDateTime(dr["UpDateTime"]);
            }
            AT.DeFlag = Convert.ToInt32(dr["DeFlag"]);
            return AT;
        }

    }
}
