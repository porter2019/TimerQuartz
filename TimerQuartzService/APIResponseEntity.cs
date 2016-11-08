using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerQuartzService
{
    /// <summary>
    /// 接口json返回统一格式
    /// </summary>
    public class APIResponseEntity<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public int msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string msgbox { get; set; }

        public T data { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int total { get; set; }
    }
}
