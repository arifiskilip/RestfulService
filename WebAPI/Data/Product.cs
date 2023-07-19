using System;

namespace WebAPI.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }


        public Category Category { get; set; }
    }
}
