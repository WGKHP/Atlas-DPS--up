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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            //关闭登录对话框
            this.Close();
        }


        private bool CheckText()
        {
            if (string.IsNullOrEmpty(textName.Text))
            {
                MessageBox.Show("账号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(textPwd.Text))
            {
                MessageBox.Show("密码不能为空");
                return false;
            }
            return true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string msg = "";

            ATUserInforBLL bll = new ATUserInforBLL();
            if (bll.Islongin(textName.Text,textPwd.Text,out msg))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
               // MessageBox.Show(msg);
            }

            else
            {
                MessageBox.Show(msg);
            }        
        }


        //判断用户名和密码不能为空

            
      
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
