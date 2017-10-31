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
    public partial class FrmStationInerAnUpdate : Form
    {
        public FrmStationInerAnUpdate()
        {
            InitializeComponent();
        }

        private int TP { get; set; }//存标识
       
        


        //为该窗体中所有文本框赋值
        public void SetText(object sender,EventArgs e)
        {
            StationEventArgs sema = e as StationEventArgs;

            this.TP = sema.tmp; //标识存起来
            if (this.TP==1)//新增
            {
                //清除所有文本框
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox tb = item as TextBox;
                        tb.Text = "";
                    }
                }
            }
            else if (this.TP==2)//修改 赋值到文本框
            {
             ATStationSetInfor sem  =sema.obj as ATStationSetInfor;
                StationIDText.Text = sem.StationID.ToString();
                StationNumText.Text= sem.StationNum.ToString();
                StationNameText.Text = sem.StationName.ToString();
                StationIPText.Text = sem.StationIP.ToString();
                StationMacText.Text = sem.StationMac.ToString();
                StationbeizhuText.Text = sem.Stationbeizhu.ToString();          
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
  
        private void btnStationInsert_Click(object sender, EventArgs e)
        {

            if (CheckEmpty())
            {
                //获取每个文本框的值
                ATStationSetInfor atsa = new ATStationSetInfor();
               // Int16 result;
                //Int16.TryParse(StationNumText.Text, out result);
                atsa.StationNum = Convert.ToInt16(StationNumText.Text);
                atsa.StationName = Convert.ToString(StationNameText.Text);
                atsa.StationIP = Convert.ToString(StationIPText.Text);
                atsa.StationMac = Convert.ToString(StationMacText.Text);
                atsa.Stationbeizhu = Convert.ToString(StationbeizhuText.Text);

                //判断是新增还是修改
                if (TP == 1)//新增
                {
                    //自动生成ID
                   Guid id=Guid.NewGuid() ;
                   atsa.StationID = Convert.ToString(id);
                   atsa.DeFlag = 0;      
                }
                else if (TP == 2)//修改
                {
                   atsa.StationID = StationIDText.Text.ToString();                    
                }
                StationBLL bll = new StationBLL();
                string msg=bll.SaveStatInfo(atsa, this.TP) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                this.Close();
            }
           
        }

        //判断文本框不能为空
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(StationNumText.Text))
            {
                MessageBox.Show("站号不能为空且要大于0的整数");
                return false;
            }
            if (Convert.ToInt32(StationNumText.Text) <= 0)
            {
                MessageBox.Show("站号要大于0的整数");
                return false;
            }
            if (string.IsNullOrEmpty(StationNameText.Text))
            {
                MessageBox.Show("站名不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(StationIPText.Text))
            {
                MessageBox.Show("IP地址不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(StationMacText.Text))
            {
                MessageBox.Show("Mac地址不能为空");
                return false;
            }
            return true;
        }

        private void FrmStationInerAnUpdate_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(FrimMain.GStationNum.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //只能输入大于0的正整数
        private void StationNumText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                int len = StationNumText.Text.Length;
                if (len < 1 && e.KeyChar == '0')
                {
                    e.Handled = true;
                }
                else if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }

            }

        }
    }
}
