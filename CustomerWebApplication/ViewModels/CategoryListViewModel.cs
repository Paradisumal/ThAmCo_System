using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Web.Services.Product;

namespace Customer.Web.ViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
