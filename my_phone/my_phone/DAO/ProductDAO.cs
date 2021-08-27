using my_phone.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_phone.DAO
{
    public class ProductDAO
    {

        db_web_aspEntities1 db = null;
        public ProductDAO()
        {
            db = new db_web_aspEntities1();
        }
        /*public product findProductById(int id)
        {
            db_web_aspEntities1 db = new db_web_aspEntities1();
            product pro = new product(db.products.Find(id));
            return pro;
        }*/
        public IEnumerable<product> ListAllPaging(int page, int pageSize)
        {
            return db.products.OrderByDescending(x => x.create_date).ToPagedList(page, pageSize);
        }
    }
}