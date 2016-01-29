using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB2C.DTO
{
    public class  TarjetaDTO
    {
        public string nombreTitular { get; set; }
        public long numeroTarjeta { get; set; }
        public int codigoSeguridad { get; set; }
        public DateTime fechaExpiracion { get; set; }


    }
}
