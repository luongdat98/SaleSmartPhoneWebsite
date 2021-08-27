using my_phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace my_phone.DAO
{
    public class InvoiceDao
    {
        db_web_aspEntities1 db = null;
        public InvoiceDao()
        {
            db = new db_web_aspEntities1();
        }

        public IEnumerable<invoicedetail> ListAllPaging(int page, int pageSize)
        {
            return db.invoicedetails.OrderByDescending(x=>x.create_date).ToPagedList(page, pageSize);
        }

    }
}