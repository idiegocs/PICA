using System.ComponentModel.DataAnnotations;
using KB2C.DTO;

//=================================================================================
// TOCA MOVER TODA ESTA CLASE A UN DTO --> PENDIENTE
//=================================================================================
namespace KallSonysB2C.Models
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public long ProductId { get; set; }

        public virtual ProductosDTO Product { get; set; }

        public virtual CampaniasDTO Campania { get; set; }

        public string NombreItem { get; set; }

        public float valorUnitarioItem { get; set; }

    }
}