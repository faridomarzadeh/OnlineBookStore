using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAgg;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.EF.SellerAgg
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        private DapperContext _dapperContext;
        public SellerRepository(ShopContext shopContext, DapperContext dapperContext) : base(shopContext)
        {
            _dapperContext = dapperContext;
        }

        //public async Task<InventoryResult?> GetInventoryById(long id)
        //{
        //    return await _shopContext.Inventories.Where(r => r.Id == id)
        //    .Select(i => new InventoryResult()
        //    {
        //        Count = i.Count,
        //        Id = i.Id,
        //        Price = i.Price,
        //        ProductId = i.ProductId,
        //        SellerId = i.SellerId
        //    }).FirstOrDefaultAsync();
        //}

        public async Task<InventoryResult?> GetInventoryById(long id)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT * From {_dapperContext.Inventories} WHERE Id=@id";
            var result =await connection.QueryFirstOrDefaultAsync<InventoryResult>(sql,new {id});
            return result;
        }
    }
}
