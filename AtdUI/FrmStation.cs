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
    public partial class FrmStation : Form
    {
        public FrmStation()
        {
            InitializeComponent();
        }


        //站的窗体加载
        private void FrmMemmber_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(FrimMain.GStationNum.ToString());
            //显示所有会员(没有被删除的)
            FrimStation_Load(0);
        }


        public event EventHandler evtFrmsau;

        StationBLL bll = new StationBLL();

        /// <summary>
        /// 窗体加载所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrimStation_Load(int p)
        {
            dgvStation.AutoGenerateColumns = false;//禁止自动生成列
            dgvStation.DataSource = bll.GetStationInforByDeFlag(p);
            if (dgvStation.Rows.Count > 0)
            {
                dgvStation.SelectedRows[0].Selected = false;//禁止第一行被选中
                dgvStation.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//所有行的内容居中显示
            }
        }

        

        //标识1---新增  2--修改   
        //新增站
        private void btnAddStation_Click(object sender, EventArgs e)
        {
            ShowFrmStationInerAnUpdateInfor(1);           
        }
        
        //修改站
        private void btnUpDateStation_Click(object sender, EventArgs e)
        {
            if (dgvStation.SelectedRows.Count>0)//有选中的行
            {
                //获取选中行的ID 
                string id = Convert.ToString(dgvStation.SelectedRows[0].Cells[1].Value.ToString());
                //根据ID去数据库查询 
                ste.obj =  bll.GetStationInforByStationID(0,id);//对象拿到了 要先赋值 再去执行修改
                ShowFrmStationInerAnUpdateInfor(2);//显示修改标志
            }
            else
            {
                MessageBox.Show("请选中后再修改");
            }
        }

        //删除站
        private void btnDeleStation_Click(object sender, EventArgs e)
        {
            if (dgvStation.SelectedRows.Count > 0)
            {
                string id = Convert.ToString(dgvStation.SelectedRows[0].Cells[1].Value);
                string msg = bll.DeleStaBySatID(id) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                FrimStation_Load(0);
            }
        }

        //创建增加修改窗口 弄一个标识来判别是新增还是修改

        StationEventArgs ste = new StationEventArgs();//用来传值的
        public void ShowFrmStationInerAnUpdateInfor(int p)
        {
            FrmStationInerAnUpdate frmstatinsertandupdate = new FrmStationInerAnUpdate();
            this.evtFrmsau += new EventHandler(frmstatinsertandupdate.SetText);
            ste.tmp = p;
            if (this.evtFrmsau!=null)
            {
                this.evtFrmsau(this, ste);
                frmstatinsertandupdate.FormClosed += new FormClosedEventHandler(frmstatinsertandupdate_FormClosed);//关闭刷新
                frmstatinsertandupdate.ShowDialog();
            }        
        }

         void frmstatinsertandupdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrimStation_Load(0);
        }

       

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //模糊查询
        private void search_TextChanged(object sender, EventArgs e)
        {
            dgvStation.AutoGenerateColumns = false;
            dgvStation.DataSource = bll.GetSTinfBytext(search.Text);
            if (dgvStation.Rows.Count>0)
            {
                dgvStation.Rows[0].Selected = false;
            }
        }
    }
}
