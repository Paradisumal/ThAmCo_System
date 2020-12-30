using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Basket
{
    public class FakeBasketFacade : IBasketFacade
    {
        public List<BasketItemDto> _basket;

        public FakeBasketFacade()
        {
            _basket = new List<BasketItemDto>()
            {
                new BasketItemDto(){CustomerId = 1, ProductId = 1, ProductName = "Temp", Price = 10.01, Quantity = 1},
                new BasketItemDto(){CustomerId = 1, ProductId = 2, ProductName = "Temp", Price = 9.08, Quantity = 2},
                new BasketItemDto(){CustomerId = 1, ProductId = 3, ProductName = "Temp", Price = 11.27, Quantity = 3},
                new BasketItemDto(){CustomerId = 1, ProductId = 4, ProductName = "Temp", Price = 8.64, Quantity = 5},
                new BasketItemDto(){CustomerId = 1, ProductId = 5, ProductName = "Temp", Price = 12.04, Quantity = 7},
            };
        }

        public Task<IEnumerable<BasketItemDto>> GetBasket(int customerId)
        {
            IEnumerable<BasketItemDto> basket = _basket.Where(p => p.CustomerId == customerId);
            return Task.FromResult(basket);
        }

        public Task<BasketItemDto> AddItem(BasketItemDto newItem)
        {
            _basket.Add(newItem);
            return Task.FromResult(newItem);
        }

        public Task<BasketItemDto> UpdateItem(int customerId, BasketItemDto updatedItem)
        {
            throw new NotImplementedException();
        }

        public Task<BasketItemDto> RemoveItem(int customerId, int productId)
        {
            _basket.RemoveAll(b => b.CustomerId == customerId && b.ProductId == productId);
            return null;
        }
    }
}
