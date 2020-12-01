using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Basket
{
    public class FakeBasketFacade : IBasketFacade
    {
        public Task<List<BasketItemDto>> GetBasket(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<BasketItemDto> PostItem(BasketItemDto basketItem)
        {
            throw new NotImplementedException();
        }

        public Task<BasketItemDto> PutItem(int customerId, BasketItemDto basketItem)
        {
            throw new NotImplementedException();
        }

        public Task<BasketItemDto> DeleteItem(int customerId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
