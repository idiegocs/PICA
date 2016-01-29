using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.Data;
using KB2C.DTO;

namespace KB2C.Business
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
