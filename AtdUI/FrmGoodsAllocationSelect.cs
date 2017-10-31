using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atd.BLL;
using Atd.Model;

namespace AtdUI
{
    public partial class FrmGoodsAllocationSelect : Form
    {


        private string myid;
        public int r;
        private Dictionary<string, NumericUpDown> ListNumericUpDown;
        private Dictionary<string, CheckBox> ListCheckbox;
        private List<CheckBox> lscheckbox;
        private List<NumericUpDown> nd;
        //public static string GGoodsAllocationID = "-1";
        private List<ATGoodsALLocationInforSET> listatgas;
        private ATGoodsALLocationInforSET atgas;
        private ATGoodsAllocationSetBLL atgabll;
        private ATBarCodeInfor atbc;
        private int TP { get; set; }//存标识

        //关系转对象
        public ATGoodsALLocationInforSET RowToATGoodsALLocationInforSET(DataRow dr)
        {
            atgas.GoodsAllocationNum = Convert.ToInt32(dr["GoodsAllocationNum"]);
            atgas.GoodsAllocationName = dr["GoodsAllocationName"].ToString();
            return atgas;
        }
        //窗体的构造函数
        public FrmGoodsAllocationSelect(string ParID)
        {
            InitializeComponent();
            myid = ParID;
            ListNumericUpDown = new Dictionary<string, NumericUpDown>();
            ListCheckbox = new Dictionary<string, CheckBox>();
            lscheckbox = new List<CheckBox>();
            nd = new List<NumericUpDown>();
            listatgas = new List<ATGoodsALLocationInforSET>();
            atgas = new ATGoodsALLocationInforSET();
            atgabll = new ATGoodsAllocationSetBLL();
            atbc = new ATBarCodeInfor();
        }

        public void chuanzhi(object sender, EventArgs e)
        {
            GoodsAllocationSelectEventArgs gase = e as GoodsAllocationSelectEventArgs;
            this.TP = gase.tmp;

        }

        //货位指派窗体加载    
        private void FrmGoodsAllocationSelect_Load(object sender, EventArgs e)
        {
            checkbox();
            if (r > 0)//货位关联的查看判断条件
            {
                btnGASOK.Enabled = false;
                lookcheckandqty();
                foreach (var item in lscheckbox)
                {
                    item.Enabled = false;
                }
                foreach (var item in nd)
                {
                    item.Enabled = false;
                }
            }
        }

        //动态生成复选框的方法
        private void checkbox()
        {
            List<ATGoodsALLocationInforSET> mylist = atgabll.GetGoodsAllocationInfByDeFlag2(0);
            int mytop = 65;
            int myleft = 50;
            int mytexboxtop = 68;
            int mytexboxleft = 435; // 数值增减输入框 第一个位置 x坐标
            panel1.Controls.Clear();
            foreach (var item in mylist)
            {
                CheckBox chb = new CheckBox();//复选框
                NumericUpDown tbx = new NumericUpDown();//数值增减输入框
                chb.Parent = panel1;
                chb.Tag = item.GoodsAllocationID + "@" + item.GoodsAllocationName + "@" + item.GoodsAllocationNum + "@" +item.GoodsCode;                
                chb.Text = item.GoodsAllocationNum + "号货位:" + item.GoodsCode +":"+ item.GoodsAllocationName ;                
                //MessageBox.Show(item.GoodsAllocationNum + "号货位:" + item.GoodsAllocationName);
                chb.BackColor = Color.AntiqueWhite;
                chb.Top = mytop;
                chb.Left = myleft;
                chb.AutoSize = false;
                chb.Width = 370;//复选框宽度
                chb.Height = 28;
                mytop = mytop + 35;
                if (mytop >= 620)//多排控件控制用
                {
                    mytop = 65;
                    myleft = myleft + 450;
                }
                chb.Parent = panel1;
                ListCheckbox.Add(item.GoodsAllocationID, chb);
                lscheckbox.Add(chb);//查看时禁止修改用

                tbx.Parent = panel1;
                tbx.Tag = item.GoodsAllocationID;
                tbx.Text = "0";
                tbx.Minimum = 0;
                tbx.Maximum = 999;
                tbx.BackColor = Color.AntiqueWhite;
                tbx.Width = 43;
                tbx.Height = 32;
                tbx.Top = mytexboxtop;
                tbx.Left = mytexboxleft;
                mytexboxtop = mytexboxtop + 35;
                if (mytexboxtop >= 620)//多排控件控制用
                {
                    mytexboxtop = 68;
                    mytexboxleft = mytexboxleft + 450;//数字输入框向右平移
                }
                tbx.Parent = panel1;
                ListNumericUpDown.Add(item.GoodsAllocationID, tbx);
                nd.Add(tbx);
            }
        }

        //遍历复选框 选中几个就生成几个id 并将选中状态和数据插入到数据库中
        private bool ches()
        {
            int r = -1;
            foreach (var item in ListCheckbox)
            {
                string[] myunitstr = item.Value.Tag.ToString().Split('@');
                string[] myunitstr2 = ListCheckbox[myunitstr[0]].Text.Split(':');
                Guid id = Guid.NewGuid();
                atgas.SaveGAid = Convert.ToString(id);
                atgas.StationID = FrmMain.GStationID;
                atgas.BarCodeID = myid;
                atgas.SaveGoodsAllocationName = myunitstr2[2];
                atgas.SaveGoodsAllocationNum = Convert.ToInt32(myunitstr[2]);
                atgas.SaveGoodsCode = myunitstr[3].ToString();
                atgas.SelectStates = ListCheckbox[myunitstr[0]].Checked;
                atgas.SaveGoodsAllocationPartsQTY = Convert.ToInt32(ListNumericUpDown[myunitstr[0]].Text);
                listatgas.Add(atgas);
                atgas = new ATGoodsALLocationInforSET();//每添加一次后就新实例化一个对象为下一次存储数据做准备
            }
            if (this.TP == 1)
            {
                r = Convert.ToInt32(atgabll.AddAndfuzhi(FrmMain.GStationID, myid, listatgas));
            }
            else if (this.TP == 2)
            {
                r = Convert.ToInt32(atgabll.updateGAS(FrmMain.GStationID, myid, listatgas));
            }
            return r > 0;
        }

        //查看货位选中状态和对应的数量
        private void lookcheckandqty()
        {
            List<ATGoodsALLocationInforSET> mylist2 = atgabll.GetGAStatesAndQTYInf(FrmMain.GStationID, myid);
            int index = 0;
            foreach (var item in ListCheckbox)
            {
                string[] myunitstr = item.Value.Tag.ToString().Split('@');
                string[] myunitstr2 = ListCheckbox[myunitstr[0]].Text.Split(':');
                ListCheckbox[myunitstr[0]].Checked = Convert.ToBoolean(mylist2[index].SelectStates);
                ListNumericUpDown[myunitstr[0]].Text = Convert.ToString(mylist2[index].SaveGoodsAllocationPartsQTY);
                index++;
            }
        }

        //向数据库插入数据
        private void btnGASOK_Click(object sender, EventArgs e)
        {
            //GoodsAllocationEventArgs gaeas = e as GoodsAllocationEventArgs;
            //this.TP = gaeas.tmp;
            if (this.TP == 1)//货位关联新增
            {
                MessageBox.Show(ches() ? "操作成功" : "操作失败");
            }
            else if (this.TP == 2)//货位修改
            {
                MessageBox.Show(ches() ? "操作成功" : "操作失败");
            }

            // MessageBox.Show(myid);      

            this.Close();
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



    }
}

