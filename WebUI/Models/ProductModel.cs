using System;

namespace WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
    }
}
