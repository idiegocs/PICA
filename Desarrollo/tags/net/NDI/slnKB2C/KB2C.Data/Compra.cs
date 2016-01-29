using KB2C.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace KB2C.Data
{
    public class Compra
    {
        public EstadoCompraDTO SetCompra(CompraDTO compraDTO)
        {
            ServiceCompra.RegistrarCompraEntrada entrada = new ServiceCompra.RegistrarCompraEntrada();
           
            ServiceCompra.Compra compraWs = new ServiceCompra.Compra();
            
            EstadoCompraDTO respCompra=null;

            try
            {


                compraWs.tarjeta = new ServiceCompra.Tarjeta();
                compraWs.usuarioEnvio = new ServiceCompra.Usuario();
                compraWs.orden = new ServiceCompra.Orden();
                if (compraDTO != null)
                {
                    compraWs.envioTitular = compraDTO.envioTitular;
                }


                //setear todos los objetos.
                // desde compraDTO al los objetos del servicio.


                //datos tarjeta
                if (compraDTO != null && compraDTO.tarjeta != null)
                {
                    compraWs.tarjeta.nombreTitular = compraDTO.tarjeta.nombreTitular;
                    compraWs.tarjeta.numeroTarjeta = Convert.ToString(compraDTO.tarjeta.numeroTarjeta);
                    compraWs.tarjeta.codigoSeguridad = Convert.ToString(compraDTO.tarjeta.codigoSeguridad);
                    string xsdDateTime = SoapDateTime.ToString(compraDTO.tarjeta.fechaExpiracion);
                    //DateTime dateTime = SoapDateTime.Parse(xsdDateTime);
                    //se indica que va la fecha
                    compraWs.tarjeta.fechaExpiracionSpecified = true;
                    compraWs.tarjeta.fechaExpiracion = xsdDateTime;
                   
                }
                //Fin Datos tarjeta

                //datos usuario envio
                if (compraDTO != null && compraDTO.usuarioEnvio!= null)
                {
                    compraWs.usuarioEnvio.nombreUsuario = compraDTO.usuarioEnvio.nombreUsuario;
                    compraWs.usuarioEnvio.nombre = compraDTO.usuarioEnvio.nombre;
                    compraWs.usuarioEnvio.apellido = compraDTO.usuarioEnvio.apellido;
                    compraWs.usuarioEnvio.tipoDocumento = compraDTO.usuarioEnvio.tipoDocumento;
                    compraWs.usuarioEnvio.numeroDocumento = Convert.ToString(compraDTO.usuarioEnvio.numeroDocumento);
                    compraWs.usuarioEnvio.correoElectronico = compraDTO.usuarioEnvio.correoElectronico;
                    compraWs.usuarioEnvio.telefono= compraDTO.usuarioEnvio.telefono;
                    compraWs.usuarioEnvio.direccion = new ServiceCompra.Direccion();
                    if (compraDTO.usuarioEnvio.ubicacionCliente != null)
                    {
                        compraWs.usuarioEnvio.direccion.numero = compraDTO.usuarioEnvio.ubicacionCliente.numeroDireccion;
                        compraWs.usuarioEnvio.direccion.ciudad = compraDTO.usuarioEnvio.ubicacionCliente.nombreCiudad;
                        compraWs.usuarioEnvio.direccion.departamento = compraDTO.usuarioEnvio.ubicacionCliente.nombreDepartamento;
                    }

                }

                //Fin datos usuario envio

                //datos ordencompra
                if (compraDTO.ordenCompra != null)
                {
                    compraWs.orden.idOrden = Convert.ToInt32(compraDTO.ordenCompra.idOrden);
                    compraWs.orden.numeroItems = compraDTO.ordenCompra.numeroItemsOrden;
                    //se dice que el campo opcional numeroitem esta activo
                    compraWs.orden.numeroItemsSpecified = true;
                    compraWs.orden.total = compraDTO.ordenCompra.totalOrden;
                    //se dice que el campo opcional total esta activo
                    compraWs.orden.totalSpecified= true;
                    compraWs.orden.cliente = new ServiceCompra.Usuario();
                    

                    //Usuario Titular Orden
                    if (compraDTO.ordenCompra.usuarioOrden != null)
                    {

                        compraWs.orden.cliente.nombreUsuario = compraDTO.ordenCompra.usuarioOrden.nombreUsuario;
                        compraWs.orden.cliente.nombre = compraDTO.ordenCompra.usuarioOrden.nombre;
                        compraWs.orden.cliente.apellido = compraDTO.ordenCompra.usuarioOrden.apellido;
                        compraWs.orden.cliente.tipoDocumento = compraDTO.ordenCompra.usuarioOrden.tipoDocumento;
                        compraWs.orden.cliente.numeroDocumento = Convert.ToString(compraDTO.ordenCompra.usuarioOrden.numeroDocumento);
                        compraWs.orden.cliente.correoElectronico = compraDTO.ordenCompra.usuarioOrden.correoElectronico;
                        compraWs.orden.cliente.telefono = compraDTO.ordenCompra.usuarioOrden.telefono;
                        compraWs.orden.cliente.direccion = new ServiceCompra.Direccion();
                        if (compraDTO.ordenCompra.usuarioOrden.ubicacionCliente != null)
                        {
                            compraWs.orden.cliente.direccion.numero = compraDTO.ordenCompra.usuarioOrden.ubicacionCliente.numeroDireccion;
                            compraWs.orden.cliente.direccion.ciudad = compraDTO.ordenCompra.usuarioOrden.ubicacionCliente.nombreCiudad;
                            compraWs.orden.cliente.direccion.departamento = compraDTO.ordenCompra.usuarioOrden.ubicacionCliente.nombreDepartamento;
                        }

                    }//fin if usuario tirular

                    //datos ordencDetalleItems
                    if(compraDTO.ordenCompra!=null && compraDTO.ordenCompra.listaItemsOrden!=null)
                    {
                        compraWs.orden.listaItems= new ServiceCompra.Item[compraDTO.ordenCompra.listaItemsOrden.Count];
                        ServiceCompra.Item itemWs = null;
                        ItemOrdenDTO itemCompra = null;

                        ServiceCompra.Producto productoWs=null;
                        ProductosDTO productoCompra = null;
                        for (int i = 0; i < compraDTO.ordenCompra.listaItemsOrden.Count; i++)
                        {
                            itemWs=new ServiceCompra.Item();
                            itemCompra= compraDTO.ordenCompra.listaItemsOrden[i];

                            itemWs.cantidad = itemCompra.cantidadItem;
                         
                            itemWs.tipo = itemCompra.tipo;
                            itemWs.idCampania = Convert.ToInt32(itemCompra.idCampania);
                            itemWs.idCampaniaSpecified = true;

                            productoCompra = itemCompra.producto;
                            productoWs = null;
                            if (productoCompra != null)
                            {
                                productoWs = new ServiceCompra.Producto();
                                productoWs.codigoProducto = productoCompra.codigoProducto;
                                productoWs.descripcionProducto = productoCompra.descripcionProducto;
                                productoWs.fabricanteProducto = productoCompra.fabricanteProducto;
                                productoWs.idProducto = productoCompra.idProducto;
                                productoWs.idProductoSpecified = true;
                                productoWs.nombreImagenProducto = productoCompra.nombreImagenProducto;
                                productoWs.nombreProducto= productoCompra.nombreProducto;
                                productoWs.precioProducto = productoCompra.precioProducto;
                                productoWs.precioProductoSpecified = true;

                                productoWs.tipoProducto = new ServiceCompra.TipoProducto();
                                productoWs.tipoProducto.categoria = new ServiceCompra.Tipo();
                                productoWs.tipoProducto.subCategoria = new ServiceCompra.Tipo();

                                productoWs.tipoProducto.categoria.nombreTipo = productoCompra.nombreCategoria;
                                productoWs.tipoProducto.categoria.idTipo = productoCompra.idCategoria;
                                productoWs.tipoProducto.categoria.idTipoSpecified = true;
                                productoWs.tipoProducto.subCategoria.idTipo = productoCompra.idSubcategoria;
                                productoWs.tipoProducto.subCategoria.idTipoSpecified = true;
                                productoWs.tipoProducto.subCategoria.nombreTipo = productoCompra.nombreSubcategoria;



                            }

                            itemWs.producto = productoWs;


                            compraWs.orden.listaItems[i] = itemWs;
                        }//cierra for
                   
                    }
                    //Fin datos ordencDetalleItems


                }

                //Fin datos ordencompra

                ServiceCompra.PortCompraClient clienteWs = new ServiceCompra.PortCompraClient();
                ServiceCompra.RegistrarCompraSalida salida;
                entrada.compra = compraWs;
                

                salida = clienteWs.registrarCompra(entrada);
                if (salida != null)
                {
                    respCompra = new EstadoCompraDTO();
                   
                    if (salida != null)
                    {
                        respCompra.EstadoTarjeta = salida.estadoTarjeta;
                        if (salida.idPreOrden != null)
                        {
                            respCompra.IdPreOrden = salida.idPreOrden;
                        }
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error  SetCompra " + e.Message);

                respCompra = null;
            }

               
            return respCompra;
        }

    }
}
