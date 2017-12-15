using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_self_service_system.Models;

namespace IT_self_service_system.Controllers
{
    public class SolutionController : Controller
    {
        private ApplicationDbContext _context;

        public SolutionController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        // GET: Solution
        public ActionResult Index()
        {
            SolutionListViewModel model = new SolutionListViewModel();
            model.listSolution = _context.Soluton.ToList();
            return View(model);
        }

        // GET: Solution/Create
        public ActionResult Create()
        {
            CreateSolutionViewModel model = new CreateSolutionViewModel();
            model.categoryList = _context.Category.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateSolutionViewModel model)
        {
            if(model.title != null && model.selectedCategory != 0 && model.description != null)
            {
                Solution newSolution = new Solution()
                {
                    CategoryId = model.selectedCategory,
                    Title = model.title,
                    Description = model.description,
                    CreateDate = DateTime.Now
                };

                _context.Soluton.Add(newSolution);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                return View(model);
            }
           

        }

    }
}