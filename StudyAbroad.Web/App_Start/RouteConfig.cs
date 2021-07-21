using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudyAbroad.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "Contact",
                 url: "lien-he",
                 defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                      namespaces: new[] { "StudyAbroad.Web.Controllers" }
              );

            routes.MapRoute(
                 name: "Register",
                 url: "dang-ky",
                 defaults: new { controller = "Home", action = "CustomerRegister", id = UrlParameter.Optional },
                      namespaces: new[] { "StudyAbroad.Web.Controllers" }
              );
            routes.MapRoute(
                name: "Procedure",
                url: "quy-trinh-tuyen-dung",
                defaults: new { controller = "Home", action = "Procedure", id = UrlParameter.Optional },
                     namespaces: new[] { "StudyAbroad.Web.Controllers" }
             );
            routes.MapRoute(
                name: "Home",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                     namespaces: new[] { "StudyAbroad.Web.Controllers" }
             );
            routes.MapRoute(
               name: "WhyChooseMe",
               url: "vi-sao-chon-chung-toi",
               defaults: new { controller = "Home", action = "WhyChooseUs", id = UrlParameter.Optional },
                    namespaces: new[] { "StudyAbroad.Web.Controllers" }
            );

            routes.MapRoute(
              name: "About",
              url: "ve-jvnet",
              defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                   namespaces: new[] { "StudyAbroad.Web.Controllers" }
           );

            routes.MapRoute(
                name: "Program",
                url: "chuong-trinh-dich-vu",
                defaults: new { controller = "Program", action = "Index", id = UrlParameter.Optional },
                     namespaces: new[] { "StudyAbroad.Web.Controllers" }
             );

            routes.MapRoute(
                name: "Order",
                url: "don-hang-di-nhat",
                defaults: new { controller = "Order", action = "Order", id = UrlParameter.Optional },
                     namespaces: new[] { "StudyAbroad.Web.Controllers" }
             );

            routes.MapRoute(
              name: "News",
              url: "tin-tuc-su-kien",
              defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional },
                   namespaces: new[] { "StudyAbroad.Web.Controllers" }
           );

            routes.MapRoute(
               name: "DetailOrder",
               url: "don-hang/chi-tiet/{id}",
               defaults: new { controller = "Order", action = "OrderDetail", id = UrlParameter.Optional },
                   namespaces: new[] { "StudyAbroad.Web.Controllers" }
           );

            routes.MapRoute(
              name: "NewsOrder",
              url: "tin-tuc-su-kien/chi-tiet/{id}",
              defaults: new { controller = "News", action = "NewsDetail", id = UrlParameter.Optional },
                   namespaces: new[] { "StudyAbroad.Web.Controllers" }
          );

            routes.MapRoute(
             name: "ProgremOrder",
             url: "chuong-trinh-dich-vu/chi-tiet/{id}",
             defaults: new { controller = "Program", action = "ProgramDetail", id = UrlParameter.Optional },
                   namespaces: new[] { "StudyAbroad.Web.Controllers" }
         );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                  namespaces: new[] { "StudyAbroad.Web.Controllers" }
            );
        }
    }
}
