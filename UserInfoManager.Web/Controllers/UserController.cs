using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInfoManager.Data.Models;
using UserInfoManager.Data.Services;


namespace UserInfoManager.Web.Controllers
{

    public class UserController : Controller
    {

        // Variables

        readonly string CreateTitle = "Add",
                        CreateButton = "Add",
                        EditTitle = "Edit",
                        EditButton = "Update";

        private readonly IUserData db;


        // Ctor

        public UserController(IUserData db)
        {
            this.db = db;
        }

        // Index(es)

        [HttpGet]
        public ActionResult Index(string sortOrder)
        {

            // Sort params ViewBags
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "NameDesc" : "";
            ViewBag.SurnameSortParam = string.IsNullOrEmpty(sortOrder) ? "SurnameDesc" : "";
            ViewBag.OccupationSortParam = string.IsNullOrEmpty(sortOrder) ? "OccupationDesc" : "";
            ViewBag.IdSortParm = sortOrder == "Id" ? "IdDesc" : "Id";

            var model = db.GetAllUsers();
            model = model.OrderBy(r => r.Id);

            switch (sortOrder)
            {
                case "NameDesc":
                    model = model.OrderBy(r => r.Name);
                    break;
                case "SurnameDesc":
                    model = model.OrderBy(r => r.Surname);
                    break;
                case "OccupationDesc":
                    model = model.OrderBy(r => r.Occupation);
                    break;
                case "IdDesc":
                    model = model.OrderBy(r => r.Id);
                    break;
                // Default case model = model.OrderBy(r => r.Id);
            }

            return View(model.ToList());
        }


        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Index")]
        public ActionResult IndexSearch(string searchString)
        {
            var model = db.GetAllUsers();
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.Name.Contains(searchString)
                                       || s.Surname.Contains(searchString));
            }

            return View("Index", model.ToList());
        }



        // TO DO

        [HttpGet]
        public ActionResult SimpleIndex()
        {
            var model = db.GetAllUsers();
            return View(model);
        }

        // Details

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.GetUserData(id);
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
        public ActionResult Create(User user)
        {
            ViewBag.Title = CreateTitle;
            ViewBag.SubmitText = CreateButton;

            //if (string.IsNullOrEmpty(user.Name))
            //{
            //    ModelState.AddModelError(nameof(user.Name), "The name is required"); // html hoppers handle the error display that we feed here
            //}

            if (ModelState.IsValid)
            {
                db.AddUser(user);
                TempData["Message"] = "User was added successfully";
                return RedirectToAction("Details", new { id = user.Id });
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
            var model = db.GetUserData(id); // to get info (query)
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("CreateAndEdit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.UpdateUser(user);
                TempData["Message"] = "User Info updated successfully";
                return RedirectToAction("Details", new { id = user.Id });
            }
            return View("CreateAndEdit", user);
        }


        //------------------------------------------------------------------------------------------

        //
        // Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.GetUserData(id);
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
            db.DeleteUser(id);
            TempData["Message"] = "User Deleted successfully";
            return RedirectToAction("Index");
        }

    }
}



/*
 *  //FormCollection form: FormCollection form is a dummy param to overload the delete method
 *
 *
 *  private CustomerContext db = new CustomerContext();

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
*/
