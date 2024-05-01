using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Common.Query.Filter;

namespace Shop.Query.Orders.DTOs
{
    public class OrderDto:BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus Status { get; set; }
        public OrderDiscount? Discount { get;set; }
        public OrderAddress? Address { get; set; }
        public ShippingMethod? ShippingMethod { get;set; }
        public List<OrderItemDto> Items { get;set; }
        public DateTime? LastUpdate { get;set; }
    }

    public class OrderItemDto:BaseDto
    {
        public ProductOrderItem Product { get; set; }
        public string ShopName { get; set; }
        public long OrderId { get;set; }
        public long InventoryId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int TotalPrice => Count * Price;
    }

    public class ProductOrderItem
    {
        public string ProductTitle { get; set; }
        public string Slug { get; set; }
        public string ImageName { get; set; }
    }

    public class OrderFilterData : BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus Status { get; set; }
        public string? Province { get;  set; }
        public string? City { get; set; }
        public int TotalPrice {  get; set; }
        public int TotalItemCount { get; set; }
        public string? ShippingType { get; set; }
    }

    public class OrderFilterParams:BaseFilterParam
    {
        public long? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
        public OrderStatus? Status { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
    }
    public class OrderFilterResult:BaseFilter<OrderFilterData,OrderFilterParams>
    {

    }
}
