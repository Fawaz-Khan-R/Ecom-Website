using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models{


public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Navigation properties
    public virtual ICollection<Product> Products { get; set; } // For Sellers
    public virtual ICollection<Order> Orders { get; set; } // For Buyers
    public virtual ICollection<ProductRequest> ProductRequests { get; set; }
}

}