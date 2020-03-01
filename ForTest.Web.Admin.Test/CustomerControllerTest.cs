using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForTest.Web.Areas.Admin.Controllers;
using System.Web.Mvc;
using Moq;
using ForTest.Core.Service;
using PagedList;
using ForTest.Core.Models;
using System.Collections.Generic;

namespace ForTest.Web.Admin.Test
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void IndexViewModel_NotNull()
        {
            var mock = new Mock<ICustomerService>();

            CustomerController controller = new CustomerController(mock.Object);

            ViewResult result = controller.Index(new CustomerFiltering(), 1) as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void IndexPostAction_RedirectToIndexView()
        {
            string expected = "Index";
            var mock = new Mock<ICustomerService>();

            CustomerController controller = new CustomerController(mock.Object);

            RedirectToRouteResult result = controller.Index(new CustomerFiltering()) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }
    }
}
