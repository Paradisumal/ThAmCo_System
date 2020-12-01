using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Order
{
    public interface IOrderFacade
    {
        Task<OrderDto> PostOrder(OrderDto newOrder);

        Task<OrderDto> GetOrder(int orderId);

        Task<List<OrderHistoryDto>> GetOrders(int customerId);
    }
}

