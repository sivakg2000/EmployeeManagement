using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using UserInfoManager.Data.Services;

namespace UserInfoManager.Web.Controllers
{
    public class JQController : Controller
    {
        private readonly IUserData db;

        public JQController(IUserData db)
        {
            this.db = db;
        }

        // GET: JQ
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        public ActionResult LoadData()
        {
            var data = db.GetAllUsers();
            return Json(new { d = data }, JsonRequestBehavior.AllowGet);
        }

    }
}
