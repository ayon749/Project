using ReviewVaiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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