using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Review
{
    public interface IReviewFacade
    {
        Task<IEnumerable<ReviewDto>> GetProductReviews(int productId);
        Task<ReviewDto> NewReview(ReviewDto newReview);
        Task<ReviewDto> EditReview(ReviewDto updatedReview);
        Task<ReviewDto> DeleteReview(int customerId, int productId);
        Task<IEnumerable<ReviewDto>> GetCustomerReviews(int customerId);
    }
}
