using Common.Query;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Categories.GetByParentId
{
    public record GetCategoriesByParentIdQuery(long ParentId):IQuery<List<SubCategoryDto>>;
}
