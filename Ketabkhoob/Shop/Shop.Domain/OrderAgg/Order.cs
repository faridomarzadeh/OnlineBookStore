using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public class Order:AggregateRoot
    {
        private Order()
        {
            
        }
        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }

        public long UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public OrderAddress? Address { get; private set; }
        public ShippingMethod? ShippingMethod { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public int TotalPrice
        { 
            get
            {
                var totalPrice = Items.Sum(x => x.TotalPrice);
                if (ShippingMethod!=null)
                    totalPrice += ShippingMethod.ShippingCost;

                if (Discount != null)
                    totalPrice -= Discount.DiscountAmount;

                return totalPrice;
            }
        }
        public int ItemCount => Items.Count;

        public void AddItem(OrderItem item)
        {
            ChangeOrderCountValidator();
            var oldItem = Items.FirstOrDefault(x => x.InventoryId == item.InventoryId);
            if (oldItem != null)
            {
                oldItem.SetCount(item.Count+oldItem.Count);
                return;
            }
            Items.Add(item);
        }

        public void RemoveItem(long itemId)
        {
            var item = Items.FirstOrDefault(f => f.Id == itemId);
            if(item != null)
            {
                Items.Remove(item);
            }
        }

        public void IncreaseItemCount(long itemId, int count)
        {
            ChangeOrderCountValidator();
            var item = Items.FirstOrDefault(f=>f.Id == itemId);
            if (item == null)
                throw new NullOrEmptyDomainDataException("Item not found");
            item.IncreaseCount(count);
        }

        public void DecreaseItemCount(long itemId, int count)
        {
            ChangeOrderCountValidator();
            var item = Items.FirstOrDefault(f => f.Id == itemId);
            if (item == null)
                throw new NullOrEmptyDomainDataException("Item not found");
            item.IncreaseCount(count);
        }

        public void SetItemCount(long itemId, int count)
        {
            var currentItem = Items.FirstOrDefault(f=>f.Id == itemId);
            if(currentItem != null)
            {
                currentItem.SetCount(count);
            }
            else
            {
                throw new NullOrEmptyDomainDataException();
            }
        }

        public void SetStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Checkout(OrderAddress orderAddress)
        {
            Address = orderAddress;
        }

        private void ChangeOrderCountValidator()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidDomainDataException("can not change this order");
        }

    }
}
