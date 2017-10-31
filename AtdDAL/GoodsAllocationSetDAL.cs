using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using Atd.Model;

namespace Atd.DAL
{
    public class GoodsAllocationSetDAL
    {

        //获取主机名称
        static string gethostname()
        {
            string hostname = GetHostName.gethostname();
            return hostname;
        }
        static string str = gethostname(); //全局连接字符串

        /// <summary>
        /// 根据文本框输入的信息模糊查询总货位信息
        /// </summary>
        /// <param name="text">输入的查询的关键字</param>
        /// <returns>返回的是一个集合</returns>
        public List<ATGoodsALLocationInforSET> GetGAinfByreachText(string text)
        {
            string sql = "select * from ATGoodsAllocation where DeFlag=0 and (GoodsCode like @text or GoodsAllocationNum like @text or GoodsAllocationName like @text)";
            List<ATGoodsALLocationInforSET> listga = new List<ATGoodsALLocationInforSET>();
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@text", "%" + text + "%"));
            if (dt.Rows.Count>0)
            {
                int count = 1;  //行的序号
                foreach (DataRow dr in dt.Rows)
                {
                    ATGoodsALLocationInforSET atgas = RowToATGoodsALLocationInforSET(dr);
                    atgas.GoodsAlllocationCount = count;
                    listga.Add(atgas);
                    count++;
                }
            }
            return listga;
        }

        //EXCEL 导入对应条码货位指派事务 操作
        /// <summary>
        /// EXCEL 导入对应条码货位指派事务 操作
        /// </summary>
        /// <param name="StationID">站ID</param>
        /// <param name="BarCodeID">所选条码ID</param>
        /// <param name="SelectStates">货指派状态0-没有指派 ， 1-已经指派</param>
        /// <param name="dt2">提供的DataTable条件</param>
        /// <returns>返回成功与否</returns>
        public int InPutBCAndGARelByExcel(string StationID,string BarCodeID, int SelectStates, DataTable dt2)
        {
            int r = -1;
           // string str = "Data Source = WG; Initial Catalog = cangkuDB; Integrated Security = True";//连到sql server 服务器里面的数据库
            //string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\AtlasDPS\\cangkudDB.mdf;Integrated Security=True;Connect Timeout=30";//数据库移植用
            SqlConnection myConnection = new SqlConnection(str);//新建到sqlserver一个数据库的连接实例
            myConnection.Open();//打开连接
            SqlCommand myCommand = myConnection.CreateCommand();
            SqlTransaction myTrans;
            // Start a local transaction
            myTrans = myConnection.BeginTransaction();
            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            myCommand.Connection = myConnection;
            myCommand.Transaction = myTrans;
            try
            {
                if (SelectStates==0)//如果没有指派就执行新增指派操作
                {
                    for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        myCommand.CommandText = "insert into ATSaveGoodsAllocationNum(SaveGAid,SaveGoodsAllocationNum,SaveGoodsCode,SaveGoodsAllocationName,SaveGoodsAllocationPartsQTY,DeFlag2,SelectStates) values ('" + dt2.Rows[i]["SaveGAid"] + "' ," + dt2.Rows[i]["SaveGoodsAllocationNum"] + " , '" + dt2.Rows[i]["SaveGoodsCode"] + "','" + dt2.Rows[i]["SaveGoodsAllocationName"] + "'," + dt2.Rows[i]["SaveGoodsAllocationPartsQTY"] + "," + dt2.Rows[i]["DeFlag2"] + "," + Convert.ToInt16(dt2.Rows[i]["SelectStates"]).ToString() + ")";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "insert into ATGASBRe(StationID,BarCodeID,SaveGAid) values ('" + StationID + "','" + BarCodeID + "','" + dt2.Rows[i]["SaveGAid"] + "')";
                     r= myCommand.ExecuteNonQuery();  
                    }
                    myCommand.CommandText = "update ATBarCode SET GAReStates=1 where BarCodeID = '" + BarCodeID + "'";
                    myCommand.ExecuteNonQuery();
                }

                if (SelectStates==1)//如果已经指派就执行更新操作
                {
                    myCommand.CommandText = "select * from ATGASBRe where StationID='" + StationID + "'and BarCodeID='" + BarCodeID + "'";
                    myCommand.ExecuteNonQuery();
                    DataTable dt = SqlHelper.ExecuteTable(myCommand.CommandText, new SqlParameter("@StationID", StationID), new SqlParameter("@BarCodeID", BarCodeID));
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            myCommand.CommandText = "delete from ATSaveGoodsAllocationNum where SaveGAid='" + dt.Rows[i]["SaveGAid"] + "'";
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    myCommand.CommandText = "delete from ATGASBRe where StationID='" + StationID + "'and BarCodeID='" + BarCodeID + "'";
                    myCommand.ExecuteNonQuery();
                   for  (int i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        myCommand.CommandText = "insert into ATSaveGoodsAllocationNum(SaveGAid,SaveGoodsAllocationNum,SaveGoodsCode,SaveGoodsAllocationName,SaveGoodsAllocationPartsQTY,DeFlag2,SelectStates) values ('" + dt2.Rows[i]["SaveGAid"] + "' ," + dt2.Rows[i]["SaveGoodsAllocationNum"] + " , '" + dt2.Rows[i]["SaveGoodsCode"] + "','" + dt2.Rows[i]["SaveGoodsAllocationName"] + "'," + dt2.Rows[i]["SaveGoodsAllocationPartsQTY"] + "," + dt2.Rows[i]["DeFlag2"] + "," + Convert.ToInt16(dt2.Rows[i]["SelectStates"]).ToString() + ")";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "insert into ATGASBRe(StationID,BarCodeID,SaveGAid) values ('" + StationID + "','" + BarCodeID + "','" + dt2.Rows[i]["SaveGAid"] + "')";
                        r = myCommand.ExecuteNonQuery();
                    }
                    myCommand.CommandText = "update ATBarCode SET GAReStates=1 where BarCodeID = '" + BarCodeID + "'";
                    myCommand.ExecuteNonQuery();
                }
             myTrans.Commit();//提交事务
            }
            catch (Exception e)
            {
                r = -1;
                try
                {
                    myTrans.Rollback();
                }
                catch (SqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                                          " was encountered while attempting to roll back the transaction.");
                    }
                }
                Console.WriteLine("An exception of type " + e.GetType() +
                                  " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
            }
            finally
            {
                myConnection.Close();
            }

