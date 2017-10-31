using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Atd.BLL;
using Atd.Model;
using System.Collections;
using System.Timers;


namespace AtdUI
{
    public partial class FrmBarCodeSet : Form
    {
        //public int sid;
       // private string id;
        private bool b;//控制发送失败弹出只显示一次
        int v;
        int sendcounts;//发送次数
        int setsendcounts;//发送失败后再发送当前数据次数
        string timer;//数据发送循环时间间隔
    
        public string GStationID { get; private set; }
        public string GStationNum { get; private set; }

        public byte packID;
        public byte[] Data;
        public byte[] Data2;
        public byte[] sendbuffer;
        public byte RecevePackID;
        List<string> strsendbuffer = new List<string>();//16进制字符串集合
        List<byte[]> bytesendbuffer = new List<byte[]>();//字节数组集合
        List<byte[]> errorlist = new List<byte[]>();//发送失败将那些失败的数据放进去
        List<string> bclist = new List<string>();//条码信息去数据库查询用
        public System.Timers.Timer t1;

        ATBarCodeInfor atbc = new ATBarCodeInfor();
        ATGoodsALLocationInforSET atgas = new ATGoodsALLocationInforSET();
        AsyncSocketTCPServer tcp_server = new AsyncSocketTCPServer(8100);
        BarCodeBLL bcbll = new BarCodeBLL();
        ATGoodsAllocationSetBLL atgasbll = new ATGoodsAllocationSetBLL();
        ExcelHelp excelhelp = new ExcelHelp();
        FrmGoodsAllocationSelect fgaselect;
        public event EventHandler evtBC;
        public event EventHandler evtgase;
        BarCodeEventArgs bce = new BarCodeEventArgs();//事件传值
        GoodsAllocationSelectEventArgs gase = new GoodsAllocationSelectEventArgs();
        //static string path = @"D:\ATDPS\XMLSYS.xml";
        static string path = @"E:\C# TEST\Atlas DPS -up\AtdUI\bin\x86\Debug\XMLSYS.xml";
        static XDocument d = XDocument.Load(path);
        static XElement xelet = d.Root;
        IEnumerable<XElement> els = xelet.Elements();
        XmlDocument xmd = new XmlDocument();

        public FrmBarCodeSet()  //int parsid
        {
            InitializeComponent();
            t1 = new System.Timers.Timer();
        }


        //窗体加载
        private void FrmBarCodeSet_Load(object sender, EventArgs e)
        {
            LoadATBarCodeInforByDeFlag(0, atbc.StationID);
            //MessageBox.Show(d.Root.ToString());
            xmd.Load(path);
            //XmlNode root = xmd.SelectSingleNode("//comuncation");
            //timer = (root.SelectSingleNode("timer")).InnerText;
            timer = xmd["congfing"]["comuncation"]["time"]["timer"].InnerText;
            setsendcounts = Convert.ToInt32(xmd["congfing"]["comuncation"]["time"]["sendcounts"].InnerText);
        }


        // 给客户端发送消息
        private void button1_Click(object sender, EventArgs e)
        {
            GStationNum = Convert.ToString(FrmMain.GStationNum);
            GStationID = Convert.ToString(FrmMain.GStationID);
            //int dgvcount = 0;
            //for (int i = 0; i <= dgvBarCode.Rows.Count - 1; i++)
            //{
            //    if (dgvBarCode.Rows[i].Cells[1].EditedFormattedValue.ToString() == "True")
            //    {
            //        dgvcount++;
            //        dgvBarCode.Rows[i].Selected = true;
            //    }
            //}
            //if (dgvcount<=0)
            //{               
            //   MessageBox.Show("请勾选后再发送数据");
            //    return;
            //}
            //for (int m = 0; m <= dgvBarCode.SelectedRows.Count - 1; m++)
            //{
            //    //bclist.Add(dgvBarCode.SelectedRows[i].Cells[0].Value.ToString());
            //    strsendbuffer.Add(bcbll.GetGANumAndQTY(0, GStationID, dgvBarCode.SelectedRows[m].Cells[0].Value.ToString()));
            //}
            strsendbuffer = bcbll.GetGANumAndQTY(0, GStationID);
            //Data = change(strsendbuffer[0]);
            //packID = Data[6];
            b = false;
            t1.Interval = Convert.ToInt32(timer);
            t1.Elapsed += new System.Timers.ElapsedEventHandler(senddata);
            t1.Start();

        }

