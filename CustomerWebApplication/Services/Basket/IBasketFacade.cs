using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Web.Services.Basket
{
    public interface IBasketFacade
    {
        Task<BasketItemDto> PostItem(BasketItemDto basketItem);
        Task<List<BasketItemDto>> GetBasket(int customerId);
        Task<BasketItemDto> PutItem(int customerId, BasketItemDto basketItem);
        Task<BasketItemDto> DeleteItem(int customerId, int productId);
    }
}
