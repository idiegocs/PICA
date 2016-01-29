using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.DTO;
using KB2C.Data.Interface;

namespace KB2C.Data
{
    public class CategoryDAL : IData.ICategoriaDAL
    {
        public List<CategoriesDTO> GetCat_SubCategories()
        {


            ServiceCategorias.ConsultaCategoriaEntrada entrada = new ServiceCategorias.ConsultaCategoriaEntrada();
            ServiceCategorias.Filtro filtro = new ServiceCategorias.Filtro();
            List<CategoriesDTO> lstCategorias = null;
            try
            {
                filtro.tipoFiltro = "C";
                filtro.valorFiltro = "1";
                filtro.pagina = 1;

                entrada.filtroCategoria = filtro;

                ServiceCategorias.portCategoriasClient clienteWs = new ServiceCategorias.portCategoriasClient();
                ServiceCategorias.ConsultaCategoriaSalida salida;

                salida = clienteWs.consultaCategorias(entrada);
                lstCategorias = new List<CategoriesDTO>();

                CategoriesDTO cate = null;

                foreach (var item in salida.listaCategorias)
                {
                    foreach (var sub in item.listaSubCategorias)
                    {
                        cate = new CategoriesDTO();

                        cate.IdCategoria = item.tipoCategoria.idTipo;
                        cate.NombreCategoria = item.tipoCategoria.nombreTipo;
                        if (sub != null && sub.tipoSubCategoria != null)
                        {
                            cate.IdSubcategoria = sub.tipoSubCategoria.idTipo;
                            cate.NombreSubcategoria = sub.tipoSubCategoria.nombreTipo;
                            lstCategorias.Add(cate);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error wsCategorias  GetCat_SubCategories " + e.Message);

                var categories = new List<CategoriesDTO> 
                {
                    new CategoriesDTO
                    {
                        IdCategoria = 1,
                        NombreCategoria="Electrodomesticos",
                        NombreSubcategoria="Lavadoras",
                        IdSubcategoria = 1


                    },
                    new CategoriesDTO
                    {
                        IdCategoria = 1,
                        NombreCategoria="Electrodomesticos",
                        NombreSubcategoria="Neveras",
                        IdSubcategoria = 2


                    },
                    new CategoriesDTO
                    {
                        IdCategoria = 1,
                        NombreCategoria="Electrodomesticos",
                        NombreSubcategoria="Hornos Microondas",
                        IdSubcategoria = 3


                    },
                    new CategoriesDTO
                    {
                        IdCategoria = 1,
                        NombreCategoria="Electrodomesticos",
                        NombreSubcategoria="Estufas",
                        IdSubcategoria = 4


                    },
                    new CategoriesDTO
                    {
                        IdCategoria = 1,
                        NombreCategoria="Electrodomesticos",
                        NombreSubcategoria="Licuadoras",
                        IdSubcategoria = 5


                    },
                    new CategoriesDTO
                    {
                        IdCategoria = 1,
                        NombreCategoria="Electrodomesticos",
                        NombreSubcategoria="Planchas",
                        IdSubcategoria = 6


                    },

             
                
                };
            }//cierra catch
        
            return lstCategorias;

        }
    }
}
