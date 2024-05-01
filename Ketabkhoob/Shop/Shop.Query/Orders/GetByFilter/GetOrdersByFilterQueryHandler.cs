using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.EF;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter
{
    public class GetOrdersByFilterQueryHandler : IQueryHandler<GetOrdersByFilterQuery, OrderFilterResult>
    {
        private readonly ShopContext _context;

        public GetOrdersByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<OrderFilterResult> Handle(GetOrdersByFilterQuery request, CancellationToken cancellationToken)
        {
            var results = _context.Orders.OrderByDescending(r=>r.CreationDate).AsQueryable();
            var @params = request.FilterParams;
            if (@params.UserId != null)
                results = results.Where(r=>r.UserId == @params.UserId);
            if(@params.StartDate != null)
                results = results.Where(r=>r.CreationDate.Date >= @params.StartDate.Value.Date);
            if(@params.EndDate != null)
                results = results.Where(r=>r.CreationDate.Date <= @params.EndDate.Value.Date);
            if(@params.Province != null)
                results = results.Where(r=>r.Address.Province == @params.Province);
            if (@params.City != null)
                results = results.Where(r=>r.Address.City == @params.City);

            var skip = (@params.CurrentPage - 1)*@params.Take;
            var result = new OrderFilterResult()
            {
                Data = await results.Skip(skip).Select(order => order.MapToFilterData(_context)).ToListAsync(),
                FilterParams = @params,
            };

            result.GeneratePaging(results, @params.Take,@params.CurrentPage);
            return result;
        }
    }
}
