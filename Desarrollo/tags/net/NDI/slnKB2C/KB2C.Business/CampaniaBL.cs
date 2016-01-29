using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.Data;
using KB2C.DTO;

namespace KB2C.Business
{
    public class CampaniaBL
    {
        public List<CampaniasDTO> listaCampanias()
        {
            List<CampaniasDTO> lstDeals = new List<CampaniasDTO>();
            Campania p = new Campania();

            lstDeals = p.GetCampanias();

            return lstDeals;
        }
    }
}
