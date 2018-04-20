using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiTemplate.Business;
using WebApiTemplate.Common.IBusiness;
using WebApiTemplate.WebAPI.Filters;

namespace WebApiTemplate.WebAPI.Controllers
{
    [Authorization]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IValueBusiness _valueBusiness;
        public ValuesController(IValueBusiness valueBusiness)
        {
            _valueBusiness = valueBusiness;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _valueBusiness.Get();
        }
    }
}
