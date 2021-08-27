using my_phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace my_phone.Controllers
{
    public class ClientController : Controller
    {
        private db_web_aspEntities1 db = new db_web_aspEntities1();
        // GET: Client
        public ActionResult Index()
        {
            List<product> products = db.products.ToList();
        
            return View(products);
        }
      

        // GET: Client/list product from category
        public ActionResult CategoryPhone()
        {
            List<product> products = db.products.Where(b => b.category.id == 1).ToList();

            return View(products);
        }
        public ActionResult CategoryLaptop()
        {
            List<product> products = db.products.Where(b => b.category.id == 2).ToList();

            return View(products);
        }
        public ActionResult CategoryGrid()
        {
            return View();
        }


        // GET: Client/ Single Product
        public ActionResult SingleProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult Login()
        {
            return View();
        }
        // Post : Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {


                var pass_md5 = GetMD5(password);
                var data = db.users.Where(s => s.username.Equals(username) && s.password.Equals(pass_md5)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().fullname;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(user _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.users.FirstOrDefault(s => s.username.Equals(_user.username));
                if (check == null)
                {
                    _user.password = GetMD5(_user.password);
                    _user.create_date = DateTime.Now;
                    _user.update_date = DateTime.Now;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Username already exists";
                    return View();
                }


            }
            return View();

        }

        private string GetMD5(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(password);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}