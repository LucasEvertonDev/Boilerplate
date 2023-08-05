using Boilerplate.WebUi.Infra.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Boilerplate.WebUi.Infra.Attributes
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ISession session = filterContext.HttpContext.Session;
            // check  sessions here
            if (string.IsNullOrEmpty(session.Get<string>("UserId").ToString()))
            {
                filterContext.Result = new RedirectToActionResult("Login", "Account", new { });
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
