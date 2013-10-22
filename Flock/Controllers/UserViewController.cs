using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flock.Controllers
{
    public class UserViewController : Controller
    {
        //
        // GET: /UserView/

        public ActionResult Index()
        {
            return View();
        }

    }
}
