using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2C.Data;
using B2C.DTO;

namespace B2C.Business
{
    public class ProductoBL
    {
        public List<ProductosDTO> listaProductos(string tipoFiltro, string valorFiltro, int pagina) 
        {
            List<ProductosDTO> lstProductos = new List<ProductosDTO>();
            Producto p = new Producto();

            lstProductos = p.ConsultarProductos(tipoFiltro, valorFiltro, pagina);

            return lstProductos;
        }


    }
}
