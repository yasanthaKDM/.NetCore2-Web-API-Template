using WebApiTemplate.Common.Common;
using WebApiTemplate.Common.IRepository;

namespace WebApiTemplate.Data
{
    public class ValueRepository : IValueRepository
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
