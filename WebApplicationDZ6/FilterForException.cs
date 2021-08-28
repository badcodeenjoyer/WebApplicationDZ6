using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using  WebApplicationDZ6.Controllers;

namespace WebApplicationDZ6
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
    public class FilterForException : Attribute, IExceptionFilter 
    {
        
        private readonly ILogger<FilterForException> logger;

        public FilterForException(ILogger<FilterForException> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
           
            if (context.Exception != null)
            {
                logger.LogError(context.Exception, "Exception handled");
                context.ExceptionHandled = true;
               
                Console.WriteLine("---------------------------------------***************************************************");
                

            }
            logger.LogInformation("FilterForException.OnException");
            Console.WriteLine(".............................-------------------------------");


        }
    }
}
