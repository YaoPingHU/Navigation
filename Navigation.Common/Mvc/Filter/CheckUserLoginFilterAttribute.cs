using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Navigation.Common.Helper;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Navigation.Common.Mvc.Filter
{
    public class CheckUserLoginFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!SessionHelper.CheckSessionExist("User")) return;
            
            var apiResult = new ApiResult
            {
                Result = false,
                Code = 401,
                Message = "请先登录"
            };

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, apiResult);
        }

        public class ApiResult
        {
            public bool Result { get; set; }
            public int Code { get; set; }
            public string Message { get; set; }
            public object Data { get; set; }
        }

    }
}
