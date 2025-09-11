using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models{


public class Order
{
    public int Id { get; set; }
    public int OrderId { get; set; } // For compatibility
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; }
    public decimal TotalAmount { get; set; }
    public int BuyerId { get; set; } // Added BuyerId property
    public Buyer Buyer { get; set; } // Navigation property
    public ICollection<OrderItem> OrderItems { get; set; }
}

}