using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navigation.Common.Mvc.Filter;
using Navigation.Services;

namespace Navigation.Controllers
{
    [CheckUserLoginFilter]
    public class NavigateController
    {
        #region 初始化

        private readonly CategoryServices _categoryServices;
        private readonly NavigateServices _navigateServices;

        public NavigateController(CategoryServices categoryServices, NavigateServices navigateServices)
        {
            _categoryServices = categoryServices;
            _navigateServices = navigateServices;
        }

        #endregion


    }
}
