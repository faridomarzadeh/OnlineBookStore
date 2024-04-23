using Microsoft.EntityFrameworkCore;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.EF.OrderAgg
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopContext shopContext) : base(shopContext)
        {
        }

        public async Task<Order?> GetCurrentUserOrder(long userId)
        {
            return await _shopContext.Orders.AsTracking()
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == OrderStatus.Pending);
        }
    }
}
