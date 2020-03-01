using PagedList;

namespace ForTest.Core.Models
{
    public class CustomerPagingModel
    {
        public CustomerFiltering Filter { get; set; }

        public IPagedList<Customer> CustomerList { get; set; }
    }
}
