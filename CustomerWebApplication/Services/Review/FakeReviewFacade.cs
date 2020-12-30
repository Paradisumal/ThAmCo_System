using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Review
{
    public class FakeReviewFacade : IReviewFacade
    {
        public List<ReviewDto> _reviews;

        public FakeReviewFacade()
        {
            _reviews = new List<ReviewDto>()
            {
                new ReviewDto(){ProductId = 1, ProductName = "Temp", CustomerName = "Paul", CustomerId = 5, Rating = 1, ReviewText = "Temp", Timestamp = new DateTime(2020, 12, 1, 6, 1, 13)},
                new ReviewDto(){ProductId = 1, ProductName = "Temp", CustomerName = "Jack", CustomerId = 4, Rating = 2, ReviewText = "Temp", Timestamp = new DateTime(2019, 11, 2, 7, 2, 19)},
                new ReviewDto(){ProductId = 2, ProductName = "Temp", CustomerName = "Karl", CustomerId = 3, Rating = 3, ReviewText = "Temp", Timestamp = new DateTime(2018, 10, 3, 8, 3, 23)},
                new ReviewDto(){ProductId = 2, ProductName = "Temp", CustomerName = "Chris", CustomerId = 2, Rating = 4, ReviewText = "Temp", Timestamp = new DateTime(2017, 9, 4, 9, 5, 29)},
                new ReviewDto(){ProductId = 3, ProductName = "Temp", CustomerName = "Carter", CustomerId = 1, Rating = 5, ReviewText = "Temp", Timestamp = new DateTime(2016, 8, 5, 10, 7, 37)},
                new ReviewDto(){ProductId = 3, ProductName = "Temp", CustomerName = "Paul", CustomerId = 5, Rating = 4, ReviewText = "Temp", Timestamp = new DateTime(2015, 7, 6, 11, 11, 41)},
                new ReviewDto(){ProductId = 4, ProductName = "Temp", CustomerName = "Jack", CustomerId = 4, Rating = 3, ReviewText = "Temp", Timestamp = new DateTime(2014, 6, 7, 12, 13, 43)},
                new ReviewDto(){ProductId = 4, ProductName = "Temp", CustomerName = "Karl", CustomerId = 3, Rating = 2, ReviewText = "Temp", Timestamp = new DateTime(2013, 5, 8, 13, 17, 47)},
                new ReviewDto(){ProductId = 5, ProductName = "Temp", CustomerName = "Chris", CustomerId = 2, Rating = 1, ReviewText = "Temp", Timestamp = new DateTime(2012, 4, 9, 14, 19, 49)},
                new ReviewDto(){ProductId = 5, ProductName = "Temp", CustomerName = "Carter", CustomerId = 1, Rating = 2, ReviewText = "Temp", Timestamp = new DateTime(2011, 3, 10, 15, 23, 53)},
                new ReviewDto(){ProductId = 6, ProductName = "Temp", CustomerName = "Paul", CustomerId = 5, Rating = 3, ReviewText = "Temp", Timestamp = new DateTime(2010, 2, 11, 16, 29, 7)},
                new ReviewDto(){ProductId = 6, ProductName = "Temp", CustomerName = "Jack", CustomerId = 4, Rating = 4, ReviewText = "Temp", Timestamp = new DateTime(2009, 1, 12, 17, 31, 11)},
                new ReviewDto(){ProductId = 7, ProductName = "Temp", CustomerName = "Karl", CustomerId = 3, Rating = 5, ReviewText = "Temp", Timestamp = new DateTime(2008, 2, 13, 18, 37, 17)},
                new ReviewDto(){ProductId = 7, ProductName = "Temp", CustomerName = "Chris", CustomerId = 2, Rating = 4, ReviewText = "Temp", Timestamp = new DateTime(2007, 3, 14, 19, 41, 19)},
                new ReviewDto(){ProductId = 8, ProductName = "Temp", CustomerName = "Carter", CustomerId = 1, Rating = 3, ReviewText = "Temp", Timestamp = new DateTime(2006, 4, 15, 20, 43, 29)},
                new ReviewDto(){ProductId = 8, ProductName = "Temp", CustomerName = "Paul", CustomerId = 5, Rating = 2, ReviewText = "Temp", Timestamp = new DateTime(2005, 5, 16, 21, 47, 31)},
                new ReviewDto(){ProductId = 9, ProductName = "Temp", CustomerName = "Jack", CustomerId = 4, Rating = 1, ReviewText = "Temp", Timestamp = new DateTime(2004, 6, 17, 22, 53, 37)},
                new ReviewDto(){ProductId = 9, ProductName = "Temp", CustomerName = "Karl", CustomerId = 3, Rating = 2, ReviewText = "Temp", Timestamp = new DateTime(2003, 7, 18, 23, 59, 43)},
                new ReviewDto(){ProductId = 10, ProductName = "Temp", CustomerName = "Chris", CustomerId = 2, Rating = 3, ReviewText = "Temp", Timestamp = new DateTime(2002, 8, 24, 8, 1, 47)},
                new ReviewDto(){ProductId = 10, ProductName = "Temp", CustomerName = "Carter", CustomerId = 1, Rating = 4, ReviewText = "Temp", Timestamp = new DateTime(2001, 9, 1, 8, 7, 53)},
            };
        }

        public Task<IEnumerable<ReviewDto>> GetProductReviews(int productId)
        {
            IEnumerable<ReviewDto> reviews = _reviews.Where(r => r.ProductId == productId)
                                                     .OrderByDescending(t => t.Timestamp);
            return Task.FromResult(reviews);
        }

        public Task<ReviewDto> NewReview(ReviewDto newReview)
        {
            _reviews.Add(newReview);

            return Task.FromResult(newReview);
        }

        public Task<IEnumerable<ReviewDto>> GetCustomerReviews(int customerId)
        {
            IEnumerable<ReviewDto> reviews = _reviews.Where(r => r.CustomerId == customerId)
                                                     .OrderByDescending(t => t.Timestamp);
            return Task.FromResult(reviews);
        }

        public Task<ReviewDto> EditReview(ReviewDto updatedReview)
        {
            var review = _reviews.FirstOrDefault(r => r.CustomerId == updatedReview.CustomerId
                                                   && r.ProductId == updatedReview.ProductId);
            if(review != null)
            {
                review.CustomerName = updatedReview.CustomerName;
                review.Timestamp = updatedReview.Timestamp;
                review.Rating = updatedReview.Rating;
                review.ReviewText = updatedReview.ReviewText;
            }

            return Task.FromResult(updatedReview);
        }

        public Task<ReviewDto> DeleteReview(int customerId, int productId)
        {
            var review = _reviews.FirstOrDefault(r => r.CustomerId == customerId
                                                   && r.ProductId == productId);

            _reviews.Remove(review);

            return Task.FromResult(review); ;
        }
    }
}
