using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atd.Model;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using Atd.DAL;

namespace Atd.DAL
{

    public class BarCodeDAL
    {
        private object StationNum;
        string stationid  ;

        //获取主机名称
        static string gethostname()
        {
            string hostname = GetHostName.gethostname();
            return hostname;
        }
        static string str = gethostname(); //全局连接字符串

        NetWorkHelper datachange = new NetWorkHelper();
        

        /// <summary>
        /// 根据条码名称模糊查询
        /// </summary>
        /// <param name="BarCodeName">条码名称</param>
        /// <returns>返回的是一个集合</returns>
        public List<ATBarCodeInfor> GetBCinfByBCname(string BarCodeName,string StationID)
        {
            string sql = "select * from ATBCRe as m join ATBarCode as b on m.BarCodeID = b.BarCodeID join ATStationSeting as s on m.StationID = s.StationID  where b.DeFlag=0 and s.StationID ='" + StationID + "' and (b.BarCodeName like @BarCodeName or b.BarCode like @BarCodeName)";
            List<ATBarCodeInfor> listbc = new List<ATBarCodeInfor>();
           DataTable dt= SqlHelper.ExecuteTable(sql, new SqlParameter("@BarCodeName", "%"+ BarCodeName + "%"),new SqlParameter("@StationID", StationID));
            if (dt.Rows.Count>0)
            {
                int count = 1;  //行的序号
                foreach (DataRow dr in dt.Rows)
                {
                    ATBarCodeInfor atb = RowToATBarCodeInfor(dr);
                    atb.BarCodeCount = count.ToString();
                    listbc.Add(atb);
                    count++; 
                }
            }
            return listbc;
        }

