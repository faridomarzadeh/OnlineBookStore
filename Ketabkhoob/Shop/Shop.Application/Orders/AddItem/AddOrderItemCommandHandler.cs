using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISellerRepository _sellerRepository;

        public AddOrderItemCommandHandler(IOrderRepository repository, ISellerRepository sellerRepository)
        {
            _orderRepository = repository;
            _sellerRepository = sellerRepository;
        }

        public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
           var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
            if (inventory == null)
                return OperationResult.NotFound();
            if (inventory.Count < request.Count)
                return OperationResult.Error($"تعداد {inventory.Count} در انبار موجود است");

            var order = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (order == null)
                order = new Order(request.UserId);
            var orderItem = new OrderItem(request.InventoryId, request.Count, inventory.Price);
            order.AddItem(orderItem);
            if (!SufficientInventoryCount(inventory, order))
                return OperationResult.Error($"تعداد {inventory.Count} در انبار موجود است");

            await _orderRepository.Save();
            return OperationResult.Success();

        }


        private bool SufficientInventoryCount(InventoryResult inventory, Order order)
        {
            if(order == null)
                return false;

            var orderItemCount = order.Items.FirstOrDefault(f => f.InventoryId == inventory.Id).Count;

            return inventory.Count > orderItemCount;
        }
    }
}
