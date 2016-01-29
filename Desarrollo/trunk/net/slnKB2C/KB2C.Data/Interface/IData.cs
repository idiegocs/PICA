using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.DTO;

namespace KB2C.Data.Interface
{
    public class IData 
    {
        public interface ICampaniaDAL
        {
            List<CampaniasDTO> GetCampanias();
        }

        public interface ICategoriaDAL
        {
            List<CategoriesDTO> GetCat_SubCategories();
        }

        public interface ICompraDAL
        {
            EstadoCompraDTO SetCompra(CompraDTO compraDTO);
        }

        public interface IOrdenDAL
        {
            List<OrdenDTO> ConsultarOrdenesUsuario(int idOrden, ClienteDTO cliente, string estadoOrden);
        }

        public interface IProductoDAL
        {
            List<ProductosDTO> ConsultarProductos(string tipoFiltro, string valorFiltro, int pagina);
            List<ProductoTop5DTO> consultarTop5(int IdProductoPadre);
            //List<ProductosDTO> ConsultarProductosDetalle(string vTipoFiltro, string vValorFiltro);
        }

    }
    
}
