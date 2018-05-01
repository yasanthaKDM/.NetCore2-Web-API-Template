using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection;

namespace WebApiTemplate.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            string jsonStr;
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Json\test.json");
            using (StreamReader r = new StreamReader(path))
            {
                jsonStr = r.ReadToEnd();
            }
            return jsonStr;
        }
    }
}