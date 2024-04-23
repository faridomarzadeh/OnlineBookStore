using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAgg;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.EF.SellerAgg
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(ShopContext shopContext) : base(shopContext)
        {
        }

        public async Task<InventoryResult?> GetInventoryById(long id)
        {
            return await _shopContext.Inventories.Where(r => r.Id == id)
            .Select(i => new InventoryResult()
            {
                Count = i.Count,
                Id = i.Id,
                Price = i.Price,
                ProductId = i.ProductId,
                SellerId = i.SellerId
            }).FirstOrDefaultAsync();
        }
    }
}
