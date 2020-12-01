using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Product
{
    public class FakeProductFacade : IProductFacade
    {
        public Task<ProductInfoDto> GetCategoriesAndBrands()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsBySearch(string searchString)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsByFilter(int? categoryId, int? brandId, double? minPrice, double? maxPrice)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
