using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Query.Filter
{
    public class BaseFilter
    {
        public int EntityCount { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageCount { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int Take { get; private set; }

        public void GeneratePaging(IQueryable<object> data, int take, int currentPage)
        {
            var entityCount = data.Count();
            var pageCount = (int)Math.Ceiling(entityCount / (double)Take);
            PageCount = pageCount;
            CurrentPage = currentPage;
            EndPage = CurrentPage + 5 > PageCount ? PageCount : CurrentPage + 5;
            EntityCount = entityCount;
            StartPage = CurrentPage - 4 <= 0 ? 1 : CurrentPage - 4;
        }
    }

    public class BaseFilterParam
    {
        public int CurrentPage { get; set; } = 1;
        public int Take { get; set; } = 10;

    }

    public class BaseFilter<TData, TParams> : BaseFilter
        where TParams : BaseFilterParam
        where TData : BaseDto
    {
        public List<TData> Data { get; set; }
        public TParams FilterParams { get; set; }
    }
}
