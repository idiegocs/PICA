using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.Data;
using KB2C.DTO;

namespace KB2C.Business
{
    public class OrdenBL
    {
        public List<OrdenDTO> ConsultarOrdenesUsuario(int idOrden, ClienteDTO cliente)
        {
            List<OrdenDTO> lstOrdenes = null;
            Orden conOrden = new Orden();

            lstOrdenes = conOrden.ConsultarOrdenesUsuario(idOrden, cliente);

            return lstOrdenes;
        }
    }
}
