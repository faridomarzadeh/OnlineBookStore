using Common.Application;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Sellers.EditInventory
{
    internal class EditInventoryCommandHandler : IBaseCommandHandler<EditInventoryCommand>
    {
        private readonly ISellerRepository _sellerRepository;

        public EditInventoryCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<OperationResult> Handle(EditInventoryCommand request, CancellationToken cancellationToken)
        {
            var seller = await _sellerRepository.GetTracking(request.SellerId);
            if (seller == null)
                return OperationResult.NotFound();
            seller.EditInventory(request.InventoryId,request.Count,request.Price,request.DiscountPercentage);
            await _sellerRepository.Save();
            return OperationResult.Success();
        }
    }
}
