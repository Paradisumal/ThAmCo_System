using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Order
{
    public class FakeOrderFacade : IOrderFacade
    {
        public Task<OrderDto> PostOrder(OrderDto newOrder)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderHistoryDto>> GetOrders(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