            return r;
      }

        //EXCEL 导入总货位 操作
        /// <summary>
        /// 将总货位excel表导入数据库事务
        /// </summary>
        /// <param name="dt2">需要提供DataTable</param>
        /// <returns>返回值</returns>
        public int InPutAllGAByExcel (DataTable dt2)
        {
            int r = -1;
            //string str = "Data Source = WG; Initial Catalog = cangkuDB; Integrated Security = True";//连到sql server 服务器里面的数据库  
            //string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\AtlasDPS\\cangkudDB.mdf;Integrated Security=True;Connect Timeout=30";//数据库移植用
            SqlConnection myConnection = new SqlConnection(str);//新建到sqlserver一个数据库的连接实例
            myConnection.Open();//打开连接
            SqlCommand myCommand = myConnection.CreateCommand();
            SqlTransaction myTrans;
            myTrans = myConnection.BeginTransaction();
            myCommand.Connection = myConnection;
            myCommand.Transaction = myTrans;
            try
            {
                myCommand.CommandText = "delete from ATGoodsAllocation";
                myCommand.ExecuteNonQuery();
                for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                {
                     myCommand.CommandText = "insert into ATGoodsAllocation(GoodsAllocationID,GoodsAllocationNum,GoodsCode,GoodsAllocationName,GAPartsCount,DeFlag,CreatDateTime,GoodsAllocationbeizhu) values ('" + dt2.Rows[i]["GoodsAllocationID"] + "','" + dt2.Rows[i]["GoodsAllocationNum"] + "','" + dt2.Rows[i]["GoodsCode"].ToString() + "','"+ dt2.Rows[i]["GoodsAllocationName"] +"',"+ dt2.Rows[i]["GAPartsCount"] + ", " + dt2.Rows[i]["DeFlag"] + ",getdate(),'" + dt2.Rows[i]["GoodsAllocationbeizhu"] + "')";
                 r = myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
            }
            catch (Exception e)
            {
                r = -1;
                try
                {
                    myTrans.Rollback();
                }
                catch (SqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                                          " was encountered while attempting to roll back the transaction.");
                    }
                }
                Console.WriteLine("An exception of type " + e.GetType() +
                                 " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
            }
            finally
            {
                myConnection.Close();
            }
            return r;
        }

        //货位增加事务
        /// <summary>
        /// 条码货位关联事务
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="mysqlcon"></param>
        /// <param name="atbc"></param>
        /// <returns></returns>
        public int AddAndfuzhi(string StationID, string BarCodeID, List<ATGoodsALLocationInforSET> atgas)
        {
            int r = -1;
            //string str = "Data Source = WG; Initial Catalog = cangkuDB; Integrated Security = True";//连到sql server 服务器里面的数据库
            //string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\AtlasDPS\\cangkudDB.mdf;Integrated Security=True;Connect Timeout=30";//数据库移植用
            SqlConnection myConnection = new SqlConnection(str);//新建到sqlserver一个数据库的连接实例
            myConnection.Open();//打开连接
            SqlCommand myCommand = myConnection.CreateCommand();
            SqlTransaction myTrans;
            // Start a local transaction
            myTrans = myConnection.BeginTransaction();
            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            myCommand.Connection = myConnection;
            myCommand.Transaction = myTrans;
            try
            {

                //myCommand.CommandText = "insert into ATSaveGoodsAllocationNum(SaveGAid,SaveGoodsAllocationNum,SaveGoodsAllocationName,SaveGoodsAllocationPartsQTY,DeFlag2,SelectStates) values ('" + atgas.SaveGAid + "' ," + atgas.SaveGoodsAllocationNum + " , '" + atgas.SaveGoodsAllocationName + "',"+atgas.SaveGoodsAllocationPartsQTY+"," + atgas.DeFlag2 + ","+Convert.ToInt16(atgas.SelectStates).ToString()+")";
                //myCommand.ExecuteNonQuery();
                //myCommand.CommandText = "insert into ATGASBRe(StationID,BarCodeID,SaveGAid) values ('" + atgas.StationID + "','" + atgas.BarCodeID + "','" + atgas.SaveGAid + "')";
                //myCommand.ExecuteNonQuery();
                //myCommand.CommandText = "update ATBarCode SET GAReStates=1 where BarCodeID = '"+atgas.BarCodeID +"'";
                //myCommand.ExecuteNonQuery();
                foreach (var item in atgas)
                {
                    myCommand.CommandText = "insert into ATSaveGoodsAllocationNum(SaveGAid,SaveGoodsAllocationNum,SaveGoodsCode,SaveGoodsAllocationName,SaveGoodsAllocationPartsQTY,DeFlag2,SelectStates) values ('" + item.SaveGAid + "' ," + item.SaveGoodsAllocationNum + " , '"+ item.SaveGoodsCode +"','" + item.SaveGoodsAllocationName + "'," + item.SaveGoodsAllocationPartsQTY + "," + item.DeFlag2 + "," + Convert.ToInt16(item.SelectStates).ToString() + ")";
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = "insert into ATGASBRe(StationID,BarCodeID,SaveGAid) values ('" + item.StationID + "','" + item.BarCodeID + "','" + item.SaveGAid + "')";
                    r = myCommand.ExecuteNonQuery();
                }
                myCommand.CommandText = "update ATBarCode SET GAReStates=1 where BarCodeID = '" + BarCodeID + "'";
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                // Console.WriteLine("Both records are written to database.");
            }
            catch (Exception e)
            {
                r = -1;
                try
                {
                    myTrans.Rollback();
                }
                catch (SqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                                          " was encountered while attempting to roll back the transaction.");
                    }
                }
                Console.WriteLine("An exception of type " + e.GetType() +
                                  " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
            }
            finally
            {
                myConnection.Close();
            }

            return r;
        }

        /// <summary>
        /// 条码更新关联货位事务
        /// </summary>
        /// <param name="atbc"></param>
        /// <returns>返回成功与否</returns>
        public int updateGAS(string StationID, string BarCodeID, List<ATGoodsALLocationInforSET> atgas)
        {
            int r = -1;
            //string str = "Data Source = WG; Initial Catalog = cangkuDB; Integrated Security = True";//连到sql server 服务器里面的数据库
            //string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\AtlasDPS\\cangkudDB.mdf;Integrated Security=True;Connect Timeout=30";//数据库移植用
            SqlConnection myConnection = new SqlConnection(str);//新建到sqlserver一个数据库的连接实例
            myConnection.Open();//打开连接
            SqlCommand myCommand = myConnection.CreateCommand();
            SqlTransaction myTrans;
            // Start a local transaction
            myTrans = myConnection.BeginTransaction();
            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            myCommand.Connection = myConnection;
            myCommand.Transaction = myTrans;
            try
            {
                myCommand.CommandText = "select * from ATGASBRe where StationID='" + StationID + "'and BarCodeID='" + BarCodeID + "'";
                myCommand.ExecuteNonQuery();
                DataTable dt = SqlHelper.ExecuteTable(myCommand.CommandText, new SqlParameter("@StationID", StationID), new SqlParameter("@BarCodeID", BarCodeID));
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        myCommand.CommandText = "delete from ATSaveGoodsAllocationNum where SaveGAid='" + dt.Rows[i]["SaveGAid"] + "'";
                        myCommand.ExecuteNonQuery();
                    }
                }
                myCommand.CommandText = "delete from ATGASBRe where StationID='" + StationID + "'and BarCodeID='" + BarCodeID + "'";
                myCommand.ExecuteNonQuery();
                foreach (var item in atgas)
                {
                    myCommand.CommandText = "insert into ATSaveGoodsAllocationNum(SaveGAid,SaveGoodsAllocationNum,SaveGoodsCode,SaveGoodsAllocationName,SaveGoodsAllocationPartsQTY,DeFlag2,SelectStates) values ('" + item.SaveGAid + "' ," + item.SaveGoodsAllocationNum + " , '" + item.SaveGoodsCode +"', '" + item.SaveGoodsAllocationName + "'," + item.SaveGoodsAllocationPartsQTY + "," + item.DeFlag2 + "," + Convert.ToInt16(item.SelectStates).ToString() + ")";
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = "insert into ATGASBRe(StationID,BarCodeID,SaveGAid) values ('" + item.StationID + "','" + item.BarCodeID + "','" + item.SaveGAid + "')";
                  r = myCommand.ExecuteNonQuery();
                }
                myCommand.CommandText = "update ATBarCode SET GAReStates=1 where BarCodeID = '" + BarCodeID + "'";
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                // Console.WriteLine("Both records are written to database.");
            }

            catch (Exception e)
            {
                r = -1;
                try
                {
                    myTrans.Rollback();
                }
                catch (SqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                                          " was encountered while attempting to roll back the transaction.");
                    }
                }
                Console.WriteLine("An exception of type " + e.GetType() +
                                  " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");

            }
            finally
            {
                myConnection.Close();
            }
            return r;
        }

        /// <summary>
        /// 根据站和条码的ID查货位指派的信息,返回的是一个集合
        /// </summary>
        /// <param name="StationID">站的ID</param>
        /// <param name="BarCodeID">条码的ID</param>
        /// <returns>返回值是集合</returns>
        public List<ATGoodsALLocationInforSET> GetGAStatesAndQTYInf(string StationID, string BarCodeID)
        {
            string sql = " select  b.SaveGAid,b.SaveGoodsAllocationNum,b.SaveGoodsCode,b.SaveGoodsAllocationName,b.SaveGoodsAllocationPartsQTY,b.DeFlag2,b.SelectStates  from ATGASBRe as m join  ATSaveGoodsAllocationNum as b on m.SaveGAid=b.SaveGAid join ATStationSeting as s on m.StationID=s.StationID join ATBarCode as c on m.BarCodeID=c.BarCodeID where s.StationID='" + StationID + "'and c.BarCodeID='" + BarCodeID + "'";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@StationID", StationID), new SqlParameter("@BarCodeID", BarCodeID));
            List<ATGoodsALLocationInforSET> listGAS = new List<ATGoodsALLocationInforSET>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ATGoodsALLocationInforSET atgass = RowToATGoodsALLocationInforSET2(dr);
                    listGAS.Add(atgass);
                }
            }
            return listGAS;
        }

        /// <summary>
        /// 根据ID修改货位的删除标识
        /// </summary>
        /// <param name="id">货位的id</param>
        /// <returns>受影响的行数</returns>
        public int DeleGASByGASID(string id)
        {
            string sql = "update ATGoodsAllocation set DeFlag=1 where GoodsAllocationID = @GoodsAllocationID ";
            return SqlHelper.ExcuteNonQuery(sql, new SqlParameter("@GoodsAllocationID", id));
        }

        /// <summary>
        ///对数据库进行增加货位操作
        /// </summary>
        /// <param name="atsa">对象</param>
        /// <returns>返回</returns>

        //新增总货位用
        public int AddGASInfByGASinf(ATGoodsALLocationInforSET atga)
        {
            string sql = "insert into ATGoodsAllocation (GoodsAllocationID,GoodsAllocationNum,GoodsCode,GoodsAllocationName,GAPartsCount,DeFlag,CreatDateTime,GoodsAllocationbeizhu) values (@GoodsAllocationID,@GoodsAllocationNum,@GoodsCode,@GoodsAllocationName,@GAPartsCount,@DeFlag,getdate(),@GoodsAllocationbeizhu)";
            return AddAndUpdateGAInf(1, sql, atga);
        }
        //修改总货位用
        public int UpdateGASInfByGASinf(ATGoodsALLocationInforSET atga)
        {
            string sql = "update ATGoodsAllocation set GoodsAllocationNum = @GoodsAllocationNum,GoodsCode = @GoodsCode,GoodsAllocationName = @GoodsAllocationName,GAPartsCount = GAPartsCount,UpDateTime = getdate(),GoodsAllocationbeizhu=@GoodsAllocationbeizhu where GoodsAllocationID = @GoodsAllocationID";
            return AddAndUpdateGAInf(2, sql, atga);
        }

        //更新总货位用的
        private int AddAndUpdateGAInf(int temp, string sql, ATGoodsALLocationInforSET atga)
        {
            SqlParameter[] ps =
            {
                new SqlParameter("@GoodsAllocationNum",atga.GoodsAllocationNum),
                new SqlParameter("@GoodsCode",atga.GoodsCode),
                new SqlParameter("@GoodsAllocationName",atga.GoodsAllocationName),
                new SqlParameter("@GAPartsCount",atga.GAPartsCount),
                new SqlParameter("@GoodsAllocationbeizhu",atga.GoodsAllocationbeizhu)
            };
            List<SqlParameter> list = new List<SqlParameter>();
            list.AddRange(ps);
            if (temp == 1)//增加
            {
                list.Add(new SqlParameter("@DeFlag", atga.DeFlag));
                list.Add(new SqlParameter("@GoodsAllocationID", atga.GoodsAllocationID));
                //list.Add(new SqlParameter("@CreatDateTime", atsa.CreatDateTime));
            }
            else if (temp == 2)//修改
            {
                list.Add(new SqlParameter("@GoodsAllocationID", atga.GoodsAllocationID));
                //list.Add(new SqlParameter("@UpDateTime", atsa.UpDateTime));
            }
            return SqlHelper.ExcuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 根据删除标识去查询所有未删除的货位号
        /// </summary>
        /// <param name="deFlag">删除标识 0--==没有删除，1--删除</param>
        /// <returns>返回的所有货位号的集合</returns>
        public List<ATGoodsALLocationInforSET> GetGoodsAllocationInfByDeFlag2(int DeFlag)
        {
            string sql = "select * from ATGoodsAllocation where DeFlag=@DeFlag order by GoodsAllocationNum";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag", DeFlag));
            List<ATGoodsALLocationInforSET> list = new List<ATGoodsALLocationInforSET>();
            if (dt.Rows.Count > 0)
            {
                int count = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    ATGoodsALLocationInforSET atg = RowToATGoodsALLocationInforSET(dr);
                    atg.GoodsAlllocationCount = Convert.ToInt32(count);
                    list.Add(atg);
                    count++;
                }
            }
            return list;
        }

        /// <summary>
        /// 根据删除标识去查询所有未删除的货位号
        /// </summary>
        /// <param name="deFlag">删除标识 0--==没有删除，1--删除</param>
        /// <returns>返回的所有货位号的集合</returns>
        public List<ATGoodsALLocationInforSET> GetGoodsAllocationInfByDeFlag(int DeFlag)
        {
            string sql = "select * from ATGoodsAllocation where DeFlag=@DeFlag order by GoodsAllocationNum";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag", DeFlag));
            List<ATGoodsALLocationInforSET> list = new List<ATGoodsALLocationInforSET>();
            if (dt.Rows.Count > 0)
            {
                int count = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    ATGoodsALLocationInforSET atg = RowToATGoodsALLocationInforSET(dr);
                    atg.GoodsAlllocationCount = Convert.ToInt32(count);
                    list.Add(atg);
                    count++;
                }
            }
            return list;
        }

        /// <summary>
        /// 根据站的ID查对象
        /// </summary>
        /// <param name="id">站的ID</param>
        /// <returns>站的对象</returns>
        public ATGoodsALLocationInforSET GetGASInforByGASID(int deFlag, string id)
        {
            string sql = "select * from ATGoodsAllocation  where DeFlag=@DeFlag and GoodsAllocationID=@id";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag", deFlag), new SqlParameter("@id", id));
            ATGoodsALLocationInforSET atga = null;
            if (dt.Rows.Count > 0)
            {
                atga = RowToATGoodsALLocationInforSET(dt.Rows[0]);
            }
            return atga;
        }

        /// <summary>
        /// 根据站的ID查对象
        /// </summary>
        /// <param name="id">站的ID</param>
        /// <returns>站的对象</returns>
        public ATGoodsALLocationInforSET GetGASInforByGASID2(int deFlag, string id)
        {
            string sql = "select * from ATSaveGoodsAllocationNum  where DeFlag2=@DeFlag2 and SaveGAid=@id";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag2", deFlag), new SqlParameter("@SaveGAid", id));
            ATGoodsALLocationInforSET atgas = null;
            if (dt.Rows.Count > 0)
            {
                atgas = RowToATGoodsALLocationInforSET2(dt.Rows[0]);
            }
            return atgas;
        }

        //关系转对象 货位总设置用
        private ATGoodsALLocationInforSET RowToATGoodsALLocationInforSET(DataRow dr)
        {
            ATGoodsALLocationInforSET atga = new ATGoodsALLocationInforSET();
            atga.GoodsAllocationID = dr["GoodsAllocationID"].ToString();
            atga.GoodsAllocationNum = Convert.ToInt32(dr["GoodsAllocationNum"]);
            atga.GoodsCode = dr["GoodsCode"].ToString();
            atga.GoodsAllocationName = dr["GoodsAllocationName"].ToString();
            atga.GoodsAllocationbeizhu = dr["GoodsAllocationbeizhu"].ToString();
            atga.DeFlag = Convert.ToInt32(dr["DeFlag"]);
            atga.GAPartsCount = Convert.ToInt32(dr["GAPartsCount"]);
            if (dr["CreatDateTime"].ToString() != "")
            {
                atga.CreatDateTime = Convert.ToDateTime(dr["CreatDateTime"]);
            }
            if (dr["UpDateTime"].ToString() != "")
            {
                atga.UpDateTime = Convert.ToDateTime(dr["UpDateTime"]);
            }
            return atga;
        }

        //关系转对象 货位绑条码用
        private ATGoodsALLocationInforSET RowToATGoodsALLocationInforSET2(DataRow dr)
        {
            ATGoodsALLocationInforSET atgas = new ATGoodsALLocationInforSET();
            atgas.SaveGAid = dr["SaveGAid"].ToString();
            atgas.SaveGoodsAllocationNum = Convert.ToInt32(dr["SaveGoodsAllocationNum"]);
            atgas.SaveGoodsCode = dr["SaveGoodsCode"].ToString();
            atgas.SaveGoodsAllocationName = dr["SaveGoodsAllocationName"].ToString();
            atgas.SaveGoodsAllocationPartsQTY = Convert.ToInt32(dr["SaveGoodsAllocationPartsQTY"]);
            atgas.DeFlag2 = Convert.ToInt32(dr["DeFlag2"]);
            atgas.SelectStates = Convert.ToBoolean(dr["SelectStates"]);
            return atgas;
        }

    }
}

