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
using Navigation.Model;
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

        #region 创建分类

        [HttpPost]
        [Route("Categroy")]
        public HttpResponseMessage PostCreateCategory(int fatherCategoryId, string categoryName, int sort, string ico)
        {
            if (categoryName.IsNullOrEmpty() || !ValidateHelper.IsNormalInput(categoryName)) return BadParam("分类目录名称不能为空或特殊字符");
            if (sort < 0) return BadParam("排序不能为负数"); sort = 100;

            var count = _categoryServices.Select_CategoryCount(o => o.UserId == CurrentUser.UserId && o.CategoryName == categoryName);
            if (count != 0) return Bad("分类目录名称已存在");

            var category = new Category
            {
                CategoryName = categoryName,
                FatherCategoryId = fatherCategoryId,
                Sort = sort,
                HaveSub = false,
                UserId = CurrentUser.UserId,
                Ico = ico,
                ModifiedOn = DateTime.Now
            };

            var result = _categoryServices.Insert_Category(category);
            return Ok(result);
        }


        #endregion

        #region 修改分类

        [HttpPost]
        [Route("Categroy/Edit")]
        public HttpResponseMessage EditCategory(int categoryId, int fatherCategoryId, string categoryName, int sort, string ico)
        {
            if (categoryName.IsNullOrEmpty() || !ValidateHelper.IsNormalInput(categoryName)) return BadParam("分类目录名称不能为空或特殊字符");
            if (sort < 0) return BadParam("排序不能为负数"); sort = 100;

            var count = _categoryServices.Select_CategoryCount(o => o.UserId == CurrentUser.UserId && o.CategoryId != categoryId && o.CategoryName == categoryName);
            if (count != 0) return Bad("分类目录名称已存在");

            var category = _categoryServices.Select_Category(categoryId);
            if (category == null) return Bad("分类目录不存在");

            category.FatherCategoryId = fatherCategoryId;
            category.CategoryName = categoryName;
            category.Sort = sort;
            category.Ico = ico;

            var result = _categoryServices.Update_Category(categoryId, CurrentUser.UserId, new
            {
                FatherCategoryId = fatherCategoryId,
                CategoryName = categoryName,
                Sort = sort,
                Ico = ico,
                ModifiedOn = DateTime.Now
            });

            return Ok(result);
        }

        #endregion

        #region 删除分类

        public HttpResponseMessage DeleteCategory(int categoryId)
        {
            var result = _categoryServices.Delete_Category(categoryId, CurrentUser.UserId);
            return Ok(result);
        }

        #endregion

        #region 获取所有分类

        [HttpGet]
        [Route("Category")]
        public HttpResponseMessage GetCategory()
        {
            var t = _categoryServices.Select_Category(o => o.UserId == CurrentUser.UserId);
            return Ok(t);
        }

        [HttpGet]
        [Route("Category/{categoryId}")]
        public HttpResponseMessage GetCategory(int categoryId)
        {
            var t = _categoryServices.Select_Category(o => o.UserId == CurrentUser.UserId && o.CategoryId == categoryId);
            return Ok(t);
        }

        #endregion

    }
}
