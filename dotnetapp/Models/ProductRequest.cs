using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models{


public class ProductRequest
{
    public int RequestId { get; set; }
    public int ProductId { get; set; }
    public int SellerId { get; set; }
    public RequestType RequestType { get; set; }
    public DateTime RequestDate { get; set; }
    public RequestStatus Status { get; set; }
    public string AdminNotes { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public int? ReviewedBy { get; set; }
    
    // Store original product data for updates
    public string OriginalData { get; set; }
    
    // Navigation properties
    public virtual Product Product { get; set; }
    public virtual User Seller { get; set; }
    public virtual ICollection<ProductRequest> ProductRequests { get; set; } // Added navigation property
}


}