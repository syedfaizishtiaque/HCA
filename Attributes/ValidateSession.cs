using Microsoft.AspNetCore.Mvc.Filters;

namespace HCA.Attributes
{
    public class ValidateSession : ActionFilterAttribute
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        public ValidateSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //var httpContext = context.HttpContext;
            //if (httpContext.Session == null || !httpContext.Session.TryGetValue("AppSession", out _))
            //{
            //    context.Result = new RedirectToActionResult("Index", "LogIn", null);
            //}
            //else
            //{
            //    context.Result = new RedirectToActionResult("Index", "Home", null);
            //}
            var session = _httpContextAccessor.HttpContext.Session;

            // Example: Set session variable
            session.SetString("UserId", "123456");

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
