using Common.Logging;

namespace TimerQuartzService
{
    public class BaseTaskJob
    {
        /// <summary>  
        /// JOB状态日志  
        /// </summary>  
        protected internal static readonly ILog jobStatus = LogManager.GetLogger("JobLogAppender");

        /// <summary>  
        /// 服务错误日志  
        /// </summary>  
        protected internal static readonly ILog serviceErrorLog = LogManager.GetLogger("JobLogAppender");
    }
}
