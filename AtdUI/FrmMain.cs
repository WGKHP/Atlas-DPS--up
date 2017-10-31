using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Atd.Model;
using Atd.BLL;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Collections;
using Microsoft.Office.Core;
using static AtdUI.AsyncSocketTCPServer;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;


namespace AtdUI
{
    public partial class FrmMain : Form
    {
        public static Dictionary<string, int> clientsconn;
      //public static ArrayList clientconn2;
        //public static List<Client> clientconn2;
        public delegate void GetDataEventHandler(string data, string myip);//委托去服务器里面拿数据 
       // public static int GStationNum = -1;
        public static string GStationID = "-1";
        public static string GStationNum = "";

        StationBLL stabll = new StationBLL();
        BarCodeBLL bcbll = new BarCodeBLL();
        ATStationSetInfor ats = new ATStationSetInfor();
        NetWorkHelper nethlp = new NetWorkHelper();
        ExcelHelp excelhelp = new ExcelHelp();
        public string ddd;
        public byte[] ss;
        public byte recvpackID;
        public FrmBarCodeSet frbc;

        //关系转对象
        public ATStationSetInfor RowToATStationSetInfor(DataRow dr)
        {
            ats.StationNum = Convert.ToInt16(dr["StationNum"]);
            ats.StationName = dr["StationName"].ToString();
            return ats;
        }

        public FrmMain()
        {
            InitializeComponent();
        }


        //主窗体加载
        private void FrimMain_Load(object sender, EventArgs e)
        {
            RefUi();
            AsyncSocketTCPServer tcp_server = new AsyncSocketTCPServer(8100);
           
            tcp_server.Start(200);//服务器监听
            //tcp_server.getdataRecv += new GetDataEventHandler(recv);            
        }
     
        //返回的方法
        public void  recv(string data2,string ip)
        {
            ddd = data2;
            ss = nethlp.change(ddd);//返回的数据转成16进制字节数组
            recvpackID = ss[6];//包号
            frbc.recv(recvpackID);
            //MessageBox.Show(data2);
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }
        //加载所选站的条码窗体
        private void button3_Click(object sender, EventArgs e)
        {
            string [] cc  = (sender as System.Windows.Forms.Button).Tag.ToString().Split('@');
            GStationID = cc[0];
            GStationNum = cc[1];
            frbc = new FrmBarCodeSet();
            frbc.ShowDialog();
            //MessageBox.Show(GStationID.ToString());

        }
        //加载站设置
        private void button5_Click(object sender, EventArgs e)
        {
            FrmStation frmsat = new FrmStation();
            frmsat.ShowDialog();
            RefUi();
            /* if (GStationNum==-1)
             {
                 MessageBox.Show("请选择将要选择的站点");
             }
             else
             {

             }*/
        }
        
        //动态生成按钮的方法
        private void RefUi()
        {
            List<ATStationSetInfor> mylist = stabll.GetStationInforByDeFlag2(0);
            int mytop = 90; //定义离面板的顶部的距离
            splitContainer1.Panel1.Controls.Clear();//清除
            foreach (var item in mylist)
            {
                System.Windows.Forms.Button bt = new System.Windows.Forms.Button();//按钮实例化
                bt.Parent = splitContainer1.Panel1;//按钮的父亲
             //MessageBox.Show(item.StationName + "***" + item.StationNum);
                bt.Tag = item.StationID + "@" + item.StationNum;
                //bt.Tag = item.StationNum;     
                bt.Text = item.StationNum + "号站" + item.StationName;//按钮显示名称
                bt.BackColor = Color.AntiqueWhite;//按钮背景色
             
                bt.Top = mytop;//第一个按钮离面板顶部的距离
                bt.Width = 126;//按钮的宽度
                bt.Height = 50;//按钮的高度
                bt.Click += new System.EventHandler(button3_Click);
                //MessageBox.Show(mytop.ToString());
                bt.Left = 23;//按钮离面板左边的距离
                bt.Parent = splitContainer1.Panel1;
                mytop = mytop + 70;//相当于每个按钮的间隔
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void FrmBarCodeSet_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGoodsAllocationSet frmGoodsAllocationSet = new FrmGoodsAllocationSet();
            frmGoodsAllocationSet.ShowDialog();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        


        private void lstReceiveMsg_TextChanged(object sender, EventArgs e)
        {
            
            
            

        }


       

        //从excel将条码导入到数据库
        private void btIN_Click(object sender, EventArgs e)
        {

            System.Data.DataTable dt2 = new System.Data.DataTable();//创建一个DataTable表，用于存储从excel表中读取的数据  
            OpenFileDialog open = new OpenFileDialog();//创建一个打开文件窗口类  
            open.Filter = "excel 2007版以上|*.xlsx;";//文件过滤 只选择excel类型的文件
            if (open.ShowDialog() == DialogResult.OK)
            {
                string fileName = open.FileName;//获取选取的文件，这里你也可以用过滤方式，过滤一下文件类型。  
                //bind(dt, fileName);//excel表中数据导入到DataTable中过程函数  
             dt2 = excelhelp.ImportExcel(fileName);
            }
            MessageBox.Show(bcbll.ExcelDaoRu(0, dt2) ? "导入成功" : "导入失败");
        }
        
    }
}


