using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Hubert.Utility.Lite.Extension;
using Hubert.Utility.Lite.Helper;
using Navigation.Common.Mvc.Filter;
using Navigation.Services;

namespace Navigation.Controllers
{
    [CheckUserLoginFilter]
    public class CategoryController : BaseApiController
    {

        #region 初始化

        private readonly CategoryServices _categoryServices;
        private readonly NavigateServices _navigateServices;

        public CategoryController(CategoryServices categoryServices, NavigateServices navigateServices)
        {
            _categoryServices = categoryServices;
            _navigateServices = navigateServices;
        }

        #endregion

        #region 检查分类名称是否存在

        /// <summary>
        /// 检查分类名称是否存在
        /// </summary>
        /// <param name="categoryName">分类名称</param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckExistCategoryName/{categoryName}")]
        public HttpResponseMessage GetCheckExistCategoryName(string categoryName)
        {
            if (categoryName.IsNullOrEmpty() || !ValidateHelper.IsNormalInput(categoryName)) return BadParam("分类目录名称不能为空或特殊字符");
            var count = _categoryServices.Select_CategoryCount(o => o.UserId == CurrentUser.UserId && o.CategoryName == categoryName);

            return Ok(count == 0);
        }

        /// <summary>
        /// 检查分类名称是否存在
        /// </summary>
        /// <param name="categoryId">分类编号</param>
        /// <param name="categoryName">分类名称</param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckExistCategoryName/{categoryName}/{categoryId}")]
        public HttpResponseMessage GetCheckExistCategoryName(int categoryId, string categoryName)
        {
            if (categoryName.IsNullOrEmpty() || !ValidateHelper.IsNormalInput(categoryName)) return BadParam("分类目录名称不能为空或特殊字符");
            var count = _categoryServices.Select_CategoryCount(o => o.UserId == CurrentUser.UserId && o.CategoryId != categoryId && o.CategoryName == categoryName);

            return Ok(count == 0);
        }

        #endregion






    }
}
