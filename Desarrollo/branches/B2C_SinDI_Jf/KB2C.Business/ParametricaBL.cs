using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.DTO;
using KB2C.Data;

namespace KB2C.Business
{
    public class ParametricaBL
    {
        public List<PaisDTO> getPais()
        {
            ParametricaDAL pais = new ParametricaDAL();
            return pais.getPais();
        }

        public List<DepartamentoDTO> getDepartamento(int idPais = -1)
        {
            ParametricaDAL depar = new ParametricaDAL();
            return depar.getDepartamento(idPais);
        }

        public List<CiudadDTO> getCiudad(int idDepartamento = -1)
        {
            ParametricaDAL ciudad = new ParametricaDAL();
            return ciudad.getCiudad(idDepartamento);
        }
    }
}
