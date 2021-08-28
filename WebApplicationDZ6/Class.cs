using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;


namespace WebApplicationDZ6
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
    public class Class : Attribute, IAuthorizationFilter
    {
        public Class(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string name = "MathAddResult";
            var arg1 = Configuration.GetSection("Custom section:arg1").Value;
            var arg2 = Configuration.GetSection("Custom section:arg2").Value;
            context.HttpContext.Response.Cookies.Append(arg1, arg1);
            context.HttpContext.Response.Cookies.Append(arg2, arg2);
            var header = Configuration.GetSection("Custom section:MathAddResult").Value;
            context.HttpContext.Response.Headers.Add(name, header);
            int first = int.Parse(arg1);
            int second = int.Parse(arg2);
            int headervaluenumber = int.Parse(header);
            if (first + second == headervaluenumber)
            {
                Console.WriteLine("Success request");
            }
            else
            {
                throw new Exception("Not valid request");
            }
           

        }
    }
}
