using Dapper;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.EF;
using Shop.Query.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Orders
{
    public static class OrderMapper
    {
        public static OrderDto Map(this Order order)
        {
            return new OrderDto()
            {
                Address = order.Address,
                CreationDate = order.CreationDate,
                Id = order.Id,
                Discount = order.Discount,
                LastUpdate = order.LastUpdate,
                ShippingMethod = order.ShippingMethod,
                Status = order.Status,
                UserId = order.UserId,
            };
        }
        public static async Task<List<OrderItemDto>> MapOrderItems(this OrderDto order, DapperContext dapperContext)
        {
            using var connection = dapperContext.CreateConnection();
            var sql = $"SELECT s.ShopName, o.OrderId, o.InventoryId,o.Count, o.Price," +
                $"p.Title as Product.Title, p.Slug as Product.Slug" +
                $" FROM {dapperContext.OrderItems} o" +
                $"Inner Join {dapperContext.Inventories} i on o.InventoryId=i.Id" +
                $"Inner Join {dapperContext.Products} p on i.ProductId=p.Id" +
                $"Inner Join {dapperContext.Sellers} s on i.SellerId=s.Id" +
                $"where o.OrderId=@orderId";

            var queryResult =await connection.QueryAsync<OrderItemDto>(sql, new { orderId = order.Id });
            return queryResult.ToList();
        }

        public static OrderFilterData MapToFilterData(this Order order,ShopContext context)
        {
            var userFullName = context.Users.Where(f => f.Id == order.UserId)
                .Select(f => $"{f.Name} {f.Family}").First();
            return new OrderFilterData()
            {
                City = order.Address?.City,
                Id = order.Id,
                CreationDate = order.CreationDate,
                Province = order.Address?.Province,
                ShippingType = order.ShippingMethod?.ShippingType,
                Status = order.Status,
                TotalItemCount = order.ItemCount,
                TotalPrice = order.TotalPrice,
                UserId = order.UserId,
                UserFullName = userFullName
            };
        }
    }
}
