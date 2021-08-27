using Google.Protobuf.WellKnownTypes;
using my_phone.DAO;
using my_phone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace my_phone.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private db_web_aspEntities1 db = new db_web_aspEntities1();

        public ActionResult ListCategory(int page = 1, int pageSize = 1)
        {

            var dao = new CategoryDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        // GET: Admin/Category
        /*public ActionResult ListCategory()
        {
          
            return View(db.categories.ToList());
        }*/

        // Chi tiết thể loại.
        public ActionResult Details(int? id )
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.categories.Find(id);
            if(category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // Get: Sửa thể thể loại.
        public ActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        
        /* - Post: Sửa thể loại sản phẩm.
           - ValidateAntiForgeryToken là chức năng bảo về resquest giả mạo, độc của brownser.
           - ModelState.isValid là kiểm tra xem câu lệnh query ở trên có hợp lệ với dữ liệu trong database hay ko.
           Nó bắt chuyển đổi kiểu dữ liệu cho hợp lệ với cơ sở dữ liệu của các field.
           - Bind là gắn kết nguồn dữ liệu với control và tự động hiển thị dữ liệu. */      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory([Bind(Include = "id,name,code,description,active,create_date,update_date")] category category)
        {
            if (ModelState.IsValid)
            {
                category.active = 1;
                category.update_date = DateTime.Now;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListCategory");
            }
            
            return View(category);
        }

        // Get: Delete Category
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            category category = db.categories.Find(id);
            db.categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("ListCategory");
        }

        // GET: Create Categories
        public ActionResult CreateCategory()
        {
            return View();
        }
        // Post: Create Categories
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory([Bind(Include = "id,name,code,description,active,create_date,update_date")] category category)
        {
            if (ModelState.IsValid)
            {
                var check = db.categories.FirstOrDefault(s => s.code == category.code);
                if(check == null)
                {
                   
                    category.active = 1;
                    category.create_date = DateTime.Now;
                    db.categories.Add(category);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    return RedirectToAction("ListCategory");
                }
                else
                {
                    ViewBag.error = "Code already exists";
                    return View("CreateCategory");
                }
                
            }

            return View(category);
        }

    }
}