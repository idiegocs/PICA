using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;
using KB2C.DTO;

namespace KB2C.Data
{
    public class ProductoDAL
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
                Console.WriteLine("Error en Web service Productos: "
                 + e.Message);

                throw new Exception("Error - WebService Productos");
            }


            return lstProductos;

        }// end public List<ProductosDTO> ConsultarProductos

        public List<ProductoTop5DTO> consultarTop5(int IdProductoPadre) 
        {
            Parametros p = new Parametros();
            ProductoTop5DTO pro;
            List<ProductoTop5DTO> listaTop5 = new List<ProductoTop5DTO>();
            
            using (OracleConnection con = new OracleConnection(p.oracleConnString().ToString()))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "P_GET_TOP5_PRODUCTOS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IDPRODUCTO_PADRE", OracleDbType.Int32,ParameterDirection.Input).Value = IdProductoPadre;
                cmd.Parameters.Add("PRODUCTOS", OracleDbType.RefCursor, ParameterDirection.Output);

                con.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pro = new ProductoTop5DTO();
                    pro.idProductoPadre = Convert.ToInt32(reader[0]);
                    pro.idProducto = Convert.ToInt32(reader[1]);
                    pro.cantOrdenesJuntos = Convert.ToInt32(reader[2]);
                    listaTop5.Add(pro);
                }
                con.Close();
                con.Dispose();
            }
            return listaTop5;
        }

    }
}
