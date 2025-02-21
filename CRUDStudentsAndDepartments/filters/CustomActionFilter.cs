using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDStudentsAndDepartments.filters
{
    public class CustomActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.ExceptionHandled = true; 
            context.Result = new ContentResult()
            {
                Content = "ops there was an error"
            };
        }

        
    }
}