        //删除条码
        /// <summary>
        /// 根据条码ID修改条码的删除标识
        /// </summary>
        /// <param name="id">条码的ID</param>
        /// <returns>返回受影响的行</returns>
        public int  DeletBCInfByBCID(string id)
        {
            string sql = "update ATBarCode set DeFlag=1 where BarCodeID = @BarCodeID ";
            return SqlHelper.ExcuteNonQuery(sql, new SqlParameter("@BarCodeID", id));
        }

        
        /// <summary>
        /// 将Excel条码数据导入到数据库事务
        /// </summary>
        /// <param name="DeFlag">未删除标志</param>
        /// <param name="dt2">Excel数据形成的临时表</param>
        public int ExcelDaoRu(int DeFlag,DataTable dt2)
        {
            int r = -1;
          //  string str = "Data Source = WG; Initial Catalog = cangkuDB; Integrated Security = True";//连到sql server 服务器里面的数据库  
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
                string sql = "select StationID from ATStationSeting where StationNum='" + dt2.Rows[0]["StationNum"] + "'";
                DataTable st = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag", DeFlag), new SqlParameter("@StationNum", dt2.Rows[0]["StationNum"]));
                 stationid = Convert.ToString(st.Rows[0]["StationID"]);
                for (int i = 0; i <= dt2.Rows.Count-1 ; i++)
                {
                    myCommand.CommandText = "insert into ATBarCode(BarCodeID,BarCode,BarCodeName,CreatDateTime,GAReStates,StationNum,DeFlag,BarCodebeizhu) values ('" +dt2.Rows[i]["BarCodeID"]+ "','" + dt2.Rows[i]["BarCode"] + "','" + dt2.Rows[i]["BarCodeName"].ToString () + "',getdate()," + dt2.Rows[i]["GAReStates"] + "," + dt2.Rows[i]["StationNum"] + "," + dt2.Rows[i]["DeFlag"] + ",'" + dt2.Rows[i]["BarCodebeizhu"] + "')";
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = "insert into ATBCRe(BarCodeID,StationID) values ('" + dt2.Rows[i]["BarCodeID"] + "','" + stationid + "')";
                   r=myCommand.ExecuteNonQuery();
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

        //条码增加事务 
        /// <summary>
        /// 条码增加事务
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="mysqlcon"></param>
        /// <param name="atbc"></param>
        /// <returns></returns>
        public int  AddAndfuzhi(int temp,string mysqlcon,ATBarCodeInfor atbc)
        {
            int r = -1;
           // string str = "Data Source = WG; Initial Catalog = cangkuDB; Integrated Security = True";//连到sql server 服务器里面的数据库
           // string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\AtlasDPS\\cangkudDB.mdf;Integrated Security=True;Connect Timeout=30";//数据库移植用
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
                myCommand.CommandText = "insert into ATBarCode(BarCodeID,BarCode,BarCodeName,CreatDateTime,GAReStates,StationNum,DeFlag,BarCodebeizhu) values ('" + atbc.BarCodeID+"','"+atbc.BarCode+"','"+atbc.BarCodeName+"',getdate(),"+atbc.GAReStates+","+atbc.StationNum+","+atbc.DeFlag+",'"+atbc.BarCodebeizhu+"')";
                myCommand.ExecuteNonQuery();
                ////myCommand.CommandText = "insert  ATBCRe into (BarCodeID) values (@BarCode,@BarCodeName,getdate(),@DeFlag,@BarCodebeizhu)";
                //myCommand.ExecuteNonQuery();
                //myCommand.CommandText = "insert into ATBCRe(BarCodeID,StationID) values (@BarCodeID ,@StationID )";
                myCommand.CommandText = "insert into ATBCRe(BarCodeID,StationID) values ('"+atbc.BarCodeID+"','"+atbc.StationID+"')";
               r = myCommand.ExecuteNonQuery();
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

            return r ;   
        }

       // 新增条码
        public int AddBarCodeInf(ATBarCodeInfor atbc)
        {
            string sql = "insert into ATBarCode (BarCodeID,BarCode,BarCodeName,CreatDateTime,DeFlag,StationNum,BarCodebeizhu) values (@BarCodeID,@BarCode,@BarCodeName,getdate(),@DeFlag,@StationNum,@BarCodebeizhu)";
            return AddAndUpdateBarCodeInf(1, sql, atbc);
        }
        //修改条码
        public int UpdateBarCodeInf(ATBarCodeInfor atbc)
        {
            string sql = "update  ATBarCode set  BarCode = @BarCode,BarCodeName = @BarCodeName,UpDateTime = getdate(),BarCodebeizhu = @BarCodebeizhu where BarCodeID = @BarCodeID";
            return AddAndUpdateBarCodeInf(2, sql, atbc); ;
        }
        //条码增加和修改共用的方法 
        private int AddAndUpdateBarCodeInf(int temp ,string sql ,ATBarCodeInfor atbc)
        {         
            SqlParameter[] ps ={
                               new SqlParameter ("@BarCode",atbc.BarCode),
                               new SqlParameter ("@BarCodeName",atbc.BarCodeName),
                               new SqlParameter ("@BarCodebeizhu",atbc.BarCodebeizhu)
                                };
            List<SqlParameter> list = new List<SqlParameter>();
            list.AddRange(ps);
            if (temp==1)//新增
            {
                list.Add(new SqlParameter("@BarCodeID", atbc.BarCodeID));
                list.Add(new SqlParameter("@DeFlag", atbc.DeFlag));                
            }
            else if (temp==2)//修改
            {
                list.Add(new SqlParameter("@BarCodeID", atbc.BarCodeID));
            }
            return SqlHelper.ExcuteNonQuery(sql, list.ToArray());
        } 
        //加载条码的方法
        /// <summary>
        /// 根据删除标识去查数据库其中的一个表中所有未被删除的记录 
        /// </summary>
        /// <param name="deFlag">删除标识 站号</param>
        /// <returns>返回的是集合</returns>
    public List<ATBarCodeInfor> GetBarCodeInfByDeFlag(int deFlag , string StationID)
        {
            string sql = "select distinct b.BarCode,b.BarCodeName,b.BarCodeID,b.CreatDateTime,b.UpDateTime,b.BarCodebeizhu,b.GAReStates,b.StationNum,b.DeFlag from ATBCRe as m join ATBarCode as b on m.BarCodeID = b.BarCodeID join ATStationSeting as s on m.StationID = s.StationID  where s.StationID ='" + StationID + "' and b.DeFlag=" + deFlag.ToString() + " order by CreatDateTime ASC ";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag", deFlag),new SqlParameter("@StationID", StationID));// 根据删除标识去数据查数据，返回的数据放在dt临时表里
            List<ATBarCodeInfor> list = new List<ATBarCodeInfor>();//实例化一个泛型集合
            if (dt.Rows.Count>0)//如果dt表里行的总数>0
            {
                int count = 1;  //行的序号
                foreach (DataRow dr in dt.Rows)//遍历dt表里的行
                {
                    ATBarCodeInfor atb = RowToATBarCodeInfor(dr);
                    atb.BarCodeCount = count.ToString();
                    list.Add(atb);
                    count++;
                }   
            }
            return list;//返回list的这个集合
        }

        /// <summary>
        /// 根据ID和删除标识查对象
        /// </summary>
        /// <param name="DeFlag">条码删除标识</param>
        /// <param name="id">条码ID</param>
        /// <returns>返回的是对象</returns>
        public ATBarCodeInfor GetBCInfByBCSID(int DeFlag, string  id)
        {
           string sql = "select* from ATBarCode where DeFlag = @DeFlag and BarCodeID = @id";
        //   string sql = "select distinct s.StationNum, b.BarCode , b.BarCodeName ,b.BarCodeID ,b.CreatDateTime,b.UpDateTime,b.BarCodebeizhu , b.DeFlag from ATBCRe as m join ATBarCode as b on b.BarCodeID = m.BarCodeID join ATStationSeting as s on s.StationID = s.StationID where=@DeFlag and @BarCodeID";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag", DeFlag), new SqlParameter("@id", id)); //new SqlParameter("@DeFlag", DeFlag), new SqlParameter("@id", id)
            ATBarCodeInfor atbcinf = null;
            if (dt.Rows.Count > 0)
            {
                atbcinf = RowToATBarCodeInfor(dt.Rows[0]);
            }
            return atbcinf;
        }

        public  string Body;
        public byte[] ss(string hexString)
        {
            byte[] sendbuffer;
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            sendbuffer = new byte[hexString.Length / 2];
            for (int j = 0; j < sendbuffer.Length; j++)
            {
                sendbuffer[j] = Convert.ToByte(hexString.Substring(j * 2, 2), 16);
            }
            return sendbuffer;
        }


        /// <summary>
        /// 根据站号ID和条码ID获取数据主体货位的选中状态和对应的零件数量，发数据用
        /// </summary>
        /// <param name="StationID">站号的ID</param>
        /// <param name="BarCodeID">条码的ID</param>
        /// <returns>数据主体</returns>
        public List<string>  GetGANumAndQTY(int deFlag, string StationID)

        {
            string BeginFu = Convert.ToInt32("FD", 16).ToString("X2"); //开始符FD
            int dataLength = 19;
            string DataLength = dataLength.ToString("X2"); //数据长度13
            string StationNum = ""; //目的地址
            //string CommandHead = Convert.ToString(Int32.Parse("0F", System.Globalization.NumberStyles.HexNumber)) ;//命令头0F
            string CommandHead = Convert.ToInt32("0F", 16).ToString("X2");//命令头0F
            string CommandTYP = Convert.ToInt32("1000", 2).ToString("X2");//命令类型
            string CRC16 = ""; //CRC16校验
            string HostNum= Convert.ToInt32("01", 2).ToString("X2").PadLeft(4,'0');
            string BarCodeID = "";
            string BarCode = "";
            string ganum = "";
            string ganum2 = "";
            string gapartsqty = "";
            string hexString = ""; //拼接16进制字符串总和
            string BarCodeID2 = "";//条码转换临时

           
            int s;
           
            string s1 = "";//条码序号
            
            //List<byte[]> Data = new List<byte[]>();
            List<string> Data = new List<string>();
            string sql = "select StationNum from ATStationSeting where StationID=@StationID order by StationNum";
            DataTable st = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag", deFlag), new SqlParameter("@StationID", StationID));
            if (st!=null&&st.Rows.Count>0)
            {
                for (int a = 0; a <= st.Rows.Count-1; a++)
                {
                    StationNum= Convert.ToInt32(Convert.ToString(Convert.ToInt32(st.Rows[a]["StationNum"].ToString().PadLeft(2,'0')), 2), 2).ToString("X2").PadLeft(4,'0');
                }
            }
            string sql2 = "select  b.BarCode,b.BarCodeID,b.CreatDateTime,b.DeFlag from ATBCRe as m join ATBarCode as b on m.BarCodeID = b.BarCodeID join ATStationSeting as s on m.StationID = s.StationID  where s.StationID ='" + StationID + "' and b.DeFlag=0  order by CreatDateTime ASC ";
            DataTable dtbc = SqlHelper.ExecuteTable(sql2, new SqlParameter("@DeFlag", deFlag), new SqlParameter("@StationID", StationID));// 根据删除标识去数据查数据，返回的数据放在dtbc临时表里
            
            if (dtbc!=null&&dtbc.Rows.Count>0)
            {                
                for (s = 0; s <= dtbc.Rows.Count - 1; s++)
                {
                    //asciiEncoding = new System.Text.ASCIIEncoding();
                    BarCodeID = Convert.ToString(dtbc.Rows[s]["BarCodeID"]);
                    BarCode = Convert.ToString(dtbc.Rows[s]["BarCode"]);
                    byte[] bTemp = System.Text.Encoding.Default.GetBytes(BarCode);
                    for (int i = 0; i < bTemp.Length; i++)
                    {
                        BarCodeID2 += bTemp[i].ToString("X");
                    }                    
                    string sql3 = "select b.SaveGoodsAllocationNum,b.SaveGoodsAllocationPartsQTY,b.SelectStates from ATGASBRe as m join ATSaveGoodsAllocationNum as b on m.SaveGAid=b.SaveGAid join ATStationSeting as s on m.StationID=s.StationID join ATBarCode as c on m.BarCodeID=c.BarCodeID where c.BarCodeID='" + BarCodeID + "'order by SaveGoodsAllocationNum ASC";
                    DataTable dtGAinf = SqlHelper.ExecuteTable(sql3, new SqlParameter("@BarCodeID", BarCodeID));
                    if (dtGAinf != null && dtGAinf.Rows.Count > 0)
                    {
                        for (int k = 0; k <= dtGAinf.Rows.Count - 1; k++)
                        {
                            ganum = ganum + Convert.ToInt32(dtGAinf.Rows[k]["SelectStates"]).ToString();
                            gapartsqty = gapartsqty + Convert.ToInt32(Convert.ToString(Convert.ToInt32(dtGAinf.Rows[k]["SaveGoodsAllocationPartsQTY"].ToString().PadLeft(3, '0')), 2), 2).ToString("X2");
                            //gapartsqty = gapartsqty + dtGAinf.Rows[i]["SaveGoodsAllocationPartsQTY"].ToString().PadLeft(3, '0') + ':';
                            //gapartsqty2 = gapartsqty.Substring(0, gapartsqty.Length - 1);
                            //gapartsqty = gapartsqty+ dtGAinf.Rows[i]["SaveGoodsAllocationPartsQTY"].ToString();
                        }
                        //ganum = Convert.ToInt32(ganum, 2).ToString("X2");
                        ganum2= datachange.GetHexStringByBinary(ganum);
                    }
                    s1 = Convert.ToInt32(Convert.ToString(s+1, 2), 2).ToString("X2");
                    string hexStringCRC =  CommandHead+CommandTYP+s1+BarCodeID2+ganum2+gapartsqty;                   
                    CRC16 = datachange.CRC16Calc(hexStringCRC); //返回的是Crc16校验码 必须是2个字节的     
                    hexString = BeginFu+DataLength+StationNum+CommandHead+CommandTYP+s1+BarCodeID2+ganum2+gapartsqty+CRC16+HostNum;
                    //hexString = hexString.Replace(" ", "");
                    //if ((hexString.Length % 2) != 0)
                    //    hexString += " ";
                    //    sendbuffer = new byte[hexString.Length / 2];
                    //for (int j = 0; j < sendbuffer.Length; j++)
                    //{
                    //    sendbuffer[j] = Convert.ToByte(hexString.Substring(j * 2, 2), 16);
                    //}
                    Data.Add(hexString);//添加数据
                    BarCodeID2 = "";//条码ID暂存清空
                    ganum = "";//货位选择暂存清空
                    gapartsqty = "";//货位零件数量暂存清空

                } // 条码数量循环      
            }
            return Data;
           /* return hexString*/;
        }

        //关系转对象
        private ATBarCodeInfor RowToATBarCodeInfor(DataRow dr)
        {          
            ATBarCodeInfor ATB = new ATBarCodeInfor();
           // ATB.StationNum = Convert.ToInt16(dr["StationNum"]);
            ATB.BarCodeID = dr["BarCodeID"].ToString();
            ATB.BarCode = dr["BarCode"].ToString();    //Convert.ToString(dr["BarCode"]);
            ATB.BarCodeName = dr["BarCodeName"].ToString();
            ATB.GAReStates = Convert.ToInt32(dr["GAReStates"]);
            ATB.StationNum = Convert.ToInt32(dr["StationNum"]);
            ATB.DeFlag = Convert.ToInt32(dr["DeFlag"]);
            if (dr["CreatDateTime"].ToString() != "")
            {
                ATB.CreatDateTime = Convert.ToDateTime(dr["CreatDateTime"]);
            }
            if (dr["UpDateTime"].ToString() != "")
            {
                ATB.UpDateTime = Convert.ToDateTime(dr["UpDateTime"]);
            }
            ATB.BarCodebeizhu = dr["BarCodebeizhu"].ToString();
            return ATB;
         }

        //public List<byte[]> GetGANumAndQTY(int deFlag, string StationID)
        //{
        //    string BeginFu = Convert.ToInt32("FD", 16).ToString("X2"); //开始符FD
        //    int dataLength = 19;
        //    string DataLength = dataLength.ToString("X2"); //数据长度13
        //    string StationNum = ""; //目的地址
        //    //string CommandHead = Convert.ToString(Int32.Parse("0F", System.Globalization.NumberStyles.HexNumber)) ;//命令头0F
        //    string CommandHead = Convert.ToInt32("0F", 16).ToString("X2");//命令头0F
        //    string CommandTYP = Convert.ToInt32("1000", 2).ToString("X2");//命令类型
        //    string CRC16 = ""; //CRC16校验
        //    string HostNum = Convert.ToInt32("01", 2).ToString("X2").PadLeft(4, '0');
        //    string BarCodeID = "";
        //    string BarCode = "";
        //    string ganum = "";
        //    string ganum2 = "";
        //    string gapartsqty = "";
        //    string hexString = ""; //拼接16进制字符串总和
        //    string BarCodeID2 = "";//条码转换临时

        //    byte[] sendbuffer;//发送的字节数组
        //    int s;
        //    int bc;
        //    string s1 = "";//条码序号
        //    System.Text.ASCIIEncoding asciiEncoding;
        //    List<byte[]> Data = new List<byte[]>();
        //    string sql = "select StationNum from ATStationSeting where StationID=@StationID order by StationNum";
        //    DataTable st = SqlHelper.ExecuteTable(sql, new SqlParameter("@DeFlag", deFlag), new SqlParameter("@StationID", StationID));
        //    if (st != null && st.Rows.Count > 0)
        //    {
        //        for (int a = 0; a <= st.Rows.Count - 1; a++)
        //        {
        //            StationNum = Convert.ToInt32(Convert.ToString(Convert.ToInt32(st.Rows[a]["StationNum"].ToString().PadLeft(2, '0')), 2), 2).ToString("X2").PadLeft(4, '0');
        //        }
        //    }
        //    string sql2 = "select  b.BarCode,b.BarCodeID,b.CreatDateTime,b.DeFlag from ATBCRe as m join ATBarCode as b on m.BarCodeID = b.BarCodeID join ATStationSeting as s on m.StationID = s.StationID  where s.StationID ='" + StationID + "' and b.DeFlag=" + deFlag.ToString() + " order by CreatDateTime ASC ";
        //    DataTable dtbc = SqlHelper.ExecuteTable(sql2, new SqlParameter("@DeFlag", deFlag), new SqlParameter("@StationID", StationID));// 根据删除标识去数据查数据，返回的数据放在dtbc临时表里
        //    if (dtbc != null && dtbc.Rows.Count > 0)
        //    {
        //        for (s = 0; s <= dtbc.Rows.Count - 1; s++)
        //        {
        //            asciiEncoding = new System.Text.ASCIIEncoding();
        //            BarCodeID = Convert.ToString(dtbc.Rows[s]["BarCodeID"]);
        //            BarCode = Convert.ToString(dtbc.Rows[s]["BarCode"]);
        //            byte[] bTemp = System.Text.Encoding.Default.GetBytes(BarCode);
        //            for (int i = 0; i < bTemp.Length; i++)
        //            {
        //                BarCodeID2 += bTemp[i].ToString("X");
        //            }
        //            string sql3 = "select b.SaveGoodsAllocationNum,b.SaveGoodsAllocationPartsQTY,b.SelectStates from ATGASBRe as m join ATSaveGoodsAllocationNum as b on m.SaveGAid=b.SaveGAid join ATStationSeting as s on m.StationID=s.StationID join ATBarCode as c on m.BarCodeID=c.BarCodeID where c.BarCodeID='" + BarCodeID + "'order by SaveGoodsAllocationNum ASC";
        //            DataTable dtGAinf = SqlHelper.ExecuteTable(sql3, new SqlParameter("@BarCodeID", BarCodeID));
        //            if (dtGAinf != null && dtGAinf.Rows.Count > 0)
        //            {
        //                for (int k = 0; k <= dtGAinf.Rows.Count - 1; k++)
        //                {
        //                    ganum = ganum + Convert.ToInt32(dtGAinf.Rows[k]["SelectStates"]).ToString();
        //                    gapartsqty = gapartsqty + Convert.ToInt32(Convert.ToString(Convert.ToInt32(dtGAinf.Rows[k]["SaveGoodsAllocationPartsQTY"].ToString().PadLeft(3, '0')), 2), 2).ToString("X2");
        //                    //gapartsqty = gapartsqty + dtGAinf.Rows[i]["SaveGoodsAllocationPartsQTY"].ToString().PadLeft(3, '0') + ':';
        //                    //gapartsqty2 = gapartsqty.Substring(0, gapartsqty.Length - 1);
        //                    //gapartsqty = gapartsqty+ dtGAinf.Rows[i]["SaveGoodsAllocationPartsQTY"].ToString();
        //                }
        //                //ganum = Convert.ToInt32(ganum, 2).ToString("X2");
        //                ganum2 = datachange.GetHexStringByBinary(ganum);
        //            }
        //            s1 = Convert.ToInt32(Convert.ToString(s + 1, 2), 2).ToString("X2");
        //            string hexStringCRC = CommandHead + CommandTYP + s1 + BarCodeID2 + ganum2 + gapartsqty;
        //            CRC16 = datachange.CRC16Calc(hexStringCRC); //返回的是Crc16校验码 必须是2个字节的     
        //            hexString = BeginFu + DataLength + StationNum + CommandHead + CommandTYP + s1 + BarCodeID2 + ganum2 + gapartsqty + CRC16 + HostNum;
        //            hexString = hexString.Replace(" ", "");
        //            if ((hexString.Length % 2) != 0)
        //                hexString += " ";
        //            sendbuffer = new byte[hexString.Length / 2];
        //            for (int j = 0; j < sendbuffer.Length; j++)
        //            {
        //                sendbuffer[j] = Convert.ToByte(hexString.Substring(j * 2, 2), 16);
        //            }
        //            Data.Add(sendbuffer);
        //        } //               
        //    }
        //    return Data;
        //}

    }
}

