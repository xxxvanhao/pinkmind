using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PinkMind.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: Organization
        public ActionResult ProFile()
        {
            return View();
        }
        public ActionResult Security()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult Project()
        {
            return View();
        }
    }
}