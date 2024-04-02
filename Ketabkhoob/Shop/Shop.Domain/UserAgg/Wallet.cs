using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAgg
{
    public class Wallet:BaseEntity 
    {
        public Wallet(int price, string description, bool isFinalized, DateTime? finalizedDate, WalletType type)
        {
            if (price < UserConstants.MINIMUM_PRICE)
                throw new InvalidDomainDataException(UserConstants.ExceptionMessages.INVALID_PRICE);
            Price = price;
            Description = description;
            IsFinalized = isFinalized;
            FinalizedDate = finalizedDate;
            this.type = type;
        }

        public long UserId { get; internal set; }
        public int Price { get; private set; }
        public string Description { get; private set; }

        public bool IsFinalized {  get; private set; }

        public DateTime? FinalizedDate { get; private set; }

        public WalletType type { get; private set; }

        public void Finalize()
        {
            IsFinalized = true;
            FinalizedDate = DateTime.Now;
        }
        public void Finalize(string refCode)
        {
            IsFinalized = true;
            FinalizedDate = DateTime.Now;
            Description += UserConstants.TRACKING_MESSAGE + refCode;
        }
    }
}
