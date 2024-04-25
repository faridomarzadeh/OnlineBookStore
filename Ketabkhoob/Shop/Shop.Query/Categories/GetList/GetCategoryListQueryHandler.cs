﻿using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.EF;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetList
{
    public class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var results = await _context.Categories.ToListAsync(cancellationToken);
            var categoryDtoList = new List<CategoryDto>();
            foreach (var item in results)
            {
                categoryDtoList.Add(item.Map());
            }
            return categoryDtoList;
        }
    }
}
