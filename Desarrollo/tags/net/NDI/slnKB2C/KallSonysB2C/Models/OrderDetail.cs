using System.ComponentModel.DataAnnotations;

namespace KallSonysB2C.Models
{
  public class OrderDetail
  {
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public string Username { get; set; }

    public long ProductId { get; set; }

    public int Quantity { get; set; }

    public double? UnitPrice { get; set; }

  }
}