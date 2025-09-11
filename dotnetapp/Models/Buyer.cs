using System.Collections.Generic;

namespace dotnetapp.Models
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
