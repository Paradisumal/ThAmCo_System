using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Web.Services.Product;

namespace Customer.Web.ViewModels
{
    public class ProductFilterViewModel
    {
        public IEnumerable<BrandDto> Brands { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public double MinPrice { get; set; }

        public double MaxPrice { get; set; }
    }
}
