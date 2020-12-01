using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebApplication.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool InStock { get; set; }
    }
}
