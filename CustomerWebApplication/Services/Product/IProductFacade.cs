using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Product
{
    public interface IProductFacade
    {
        Task<ProductInfoDto> GetCategoriesAndBrands();

        Task<IEnumerable<ProductDto>> GetProductsByCategory(int categoryId);

        Task<IEnumerable<ProductDto>> GetProductsByBrand(int brandId);

        Task<IEnumerable<ProductDto>> GetProductsBySearch(string searchString);

        Task<IEnumerable<ProductDto>> GetProductsByFilter(int? categoryId, 
                                                   int? brandId, 
                                                   double? minPrice, 
                                                   double? maxPrice);

        Task<ProductDto> GetProduct(int productId);
    }
}
