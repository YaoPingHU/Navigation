using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Navigation.Common.Sugar;
using Navigation.Model;
using SqlSugar;
using Navigation.Common.Extension;
using Navigation.Model.ViewModel;

namespace Navigation.Services
{
    public class CategoryServices
    {
        #region 初始化

        private readonly SqlSugarClient _dbservice;

        public CategoryServices(DbService dbService)
        {
            _dbservice = dbService.Db;
        }

        #endregion

        #region Category

        #region 增加

        public bool Insert_Category(Category category)
        {
            return _dbservice.Insert(category).ObjToInt() > 0;
        }

        #endregion

        #region 查询


        public CategoryModel Select_Category(int categoryId)
        {
            return _dbservice.Queryable<Category>().Where(o => o.CategoryId == categoryId).FirstOrDefault().MapperTo<Category, CategoryModel>();
        }


        public virtual List<CategoryModel> Select_Category(Expression<Func<Category, bool>> filter)
        {
            return _dbservice.Queryable<Category>().Where(filter).OrderBy(o => o.Sort, OrderByType.Desc).ToList().MapperTo<Category, CategoryModel>();
        }

        public int Select_CategoryCount(Expression<Func<Category, bool>> filter)
        {
            return _dbservice.Queryable<Category>().Where(filter).Count();
        }

        #endregion

        #region 修改

        public bool Update_Category(int categoryId, int userId, object t)
        {
            return _dbservice.Update<Category>(t, o => o.CategoryId == categoryId && o.UserId == userId);
        }

        #endregion

        #region 删除

        public bool Delete_Category(int categoryId, int userId)
        {
            try
            {
                _dbservice.BeginTran();
                _dbservice.Delete<Navigate>(o => o.CategoryId == categoryId && o.UserId == userId);
                _dbservice.Delete<Category>(o => o.CategoryId == categoryId && o.UserId == userId);
                _dbservice.CommitTran();
                return true;
            }
            catch
            {
                _dbservice.RollbackTran();
                return false;
            }
        }

        #endregion

        #endregion

    }
}
