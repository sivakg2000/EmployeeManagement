using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInfoManager.Data.Models;
using UserInfoManager.Data.Services;
//using UserInfoManager.Web.ViewModels;

namespace TaxOfficeInfoManager.Web.Controllers
{
    public class TaxOfficeController : Controller
    {
        // Variables

        readonly string CreateTitle = "Add",
                        CreateButton = "Add",
                        EditTitle = "Edit",
                        EditButton = "Update";

        private readonly ITaxOfficeData db;


        // Ctor

        public TaxOfficeController(ITaxOfficeData db)
        {
            this.db = db;
        }

        // Index(es)

        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAllTaxOffices();
            return View(model);
        }

        [HttpGet]
        public ActionResult SimpleIndex()
        {
            var model = db.GetAllTaxOffices();
            return View(model);
        }

        // Details

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.GetTaxOfficeData(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }


        //
        // Create and Edit
        //----------------------------------------------------------------------


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = CreateTitle;
            ViewBag.SubmitText = CreateButton;
            return View("CreateAndEdit");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaxOffice taxOffice)
        {
            ViewBag.Title = CreateTitle;
            ViewBag.SubmitText = CreateButton;

            //if (string.IsNullOrEmpty(user.Name))
            //{
            //    ModelState.AddModelError(nameof(user.Name), "The name is required"); // html hoppers handle the error display that we feed here
            //}

            if (ModelState.IsValid)
            {
                db.AddTaxOffice(taxOffice);
                TempData["Message"] = "Tax Office was added successfully";
                return RedirectToAction("Index"/*, new { id = taxOffice.Id }*/);
            }
            return View("CreateAndEdit");

        }


        //
        // Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Title = EditTitle;
            ViewBag.SubmitText = EditButton;
            var model = db.GetTaxOfficeData(id); // to get info (query)
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("CreateAndEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaxOffice taxOffice)
        {
            if (ModelState.IsValid)
            {
                db.UpdateTaxOffice(taxOffice);
                TempData["Message"] = "Tax Office Info updated successfully";
                return RedirectToAction("Details", new { id = taxOffice.Id });
            }
            return View("CreateAndEdit", taxOffice);
        }


        //------------------------------------------------------------------------------------------

        //
        // Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.GetTaxOfficeData(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            db.DeleteTaxOffice(id);
            TempData["Message"] = "Tax Office Deleted successfully";
            return RedirectToAction("Index");
        }
    }

}


//public class TaxOfficeController : Controller
//{

//    //readonly string CreateTitle = "Add",
//    //                CreateButton = "Add",
//    //                EditTitle = "Edit",
//    //                EditButton = "Update";

//    private readonly ITaxOfficeData db;

//    public TaxOfficeController(ITaxOfficeData db)
//    {
//        this.db = db;
//    }

//    [HttpGet]
//    public ActionResult Index()
//    {
//        var model = db.GetAllTaxOffices();
//        return View(model);
//    }

//    [HttpGet]
//    public ActionResult Create()
//    {
//        User user = new User();
//        List<TaxOffice> taxOffice;
//        using (UserInfoManagerDbContext db = new UserInfoManagerDbContext())
//        {
//            //fill your list with the resourceTypes that are in your database
//            taxOffice = db.TaxOffices.ToList();
//        }
//        //create a new viewmodel and give it the parameters necesary that we created
//        CreateTaxOfficeViewModel vm = new CreateTaxOfficeViewModel(user, taxOffice);
//        return View(vm);
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public ActionResult Create(CreateTaxOfficeViewModel vm)
//    {
//        using (UserInfoManagerDbContext db = new UserInfoManagerDbContext())
//        {
//            if (ModelState.IsValid)
//            {
//                vm.User.TaxOffice = db.TaxOffices.Find(vm.TaxOfficeId); //using the ID selected in the view find it in the database
//                db.Users.Add(vm.User);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(vm);
//        }
//    }
//}