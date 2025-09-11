using System.Collections.Generic;

namespace dotnetapp.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
