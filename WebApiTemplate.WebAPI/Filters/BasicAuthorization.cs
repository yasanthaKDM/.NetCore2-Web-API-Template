using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Text;
using WebApiTemplate.Common.Common;
using WebApiTemplate.Common.IModels;

namespace WebApiTemplate.WebAPI.Filters
{
    public class BasicAuthorization : TypeFilterAttribute
    {
        public BasicAuthorization() : base(typeof(BasicAuthorizationImpl))
        {
        }

        public class BasicAuthorizationImpl : Attribute, IActionFilter
        {
            private readonly IApplicationSettings _applicationSettings;
            public BasicAuthorizationImpl(IApplicationSettings applicationSettings)
            {
                _applicationSettings = applicationSettings;
            }

            private static IConfiguration Configuration { get; set; }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                var definedBasicAuth = _applicationSettings.GetBasicAuth();

                if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues iAuthHeader))
                {
                    string authHeader = iAuthHeader[0].ToString();

                    if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
                    {
                        var token = authHeader.Substring("Basic ".Length).Trim();
                        string credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                        if (credentialstring.Equals(definedBasicAuth.UserName + ":" + definedBasicAuth.Password))
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

    
}
