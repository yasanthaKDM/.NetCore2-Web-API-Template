using WebApiTemplate.Common.Common;
using WebApiTemplate.Common.IBusiness;
using WebApiTemplate.Common.IRepository;

namespace WebApiTemplate.Business
{
    public class ValueBusiness : IValueBusiness
    {
        private IValueRepository _valueRepo;
        public ValueBusiness(IValueRepository valueRepo)
        {
            _valueRepo = valueRepo;
        }
        public Response Get()
        {
            return _valueRepo.Get();
        }
    }
}
