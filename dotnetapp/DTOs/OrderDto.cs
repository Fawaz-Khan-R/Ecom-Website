using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using dotnetapp.DTOs;
namespace dotnetapp.DTOs
{

public class OrderDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
}
}