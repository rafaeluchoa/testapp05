namespace Naskar.Architecture.Web.Interceptors
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    public class ValidateModelStateInterceptor : IActionFilter 
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var result = ValidateModelState(filterContext.Controller);
            if (result != null)
            {
                filterContext.Result = result;
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        private ActionResult ValidateModelState(ControllerBase controller)
        {
            ActionResult result = null;

            var viewData = controller.ViewData;

            if (!viewData.ModelState.IsValid) 
            {
                if (controller.ControllerContext.HttpContext.Request.IsAjaxRequest())
                {
                    var jsonResult = new JsonResult();
                    jsonResult.Data = new
                        {
                            validations = Errors(viewData.ModelState)
                        };

                    result = jsonResult;
                }
            }

            return result;
        }

        private IEnumerable Errors(ModelStateDictionary modelState)
        {
            return modelState.ToDictionary(
                kvp => kvp.Key.Replace('.', '_'), 
                kvp => kvp.Value.Errors
                    .Select(e => e.ErrorMessage).ToArray())
                    .Where(m => m.Value.Count() > 0);
        }
    }
}
