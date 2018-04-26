using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTemplate.Common.Common;
using WebApiTemplate.Common.IData;

namespace WebApiTemplate.Data
{
    public class ValueData : IValueData
    {
        public Response Get()
        {
            return new Response
            {
                status = "test",
                message = "testing 123"
            };
        }
    }
}
