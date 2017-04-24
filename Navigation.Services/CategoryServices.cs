using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Navigation.Common.Sugar;
using Navigation.Model;
using SqlSugar;

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


        public Category Select_Category(int categoryId)
        {
            return _dbservice.Queryable<Category>().Where(o => o.CategoryId == categoryId).FirstOrDefault();
        }

        public virtual List<Category> Select_Category(Expression<Func<Category, bool>> filter)
        {
            return _dbservice.Queryable<Category>().Where(filter).OrderBy(o => o.Sort, OrderByType.Desc).ToList();
        }

        public int Select_CategoryCount(Expression<Func<Category, bool>> filter)
        {
            return _dbservice.Queryable<Category>().Where(filter).Count();
        }

        #endregion

        #region 修改



        #endregion

        #region 删除

        public bool Delete_Category(int categoryId)
        {
            try
            {
                _dbservice.BeginTran();
                _dbservice.Delete<Navigate>(o => o.CategoryId == categoryId);
                _dbservice.Delete<Category>(o => o.CategoryId == categoryId);
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
