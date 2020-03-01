using ForTest.Core.Models;
using ForTest.Core.Service;
using ForTest.Web.Admin.Infrastructure;
using ForTest.Web.Areas.Admin.Models;
using System.Linq;
using System.Web.Mvc;

namespace ForTest.Web.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private readonly int pageSize = 30;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index(CustomerFiltering filter, int page = 1)
        {
            var viewModel = new CustomerViewModel();
            viewModel.Filter = filter ?? new CustomerFiltering();

            viewModel.Customers = _customerService.GetForView(viewModel.Filter, page, pageSize);
            viewModel.GenderList = viewModel.Filter.Gender.ToLocalisedSelectItem().Select(x => new SelectListItem { Text = x.Text, Value = x.Value, Selected = false }).ToList();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CustomerFiltering model)
        {
            return RedirectToAction("Index", new 
            {
                model.CustomerId,
                model.Name,
                BirthDayFrom = model.BirthDayFrom.UrlDate(),
                BirthDayTo = model.BirthDayTo.UrlDate(),
                model.Gender,
                model.QuantityRequest,
                model.Sorting
            });
        }
    }
}