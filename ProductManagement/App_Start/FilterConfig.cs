using ProductManagement.Attributes;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ProductManagement
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {           
            // Not requred since exception filter will be registered through Autofac type registrations
            //filters.Add(new HandleErrorAttribute());
            
        }
    }
}
