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
    public partial class FrmGoodsAllocationSet : Form
    {
        public FrmGoodsAllocationSet()
        {
            InitializeComponent();
        }

        
       
        //窗体加载
        private void FrmGoodsAllocationSet_Load(object sender, EventArgs e)
        {
            FrmGoodsAllocationSet_Load(0);
        }

        
        ATGoodsAllocationSetBLL bll=new ATGoodsAllocationSetBLL();
        ExcelHelp excelhelp = new ExcelHelp();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>

        private void FrmGoodsAllocationSet_Load(int p)
        {
            dgvGoodsAllocation.AutoGenerateColumns = false;//禁止自动生成列
            dgvGoodsAllocation.DataSource = bll.GetGoodsAllocationInfByDeFlag(p);
            if (dgvGoodsAllocation.Rows.Count > 0)
            {
                dgvGoodsAllocation.SelectedRows[0].Selected = false;//禁止第一行被选中
                dgvGoodsAllocation.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//所有行的内容居中显示
            }

        }

        //标识1---新增  2--修改  
        //新增货位按钮
        private void btnAddGoodsAllocation_Click(object sender, EventArgs e)
        {
            ShowFrmGAInsAnUpdate(1);
        }


        //修改货位按钮
        private void btnUpdateGoodsAllocation_Click(object sender, EventArgs e)
        {
            if (dgvGoodsAllocation.SelectedRows.Count > 0)//有选中的行
            {
                //获取选中行的ID 
                string id = Convert.ToString(dgvGoodsAllocation.SelectedRows[0].Cells[0].Value.ToString());
                //根据ID去数据库查询 
               gae.obj = bll.GetGASInforByGASID(0, id);//对象拿到了 要先赋值 再去执行修改
                ShowFrmGAInsAnUpdate(2); //显示修改标志
            }
            else
            {
                MessageBox.Show("请选中后再修改");
            }
           
        }




        public event EventHandler evtGA;
        GoodsAllocationEventArgs gae = new GoodsAllocationEventArgs();

        //显示新增或修改货位界面的方法
        public void ShowFrmGAInsAnUpdate(int p)
        {
            FrmGAInsAnUpdate frgaaup = new FrmGAInsAnUpdate();
           this.evtGA += new EventHandler(frgaaup.SetText);
            gae.tmp = p;
            if (this.evtGA != null)
            {
                this.evtGA(this, gae);
                frgaaup.FormClosed += new FormClosedEventHandler(frgaaup_FormClosed);//关闭刷新
                frgaaup.ShowDialog();
            }
        }


        void frgaaup_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmGoodsAllocationSet_Load(0);
        }

        private void btnDeletGoodsAllocation_Click(object sender, EventArgs e)
        {
            if (dgvGoodsAllocation.SelectedRows.Count>0)
            {
                string id = Convert.ToString(dgvGoodsAllocation.SelectedRows[0].Cells[0].Value);
                MessageBox.Show(bll.DeleGASByGASID(id) ? "操作成功" : "操作失败");
                FrmGoodsAllocationSet_Load(0);
            }
                        
        }



        //模糊查询
        private void reachtinf_TextChanged(object sender, EventArgs e)
        {
            string txt = reachtinf.Text;
            dgvGoodsAllocation.AutoGenerateColumns = false;
            dgvGoodsAllocation.DataSource = bll.GetGAinfByreachText(txt);
            if (dgvGoodsAllocation.Rows.Count>0)
            {
                dgvGoodsAllocation.Rows[0].Selected = false;
            }

        }


        //总货位导入按钮
        private void BtnAllGAIn_Click(object sender, EventArgs e)
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
           DialogResult r =  MessageBox.Show(bll.InPutAllGAByExcel(dt2) ? "导入成功" : "导入失败");
            if (r == DialogResult.OK)
            {
                FrmGoodsAllocationSet_Load(0);//导入成功后刷新信息
            }
            else
            {
                return;
            }

        }
    }
}
