using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtdUI
{
    public class BarCodeEventArgs:EventArgs
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int tmp { get; set; }

        /// <summary>
        /// 对象
        /// </summary>
        public object obj { get; set; }

        
    }
}
