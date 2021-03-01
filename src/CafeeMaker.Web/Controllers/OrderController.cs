using Microsoft.AspNetCore.Mvc;

namespace CafeeMaker.Web.Controllers {

    public class OrderController : Controller {

        // GET
        public IActionResult Index() {
            return View();
        }

    }

}