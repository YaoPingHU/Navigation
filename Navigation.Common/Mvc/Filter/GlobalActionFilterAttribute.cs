using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Navigation.Common.Mvc.Filter
{
    public class GlobalActionFilterAttribute : ActionFilterAttribute
    {


        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            if (actionContext.Request.Method != HttpMethod.Post || actionContext.Request.Method != HttpMethod.Put) { return; }

            var passby = actionContext.ActionDescriptor.GetCustomAttributes<PassModelStateValidationAttribute>().Any() ||
                  actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<PassModelStateValidationAttribute>().Any();

            if (passby) return;

            if (!actionContext.ModelState.IsValid)
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);

        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public sealed class PassModelStateValidationAttribute : Attribute
    {
        //[PassModelStateValidation]
    }


}
