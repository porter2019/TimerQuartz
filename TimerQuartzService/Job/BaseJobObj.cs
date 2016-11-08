using Quartz;
using Common.Logging;

namespace TimerQuartzService
{
    public class BaseJobObj : IJob
    {
        /// <summary>  
        /// JOB状态日志  
        /// </summary>  
        protected internal static readonly ILog jobStatus = LogManager.GetLogger("JobLogAppender");

        /// <summary>  
        /// 服务错误日志  
        /// </summary>  
        protected internal static readonly ILog serviceErrorLog = LogManager.GetLogger("JobLogAppender");


        public void Execute(IJobExecutionContext context)
        {
            jobStatus.Info("############## (" + this.GetType().ToString() + ")任务开始执行.. #################");

            JobExcute(context);

            jobStatus.Info("############## (" + this.GetType().ToString() + ")任务执行完毕！ #################");

        }

        /// <summary>
        /// 任务执行.
        /// </summary>
        public virtual void JobExcute(IJobExecutionContext context)
        {
            //等待子类重写
        }
    }
}
