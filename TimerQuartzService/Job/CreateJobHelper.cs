using Common.Logging;
using System;
using System.Collections.Generic;

namespace TimerQuartzService.Job
{
    /// <summary>
    /// 创建任务帮助类
    /// </summary>
    public class CreateJobHelper
    {
        /// <summary>  
        /// JOB状态日志  
        /// </summary>  
        protected internal static readonly ILog jobStatus = LogManager.GetLogger("JobLogAppender");

        /// <summary>
        /// 添加测试任务
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="pay_time">添加时间</param>
        /// <param name="time_out">超时时间-小时</param>
        public static void AddTestJob(int id,DateTime pay_time,int time_out_hours)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("id", id);
            dic.Add("str", "abc");

            //多少个小时后执行

            DateTime dt = pay_time.AddHours(time_out_hours);

            if (dt < DateTime.Now)
                dt = DateTime.Now.AddSeconds(20);

            string cron = dt.Second.ToString() + " " +
                    dt.Minute.ToString() + " " +
                    dt.Hour.ToString() + " " +
                    dt.Day.ToString() + " " +
                    dt.Month.ToString() + " ? " +
                    dt.Year.ToString();
            QuartzManager<Job_Test>.addJob("task_test_" + id, cron, dic);
            jobStatus.Info("【测试任务】添加ID为：" + id + "的任务，执行时间：" + dt.ToString());
        }

    }
}
