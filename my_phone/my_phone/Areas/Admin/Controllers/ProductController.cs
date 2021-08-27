using my_phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Data.Entity;
using System.Configuration;
using my_phone.DAO;

namespace my_phone.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private db_web_aspEntities1 db = new db_web_aspEntities1();
        // GET: Admin/Product

        public ActionResult ListProduct(int page = 1, int pageSize = 5)
        {
            var dao = new ProductDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        /* public ActionResult ListProduct()
         {
             return View(db.products.ToList());
         }*/

        // Create Product
        public ActionResult CreateProduct()
        {
            ViewBag.brand_id = new SelectList(db.brands, "id", "name");
            ViewBag.category_id = new SelectList(db.categories, "id", "name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([Bind(Include = "id,category_id,brand_id,name,code,description,price,image_url,active,create_date,update_date")] product product)
        {
            ViewBag.brand_id = new SelectList(db.brands, "id", "name", product.brand_id);
            ViewBag.category_id = new SelectList(db.categories, "id", "name", product.category_id);
            if (ModelState.IsValid)
            {
                var check = db.products.FirstOrDefault(s => s.code == product.code);
                if(check == null)
                {
                    product.active = 1;
                    product.create_date = DateTime.Now;
                    // upload file
                    var f = Request.Files["Img"];
                    if (f != null && f.ContentLength > 0)
                    {
                        product.image_url = product.name + f.FileName.Substring(f.FileName.LastIndexOf("."));
                        string pathfile = Path.Combine(Server.MapPath("~/Images/admin/"), product.image_url);
                        f.SaveAs(pathfile);
                    }
                    db.products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("ListProduct");
                }
                else
                {
                    ViewBag.error = "Code already exists";
                    return View("CreateProduct");
                }
                
            }

            
            return View(product);
        }

        // GET: Products/Details/5
        public ActionResult DetailsProduct(int? id)
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

        // GET: Products/Edit/5
        public ActionResult EditProduct(int? id)
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
            ViewBag.brand_id = new SelectList(db.brands, "id", "name", product.brand_id);
            ViewBag.category_id = new SelectList(db.categories, "id", "name", product.category_id);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct([Bind(Include = "id,category_id,brand_id,name,code,description,price,image_url,active,create_date,update_date")] product product)
        {
            if (ModelState.IsValid)
            {


                product.update_date = DateTime.Now;
                product.active = 1;
                db.Entry(product).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("ListProduct");
            }
            ViewBag.brand_id = new SelectList(db.brands, "id", "name", product.brand_id);
            ViewBag.category_id = new SelectList(db.categories, "id", "name", product.category_id);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult DeleteProduct(int? id)
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ListProduct");
        }
    }
}