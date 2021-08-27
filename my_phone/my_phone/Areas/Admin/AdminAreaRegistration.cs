using System.Web.Mvc;

namespace my_phone.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            // List Category
            context.MapRoute(
                "Admin_ListCategory",
                "Admin/Admin/ListCategory",
                new { controller = "Category", action = "ListCategory"  }
            );
            // Edit Category
            context.MapRoute(
                "Admin_CreateCategory",
                "Admin/Admin/CreateCategory",
                new { controller = "Category", action = "CreateCategory"  }
            );

            // List Product
            context.MapRoute(
                "Admin_ListProduct",
                "Admin/Admin/ListProduct",
                new { controller = "Product", action = "ListProduct"  }
            );

            // Create Product
            context.MapRoute(
                "Admin_CreateProduct",
                "Admin/Admin/CreateProduct",
                new { controller = "Product", action = "CreateProduct"  }
            );

            // List Invoice
            context.MapRoute(
                "Admin_Invoice",
                "Admin/Admin/ListInvoice",
                new { controller = "Invoice", action = "ListInvoice" }
            );

            // List Invoice
            context.MapRoute(
                "Admin_User",
                "Admin/Admin/ListUser",
                new { controller = "User", action = "ListUser" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}