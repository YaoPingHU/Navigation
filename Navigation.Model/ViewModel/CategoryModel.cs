using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.Model.ViewModel
{

    public class CategoryModel
    {
        public int CategoryId { get; set; } 

        public int FatherCategoryId { get; set; } 

        public string CategoryName { get; set; }

        public bool HaveSub { get; set; } 

        public int Sort { get; set; } 

        public string Ico { get; set; } 

    }
}
