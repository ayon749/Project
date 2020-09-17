using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewVaiApp.Controllers
{
    public class ReviewGetPostController : Controller
    {
        // GET: ReviewGetPost
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReviews()
        {
            return View();
        }
        public ActionResult Reviews()
        {
            return View();
        }
    }
}