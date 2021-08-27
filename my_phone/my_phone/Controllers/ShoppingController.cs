using my_phone.Models;
using my_phone.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace my_phone.Controllers
{
    public class ShoppingController : Controller
    {
        private db_web_aspEntities1 db;
        private List<ShoppingCartModel> lisOfShoppingCartModel;
        public ShoppingController()
        {
            db = new db_web_aspEntities1();
            lisOfShoppingCartModel = new List<ShoppingCartModel>();
        }
        // GET: Shopping
        public ActionResult Index()
        {
            IEnumerable<ShoppingViewModel> listOfShopping = (from objItem in db.products
                                                             join
                                                                objCate in db.categories
                                                                on objItem.category_id equals objCate.id
                                                             select new ShoppingViewModel()
                                                             {
                                                                 ImagePath = objItem.image_url,
                                                                 ItemName = objItem.name,
                                                                 Description = objItem.description,
                                                                 ItemPrice = (decimal)objItem.price,
                                                                 Category = objCate.name,
                                                                 ItemCode = objItem.code
                                                             }


                                                                ).ToList();
            return View(listOfShopping);
        }

        public JsonResult Index(string ItemId)
        {
            product objItem = db.products.Single(model => model.id.ToString() == ItemId);
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}