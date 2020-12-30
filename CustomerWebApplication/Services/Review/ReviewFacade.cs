using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Customer.Web.Services.Review
{
    public class ReviewFacade : IReviewFacade
    {
        private readonly ILogger<ReviewDto> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public ReviewFacade(ILogger<ReviewDto> logger,
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

        // GET: api/Review?productId=X
        [HttpGet("api/Review")]
        public async Task<IEnumerable<ReviewDto>> GetProductReviews(int productId)
        {
            var cient = _clientFactory.CreateClient();

            var disco = await cient.GetDiscoveryDocumentAsync("");
            var tokenResponse = await cient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            var response = await _client.GetAsync("api/Review?productId=" + productId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            var reviews = await response.Content.ReadAsAsync<List<ReviewDto>>();

            return reviews;
        }

        // POST: api/Review
        [HttpPost("api/Review")]
        public async Task<ReviewDto> NewReview(ReviewDto newReview)
        {
            var cient = _clientFactory.CreateClient();

            var disco = await cient.GetDiscoveryDocumentAsync("");
            var tokenResponse = await cient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            var response = await _client.PostAsJsonAsync("api/Review", newReview);
            response.EnsureSuccessStatusCode();

            return newReview;
        }

        // GET: api/Review?customerId=X
        [HttpGet("api/Review")]
        public async Task<IEnumerable<ReviewDto>> GetCustomerReviews(int customerId)
        {
            var cient = _clientFactory.CreateClient();

            var disco = await cient.GetDiscoveryDocumentAsync("");
            var tokenResponse = await cient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            var response = await _client.GetAsync("api/Review?customerId=" + customerId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            var reviews = await response.Content.ReadAsAsync<List<ReviewDto>>();

            return reviews;
        }

        // PUT: api/Review/X
        [HttpPut("api/Review")]
        public async Task<ReviewDto> EditReview(ReviewDto updatedReview)
        {
            var cient = _clientFactory.CreateClient();

            var disco = await cient.GetDiscoveryDocumentAsync("");
            var tokenResponse = await cient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            var response = await _client.PutAsJsonAsync("/api/Review?customerId=" + updatedReview.CustomerId 
                                                                  + "&productId=" + updatedReview.ProductId, updatedReview);
            response.EnsureSuccessStatusCode();

            return updatedReview;
        }

        // DELETE: api/Review/X
        [HttpDelete("api/Review")]
        public async Task<ReviewDto> DeleteReview(int customerId, int productId)
        {
            var cient = _clientFactory.CreateClient();

            var disco = await cient.GetDiscoveryDocumentAsync("");
            var tokenResponse = await cient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            var response = await _client.DeleteAsync("/api/Review?customerId=" + customerId
                                                                  + "&productId=" + productId);

            return null;
        }
    }
}
