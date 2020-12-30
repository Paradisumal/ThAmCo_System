using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Web.Services.Basket;

namespace Customer.Web.Services.Order
{
    public class FakeOrderFacade : IOrderFacade
    {
        public List<OrderDto> _orders;

        public FakeOrderFacade()
        {
            _orders = new List<OrderDto>()
            {
                new OrderDto(){OrderId = 1, CustomerId = 1, Date = new DateTime(2020, 12, 1, 6, 1, 13), 
                    OrderedItems = new List<OrderedItemDto>()
                    { 
                        new OrderedItemDto(){OrderId = 1, ProductId = 1, Quantity = 1, Price = 10.01, ProductName = "Temp"},
                        new OrderedItemDto(){OrderId = 1, ProductId = 2, Quantity = 1, Price = 9.08, ProductName = "Temp"}
                    }, TotalPrice = 19.09},
                new OrderDto(){OrderId = 2, CustomerId = 1, Date = new DateTime(2020, 12, 1, 6, 1, 13), 
                    OrderedItems = new List<OrderedItemDto>()
                    { 
                        new OrderedItemDto(){OrderId = 2, ProductId = 2, Quantity = 1, Price = 9.08, ProductName = "Temp"},
                        new OrderedItemDto(){OrderId = 2, ProductId = 3, Quantity = 2, Price = 11.27, ProductName = "Temp"}
                    }, TotalPrice = 31.62},
                new OrderDto(){OrderId = 3, CustomerId = 2, Date = new DateTime(2020, 12, 1, 6, 1, 13),
                    OrderedItems = new List<OrderedItemDto>()
                    { 
                        new OrderedItemDto(){OrderId = 3, ProductId = 3, Quantity = 1, Price = 11.27, ProductName = "Temp"},
                        new OrderedItemDto(){OrderId = 3, ProductId = 4, Quantity = 3, Price = 8.64, ProductName = "Temp"}
                    }, TotalPrice = 37.19},
                new OrderDto(){OrderId = 4, CustomerId = 2, Date = new DateTime(2020, 12, 1, 6, 1, 13),
                    OrderedItems = new List<OrderedItemDto>()
                    {
                        new OrderedItemDto(){OrderId = 4, ProductId = 4, Quantity = 2, Price = 8.64, ProductName = "Temp"},
                        new OrderedItemDto(){OrderId = 4, ProductId = 5, Quantity = 1, Price = 12.04, ProductName = "Temp"}
                    }, TotalPrice = 29.32},
                new OrderDto(){OrderId = 5, CustomerId = 3, Date = new DateTime(2020, 12, 1, 6, 1, 13),
                    OrderedItems = new List<OrderedItemDto>()
                    {
                        new OrderedItemDto(){OrderId = 5, ProductId = 5, Quantity = 2, Price = 12.04, ProductName = "Temp"},
                        new OrderedItemDto(){OrderId = 5, ProductId = 6, Quantity = 2, Price = 7.09, ProductName = "Temp"}
                    }, TotalPrice = 38.26},
                new OrderDto(){OrderId = 6, CustomerId = 3, Date = new DateTime(2020, 12, 1, 6, 1, 13),
                    OrderedItems = new List<OrderedItemDto>()
                    {
                        new OrderedItemDto(){OrderId = 6, ProductId = 6, Quantity = 2, Price = 7.09, ProductName = "Temp"},
                        new OrderedItemDto(){OrderId = 6, ProductId = 7, Quantity = 3, Price = 13.16, ProductName = "Temp"}
                    }, TotalPrice = 53.66},
                new OrderDto(){OrderId = 7, CustomerId = 4, Date = new DateTime(2020, 12, 1, 6, 1, 13),
                    OrderedItems = new List<OrderedItemDto>()
                    {
                        new OrderedItemDto(){OrderId = 7, ProductId = 7, Quantity = 3, Price = 13.16, ProductName = "Temp"},
                        new OrderedItemDto(){OrderId = 7, ProductId = 8, Quantity = 1, Price = 6.25, ProductName = "Temp"}
                    }, TotalPrice = 45.73},
                new OrderDto(){OrderId = 8, CustomerId = 4, Date = new DateTime(2020, 12, 1, 6, 1, 13),
                    OrderedItems = new List<OrderedItemDto>()
                    {
                        new OrderedItemDto(){OrderId = 8, ProductId = 8, Quantity = 3, Price = 6.25, ProductName = "Temp"},
                        new OrderedItemDto(){OrderId = 8, ProductId = 9, Quantity = 2, Price = 14.36, ProductName = "Temp"}
                    }, TotalPrice = 47.47},
                new OrderDto(){OrderId = 9, CustomerId = 5, Date = new DateTime(2020, 12, 1, 6, 1, 13),
                    OrderedItems = new List<OrderedItemDto>()
                    {
                        new OrderedItemDto(){OrderId = 9, ProductId = 9, Quantity = 3, Price = 14.36, ProductName = "Temp"},
                        new OrderedItemDto(){OrderId = 9, ProductId = 10, Quantity = 3, Price = 5.64, ProductName = "Temp"}
                    }, TotalPrice = 60},
                new OrderDto(){OrderId = 10, CustomerId = 5, Date = new DateTime(2020, 12, 1, 6, 1, 13),
                    OrderedItems = new List<OrderedItemDto>()
                    {
                        new OrderedItemDto(){OrderId = 10, ProductId = 10, Quantity = 4, Price = 5.64, ProductName = "Temp"},
                        new OrderedItemDto(){OrderId = 10, ProductId = 1, Quantity = 4, Price = 10.01, ProductName = "Temp"}
                    }, TotalPrice = 62.6},
            };
        }

        public Task<OrderDto> NewOrder(OrderDto newOrder)
        {
            newOrder.OrderId = _orders.OrderByDescending(o => o.OrderId).FirstOrDefault().OrderId + 1;

            _orders.Add(newOrder);

            return Task.FromResult(newOrder);
        }

        public Task<OrderDto> GetOrder(int orderId)
        {
            OrderDto order = _orders.FirstOrDefault(o => o.OrderId == orderId);

            return Task.FromResult(order);
        }

        public Task<IEnumerable<OrderHistoryDto>> GetOrders(int customerId)
        {
            IEnumerable<OrderHistoryDto> orderHistory = _orders.Where(o => o.CustomerId == customerId)
                                                        .Select(h => new OrderHistoryDto
                                                        {
                                                            OrderId = h.OrderId,
                                                            CustomerId = h.CustomerId,
                                                            Date = h.Date,
                                                            TotalPrice = h.TotalPrice
                                                        }).OrderByDescending(d => d.Date);

            return Task.FromResult(orderHistory);
        }
    }
}
