using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Web.Services.Product;

namespace Customer.Web.ViewModels
{
    public class BrandListViewModel
    {
        public IEnumerable<BrandDto> Brands { get; set; }
    }
}
