using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Customer.Web.Services.Product
{
    public class ProductFacade : ControllerBase, IProductFacade
    {
        private readonly ILogger<ProductDto> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public ProductFacade(ILogger<ProductDto> logger,
                              IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        // GET: api/Product
        [HttpGet("api/Product")]
        public async Task<ProductInfoDto> GetCategoriesAndBrands()
        {
            var client = _clientFactory.CreateClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://customerproductsthamco.azurewebsites.net/");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            var response = await client.GetAsync("https://customerproductsthamco.azurewebsites.net/Product");
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
        public async Task<IEnumerable<ProductDto>> GetProductsByCategory(int categoryId)
        {
            var client = _clientFactory.CreateClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://customerproductsthamco.azurewebsites.net/");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            var response = await client.GetAsync("https://customerproductsthamco.azurewebsites.net/Product?categoryId=" + categoryId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<IEnumerable<ProductDto>>();

            return products;
        }

        // GET: api/Product?brandId=X
        [HttpGet("api/Product")]
        public async Task<IEnumerable<ProductDto>> GetProductsByBrand(int brandId)
        {
            var client = _clientFactory.CreateClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://customerproductsthamco.azurewebsites.net/");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            var response = await client.GetAsync("https://customerproductsthamco.azurewebsites.net/Product?brandId=" + brandId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<IEnumerable<ProductDto>>();

            return products;
        }

        // GET: api/Product?searchString=X
        [HttpGet("api/Product")]
        public async Task<IEnumerable<ProductDto>> GetProductsBySearch(string searchString)
        {
            var client = _clientFactory.CreateClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://customerproductsthamco.azurewebsites.net/");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            var response = await client.GetAsync("https://customerproductsthamco.azurewebsites.net//Product?searchString=" + searchString);
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
        public async Task<IEnumerable<ProductDto>> GetProductsByFilter(int? categoryId, int? brandId, 
                                                                double? minPrice, double? maxPrice)
        {
            var client = _clientFactory.CreateClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://customerproductsthamco.azurewebsites.net/");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            var response = await client.GetAsync("https://customerproductsthamco.azurewebsites.net/Product?categoryId=" + categoryId
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
            var client = _clientFactory.CreateClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://customerproductsthamco.azurewebsites.net/");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            var response = await client.GetAsync("https://customerproductsthamco.azurewebsites.net/Product/" + productId);
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
