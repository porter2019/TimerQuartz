using Common.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TimerQuartzService.Tools
{
    public class WebHelper
    {
        static readonly ILog log = LogManager.GetLogger("JobLogAppender"); //日志信息

        /// <summary>
        /// HTTP GET方式请求数据.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <returns></returns>
        public static string HttpGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;

            WebResponse response = null;
            string responseStr = null;

            try
            {
                response = request.GetResponse();

                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error("网络请求出错：" + ex.Message + "---" + url);
                responseStr = string.Empty;
            }
            finally
            {
                request = null;
                response = null;
            }

            return responseStr;
        }

        ///// <summary>
        ///// 输出日志
        ///// </summary>
        ///// <param name="message"></param>
        //public static void WriteLogs(string message)
        //{
        //    string file_name = "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
        //    string server_path = "\\logs\\";
        //    string wl_path = System.Threading.Thread.GetDomain().BaseDirectory + server_path;
        //    if (!Directory.Exists(wl_path))
        //        Directory.CreateDirectory(wl_path); //如果没有该目录，则创建
        //    StreamWriter sw = new StreamWriter(wl_path + file_name, true, Encoding.UTF8);
        //    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +"----" + message);
        //    sw.Close();
        //}

    }
}
