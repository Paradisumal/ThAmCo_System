using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Product
{
    public class ProductInfoDto
    {
        public List<String> Brands { get; set; }

        public List<String> Categories { get; set; }
    }
}
