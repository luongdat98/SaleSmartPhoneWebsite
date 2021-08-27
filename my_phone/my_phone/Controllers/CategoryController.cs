using my_phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace my_phone.Controllers
{
    public class CategoryController : Controller
    {
        private db_web_aspEntities1 db = new db_web_aspEntities1();
        // GET: Category
        public ActionResult ListCategry()
        {
            return View(db.categories.ToList());
        }

       
    }
}