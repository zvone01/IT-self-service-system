using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using IT_self_service_system.Models;
using System.Web.Security;
using IT_self_service_system.Filters;

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

      //  public ActionResult Index()
     //   {
      //      return RedirectToAction("Index", "Home");
       // }
        // GET: Solution
        public ActionResult Index(int id = 0)
        {
            if ( id <= 0)
                return RedirectToAction("Index","Home") ;
            var sol = _context.Soluton.Include(x => x.Category).Include(y => y.Type).FirstOrDefault(s => s.Id == id);

            if (sol == null)
                return RedirectToAction("Index", "Home");

              

            SolutionViewModel model = new SolutionViewModel(sol);

            var forms = _context.Form.Include(u => u.User).Include(s => s.Status).Where(x => x.SolutionId == sol.Id).ToList();

            if (forms != null && forms.Count() > 0)
                foreach(var f in forms)
                 model.formList.Add(new FormViewModel(f));

            return View(model);
        }

        // GET: Solution
        public ActionResult Result(string q, bool category = false)
        {

            SolutionListViewModel model = new SolutionListViewModel();

            if (q == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (category)
                {
                    model.AddSolutionsToList(_context.Soluton.Include(s => s.Category).Include(y => y.Type).Where(x => x.Category.Name == q).ToList());
                }
                else
                {
                    foreach (string word in q.Split(' '))
                    {
                        if (word == "the" || word == "a" || word == "an")
                            continue;
                        model.AddSolutionsToList(_context.Soluton.Include(s => s.Category).Include(y => y.Type).Where(x => x.Description.Contains(word) || x.Title.Contains(word)).ToList());
                    }
                }

                
                
            }

            if (model != null)
                 model.listSolution.OrderByDescending(y => y.reputation);

            return View(model);
        }

        // GET: Solution/Create
       // [AuthorizeFilter(Roles = RoleName.CanAddSolution)]
        public ActionResult Create()
        {
            CreateSolutionViewModel model = new CreateSolutionViewModel();
            model.categoryList = _context.Category.ToList();

            model.stypeList = _context.SolutionType.ToList();
            return View(model);
        }

        [HttpPost]
       // [AuthorizeFilter(Roles = RoleName.CanAddSolution)]
        public ActionResult Create(CreateSolutionViewModel model)
        {
            if(model.title != null && model.selectedCategory != 0 && model.description != null)
            {
                Solution newSolution = new Solution()
                {
                    CategoryId = model.selectedCategory,
                    Title = model.title,
                    Description = model.description,
                    CreateDate = DateTime.Now,
                    Reputation = 0,
                    ContactInfo = model.ContactInfo,
                    TypeId = model.selectedType

                };

                _context.Soluton.Add(newSolution);
                _context.SaveChanges();
                return RedirectToAction("Index",newSolution.Id);
            }
            else
            {

                return View(model);
            }
           

        }

        // GET: Solution/Edit?Id=
        [HttpGet]
       // [AuthorizeFilter(Roles = RoleName.CanAddSolution)]
        public ActionResult Edit(int id)
        {
            if (id <= 0)
                return RedirectToAction("Result");
            var sol = _context.Soluton.Include(x => x.Category).Include(y => y.Type).FirstOrDefault(s => s.Id == id);

            if (sol == null)
                return RedirectToAction("Index", "Home");

            CreateSolutionViewModel model = new CreateSolutionViewModel(sol);

            model.categoryList = _context.Category.ToList();
            model.stypeList = _context.SolutionType.ToList();
            return View(model);
        }

        [HttpPost]
       // [AuthorizeFilter(Roles = RoleName.CanAddSolution)]
        public ActionResult Edit(CreateSolutionViewModel model)
        {
            if (model == null && model.Id > 0)
                return View(model);

            var sol = _context.Soluton.Include(x => x.Category).FirstOrDefault(s => s.Id == model.Id);

            if (sol == null)
                return View(model);

            if (model.title != null && model.selectedCategory != 0 && model.description != null)
            {

                sol.CategoryId = model.selectedCategory;
                sol.Title = model.title;
                sol.Description = model.description;
                sol.ContactInfo = model.ContactInfo;
                sol.TypeId = model.selectedType;

                _context.SaveChanges();
                return RedirectToAction("Index", new { id = sol.Id } );//Index(sol.Id);
            }
            else
            {

                return View(model);
            }


        }

        [HttpPost]
        public int? Rate(SetMarkData data)
        {
            Solution s = _context.Soluton.FirstOrDefault(x => x.Id == data.SolutionID);
            if (s == null)
                return null;

            s.Reputation = data.Mark ? s.Reputation + 1 : s.Reputation - 1;

            _context.SaveChanges();
            return s.Reputation;

        }

    }
}