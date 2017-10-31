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
    public partial class FrmBCInsAnUpdate : Form
    {
        private string mysqlcon;
        private int TP { get; set; }//存标识
        public FrmBCInsAnUpdate()
        {
            InitializeComponent();
        }

        //为该窗体中的所有文本框赋值
        public void SetText(object sender, EventArgs e)
        {
            //
            BarCodeEventArgs bce = e as BarCodeEventArgs;
            this.TP = bce.tmp;//标识存起来
            if (this.TP == 1)//新增
            {
                //清空所有文本框的值
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox tb = item as TextBox;
                        tb.Text = "";
                    }
                }
            }
            else if (this.TP == 2)//修改，要给窗体的文本框赋值
            {
                ATBarCodeInfor atbc = bce.obj as ATBarCodeInfor;// bce.obj as
                BarCodeIDText.Text = atbc.BarCodeID.ToString();
                BarCodeText.Text = atbc.BarCode.ToString();
                BarCodeNameText.Text = atbc.BarCodeName.ToString();
                BarCodebeizhuText.Text = atbc.BarCodebeizhu.ToString();
            }
        }
  
        private void FrmBCInsAnUpdate_Load(object sender, EventArgs e)
        {

        }

        //确定按钮 新增还是修改
        private void btnInsOrUpdate_Click(object sender, EventArgs e)
        {
            if (CheckTextEmpty())
            {
                //获取每个文本框的值                
                ATBarCodeInfor atbc = new ATBarCodeInfor();                                      
                atbc.BarCode = Convert.ToString(BarCodeText.Text);
                atbc.BarCodeName = Convert.ToString(BarCodeNameText.Text);
                atbc.BarCodebeizhu = Convert.ToString(BarCodebeizhuText.Text);                            
                //判断新增还修改
                if (this.TP == 1)//新增
                {
                    Guid id = Guid.NewGuid();
                    atbc.BarCodeID = Convert.ToString(id);
                    atbc.StationID= FrmMain.GStationID;
                    atbc.StationNum = Convert.ToInt32(FrmMain.GStationNum);
                    atbc.DeFlag = 0 ;
                    atbc.GAReStates = 0;
                }
                else if (this.TP == 2)//修改
                {    
                    atbc.BarCodeID = BarCodeIDText.Text.ToString();                                            
                }
                BarCodeBLL bcbll = new BarCodeBLL();
                MessageBox.Show(bcbll.AddAndfuzhi(this.TP, this.mysqlcon, atbc) ? "操作成功" : "操作失败"); //bcbll.SaveBarCodeInf(atbc, this.TP)
         //  bcbll.AddAndfuzhi(this.TP, this.mysqlcon, atbc);
                this.Close();
            }
        }
        //检查输入文本框是否为空
        private bool CheckTextEmpty()
        {
            if (string.IsNullOrEmpty(BarCodeText.Text) )
            {
                MessageBox.Show("条码不能为空");
                return false;
            }        
            return true ;
        }
        //新增条码输入规范
        private void BarCodeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || ((Keys)(e.KeyChar) == Keys.Back))
                { e.Handled = false; }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("只能输入数字或英文");
                }
            }
        }
    }
}
