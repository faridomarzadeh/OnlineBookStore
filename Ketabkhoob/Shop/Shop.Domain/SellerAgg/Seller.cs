﻿using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Services;
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
        public Seller(long userId, string shopName, string nationalCode, ISellerDomainService sellerDomainService)
        {

            Validate(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new List<SellerInventory>();
            if (!sellerDomainService.ValidSeller(this))
                throw new InvalidDomainDataException("اطلاعات فروشگاه نامعتبر است");
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

        public void Edit(string shopName, string nationalCode, ISellerDomainService sellerDomainService)
        {
            Validate(shopName, nationalCode);
            if (nationalCode != NationalCode && sellerDomainService.DbContainsNationalCode(nationalCode))
                throw new InvalidDomainDataException("کد ملی متعلق به شخص دیگری است");
            ShopName = shopName;
            NationalCode = nationalCode;
        }
        public void AddInventory(SellerInventory inventory)
        {
            if (Inventories.Any(f => f.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException(DomainConstants.Exceptions.PRODUCT_ALREADY_ADDED);
            Inventories.Add(inventory);
        }

        public void EditInventory(long inventoryId,int count,int price,int? discountPercentage)
        {
            var currentInventory = Inventories.FirstOrDefault(f=>f.Id == inventoryId);
            if (currentInventory == null)
                return;
            currentInventory.Edit(count, price, discountPercentage);
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
