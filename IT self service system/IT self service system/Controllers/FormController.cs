using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using IT_self_service_system.Models;
using Microsoft.AspNet.Identity;

namespace IT_self_service_system.Controllers
{
    public class FormController : Controller
    {
        ApplicationDbContext _context;


        public FormController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Form
        [Authorize]
        public ActionResult Index(int FormStatus)
        {
            List<FormViewModel> model = new List<FormViewModel>();
             foreach(var f in  _context.Form.Include(y => y.Solution).Include( f => f.User).Where( x => x.StatusId == FormStatus).ToList())
            {

                FormViewModel m = new FormViewModel(f);
                
                model.Add(new FormViewModel(f));
            }
            return View(model);
        }

        

        //GET: Create
        public ActionResult Create(int SolutionID)
        {
            FormViewModel model = new FormViewModel();
          //  Solution s = _context.Soluton.FirstOrDefault(x => x.Id == SolutionID);
            //if (s != null)
            model.SolutionId = SolutionID;
            return View(model);

        }
        //POST: Create
        [HttpPost]
        [Authorize]
        public ActionResult Create (FormViewModel model)
        {
            if(model != null)
            {
                Form f = model.GetDbForm();

                f.UserId = User.Identity.GetUserId();
                f.Status = _context.FormStatus.First(x => x.Id == 1);
                f.StatusId = 1;

                _context.Form.Add(f);
                _context.SaveChanges();
            }

            if (model != null && model.SolutionId != 0)
                return RedirectToAction("Index", "Solution",new { Id = model.SolutionId });
            else
            return RedirectToAction("Index", "Home");

        }


        //GET: Edit
        public ActionResult Edit(int Id)
        {
            Form f = _context.Form.Include(c => c.Status).Include(u => u.User).FirstOrDefault(x => x.id == Id);
            if(f == null)
                return RedirectToAction("Index", "Home");
            FormEditViewModel model = new FormEditViewModel(f);
            model.StatusList = _context.FormStatus.ToList();

            return View(model);

        }
        //POST: Form/Edit
        [HttpPost]
        public ActionResult Edit(FormEditViewModel model)
        {
            if (model != null)
            {
                var formDb = _context.Form.FirstOrDefault(x => x.id == model.Id);
                if(formDb == null)
                    return View(model);
                formDb.Comment = model.Comment;
                formDb.StatusId = model.StatusID;
                formDb.Text = model.Text;
                formDb.Title = model.Title;

                _context.SaveChanges();

                return RedirectToAction("Index", "Solution", new { id = formDb.SolutionId });

            }

            
                return RedirectToAction("Index", "Home");

        }
    }
}