        //发送有返回包号的处理
        public void recv(byte recvpackID)
        {
            if (recvpackID == packID)
            {
                sendcounts = 0;//发送次数计数器清理
                strsendbuffer.RemoveAt(0);//移除集合第一个元素
                Data = null;
                packID = 0;
                //Data2 = change(strsendbuffer[0]);
                //packID = Data2[6];
            }
        }
        
        //数据发送
        public void senddata(object source, ElapsedEventArgs e)
        {
            if ((strsendbuffer.Count <= 0) && (b == false))
            {
                sendcounts = 0;
                //Data = null;errorlist.Count
                if (errorlist.Count > 0)
                {
                    b = true;
                    MessageBox.Show(Convert.ToString(errorlist.Count) + "条数据发送失败，请检查网路或设备");
                    //errorlist=null;
                }
                if (errorlist.Count <= 0)
                {
                    b = true;
                    MessageBox.Show("数据发送成功！");
                }
                return;
            }
            if (sendcounts > setsendcounts)//发送失败后的处理 发送下一条数据
            {
                errorlist.Add(Data);//将未发送的数据放到错误列表里面
                strsendbuffer.RemoveAt(0);
                if (strsendbuffer.Count <= 0)
                {
                    sendcounts = 0;
                    //Data = null;
                    return;
                }
                //Data = bytesendbuffer[0];
                Data = change(strsendbuffer[0]);
                packID = Data[6];//包号
                sendcounts = 0;
               // tcp_server.Send(GStationNum, Data, Data.Length);
            
                WriteSPSLog(strsendbuffer[0]);//日志记录
                sendcounts++;//发送次数计数器
                return;
            }
            else
            {
                if (Data == null)//发送第一条和返回的数据正确后发送下一条
                {
                    //Data = bytesendbuffer[0];
                    try
                    {
                        Data = change(strsendbuffer[0]);//发完这里异常
                        packID = Data[6];//包号
                        sendcounts++;
                       // tcp_server.Send(GStationNum, Data, Data.Length);
                        WriteSPSLog(strsendbuffer[0]);//日志记录
                    }
                    catch
                    {
                       
                    }
                   
                    return;
                }
                else if (sendcounts > 0)
                {
                    //Data = bytesendbuffer[0];
                    //packID = Data[6];//包号
                    sendcounts++;
                  //  tcp_server.Send(GStationNum, Data, Data.Length);
                }

            }
        }


        //16进制字符串转字节数组
        public byte[] change(string strsendbuffer)
        {
            strsendbuffer = strsendbuffer.Replace(" ", "");
            if ((strsendbuffer.Length % 2) != 0)
                strsendbuffer += " ";
            sendbuffer = new byte[strsendbuffer.Length / 2];
            for (int j = 0; j < sendbuffer.Length; j++)//16进制字符串转字节数组
            {
                sendbuffer[j] = Convert.ToByte(strsendbuffer.Substring(j * 2, 2), 16);
            }
            return sendbuffer;
        }






        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="str1">要记录的字符串</param>
        private void WriteSPSLog(string str1)
        {
            try
            {
                if (str1.Trim() == "")
                {
                    return;
                }
                FileStream afile = new FileStream(@"C:\OS\ABC\" + DateTime.Now.ToString("yyyyMMdd HH") + "SPS.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(afile);
                sw.WriteLine(" ");
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + ":" + str1);
                sw.Close();
                afile.Close();
            }
            catch (Exception e)
            {
                FileStream afile = new FileStream(@"C:\OS\ABC\" + DateTime.Now.ToString("yyyyMMdd HH") + "SPS溢出.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(afile);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + ":" + str1);
                sw.Close();
                afile.Close();
                MessageBox.Show(e.ToString());
            }
        }



        //加载所有的条码
        private void LoadATBarCodeInforByDeFlag(int p, string stationID)
        {
            // GStationNum = Convert.ToInt16(FrimMain.GStationNum);
            GStationID = Convert.ToString(FrmMain.GStationID);
            dgvBarCode.AutoGenerateColumns = false;//禁止自动生成列
            dgvBarCode.DataSource = bcbll.GetBarCodeInfByDeFlag(p, GStationID);
            if (dgvBarCode.Rows.Count > 0)//如果有行数
            {
                dgvBarCode.SelectedRows[0].Selected = false;//禁止默认第一行选中
                dgvBarCode.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//所有行的内容居中显示
            }
        }



