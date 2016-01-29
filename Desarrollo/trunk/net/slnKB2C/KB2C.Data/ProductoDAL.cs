using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using KB2C.DTO;
using KB2C.Data.Interface;

namespace KB2C.Data
{
    public class ProductoDAL : IData.IProductoDAL
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
                //OracleCommand cmd = new OracleCommand();
                //cmd.Connection = con;
                //cmd.CommandText = "P_GET_TOP5_PRODUCTOS";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("IDPRODUCTO_PADRE", OracleDbType.Int32,ParameterDirection.Input).Value = IdProductoPadre;
                //cmd.Parameters.Add("PRODUCTOS", OracleDbType.RefCursor, ParameterDirection.Output);

                con.Open();
                
                //OracleDataReader reader = cmd.ExecuteReader();

                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT IDPRODUCTO_PADRE, IDPRODUCTO, CANT_ORDENES FROM PRODUCTOS_TOP5 WHERE IDPRODUCTO_PADRE = " + IdProductoPadre.ToString() + " ORDER BY CANT_ORDENES DESC";

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pro = new ProductoTop5DTO();
                        pro.idProductoPadre = Convert.ToInt32(reader[0]);
                        pro.idProducto = Convert.ToInt32(reader[1]);
                        pro.cantOrdenesJuntos = Convert.ToInt32(reader[2]);
                        listaTop5.Add(pro);
                    }
                }
                
                con.Close();
                con.Dispose();
            }
            return listaTop5;
        }

        //public List<ProductosDTO> ConsultarProductosDetalle(string vTipoFiltro, string vValorFiltro)
        //{
        //    Parametros p = new Parametros();
        //    List<ProductosDTO> lstProductos = new List<ProductosDTO>();
            
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(p.prodConnString().ToString()))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("producto.getDetalleProducto", con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Parameters.Add("@parTipoFiltro", SqlDbType.VarChar).Value = vTipoFiltro;
        //                cmd.Parameters.Add("@parValorFiltro", SqlDbType.VarChar).Value = vValorFiltro;

        //                con.Open();
        //                //cmd.ExecuteNonQuery();

        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        ProductosDTO prod = new ProductosDTO();

        //                        prod.idProducto = (Convert.ToInt64(reader[0]) == null ? -1 : Convert.ToInt64(reader[0]));
        //                        prod.codigoProducto = (Convert.ToString(reader[1]) == null ? "" : Convert.ToString(reader[1]));
        //                        prod.nombreProducto = (Convert.ToString(reader[2]) == null ? "" : Convert.ToString(reader[2]));
        //                        prod.descripcionProducto = (Convert.ToString(reader[3]) == null ? "" : Convert.ToString(reader[3]));
        //                        prod.nombreImagenProducto = (Convert.ToString(reader[4]) == null ? "" : Convert.ToString(reader[4]));
        //                        prod.fabricanteProducto = (Convert.ToString(reader[5]) == null ? "" : Convert.ToString(reader[5]));
        //                        prod.precioProducto = (reader[6] == null ? -1 : (float)Convert.ToDouble(reader[6]));
        //                        prod.idSubcategoria = (Convert.ToInt32(reader[7]) == null ? -1 : Convert.ToInt32(reader[7]));
        //                        //prod.nombreSubcategoria = (Convert.ToString(reader[8]) == null ? "" : Convert.ToString(reader[8]));
        //                        //prod.nombreCategoria = (Convert.ToString(reader[9]) == null ? "" : Convert.ToString(reader[9]));
        //                        //prod.idCategoria = (Convert.ToInt32(reader[10]) == null ? -1 : Convert.ToInt32(reader[10]));
                                
        //                        lstProductos.Add(prod);
        //                    }
        //                }

        //            }

        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error en Web service Detalle Productos: "
        //         + e.Message);

        //        throw new Exception("Error - WebService Detalle Productos");
        //    }
            
        //    return lstProductos;

        //}// end public List<ProductosDTO> ConsultarProductosDetalle

    }
}
