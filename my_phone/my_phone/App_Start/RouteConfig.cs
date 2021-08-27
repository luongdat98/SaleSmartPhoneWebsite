using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace my_phone
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            // Trang List Product by Category
            routes.MapRoute(
                name: "List Product from Category",
                url: "client/categorygrid",
                defaults: new { controller = "Client", action = "CategoryGrid" }
            );
            // Trang Single Product
            routes.MapRoute(
                name: "Single Product",
                url: "client/singleproduct/{id}",
                defaults: new { controller = "Client", action = "SingleProduct", id = UrlParameter.Optional }
            );

            // Trang  Cart
            routes.MapRoute(
                name: "Cart",
                url: "addcart",
                defaults: new { controller = "Cart", action = "AddCart", id = UrlParameter.Optional }
            );

            // Trang index client
            routes.MapRoute(
                name: "Client",
                url: "client/index",
                defaults: new { controller = "Client", action = "Index" }
            );

            // Trang index client
            routes.MapRoute(
                name: "Login",
                url: "client/login",
                defaults: new { controller = "Client", action = "Login" }
            );
            routes.MapRoute(
                name: "Register",
                url: "client/register",
                defaults: new { controller = "Client", action = "Register" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
