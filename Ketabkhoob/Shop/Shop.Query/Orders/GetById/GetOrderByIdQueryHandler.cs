using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.EF;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById
{
    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto?>
    {
        private readonly ShopContext _shopContext;
        private readonly DapperContext _dapperContext;
        public GetOrderByIdQueryHandler(ShopContext context, DapperContext dapperContext)
        {
            _shopContext = context;
            _dapperContext = dapperContext;
        }

        public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result =await _shopContext.Orders.FirstOrDefaultAsync(f => f.Id == request.OrderId);
            if (result == null) 
                return null;
            var userFullName = await _shopContext.Users.Where(user => user.Id == result.UserId)
                .Select(r => $"{r.Name} {r.Family}").FirstAsync();
            var resultDto = result.Map();
            resultDto.UserFullName = userFullName;
            resultDto.Items =await resultDto.MapOrderItems(_dapperContext);
            return resultDto;
        }
    }
}
