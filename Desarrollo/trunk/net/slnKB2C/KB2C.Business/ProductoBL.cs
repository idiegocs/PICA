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
    public class ProductoBL : IBusiness.IProductoBL
    {

        private IData.IProductoDAL _objProducto;

        public ProductoBL(IData.IProductoDAL objProducto) 
        {
            _objProducto = objProducto;
        }

        public List<ProductosDTO> listaProductos(string tipoFiltro, string valorFiltro, int pagina)
        {
            /*
            List<ProductosDTO> lstProductos = new List<ProductosDTO>();
            Producto p = new Producto();

            lstProductos = p.ConsultarProductos(tipoFiltro, valorFiltro, pagina);

            return lstProductos;
            */
            return _objProducto.ConsultarProductos(tipoFiltro, valorFiltro, pagina);
        }

        public List<ProductoTop5DTO> consultarTop5(int IdProductoPadre) 
        {
            return _objProducto.consultarTop5(IdProductoPadre);
        }

        //public List<ProductosDTO> ConsultarProductosDetalle(string vTipoFiltro, string vValorFiltro)
        //{
        //    return _objProducto.ConsultarProductosDetalle(vTipoFiltro, vValorFiltro);
        //}

    }
}
