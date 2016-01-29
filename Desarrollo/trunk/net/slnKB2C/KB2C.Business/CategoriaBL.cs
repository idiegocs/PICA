using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.Data;
using KB2C.DTO;
using KB2C.Business.Interface;
using KB2C.Data.Interface;

namespace KB2C.Business
{
    public class CategoriaBL : IBusiness.ICategoriaBL
    {

        private IData.ICategoriaDAL _objCategoria;

        public CategoriaBL(IData.ICategoriaDAL objCategoria) 
        {
            _objCategoria = objCategoria;
        }

        public List<CategoriesDTO> GetCat_SubCategories()
        {
            /*
            List<CategoriesDTO> lstCat_SubCat = new List<CategoriesDTO>();
            Category c = new Category();

            lstCat_SubCat = c.GetCat_SubCategories();

            return lstCat_SubCat;
            */
            return _objCategoria.GetCat_SubCategories();
        }
    }
}
