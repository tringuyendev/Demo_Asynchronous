using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Deadlock.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            Service.Test();

            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> ContactAsync()
        {
            await Service.TestAsync();

            ViewBag.Message = "Your contact page.";

            return View("Contact");
        }

        public ActionResult ContactConfig()
        {
            Service.TestConfig();

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}