using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Quartz;

namespace TimerQuartzService
{
    public class Job_Test : BaseJobObj
    {
        public override void JobExcute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string dt = dataMap.GetString("dt");
            jobStatus.Info("333333333333333测试任务开始执行,收到的参数是：" + dt);
            base.JobExcute(context);
        }
    }
}
