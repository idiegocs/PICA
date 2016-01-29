﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.DTO;

namespace KB2C.Data
{
    public class Orden
    {
        //
        public List<OrdenDTO> ConsultarOrdenesUsuario(int idOrden, ClienteDTO cliente)
        {
            List<OrdenDTO> lstOrdenes = null;
            
            ServiceOrdenes.ConsultaOrdenEntrada entrada = new ServiceOrdenes.ConsultaOrdenEntrada();

            try
            {
                entrada.idOrden = idOrden;
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

                    ubi.numeroDireccion = item.cliente.direccion.numero;
                    ubi.idCiudad = item.cliente.direccion.idCiudad;
                    ubi.nombreCiudad = item.cliente.direccion.ciudad;
                    ubi.idDepartamento = item.cliente.direccion.idDepartamento;
                    ubi.nombreDepartamento = item.cliente.direccion.departamento;

                    cli.ubicacionCliente = ubi;

                    ord.usuarioOrden = cli;

                    List<ItemOrdenDTO> listaItemsOrden = new List<ItemOrdenDTO>();
                    
                    foreach (var itemOrden in item.listaItems)
                    {
                        ItemOrdenDTO io = new ItemOrdenDTO();
                        io.cantidadItem = itemOrden.cantidad;
                        io.tipo = itemOrden.tipo;
                        io.idCampania = itemOrden.idCampania;
                        io.producto = new ProductosDTO()
                        {
                            idProducto = itemOrden.producto.idProducto,
                            codigoProducto = itemOrden.producto.codigoProducto,
                            nombreProducto = itemOrden.producto.nombreProducto,
                            descripcionProducto = itemOrden.producto.descripcionProducto,
                            fabricanteProducto = itemOrden.producto.fabricanteProducto,
                            nombreImagenProducto = itemOrden.producto.nombreImagenProducto,
                            precioProducto = itemOrden.producto.precioProducto,
                            idCategoria = itemOrden.producto.tipoProducto.categoria.idTipo,
                            nombreCategoria = itemOrden.producto.tipoProducto.categoria.nombreTipo,
                            idSubcategoria = itemOrden.producto.tipoProducto.subCategoria.idTipo,
                            nombreSubcategoria = itemOrden.producto.tipoProducto.subCategoria.nombreTipo
                        };

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
    }
}