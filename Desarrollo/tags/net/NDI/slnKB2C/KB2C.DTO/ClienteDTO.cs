using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB2C.DTO
{
    public class ClienteDTO
    {

        public string nombreUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public String correoElectronico { get; set; }
        public string telefono { get; set; }
        public virtual UbicacionDTO ubicacionCliente { get; set; }


    }
}
