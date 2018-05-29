using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Common.Logging;

namespace TimerQuartzService.Controllers
{
    public class TestController : ApiController
    {
        static readonly ILog log = LogManager.GetLogger("JobLogAppender"); //日志信息

        [Route("api/test/a")]
        [HttpGet]
        public APIResponseEntity<string> GetInfo()
        {
            APIResponseEntity<string> response_entity = new APIResponseEntity<string>();
            response_entity.msg = 1;
            response_entity.msgbox = "success";
            //通过接口添加任务
            //Job.CreateJobHelper.AddTestJob(1, DateTime.Now, 11);
            return response_entity;
        }
    }
}
