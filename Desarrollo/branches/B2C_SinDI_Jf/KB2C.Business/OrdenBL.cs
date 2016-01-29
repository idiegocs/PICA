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
        public List<OrdenDTO> ConsultarOrdenesUsuario(int idOrden, ClienteDTO cliente, string estadoOrden)
        {
            List<OrdenDTO> lstOrdenes = null;
            OrdenDAL conOrden = new OrdenDAL();

            lstOrdenes = conOrden.ConsultarOrdenesUsuario(idOrden, cliente, estadoOrden);

            return lstOrdenes;
        }

        public List<EstadoOrdenDTO> getEstadoOrden() 
        {
            List<EstadoOrdenDTO> lstEstadosOrden = new List<EstadoOrdenDTO>();
            OrdenDAL conOrden = new OrdenDAL();

            lstEstadosOrden = conOrden.getEstadoOrden();

            return lstEstadosOrden;
        }
    }
}
