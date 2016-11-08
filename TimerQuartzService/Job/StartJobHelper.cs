using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerQuartzService
{
    /// <summary>
    /// 服务启动任务帮助类
    /// </summary>
    public class StartJobHelper
    {
        /// <summary>
        /// 当服务启动时调用
        /// </summary>
        public static void Start()
        {
            //TODO 从数据库里查找任务，添加任务

            //测试数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("dt", DateTime.Now.ToString());
            QuartzManager<Job_Test>.addJob("task_test_01", "*/15 * * * * ?", dic);
        }
    }
}
