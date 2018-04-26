using System.Collections.Generic;
using WebApiTemplate.Common.Common;
using WebApiTemplate.Common.IBusiness;
using WebApiTemplate.Common.IData;
using WebApiTemplate.Data;

namespace WebApiTemplate.Business
{
    public class ValueBusiness : IValueBusiness
    {
        private IValueData _valueData;
        public ValueBusiness(IValueData valueData)
        {
            _valueData = valueData;
        }
        public Response Get()
        {
            return _valueData.Get();
        }
    }
}
