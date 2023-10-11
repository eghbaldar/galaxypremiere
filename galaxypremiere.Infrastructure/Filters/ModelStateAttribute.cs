using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.Filters
{
    public class ModelStateAttribute :Attribute, IActionFilter   
    {
        // Before executing action
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ModelState.Remove("Password");
            if (!context.ModelState.IsValid)
            {                
                context.Result = new BadRequestObjectResult("Model is invalid!");
            }
        }
        // After executing action
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
