using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models{


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int SellerId { get; set; }
    public ProductStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string ImageUrl { get; set; }
    public string Category { get; set; }
    
    // Navigation properties
    public virtual User Seller { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public virtual ICollection<ProductRequest> ProductRequests { get; set; }
}

}