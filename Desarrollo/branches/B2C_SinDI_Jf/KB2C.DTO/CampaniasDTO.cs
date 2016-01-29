using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB2C.DTO
{
    public class CampaniasDTO
    {
        public int IdCampania { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio{ get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; }
        public string NombreImagenCampania { get; set; }
        public float ValorUnitarioCampania { get; set; }
        public virtual List<ProductosxCampaniaDTO> listaProductosxCampania { get; set; }
    }

    public class ProductosxCampaniaDTO 
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string NombreImagenProducto { get; set; }
        public float ValorUnitario { get; set; }
        public int PorcentajeDescuento { get; set; }
    }
}
