using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2C.DTO;

namespace B2C.Data
{
    public class Producto
    {

        public List<ProductosDTO> ConsultarProductos(string tipoFiltro, string valorFiltro, int pagina)
        {
            ServiceProductos.ConsultaProductoEntrada entrada = new ServiceProductos.ConsultaProductoEntrada();
            ServiceProductos.Filtro filtro = new ServiceProductos.Filtro();

            filtro.tipoFiltro = tipoFiltro;
            filtro.valorFiltro = valorFiltro;
            filtro.pagina = pagina;

            entrada.filtroProducto = filtro;

            ServiceProductos.ProductosPortClient clienteWs = new ServiceProductos.ProductosPortClient();
            ServiceProductos.ConsultaProductoSalida salida;

            salida = clienteWs.ConsultarProductos(entrada);
            List<ProductosDTO> lstProductos = new List<ProductosDTO>();

            foreach(var item in salida.listaProductos)
            {
                ProductosDTO prod = new ProductosDTO();

                prod.idProducto = item.idProducto;
                prod.idProductoSpecified = item.idProductoSpecified;
                prod.codigoProducto = item.codigoProducto;
                prod.nombreProducto = item.nombreProducto;
                prod.descripcionProducto = item.descripcionProducto;
                prod.nombreImagenProducto = item.nombreImagenProducto;
                prod.fabricanteProducto = item.fabricanteProducto;
                prod.idSubcategoria = item.tipoProducto.subCategoria.idTipo;
                prod.precioProducto = item.precioProducto;
                prod.nombreCategoria = item.tipoProducto.categoria.nombreTipo;
                prod.nombreSubcategoria = item.tipoProducto.subCategoria.nombreTipo;

                lstProductos.Add(prod);
            }

            return lstProductos;
                        
        }
       
    }
}
