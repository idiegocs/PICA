using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.DTO;
using Oracle.ManagedDataAccess.Client;

namespace KB2C.Data
{
    public class OrdenDAL
    {
        //
        public List<OrdenDTO> ConsultarOrdenesUsuario(int idOrden, ClienteDTO cliente, string estadoOrden)
        {
            List<OrdenDTO> lstOrdenes = null;
            
            ServiceOrdenes.ConsultaOrdenEntrada entrada = new ServiceOrdenes.ConsultaOrdenEntrada();

            try
            {
                entrada.idOrden = idOrden;
                entrada.idOrdenSpecified = true;
                entrada.estadoOrden = estadoOrden;

                if (cliente != null)
                {
                    entrada.cliente = new ServiceOrdenes.Usuario
                    {
                        nombre = cliente.nombre,
                        nombreUsuario = cliente.nombreUsuario,
                        //apellido = cliente.apellido,
                        //tipoDocumento = cliente.tipoDocumento,
                        //numeroDocumento = cliente.numeroDocumento,
                        correoElectronico = cliente.correoElectronico
                        //telefono = cliente.telefono,
                        //direccion = new ServiceOrdenes.Direccion 
                        //{
                        //numero = cliente.ubicacionCliente.numeroDireccion,
                        //ciudad = cliente.ubicacionCliente.nombreCiudad,
                        //departamento = cliente.ubicacionCliente.nombreDepartamento
                        //}
                    };
                }
                
                ServiceOrdenes.PortOrdenClient clienteWs = new ServiceOrdenes.PortOrdenClient();
                ServiceOrdenes.ConsultaOrdenSalida salida;

                salida = clienteWs.consultarOrden(entrada);
                lstOrdenes = new List<OrdenDTO>();

                foreach (var item in salida.listaOrdenes)
                {
                    OrdenDTO ord = new OrdenDTO();

                    ord.idOrden = item.idOrden;
                    ord.idPreOrden = item.idPreOrden;
                    ord.fechaOrden = item.fechaOrden;
                    ord.estadoOrden = item.estadoOrden;
                    ord.idEstadoOrden = item.idEstadoOrden;
                    ord.numeroItemsOrden = item.numeroItems;
                    ord.totalOrden = item.total;
                    
                    ClienteDTO cli = new ClienteDTO();
                    cli.nombre = (item.cliente.nombre == null ? "" : item.cliente.nombre);
                    cli.nombreUsuario = (item.cliente.nombreUsuario == null ? "" : item.cliente.nombreUsuario);
                    cli.apellido = item.cliente.apellido;
                    cli.tipoDocumento = item.cliente.tipoDocumento;
                    cli.numeroDocumento = item.cliente.numeroDocumento;
                    cli.correoElectronico = item.cliente.correoElectronico;
                    cli.telefono = item.cliente.telefono;

                    UbicacionDTO ubi = new UbicacionDTO();

                    if (item.cliente.direccion != null)
                    {
                        ubi.numeroDireccion = (item.cliente.direccion.numero == null ? "" : item.cliente.direccion.numero);
                        ubi.idCiudad = (item.cliente.direccion.idCiudad == null ? -1 : item.cliente.direccion.idCiudad);
                        ubi.nombreCiudad = (item.cliente.direccion.ciudad == null ? "" : item.cliente.direccion.ciudad);
                        ubi.idDepartamento = (item.cliente.direccion.idDepartamento == null ? -1 : item.cliente.direccion.idDepartamento);
                        ubi.nombreDepartamento = (item.cliente.direccion.departamento == null ? "" : item.cliente.direccion.departamento);
                    }
                    
                    cli.ubicacionCliente = ubi;

                    ord.usuarioOrden = cli;

                    List<ItemOrdenDTO> listaItemsOrden = new List<ItemOrdenDTO>();
                    ProductosDTO pro;

                    foreach (var itemOrden in item.listaItems)
                    {
                        ItemOrdenDTO io = new ItemOrdenDTO();
                        io.cantidadItem = itemOrden.cantidad;
                        io.tipo = itemOrden.tipo;
                        io.idCampania = itemOrden.idCampania;

                        pro = new ProductosDTO();

                        pro.idProducto = (itemOrden.producto.idProducto == null ? -1 : itemOrden.producto.idProducto);
                        pro.codigoProducto = (itemOrden.producto.codigoProducto == null ? "" : itemOrden.producto.codigoProducto);
                        pro.nombreProducto = (itemOrden.producto.nombreProducto == null ? "" : itemOrden.producto.nombreProducto);
                        pro.descripcionProducto = (itemOrden.producto.descripcionProducto == null ? "" : itemOrden.producto.descripcionProducto);
                        pro.fabricanteProducto = (itemOrden.producto.fabricanteProducto == null ? "" : itemOrden.producto.fabricanteProducto);
                        pro.nombreImagenProducto = (itemOrden.producto.nombreImagenProducto == null ? "" : itemOrden.producto.nombreImagenProducto);
                        pro.precioProducto = (itemOrden.producto.precioProducto == null ? 0 : itemOrden.producto.precioProducto);
                        if (itemOrden.producto.tipoProducto != null)
                        {
                            pro.idCategoria = (itemOrden.producto.tipoProducto.categoria.idTipo == null ? -1 : itemOrden.producto.tipoProducto.categoria.idTipo);
                            pro.nombreCategoria = (itemOrden.producto.tipoProducto.categoria.nombreTipo == null ? "" : itemOrden.producto.tipoProducto.categoria.nombreTipo);
                            pro.idSubcategoria = (itemOrden.producto.tipoProducto.subCategoria.idTipo == null ? -1 : itemOrden.producto.tipoProducto.subCategoria.idTipo);
                            pro.nombreSubcategoria = (itemOrden.producto.tipoProducto.subCategoria.nombreTipo == null ? "" : itemOrden.producto.tipoProducto.subCategoria.nombreTipo);
                        }

                        io.totalItem = io.cantidadItem * pro.precioProducto;
                        
                        io.producto = pro;

                        listaItemsOrden.Add(io);

                        ord.listaItemsOrden = listaItemsOrden.ToList();
                    }
                    
                    lstOrdenes.Add(ord);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Web service Ordenes: " + e.Message);
        
                throw new Exception("Error - WebService Ordenes");
            }
            
            /*
            lstOrdenes = new List<OrdenDTO> 
            {
                new OrdenDTO
                {
                    idOrden = 39912,
                    numeroItemsOrden = 1,
                    fechaOrden = System.DateTime.Today,
                    totalOrden = 50000,
                    usuarioOrden = null,
                    listaItemsOrden = null,
                    idEstadoOrden = 1,
                    estadoOrden = "PRE-APROBADA"
                }
            };
            */
            return lstOrdenes;

        } //ConsultarOrdenesUsuario

        public List<EstadoOrdenDTO> getEstadoOrden()
        {
            List<EstadoOrdenDTO> lstEstados = new List<EstadoOrdenDTO>();
            EstadoOrdenDTO estado;
            Parametros p = new Parametros();

            using (OracleConnection con = new OracleConnection(p.oracleConnString().ToString()))
            {
                con.Open();

                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT IDESTADOORDEN, NOMBREESTADOORDEN FROM ESTADO_ORDEN ORDER BY IDESTADOORDEN ASC";

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estado = new EstadoOrdenDTO();
                        estado.idEstadoOrden = reader.GetInt32(0);
                        estado.nombreEstadoOrden = reader.GetString(1);
                        lstEstados.Add(estado);
                    }
                }

                con.Close();
                con.Dispose();
            }

            return lstEstados;
        } // getEstadoOrden()
    }
}
