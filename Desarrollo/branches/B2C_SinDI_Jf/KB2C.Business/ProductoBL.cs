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
            ProductoDAL p = new ProductoDAL();

            lstProductos = p.ConsultarProductos(tipoFiltro, valorFiltro, pagina);

            return lstProductos;
            
        }

        public List<ProductoTop5DTO> consultarTop5(int IdProductoPadre) 
        {
            List<ProductoTop5DTO> lstProductos = new List<ProductoTop5DTO>();
            ProductoDAL p = new ProductoDAL();

            lstProductos = p.consultarTop5(IdProductoPadre);

            return lstProductos;

        }

    }
}
