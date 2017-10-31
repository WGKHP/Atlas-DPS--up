using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtdUI
{
    class ExcelHelp
    {


        private int _ReturnStatus;
        private string _ReturnMessage;

        /// <summary>
        /// 执行返回状态
        /// </summary>
        public int ReturnStatus
        {
            get
            {
                return _ReturnStatus;
            }
        }

        /// <summary>
        /// 执行返回信息
        /// </summary>
        public string ReturnMessage
        {
            get
            {
                return _ReturnMessage;
            }
        }
       



        /// <summary>
        /// 导入EXCEL到DataTable
        /// </summary>
        /// <param name="fileName">Excel全路径文件名</param>
        /// <returns>导入成功的DataSet</returns>
        public System.Data.DataTable ImportExcel(string fileName)
        {
            //判断是否安装EXCEL
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                 _ReturnStatus = -1;
                _ReturnMessage = "无法创建Excel对象，可能您的计算机未安装Excel";
                return null;
            }

            //判断文件是否被其他进程使用           
            Microsoft.Office.Interop.Excel.Workbook workbook;
            try
            {
                workbook = xlApp.Workbooks.Open(fileName, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, 1, 0);
            }
            catch
            {
                _ReturnStatus = -1;
                _ReturnMessage = "Excel文件处于打开状态，请保存关闭";
                return null;
         }

            //获得所有Sheet名称
            int n = workbook.Worksheets.Count;
            string[] SheetSet = new string[n];
            System.Collections.ArrayList al = new System.Collections.ArrayList();
            for (int i = 1; i <= n; i++)
            {
                SheetSet[i - 1] = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[i]).Name;
            }

            //释放Excel相关对象
            workbook.Close(null, null, null);
            xlApp.Quit();
            if (workbook != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
            }
            if (xlApp != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                xlApp = null;
            }
            GC.Collect();

            //把EXCEL导入到DataSet
            System.Data.DataSet ds = new DataSet();
            System.Data.DataTable table = new System.Data.DataTable();
            string connStr = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + fileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                OleDbDataAdapter da;
                string sql = "select * from [" + SheetSet[0] + "$] ";
                da = new OleDbDataAdapter(sql, conn);
                da.Fill(ds, SheetSet[0]);
                da.Dispose();
                table = ds.Tables[0];
                conn.Close();
                conn.Dispose();
            }
            return table;
        }
    }

}



    

