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
    public class CampaniaBL : IBusiness.ICampaniaBL
    {

        private IData.ICampaniaDAL _objCampania;

        public CampaniaBL(IData.ICampaniaDAL objCampania) 
        {
            _objCampania = objCampania;
        }

        public List<CampaniasDTO> listaCampanias()
        {
            /*
            List<CampaniasDTO> lstDeals = new List<CampaniasDTO>();
            Campania p = new Campania();

            lstDeals = p.GetCampanias();

            return lstDeals;
            */
            return _objCampania.GetCampanias();
        }
    }
}
