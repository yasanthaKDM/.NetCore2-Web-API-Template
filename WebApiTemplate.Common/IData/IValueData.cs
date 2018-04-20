using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTemplate.Common.IData
{
    public interface IValueData
    {
        IEnumerable<string> Get();
    }
}
