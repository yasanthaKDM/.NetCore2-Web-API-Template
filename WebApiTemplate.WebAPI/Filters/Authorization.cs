using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTemplate.Common.Common;

namespace WebApiTemplate.WebAPI.Filters
{
    public class Authorization : Attribute, IActionFilter
    {
        private static IConfiguration Configuration { get; set; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            string username = Configuration["BasicAuth:Username"];
            string password = Configuration["BasicAuth:Password"];

            if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues iAuthHeader))
            {
                string authHeader = iAuthHeader[0].ToString();

                if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
                {
                    var token = authHeader.Substring("Basic ".Length).Trim();
                    string credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                    if (credentialstring == username + ":" + password)
                    {
                        return;
                    }
                }
            }

            var result = new Response
            {
                status = "error",
                message = "you are not authorized to perform this action"
            };
            context.Result = new ObjectResult(result);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
    }
}
