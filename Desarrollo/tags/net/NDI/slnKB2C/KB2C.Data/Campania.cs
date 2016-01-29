using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.DTO;

namespace KB2C.Data
{
    public class Campania
    {
        public List<CampaniasDTO> GetCampanias()
        {

            ServiceCampanias.ConsultaCampaniaEntrada entrada = new ServiceCampanias.ConsultaCampaniaEntrada();
            ServiceCampanias.FiltroCampania filtro = new ServiceCampanias.FiltroCampania();

            List<CampaniasDTO> listaCampanias = null;
            bool estadoCampania = true;

            try
            {
                filtro.estado = estadoCampania;

                entrada.filtroCampania = filtro;

                ServiceCampanias.CampaniasPortClient clienteWs = new ServiceCampanias.CampaniasPortClient();
                ServiceCampanias.ConsultaCampaniaSalida salida;

                salida = clienteWs.ConsultarCampanias(entrada);

                listaCampanias = new List<CampaniasDTO>();

                foreach (var item in salida.campanias)
                {
                    CampaniasDTO camp = new CampaniasDTO();
                    List<ProductosxCampaniaDTO> listaProdxCamp = new List<ProductosxCampaniaDTO>();

                    camp.IdCampania = item.idCampania;
                    camp.Nombre = item.nombreCampania;
                    camp.FechaInicio = item.fechaInicioCampania;
                    camp.FechaFin = item.fechaFinCampania;
                    camp.Estado = item.estadoCampania;
                    camp.NombreImagenCampania = item.imagenCampania;
                    camp.ValorUnitarioCampania = (float)item.valorCampania;
                    foreach (var pro in item.listaProductosCampanias)
                    {
                        ProductosxCampaniaDTO pxc = new ProductosxCampaniaDTO();
                        pxc.IdProducto = (int)pro.productoCampania.idProducto;
                        pxc.ValorUnitario = pro.productoCampania.precioProducto;
                        pxc.PorcentajeDescuento = pro.descuentoCampania;
                        listaProdxCamp.Add(pxc);
                    }

                    camp.listaProductosxCampania = listaProdxCamp.ToList();

                    listaCampanias.Add(camp);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Web service Campanias: "+ e.Message);
                throw new Exception("Error - WebService Campanias");
          
            
            }

            return listaCampanias;

            /*
            var deals = new List<CampaniasDTO> {
                new CampaniasDTO
                {
                    IdCampania = 1125500,
                    Nombre="campania_1",
                    FechaInicio= Convert.ToDateTime("01/03/2015"),
                    FechaFin = Convert.ToDateTime("31/03/2015"),
                    Estado = true,
                    NombreImagenCampania = "CAMPANIA_01.png",
                    ValorUnitarioCampania = 14300,
                    listaProductosxCampania = new List<ProductosxCampaniaDTO>
                    {
                        new ProductosxCampaniaDTO {IdProducto = 1, PorcentajeDescuento = 4, ValorUnitario=40000},
                        new ProductosxCampaniaDTO {IdProducto = 2, PorcentajeDescuento = 3, ValorUnitario=6500}
                    }

                },
                new CampaniasDTO
                {
                    IdCampania = 2,
                    Nombre="campania_2",
                    FechaInicio= Convert.ToDateTime("01/03/2015"),
                    FechaFin = Convert.ToDateTime("31/03/2015"),
                    Estado = true,
                    NombreImagenCampania = "CAMPANIA_02.png",
                    ValorUnitarioCampania = 5500,
                    listaProductosxCampania = new List<ProductosxCampaniaDTO>
                    {
                        new ProductosxCampaniaDTO {IdProducto = 1, PorcentajeDescuento = 4, ValorUnitario=3400},
                        new ProductosxCampaniaDTO {IdProducto = 2, PorcentajeDescuento = 3, ValorUnitario=1500}
                    }


                },
                new CampaniasDTO
                {
                    IdCampania = 3,
                    Nombre="campania_3",
                    FechaInicio= Convert.ToDateTime("01/03/2015"),
                    FechaFin = Convert.ToDateTime("31/03/2015"),
                    Estado = true,
                    NombreImagenCampania = "CAMPANIA_03.png",
                    ValorUnitarioCampania = 9000,
                    listaProductosxCampania = new List<ProductosxCampaniaDTO>
                    {
                        new ProductosxCampaniaDTO {IdProducto = 1, PorcentajeDescuento = 4, ValorUnitario=4000},
                        new ProductosxCampaniaDTO {IdProducto = 2, PorcentajeDescuento = 3, ValorUnitario=6000}
                    }


                },
             
            };
           
            return deals;
             */

        }
    }
}
