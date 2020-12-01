using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Product
{
    public interface IProductFacade
    {
        Task<ProductInfoDto> GetCategoriesAndBrands();

        Task<List<ProductDto>> GetProductsByCategory(int categoryId);

        Task<List<ProductDto>> GetProductsByBrand(int brandId);

        Task<List<ProductDto>> GetProductsBySearch(string searchString);

        Task<List<ProductDto>> GetProductsByFilter(int? categoryId, 
                                                   int? brandId, 
                                                   double? minPrice, 
                                                   double? maxPrice);

        Task<ProductDto> GetProduct(int productId);
    }
}
