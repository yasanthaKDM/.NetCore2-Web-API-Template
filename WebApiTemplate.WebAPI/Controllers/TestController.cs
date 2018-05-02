using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Reflection;

namespace WebApiTemplate.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string ReadFile()
        {
            string jsonStr;
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Json\test.json");
            using (StreamReader r = new StreamReader(path))
            {
                jsonStr = r.ReadToEnd();
            }
            return jsonStr;
        }

        [HttpGet]
        public string ConsumeService()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://api.github.com/repos/restsharp/restsharp/releases");

            request.Method = "GET";

            var response = (HttpWebResponse)request.GetResponse();

            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            return content;
        }
    }
}