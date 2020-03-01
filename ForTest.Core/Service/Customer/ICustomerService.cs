using PagedList;
using ForTest.Core.Models;

namespace ForTest.Core.Service
{
    public interface ICustomerService
    {
        IPagedList<Customer> GetForView(CustomerFiltering customerFiltering, int page, int itemsPerPage);
    }
}
