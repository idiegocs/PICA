using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.Data;
using KB2C.DTO;

namespace KB2C.Business
{
    public class CategoriaBL
    {
        public List<CategoriesDTO> GetCat_SubCategories()
        {
            List<CategoriesDTO> lstCat_SubCat = new List<CategoriesDTO>();
            Category c = new Category();

            lstCat_SubCat = c.GetCat_SubCategories();

            return lstCat_SubCat;
        }
    }
}
