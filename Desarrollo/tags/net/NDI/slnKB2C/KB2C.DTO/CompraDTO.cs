using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB2C.DTO
{
    public class CompraDTO
    {

        public TarjetaDTO tarjeta { get; set; }
        public bool envioTitular { get; set; }
        public ClienteDTO usuarioEnvio { get; set; }
        public OrdenDTO ordenCompra { get; set; }
        
        
    }

    public class EstadoCompraDTO
    {
     
        public string IdPreOrden { get; set; }
        public bool EstadoTarjeta { get; set; }
    }
}
