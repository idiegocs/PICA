using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.DTO;

namespace KB2C.Data
{
    public class Producto
    {

        public List<ProductosDTO> ConsultarProductos(string tipoFiltro, string valorFiltro, int pagina)
        {
            ServiceProductos.ConsultaProductoEntrada entrada = new ServiceProductos.ConsultaProductoEntrada();
            ServiceProductos.Filtro filtro = new ServiceProductos.Filtro();
            List<ProductosDTO> lstProductos = null;
            try
            {
                filtro.tipoFiltro = tipoFiltro;
                filtro.valorFiltro = valorFiltro;
                filtro.pagina = pagina;

                entrada.filtroProducto = filtro;

                ServiceProductos.ProductosPortClient clienteWs = new ServiceProductos.ProductosPortClient();
                ServiceProductos.ConsultaProductoSalida salida;

                salida = clienteWs.ConsultarProductos(entrada);
               lstProductos = new List<ProductosDTO>();

                foreach (var item in salida.listaProductos)
                {
                    ProductosDTO prod = new ProductosDTO();

                    prod.idProducto = item.idProducto;
                    prod.idProductoSpecified = item.idProductoSpecified;
                    prod.codigoProducto = item.codigoProducto;
                    prod.nombreProducto = item.nombreProducto;
                    prod.descripcionProducto = item.descripcionProducto;
                    prod.nombreImagenProducto = item.nombreImagenProducto;
                    prod.fabricanteProducto = item.fabricanteProducto;
                    prod.precioProducto = item.precioProducto;
                    if (item.tipoProducto != null && item.tipoProducto.subCategoria != null)
                    {
                        prod.idSubcategoria = item.tipoProducto.subCategoria.idTipo;
                        prod.nombreSubcategoria = item.tipoProducto.subCategoria.nombreTipo;
                    }
                    if (item.tipoProducto != null && item.tipoProducto.categoria != null)
                    {
                        prod.nombreCategoria = item.tipoProducto.categoria.nombreTipo;
                        prod.nombreSubcategoria = item.tipoProducto.subCategoria.nombreTipo;
                    }

                    lstProductos.Add(prod);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Errror en Web service Productos: "
                 + e.Message);

                throw new Exception("Error - WebService Productos");
            }


            return lstProductos;

        }

    }
}