        //标识 1--新增条码  2--修改条码
        //新增条码
        private void btnInsBC_Click(object sender, EventArgs e)
        {
            ShowFrmBCInsAnUpdate(1);
        }


        //修改条码
        private void btnUpdateBC_Click(object sender, EventArgs e)
        {

            if (dgvBarCode.SelectedRows.Count > 0)
            {
                //获取选中行的ID
                //根据ID去数据库查询
                string id = Convert.ToString(dgvBarCode.SelectedRows[0].Cells[0].Value.ToString());
                //去数据库查询
                bce.obj = bcbll.GetBCInfByBCSID(0, id);
                ShowFrmBCInsAnUpdate(2);
            }
            else
            {
                MessageBox.Show("请选中再修改");
            }
        }


        //删除条码--假删除
        private void btnDelBC_Click(object sender, EventArgs e)
        {
            if (dgvBarCode.SelectedRows.Count > 0)
            {
                string id = Convert.ToString(dgvBarCode.SelectedRows[0].Cells[0].Value);
                MessageBox.Show(bcbll.DeletBCInfByBCID(id) ? "操作成功" : "操作失败");
                LoadATBarCodeInforByDeFlag(0, atbc.StationID);//刷新
            }
        }

        //显示条码新增或修改界面的方法
        public void ShowFrmBCInsAnUpdate(int p)
        {
            FrmBCInsAnUpdate frbcaup = new FrmBCInsAnUpdate();
            this.evtBC += new EventHandler(frbcaup.SetText);
            bce.tmp = p;
            if (this.evtBC != null)
            {
                this.evtBC(this, bce);
                frbcaup.FormClosed += new FormClosedEventHandler(frbcaup_FormClosed);//关闭刷新
                frbcaup.ShowDialog();
            }
        }
        //关闭窗体后刷新的方法
        void frbcaup_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadATBarCodeInforByDeFlag(0, GStationID);
        }

