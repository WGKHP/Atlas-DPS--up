using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtdUI
{
    public class StationEventArgs:EventArgs
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
