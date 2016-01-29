using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB2C.DTO
{
    public class OrdenDTO
    {
        public long idOrden { get; set; }
        public int numeroItemsOrden { get; set; }
        public DateTime fechaOrden { get; set; }
        public double totalOrden { get; set; }
        public virtual ClienteDTO usuarioOrden { get; set; }
        public virtual List<ItemOrdenDTO> listaItemsOrden { get; set; }
        public int idEstadoOrden { get; set; }
        public string estadoOrden { get; set; }
    }

    public class ItemOrdenDTO
    {
        public bool tipo { get; set; } //Es CAMAPAÑA O NO. true Campaña.
        public long idCampania { get; set; }// SI TIPO ES CAMPAÑA, SE TOMARA ESTE ID. El Resto de Datos Se Toman De producto.
        public int cantidadItem { get; set; }
        public double totalItem { get; set; }
        public ProductosDTO producto { get; set; }
    }
}
