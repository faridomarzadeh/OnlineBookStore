using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory:BaseEntity
    {
        public SellerInventory(long productId, int count, int price, int? discountPercentage=null)
        {
            ValidateCount(count);
            ValidatePrice(price);
            ProductId = productId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }

        public long SellerId { get; internal set; }
        public long ProductId { get;private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? DiscountPercentage { get; private set; }

        public void Edit(int count,int price,int? discountPercentage=null) 
        {
            ValidateCount(count);
            ValidatePrice(price);
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }
        public void ValidatePrice(int price)
        {
            if(price<SellerConstants.MINIMUM_PRICE)
                throw new InvalidDomainDataException(SellerConstants.ExceptionMessages.INVALID_PRICE);
        }
        public void ValidateCount(int count)
        {
            if (count < SellerConstants.MINIMUM_COUNT)
                throw new InvalidDomainDataException(SellerConstants.ExceptionMessages.INVALID_COUNT);
        }
    }
}
