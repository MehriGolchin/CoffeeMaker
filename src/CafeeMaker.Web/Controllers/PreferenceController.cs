using Microsoft.AspNetCore.Mvc;

namespace CafeeMaker.Web.Controllers {

    public class PreferenceController : Controller {

        // GET
        public IActionResult Index() {
            return View();
        }

    }

}