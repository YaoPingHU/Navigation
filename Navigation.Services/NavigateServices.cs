using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Navigation.Common.Sugar;
using Navigation.Model;
using SqlSugar;

namespace Navigation.Services
{
    public class NavigateServices
    {

        #region 初始化

        private readonly SqlSugarClient _dbservice;

        public NavigateServices(DbService dbService)
        {
            _dbservice = dbService.Db;
        }

        #endregion

        #region Navigate

        #region 增加

        public bool Insert_Category(Navigate navigate)
        {
            return _dbservice.Insert(navigate).ObjToInt() > 0;
        }

        #endregion

        #region 查询


        public Navigate Select_Category(int categoryId)
        {
            return _dbservice.Queryable<Navigate>().Where(o => o.CategoryId == categoryId).FirstOrDefault();
        }

        public virtual List<Navigate> Select_Category(Expression<Func<Navigate, bool>> filter)
        {
            return _dbservice.Queryable<Navigate>().Where(filter).OrderBy(o => o.Sort, OrderByType.Desc).ToList();
        }

        public int Select_CategoryCount(Expression<Func<Navigate, bool>> filter)
        {
            return _dbservice.Queryable<Navigate>().Where(filter).Count();
        }

        #endregion

        #region 修改



        #endregion

        #region 删除

        public bool Delete_Navigate(int navId)
        {
            return _dbservice.Delete<Navigate>(o => o.NavId == navId);
        }

        #endregion

        #endregion


    }
}
