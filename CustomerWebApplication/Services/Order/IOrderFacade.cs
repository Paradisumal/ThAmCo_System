using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Order
{
    public interface IOrderFacade
    {
        Task<OrderDto> NewOrder(OrderDto newOrder);

        Task<OrderDto> GetOrder(int orderId);

        Task<IEnumerable<OrderHistoryDto>> GetOrders(int customerId);
    }
}

