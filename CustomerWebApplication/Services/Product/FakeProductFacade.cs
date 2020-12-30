using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Product
{
    public class FakeProductFacade : IProductFacade
    {
        public List<ProductDto> _products;
        public ProductInfoDto _brandsAndCategories;

        public FakeProductFacade()
        {
            _products = new List<ProductDto>()
            {
                new ProductDto(){ProductId = 1, Name = "Temp", Description = "Temp", Quantity = 121, BrandId = 1, Brand = "Koalaity", CategoryId = 1, Category = "Desk Warmers", Price = 10.01},
                new ProductDto(){ProductId = 2, Name = "Temp", Description = "Temp", Quantity = 144, BrandId = 2, Brand = "Bear Basics", CategoryId = 1, Category = "Desk Warmers", Price = 9.08},
                new ProductDto(){ProductId = 3, Name = "Temp", Description = "Temp", Quantity = 169, BrandId = 3, Brand = "Quacking Producks", CategoryId = 2, Category = "Window Covers", Price = 11.27},
                new ProductDto(){ProductId = 4, Name = "Temp", Description = "Temp", Quantity = 196, BrandId = 4, Brand = "Beevices", CategoryId = 2, Category = "Window Covers", Price = 8.64},
                new ProductDto(){ProductId = 5, Name = "Temp", Description = "Temp", Quantity = 225, BrandId = 5, Brand = "Stockadile", CategoryId = 3, Category = "Drawer Hangers", Price = 12.04},
                new ProductDto(){ProductId = 6, Name = "Temp", Description = "Temp", Quantity = 256, BrandId = 1, Brand = "Koalaity", CategoryId = 3, Category = "Drawer Hangers", Price = 7.09},
                new ProductDto(){ProductId = 7, Name = "Temp", Description = "Temp", Quantity = 289, BrandId = 2, Brand = "Bear Basics", CategoryId = 4, Category = "Liquid Vessels", Price = 13.16},
                new ProductDto(){ProductId = 8, Name = "Temp", Description = "Temp", Quantity = 324, BrandId = 3, Brand = "Quacking Producks", CategoryId = 4, Category = "Liquid Vessels", Price = 6.25},
                new ProductDto(){ProductId = 9, Name = "Temp", Description = "Temp", Quantity = 361, BrandId = 4, Brand = "Beevices", CategoryId = 5, Category = "Alarm Clocks", Price = 14.36},
                new ProductDto(){ProductId = 10, Name = "Temp", Description = "Temp", Quantity = 400, BrandId = 5, Brand = "Stockadile", CategoryId = 5, Category = "Alarm Clocks", Price = 5.64},
            };

            _brandsAndCategories = new ProductInfoDto()
            {
                Brands = new List<BrandDto> 
                {
                    new BrandDto(){BrandId = 1, Brand = "Koalaity"},
                    new BrandDto(){BrandId = 2, Brand = "Bear Basics"},
                    new BrandDto(){BrandId = 3, Brand = "Quacking Producks"},
                    new BrandDto(){BrandId = 4, Brand = "Beevices"},
                    new BrandDto(){BrandId = 5, Brand = "Stockadile"},
                },
                Categories = new List<CategoryDto>
                { new CategoryDto(){CategoryId = 1, Category = "Desk Warmers"},
                    new CategoryDto(){CategoryId = 2, Category = "Window Covers"},
                    new CategoryDto(){CategoryId = 3, Category = "Drawer Hangers"},
                    new CategoryDto(){CategoryId = 4, Category = "Liquid Vessels"},
                    new CategoryDto(){CategoryId = 5, Category = "Alarm Clocks"},
                },
            };
        }

        public Task<ProductInfoDto> GetCategoriesAndBrands()
        {
            return Task.FromResult(_brandsAndCategories);
        }

        public Task<IEnumerable<ProductDto>> GetProductsByCategory(int categoryId)
        {
            IEnumerable<ProductDto> products = _products.Where(p => p.CategoryId == categoryId);
            return Task.FromResult(products);
        }

        public Task<IEnumerable<ProductDto>> GetProductsByBrand(int brandId)
        {
            IEnumerable<ProductDto> products = _products.Where(p => p.BrandId == brandId);
            return Task.FromResult(products);
        }

        public Task<IEnumerable<ProductDto>> GetProductsBySearch(string searchString)
        {
            IEnumerable<ProductDto> products = _products.Where(p => p.Name.Contains(searchString) || p.Description.Contains(searchString));
            return Task.FromResult(products);
        }

        public Task<IEnumerable<ProductDto>> GetProductsByFilter(int? categoryId, int? brandId, double? minPrice, double? maxPrice)
        {
            IEnumerable<ProductDto> products = _products.Where(p => p.CategoryId == categoryId 
                                                                 && p.BrandId == brandId 
                                                                 && p.Price >= minPrice 
                                                                 && p.Price <= maxPrice);
            return Task.FromResult(products);
        }

        public Task<ProductDto> GetProduct(int productId)
        {
            ProductDto product = _products.First(p => p.ProductId == productId);
            return Task.FromResult(product);
        }
    }
}
