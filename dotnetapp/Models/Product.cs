using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models{


public class Product
{
    public int Id { get; set; }
    public int ProductId { get; set; } // For compatibility
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int SellerId { get; set; }
    public ProductStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public Seller Seller { get; set; } // Navigation property
    public ICollection<OrderItem> OrderItems { get; set; }
    public ICollection<ProductRequest> ProductRequests { get; set; }
}

}