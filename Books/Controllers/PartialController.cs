using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Partial()
        {
            return View();
        }
    }
}