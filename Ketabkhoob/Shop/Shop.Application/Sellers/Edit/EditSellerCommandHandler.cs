﻿using Common.Application;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Sellers.Edit
{
    internal class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly ISellerDomainService _sellerDomainService;
        public EditSellerCommandHandler(ISellerRepository sellerRepository,
            ISellerDomainService sellerDomainService)
        {
            _sellerRepository = sellerRepository;
            _sellerDomainService = sellerDomainService;
        }

        public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _sellerRepository.GetTracking(request.SellerId);
            if (seller == null)
                return OperationResult.NotFound();

            seller.Edit(request.ShopName, request.NationalCode,_sellerDomainService);
            seller.SetStatus(request.SellerStatus);
            await _sellerRepository.Save();
            return OperationResult.Success();

        }
    }
}