        //货位关联对话框
        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvBarCode.SelectedRows.Count > 0)
            {
                string id = Convert.ToString(dgvBarCode.SelectedRows[0].Cells[0].Value.ToString());
                showFrmGASelect(1);
            }
            else
            {
                MessageBox.Show("请选中再操作");
            }
        }

        //显示货位关联和修改界面的方法
        public void showFrmGASelect(int tp)
        {
            fgaselect = new FrmGoodsAllocationSelect(Convert.ToString(dgvBarCode.SelectedRows[0].Cells[0].Value));
            //fgaselect.btnGASOK.Enabled = true;
            this.evtgase += new EventHandler(fgaselect.chuanzhi);
            gase.tmp = tp;
            this.evtgase(this, gase);
            fgaselect.FormClosed += new FormClosedEventHandler(FrmBarCodeSet_Load);//关闭刷新           
            fgaselect.ShowDialog();
        }

        //货位修改对话框
        private void btnGAupdate_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(bcbll.GetGANumAndQTY(GStationID = Convert.ToString(FrmMain.GStationID), id = Convert.ToString(dgvBarCode.SelectedRows[0].Cells[0].Value.ToString())));    
            if (dgvBarCode.SelectedRows.Count > 0)
            {
                string id = Convert.ToString(dgvBarCode.SelectedRows[0].Cells[0].Value.ToString());
                showFrmGASelect(2);
            }
            else
            {
                MessageBox.Show("请选中再操作");
            }
        }



        public int h()
        {
            v = v + 1;
            return v;
        }

        //货位查看
        private void btnGAsee_Click(object sender, EventArgs e)
        {
            h();
            if (dgvBarCode.SelectedRows.Count>0)
            {
                fgaselect = new FrmGoodsAllocationSelect(Convert.ToString(dgvBarCode.SelectedRows[0].Cells[0].Value));
                fgaselect.r = v;
            }
            else
            {
                MessageBox.Show("请选择后再操作");
            } 
            
            //showFrmGASelect();    
            //fgaselect.btnGASOK.Enabled = false;
            if ((dgvBarCode.SelectedRows.Count > 0) && ( Convert.ToInt32(dgvBarCode.SelectedRows[0].Cells[8].Value.ToString())>0))
            {
                fgaselect.ShowDialog();
            }
            else
            {
                MessageBox.Show("还没有指派货位哦");
            }

        }

        void fgaselect_close(object sender, EventArgs e)
        {


        }
        private void dgvBarCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //全选
        private void BCSeletctALL_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dgvBarCode.Rows.Count - 1; i++)
            {
                //判断复选框是否选中
                if ((dgvBarCode.Rows[i].Cells[1].EditedFormattedValue.ToString().Trim()).Equals("False"))
                {
                    //设置复选框选中
                    dgvBarCode.Rows[i].Cells[1].Value = "True";
                }

            }
        }

        //取消全选
        private void cancelselectall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dgvBarCode.Rows.Count - 1; i++)
            {
                //判断复选框是否选中
                if ((dgvBarCode.Rows[i].Cells[1].EditedFormattedValue.ToString().Trim()).Equals("True"))
                {
                    //设置取消复选框的选中状态
                    dgvBarCode.Rows[i].Cells[1].Value = "False";
                }
            }
        }

        //实时搜索查询
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GStationID = Convert.ToString(FrmMain.GStationID);
            //获取查询文本框的值

            //传到BLL层
            dgvBarCode.AutoGenerateColumns = false;
            dgvBarCode.DataSource = bcbll.GetBCinfByBCname(textBox1.Text, GStationID);
            if (dgvBarCode.SelectedRows.Count > 0)
            {
                dgvBarCode.SelectedRows[0].Selected = false;
            }

        }


        //货位关联excel导入
        private void BtnGAReInPut_Click(object sender, EventArgs e)
        {           
            if (dgvBarCode.SelectedRows.Count>0)
            {   
                GStationID = Convert.ToString(FrmMain.GStationID);//站id
                string barcodeid = Convert.ToString(dgvBarCode.SelectedRows[0].Cells[0].Value.ToString());//所选条码id
                int SelectStates = Convert.ToInt32(dgvBarCode.SelectedRows[0].Cells[8].Value.ToString());//条码货位关联状态
                System.Data.DataTable dt2 = new System.Data.DataTable();//创建一个DataTable表，用于存储从excel表中读取的数据  
                OpenFileDialog open = new OpenFileDialog();//创建一个打开文件窗口类  
                open.Filter = "excel 2007版以上|*.xlsx;";//文件过滤 只选择excel类型的文件

                if (open.ShowDialog() == DialogResult.OK)
                {
                    string fileName = open.FileName;//获取选取的文件，这里你也可以用过滤方式，过滤一下文件类型。
                    string absolutefilename = fileName.Substring(fileName.LastIndexOf("\\") + 1);//获取导入文件的文件名
                    string[] ababsolutefilename1 = absolutefilename.Split('.');

                    string selectbcfilename = dgvBarCode.SelectedRows[0].Cells[3].Value.ToString();//选中条码的名称+".xlsx"
                    if (selectbcfilename == ababsolutefilename1[0])//导入的文件和选中的条码进行匹配
                    { 
                        dt2 = excelhelp.ImportExcel(fileName);
                        //bind(dt, fileName);//excel表中数据导入到DataTable中过程函数 
                        DialogResult r =  MessageBox.Show(atgasbll.InPutBCAndGARelByExcel(GStationID, barcodeid, SelectStates, dt2) ? "导入成功" : "导入失败");
                        if (r == DialogResult.OK)
                        {
                            LoadATBarCodeInforByDeFlag(0, atbc.StationID);//导入成功后刷新条码信息
                        }
                        else
                        {
                            return;
                        }
                    }
                    else //匹配不成功
                    {
                        MessageBox.Show("导入文件与所选条码不匹配,请重新选择文件");
                    }
                    return;
                }
            }
            else
            {
                MessageBox.Show("请选中条码后再执行操作");
            }
            return;           
        }
    }
}
//if (Data != null)
//{
//    tcp_server.Send(GStationNum, Data, Data.Length);
//    WriteSPSLog(strsendbuffer[0]);
//    return;
//}
//else 
//{
//    if (Data2 == null)
//    {
//        return;
//    }
//        tcp_server.Send(GStationNum, Data2, Data2.Length);
//        WriteSPSLog(strsendbuffer[0]);   
//}