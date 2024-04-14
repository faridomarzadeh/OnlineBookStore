using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem:BaseEntity
    {
        public OrderItem(long inventoryId, int count, int price)
        {
            ValidatePrice(price);
            ValidateCount(count);
            InventoryId = inventoryId;
            Count = count;
            Price = price;
        }

        public long OrderId { get;internal set; }
        public long InventoryId {  get; private set; }
        public int Count {  get; private set; }
        public int Price {  get; private set; }
        public int TotalPrice => Count*Price;

        public void SetCount(int newCount)
        {
            ValidateCount(newCount);
            Count = newCount;
        }

        public void IncreaseCount(int count)
        {
            Count += count;
        }

        public void DecreaseCount(int count)
        {
            if(Count -count <=0) 
                return;
            Count -= count;
        }

        public void SetPrice(int newPrice)
        {
            ValidatePrice(newPrice);
            Price = newPrice;
        }

        public void ValidatePrice(int newPrice)
        {
            if (newPrice < OrderConstants.MINIMUM_PRICE)
                throw new InvalidDomainDataException(OrderConstants.ExceptionMessages.INVALID_PRICE);
        }

        public void ValidateCount(int newCount)
        {
            if (newCount < OrderConstants.MINIMUM_COUNT)
                throw new InvalidDomainDataException(OrderConstants.ExceptionMessages.INVALID_COUNT);
        }
    }
}
