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
    public partial class FrmGAInsAnUpdate : Form
    {
        public FrmGAInsAnUpdate()
        {
            InitializeComponent();
        }

        private int TP { get; set; }//存标识

        //为该窗体中所有文本框赋值
        public void SetText(object sender, EventArgs e)
        {
            GoodsAllocationEventArgs gaea = e as GoodsAllocationEventArgs;
            this.TP = gaea.tmp; //标识存起来
            if (this.TP == 1)//新增
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
            else if (this.TP == 2)//修改 赋值到文本框
            {
                ATGoodsALLocationInforSET gas = gaea.obj as ATGoodsALLocationInforSET;
                GAidText.Text = gas.GoodsAllocationID.ToString();
                GANumText.Text = gas.GoodsAllocationNum.ToString();
                GACodeText.Text = gas.GoodsCode.ToString();
                GANameText.Text = gas.GoodsAllocationName.ToString();
                GAPartsNumText.Text = gas.GAPartsCount.ToString();
                GAbeizhuText.Text = gas.GoodsAllocationbeizhu.ToString();
            }
        }


        //判断文本框不能为空
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(GANumText.Text))
            {
                MessageBox.Show("货位号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(GACodeText.Text))
            {
                MessageBox.Show("货位代码不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(GANameText.Text))
            {
                MessageBox.Show("货位名称不能为空");
                return false;
            }
          /*  if (string.IsNullOrEmpty(StationIPText.Text))
            {
                MessageBox.Show("IP地址不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(StationMacText.Text))
            {
                MessageBox.Show("Mac地址不能为空");
                return false;
            }*/
            return true;
        }



        private void btnInsAndUpdate_Click(object sender, EventArgs e)
        {

            if (CheckEmpty())
            {
                //获取每个文本框的值
                ATGoodsALLocationInforSET atgas = new ATGoodsALLocationInforSET();
                // Int16 result;
                //Int16.TryParse(StationNumText.Text, out result);
                atgas.GoodsAllocationNum = Convert.ToInt32(GANumText.Text);
                atgas.GoodsCode = Convert.ToString(GACodeText.Text);
                atgas.GoodsAllocationName = Convert.ToString(GANameText.Text);
                atgas.GoodsAllocationbeizhu = Convert.ToString(GAbeizhuText.Text);
                //atgas.GAPartsCount = Convert.ToInt32(GAPartsNumText.Text);

                //判断是新增还是修改
                if (TP == 1)//新增
                {
                    //自动生成ID
                    Guid id = Guid.NewGuid();
                    atgas.GoodsAllocationID = Convert.ToString(id);
                    atgas.DeFlag = 0;
                }
                else if (TP == 2)//修改
                {
                    atgas.GoodsAllocationID = GAidText.Text.ToString();
                }
                ATGoodsAllocationSetBLL bll = new ATGoodsAllocationSetBLL();
                string msg = bll.SaveGASInfo(atgas,this.TP) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                this.Close();
            }
        }

        private void FrmGAInsAnUpdate_Load(object sender, EventArgs e)
        {

        }

        private void GANumText_TextChanged(object sender, EventArgs e)
        {

        }

        //只能输入数字 货位号
        private void GANumText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                int len = GANumText.Text.Length;
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


        //只能输入大于0的整数 零件数量
        private void GAPartsNumText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                int len = GAPartsNumText.Text.Length;
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

        private void GACodeText_TextChanged(object sender, EventArgs e)
        {

        }

        //货位代码
        private void GACodeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            //else
            //{
            //    MessageBox.Show("请输入数字");
            //}              
        }
    }
}



//if (e.KeyChar != '\b')//这是允许输入退格键  
//            {
//                int len = GACodeText.Text.Length;
//                if (len< 1 && e.KeyChar == '0')
//                {
//                    e.Handled = true;
//                }
//                else if ((e.KeyChar< '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
//                {
//                    e.Handled = true;
//                }
//            }