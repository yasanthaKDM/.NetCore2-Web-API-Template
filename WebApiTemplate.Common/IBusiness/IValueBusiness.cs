using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTemplate.Common.IBusiness
{
    public interface IValueBusiness
    {
        IEnumerable<string> Get();
    }
}
