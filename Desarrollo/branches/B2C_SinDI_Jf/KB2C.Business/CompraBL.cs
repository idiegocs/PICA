using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.Data;
using KB2C.DTO;

namespace KB2C.Business
{
    public class CompraBL
    {
        public EstadoCompraDTO registrarCompra(CompraDTO compraDTO)
        {
            EstadoCompraDTO resp=null;
            CompraDAL c = new CompraDAL();

            resp = c.SetCompra(compraDTO);

            return resp;

        }
    }
}
