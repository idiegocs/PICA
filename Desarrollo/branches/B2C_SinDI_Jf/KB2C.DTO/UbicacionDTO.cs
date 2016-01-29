using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB2C.DTO
{
    public class UbicacionDTO
    {

        public string numeroDireccion { get; set; }
        public string nombreCiudad { get; set; }
        public int idCiudad { get; set; }
        public string nombreDepartamento { get; set; }
        public int idDepartamento { get; set; }
        public string nombrePais { get; set; }
        public int idPais { get; set; }
    }

    public class PaisDTO 
    {
        public int idPais { get; set; }
        public string nombrePais { get; set; }
    }

    public class DepartamentoDTO 
    {
        public int idDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
        public int idPais { get; set; }
    }

    public class CiudadDTO 
    {
        public int idCiudad { get; set; }
        public string nombreCiudad { get; set; }
        public int idDepartamento { get; set; }
    }
}
