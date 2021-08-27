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
    public class InvoiceController : Controller
    {
        private db_web_aspEntities1 db = new db_web_aspEntities1();
        // GET: Admin/Invoice
        public ActionResult ListInvoice(int page = 1, int pageSize = 1)
        {
            var dao = new InvoiceDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }



       /* public ActionResult ListInvoice()
        {
            return View(db.invoicedetails.ToList());
        }*/

        // Chi tiết hóa đơn.
        public ActionResult DetailsInvoice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            invoicedetail invoicedetail = db.invoicedetails.Find(id);
            if (invoicedetail == null)
            {
                return HttpNotFound();
            }
            return View(invoicedetail);
        }

        // Edit invoice
        public ActionResult EditInvoice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            invoicedetail invoicedetail = db.invoicedetails.Find(id);
            if (invoicedetail == null)
            {
                return HttpNotFound();
            }
            return View(invoicedetail);
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInvoice([Bind(Include = "id,invoice_id,product_id,price,active,create_date,update_date")] invoicedetail invoicedetail)
        {
            if (ModelState.IsValid)
            {
                invoicedetail.invoice_id = invoicedetail.invoice_id;
                invoicedetail.product_id = invoicedetail.product_id;
                invoicedetail.active = 1;
                invoicedetail.update_date = DateTime.Now;
                db.Entry(invoicedetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListInvoice");
            }

            return View(invoicedetail);
        }*/

       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInvoice(invoicedetail invoicedetail)
        {
            try
            {
                var invoice = db.invoicedetails.Find(invoicedetail.id);
                invoice.invoice_id = invoicedetail.invoice_id;
                invoice.product_id = invoicedetail.product_id;
                invoice.price = invoicedetail.price;
                invoice.active = 1;
                invoice.update_date = DateTime.Now;
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListInvoice");
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }


            return View(invoicedetail);
        }*/


    }
}