using System.Collections.Generic;
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
        public IEnumerable<string> Get()
        {
            return _valueData.Get();
        }
    }
}
