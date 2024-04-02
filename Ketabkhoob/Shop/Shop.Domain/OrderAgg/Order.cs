using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public class Order
    {
        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
        }

        public long UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public OrderAddress? Address { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public int TotalPrice => Items.Sum(item => item.TotalPrice);
        public int ItemCount => Items.Count;
    }
}
