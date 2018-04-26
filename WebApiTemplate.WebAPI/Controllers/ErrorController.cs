using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTemplate.WebAPI.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/Error")]
        public IActionResult Index()
        {
            var result = new
            {
                status = "error",
                message = "something went wrong"
            };
            return new ObjectResult(result);
        }
    }
}