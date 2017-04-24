using System.Net;
using System.Net.Http;
using System.Web.Http;
using Navigation.Common.Helper;
using Navigation.Model;

namespace Navigation.Controllers
{
    public class BaseApiController : ApiController
    {
        #region ApiResult

        public ApiResult ApiResult { get; set; }

        #endregion

        #region MyRegion

        // public UserInfo CurrentUser => SessionHelper.Get<UserInfo>(Collections.User);

        public  UserInfo CurrentUser => new UserInfo { UserId = 1, UserName = "Hubert.Hu", Phone = "13439757559" };

        #endregion

        #region NotFound

        [NonAction]
        protected HttpResponseMessage NotFound(string msg = "", int code = 404)
        {
            if (ApiResult == null) ApiResult = new ApiResult();

            ApiResult.Code = code;
            ApiResult.Message = msg;

            return Request.CreateResponse(HttpStatusCode.NotFound, ApiResult);
        }

        #endregion

        #region Ok

        [NonAction]
        protected HttpResponseMessage Ok(object obj, string msg = "")
        {
            if (ApiResult == null) ApiResult = new ApiResult();

            ApiResult.Result = true;
            ApiResult.Code = 0;
            ApiResult.Message = msg;
            ApiResult.Data = obj;

            return Request.CreateResponse(HttpStatusCode.OK, ApiResult);
        }

        #endregion

        #region Bad

        [NonAction]
        protected HttpResponseMessage Bad(string msg = "", int code = 100)
        {
            if (ApiResult == null) ApiResult = new ApiResult();

            ApiResult.Code = code;
            ApiResult.Message = msg;

            return Request.CreateResponse(HttpStatusCode.OK, ApiResult);
        }

        #endregion

        #region BadParam

        [NonAction]
        protected HttpResponseMessage BadParam(string message = "参数错误")
        {
            if (ApiResult == null) ApiResult = new ApiResult();

            ApiResult.Code = -1;
            ApiResult.Message = message;

            return Request.CreateResponse(HttpStatusCode.OK, ApiResult);
        }
        #endregion

        #region Unauthorized

        [NonAction]
        protected HttpResponseMessage Unauthorized(string msg)
        {
            if (ApiResult == null) ApiResult = new ApiResult();

            ApiResult.Code = 401;
            ApiResult.Message = msg;

            return Request.CreateResponse(HttpStatusCode.Unauthorized, msg);
        }

        #endregion

        #region Exception

        [NonAction]
        protected HttpResponseException Exception(string ex)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(ex),
                ReasonPhrase = "UnexpectedError",
            };

            throw new HttpResponseException(resp);

        }

        #endregion

    }
}
