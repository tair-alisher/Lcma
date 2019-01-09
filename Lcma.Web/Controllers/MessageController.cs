using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lcma.Web.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult ErrorPartial(string message)
        {
            ViewBag.Message = message;
            return PartialView();
        }
    }
}