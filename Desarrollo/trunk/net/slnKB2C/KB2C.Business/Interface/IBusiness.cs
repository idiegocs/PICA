using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.DTO;

namespace KB2C.Business.Interface
{
    public class IBusiness 
    {
        public interface ICampaniaBL
        {
            List<CampaniasDTO> listaCampanias();
        }

        public interface ICategoriaBL
        {
            List<CategoriesDTO> GetCat_SubCategories();
        }

        public interface ICompraBL
        {
            EstadoCompraDTO registrarCompra(CompraDTO compraDTO);
        }

        public interface IOrdenBL
        {
            List<OrdenDTO> ConsultarOrdenesUsuario(int idOrden, ClienteDTO cliente, string estadoOrden);
        }

        public interface IProductoBL
        {
            List<ProductosDTO> listaProductos(string tipoFiltro, string valorFiltro, int pagina);
            List<ProductoTop5DTO> consultarTop5(int IdProductoPadre);
            //List<ProductosDTO> ConsultarProductosDetalle(string vTipoFiltro, string vValorFiltro);
        }
    }
    
}
