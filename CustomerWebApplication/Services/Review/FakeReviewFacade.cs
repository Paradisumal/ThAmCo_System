using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Review
{
    public class FakeReviewFacade : IReviewFacade
    {
        public Task<List<ReviewDto>> GetProductReviews(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewDto> PostReview(ReviewDto newReview)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReviewDto>> GetCustomerReviews(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewDto> GetReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewDto> PutReview(int reviewId, ReviewDto updatedReview)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewDto> DeleteReview(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
