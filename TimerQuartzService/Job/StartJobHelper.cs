using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace TimerQuartzService
{
    /// <summary>
    /// 服务启动任务帮助类
    /// </summary>
    public class StartJobHelper
    {
        /// <summary>  
        /// JOB状态日志  
        /// </summary>  
        protected internal static readonly ILog jobStatus = LogManager.GetLogger("JobLogAppender");

        /// <summary>
        /// 当服务启动时调用
        /// </summary>
        public static void Start()
        {
            //程序启动后重新从数据库里获取要添加的任务
            SetTest();
        }

        /// <summary>
        /// 从数据库里获取要设置的任务
        /// </summary>
        static void SetTest()
        {
            //以后的做法是通过API获取数据，而不是使用ADO.NET访问数据库，这样太烦了
            //string site_host = System.Configuration.ConfigurationManager.AppSettings["HDMP"].ToString();
            //string site_url = site_host + "/Intranet/TaskGetAdvisoryDoneIds";
            //string result_json = Tools.WebHelper.HttpGet(site_url);
            //Model.AdvisoryTimeOutAPI result_model;
            //try
            //{
            //    result_model = Tools.JsonHelper.ToObject<Model.AdvisoryTimeOutAPI>(result_json);
            //}
            //catch (Exception ex)
            //{
            //    jobStatus.Error("获取咨询超时完成列表出错：" + ex.Message);
            //    return;
            //}
            //if (result_model == null) return;
            //if (result_model.data_list == null) return;
            //foreach (var item in result_model.data_list)
            //{
            //    Job.CreateJobHelper.AddTestJob(item.id, item.pay_time, result_model.time_out);
            //}
            //jobStatus.Info("启动添加测试任务完成，添加数据数量：" + result_model.data_list.Count.ToString());
        }

    }
}
