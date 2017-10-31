using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtdUI
{
    class GoodsAllocationEventArgs:EventArgs
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
