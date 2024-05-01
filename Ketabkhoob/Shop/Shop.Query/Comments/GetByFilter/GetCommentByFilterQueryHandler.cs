using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.EF;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter
{
    public class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
    {
        private readonly ShopContext _context;

        public GetCommentByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var results = _context.Comments.OrderByDescending(x=>x.CreationDate).AsQueryable();
            if(@params.CommentStatus!=null)
                results = results.Where(r=>r.Status.Equals(@params.CommentStatus));
            if(@params.UserId!=null)
                results = results.Where(r=>r.UserId.Equals(@params.UserId));
            if (@params.StartDate != null)
                results = results.Where(r => r.CreationDate.Date >= @params.StartDate.Value.Date);
            if (@params.EndDate != null)
                results = results.Where(r=>r.CreationDate.Date <= @params.EndDate.Value.Date);

            var skip = (@params.CurrentPage - 1)*@params.Take;
            var result = new CommentFilterResult()
            {
                Data = await results.Skip(skip).Take(@params.Take).Select(comment => comment.Map()).ToListAsync(cancellationToken),
                FilterParams = @params,
            };
            result.GeneratePaging(results,@params.Take,@params.CurrentPage);
            return result;
        }
    }
}
