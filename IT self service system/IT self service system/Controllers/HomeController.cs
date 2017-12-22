using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_self_service_system.Models;

namespace IT_self_service_system.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Categories()
        {
            List<CategoryViewModel> model = new List<CategoryViewModel>();
            foreach (var c in _context.Category.ToList())
                model.Add(new CategoryViewModel(c));
            return View(model);
        }
        
                public ActionResult About()
                {
                    ViewBag.Message = "Your application description page.";

                    return View();
                }

                public ActionResult Contact()
                {
                    ViewBag.Message = "Your contact page.";

                    return View();
                }
    }
}