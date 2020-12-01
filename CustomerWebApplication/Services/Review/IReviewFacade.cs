using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Review
{
    public interface IReviewFacade
    {
        Task<List<ReviewDto>> GetProductReviews(int productId);
        Task<ReviewDto> PostReview(ReviewDto newReview);
        Task<ReviewDto> GetReview(int productId);
        Task<ReviewDto> PutReview(int productId, ReviewDto updatedReview);
        Task<ReviewDto> DeleteReview(int reviewId);
        Task<List<ReviewDto>> GetCustomerReviews(int customerId);
    }
}
