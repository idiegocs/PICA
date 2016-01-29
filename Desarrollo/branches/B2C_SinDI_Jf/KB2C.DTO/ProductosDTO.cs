using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB2C.DTO
{
    public class Tipo
    {
        public int idTipo;
        public bool idTipoSpecified;
        public string nombreTipo;
    }

    public class TipoProducto
    {
        public Tipo categoria;
        public Tipo subCategoria;
    }

    public class ProductosDTO
    {
        public long idProducto { get; set; }
        public bool idProductoSpecified { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public string fabricanteProducto { get; set; }
        public string nombreImagenProducto { get; set; }
        public float precioProducto { get; set; }
        public bool precioProductoSpecified { get; set; }

        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }
        public int idSubcategoria { get; set; }
        public string nombreSubcategoria { get; set; }

        public string TipoItem { get; set; } //P si es producto, C si es campaña

    }

    public class ProductoTop5DTO 
    {
        public int idProductoPadre { get; set; }
        public int idProducto { get; set; }
        public int cantOrdenesJuntos { get; set; }
    }
}
