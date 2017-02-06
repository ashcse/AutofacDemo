using Autofac.Extras.NLog;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Attributes
{
    /// <summary>
    /// Action filter attributes are instantiated by CLR hence its construction can't be intercepted. We can't rely on Dependency Injection
    /// Containers to instantiated attributes (using constructor injection).
    /// </summary>
    public class LoggingExceptionFilter : System.Web.Mvc.IExceptionFilter
    {
        public ILogger _logger { get; set; }

        public LoggingExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }              
       
        public void OnException(ExceptionContext filterContext)
        {
            _logger.Error(GetMessageFromException(filterContext.Exception));

        }        

        private string GetMessageFromException( Exception exc)
        {
            StringBuilder strBuilder = new StringBuilder();
            Exception inner = exc.InnerException;

            while(inner != null)
            {
                if(!string.IsNullOrEmpty( inner.Message))
                {
                    strBuilder.Append(inner.Message);
                    strBuilder.Append(Environment.NewLine);
                }

                inner = inner.InnerException;
            }

            strBuilder.Append(Environment.NewLine);
            strBuilder.Append(exc.StackTrace);

            return strBuilder.ToString();
        }
    }
}
