using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.EF;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId
{
    public class GetCategoriesByParentIdQueryHandler : IQueryHandler<GetCategoriesByParentIdQuery, List<SubCategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoriesByParentIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategoryDto>> Handle(GetCategoriesByParentIdQuery request, CancellationToken cancellationToken)
        {
            var results = await _context.Categories.Where(r=>r.ParentId == request.ParentId).ToListAsync(cancellationToken);
            return results.MapSubCategories();
        }
    }
}
