using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiCatalogo.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //apos
            //throw new NotImplementedException();

            _logger.LogInformation("executando OnActionExecuted");

            _logger.LogInformation("####################################");

            _logger.LogInformation("");


            _logger.LogInformation("####################################");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //antes
            //throw new NotImplementedException();
            _logger.LogInformation("### executando ActionExecuting ###");

            _logger.LogInformation("####################################");


            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");

            _logger.LogInformation($"Status code: {context.HttpContext.Response.StatusCode}");

            _logger.LogInformation("####################################");
        }


    }
}