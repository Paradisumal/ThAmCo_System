using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Web.Services.Basket
{
    public interface IBasketFacade
    {
        Task<BasketItemDto> AddItem(BasketItemDto basketItem);
        Task<IEnumerable<BasketItemDto>> GetBasket(int newItem);
        Task<BasketItemDto> UpdateItem(int customerId, BasketItemDto updatedItem);
        Task<BasketItemDto> RemoveItem(int customerId, int productId);
    }
}
