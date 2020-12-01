using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<List<ReviewDto>> GetProductReviews(int productId)
        {
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
        public async Task<ReviewDto> PostReview(ReviewDto newReview)
        {
            var response = await _client.PostAsJsonAsync("api/Review", newReview);
            response.EnsureSuccessStatusCode();

            return newReview;
        }

        // GET: api/Review?customerId=X
        [HttpGet("api/Review")]
        public async Task<List<ReviewDto>> GetCustomerReviews(int customerId)
        {
            var response = await _client.GetAsync("api/Review?customerId=" + customerId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var reviews = await response.Content.ReadAsAsync<List<ReviewDto>>();

            return reviews;
        }

        // GET: api/Review/X
        [HttpGet("api/Review")]
        public async Task<ReviewDto> GetReview(int reviewId)
        {
            var response = await _client.GetAsync("api/Review/" + reviewId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var Review = await response.Content.ReadAsAsync<ReviewDto>();

            return Review;
        }

        // PUT: api/Review/X
        [HttpPut("api/Review")]
        public async Task<ReviewDto> PutReview(int reviewId, ReviewDto updatedReview)
        {
            var response = await _client.PutAsJsonAsync("/api/Review/" + reviewId, updatedReview);
            response.EnsureSuccessStatusCode();

            return updatedReview;
        }

        // DELETE: api/Review/X
        [HttpDelete("api/Review")]
        public async Task<ReviewDto> DeleteReview(int reviewId)
        {
            var response = await _client.DeleteAsync("/api/Review/" + reviewId);

            return null;
        }
    }
}
