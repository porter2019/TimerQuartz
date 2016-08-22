using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace TimerQuartzService
{
    public partial class TimerService : ServiceBase
    {
        static readonly ILog log = LogManager.GetLogger("JobLogAppender"); //日志信息

        public TimerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            log.Info("服务启动");
        }

        protected override void OnStop()
        {
            log.Info("服务停止");
        }
    }
}
