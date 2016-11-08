using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TimerQuartzService.Controller
{
    public class TestController : ApiController
    {
        [Route("/api/test/a")]
        [HttpGet]
        public APIResponseEntity<string> GetInfo()
        {
            APIResponseEntity<string> response_entity = new APIResponseEntity<string>();
            response_entity.msg = 1;
            response_entity.msgbox = "success";

            return response_entity;
        }
    }
}
