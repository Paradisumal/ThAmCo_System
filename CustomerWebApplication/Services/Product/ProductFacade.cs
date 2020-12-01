using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Customer.Web.Services.Product
{
    public class ProductFacade : IProductFacade
    {
        private readonly ILogger<ProductDto> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public ProductFacade(ILogger<ProductDto> logger,
                              IHttpClientFactory clientFactory,
                              HttpClient client)
        {
            _logger = logger;
            _clientFactory = clientFactory;

            client.BaseAddress = new System.Uri("");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            _client = client;
        }

        // GET: api/Product
        [HttpGet("api/Product")]
        public async Task<ProductInfoDto> GetCategoriesAndBrands()
        {
            var response = await _client.GetAsync("api/Product");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var productInfo = await response.Content.ReadAsAsync<ProductInfoDto>();

            return productInfo;
        }

        // GET: api/Product?categoryId=x
        [HttpGet("api/Product")]
        public async Task<List<ProductDto>> GetProductsByCategory(int categoryId)
        {
            var response = await _client.GetAsync("api/Product?categoryId=" + categoryId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<List<ProductDto>>();

            return products;
        }

        // GET: api/Product?brandId=X
        [HttpGet("api/Product")]
        public async Task<List<ProductDto>> GetProductsByBrand(int brandId)
        {
            var response = await _client.GetAsync("api/Product?brandId=" + brandId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<List<ProductDto>>();

            return products;
        }

        // GET: api/Product?searchString=X
        [HttpGet("api/Product")]
        public async Task<List<ProductDto>> GetProductsBySearch(string searchString)
        {
            var response = await _client.GetAsync("api/Product?searchString=" + searchString);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<List<ProductDto>>();

            return products;
        }

        // GET: api/Product?categoryId=X?
        [HttpGet("api/Product")]
        public async Task<List<ProductDto>> GetProductsByFilter(int? categoryId, int? brandId, 
                                                                double? minPrice, double? maxPrice)
        {
            var response = await _client.GetAsync("api/Product?categoryId=" + categoryId
                                                              + "?brandId=" + brandId
                                                             + "?minPrice=" + minPrice
                                                             + "&maxPrice=" + maxPrice);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<List<ProductDto>>();

            return products;
        }

        // GET: api/Product/X
        [HttpGet("api/Product")]
        public async Task<ProductDto> GetProduct(int productId)
        {
            var response = await _client.GetAsync("api/Product/" + productId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<ProductDto>();

            return product;
        }
    }
}
