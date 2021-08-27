using my_phone.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_phone.DAO
{
    public class CategoryDao
    {
        db_web_aspEntities1 db = null;
        public CategoryDao()
        {
            db = new db_web_aspEntities1();
        }

        public IEnumerable<category> ListAllPaging(int page, int pageSize)
        {
            return db.categories.OrderByDescending(x => x.create_date).ToPagedList(page, pageSize);
        }
    }
}