using Shop.Domain.OrderAgg.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public class Order
    {
        public long UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public int TotalPrice => Items.Sum(item => item.TotalPrice);
        public int ItemCount => Items.Count;
    }

    public enum OrderStatus
    {
        Pending,
        Finalized,
        Shipping,
        Rejected
    }
    
    public class OrderItem
    {
        public long OrderId { get;internal set; }
        public int TotalPrice { get; private set; }
    }
}
