using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumToWordConversionApiApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect(string.Format("{0}/{1}", Request.Url.AbsoluteUri.TrimEnd('/'), "swagger/ui/index"));
        }
    }
}
