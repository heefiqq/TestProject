using ForTest.Core.Models;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForTest.Web.Areas.Admin.Models
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            Filter = new CustomerFiltering();
        }

        public CustomerFiltering Filter { get; set; }

        public List<SelectListItem> GenderList { get; set; }

        public IPagedList<Customer> Customers { get; set; }
    }
}