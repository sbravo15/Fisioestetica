using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G7.Controllers
{
    public class SesionController : Controller
    {
        // GET: Sesion
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}