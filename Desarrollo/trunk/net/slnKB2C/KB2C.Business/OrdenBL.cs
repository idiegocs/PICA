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
    public class OrdenBL : IBusiness.IOrdenBL
    {
        private IData.IOrdenDAL _objOrden;

        public OrdenBL(IData.IOrdenDAL objOrden) 
        {
            _objOrden = objOrden;
        }

        public List<OrdenDTO> ConsultarOrdenesUsuario(int idOrden, ClienteDTO cliente, string estadoOrden)
        {
            /*
            List<OrdenDTO> lstOrdenes = null;
            Orden conOrden = new Orden();

            lstOrdenes = conOrden.ConsultarOrdenesUsuario(idOrden, cliente);

            return lstOrdenes;
            */
            return _objOrden.ConsultarOrdenesUsuario(idOrden, cliente, estadoOrden);
        }
    }
}
