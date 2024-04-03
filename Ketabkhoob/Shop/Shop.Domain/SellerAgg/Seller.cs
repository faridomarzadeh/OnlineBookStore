using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg
{
    public class Seller:AggregateRoot
    {
        private Seller()
        {

        }
        public Seller(long userId, string shopName, string nationalCode)
        {
            Validate(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new List<SellerInventory>();
        }

        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public List<SellerInventory> Inventories { get; private set; }
        public DateTime? Lastupdate { get; internal set; }

        public void SetStatus(SellerStatus status)
        {
            Status = status;
            Lastupdate = DateTime.Now;
        }

        public void Edit(string shopName, string nationalCode)
        {
            Validate(shopName, nationalCode);
            ShopName = shopName;
            NationalCode = nationalCode;
        }
        public void AddInventory(SellerInventory inventory)
        {
            if (Inventories.Any(f => f.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException(DomainConstants.Exceptions.PRODUCT_ALREADY_ADDED);
            Inventories.Add(inventory);
        }

        public void EditInventory(SellerInventory inventory)
        {
            var currentInventory = Inventories.FirstOrDefault(f=>f.Id == inventory.Id);
            if (currentInventory == null)
                return;

            Inventories.Remove(currentInventory);
            Inventories.Add(inventory);
        }

        public void DeleteInventory(long inventoryId)
        {
            if (Inventories.Any(f => f.Id == inventoryId))
                Inventories.Remove(Inventories.FirstOrDefault(f => f.Id == inventoryId));
            else
                throw new InvalidDomainDataException(DomainConstants.Exceptions.PRODUCT_NOT_FOUND);
        }
        public void Validate(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName,nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode,nameof(nationalCode));
            if (!nationalCode.IsIdValid())
                throw new InvalidDomainDataException(DomainConstants.Exceptions.INVALID_ID);

        }
    }
}
