using Common.Query.Filter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Query
{
    public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class
    {

    }

    public class IQueryFilter<TResponse, TParam> : IQuery<TResponse>
        where TResponse : BaseFilter
        where TParam : BaseFilterParam
    {
        public TParam FilterParams { get; private set; }
        public IQueryFilter(TParam filterParams)
        {
            FilterParams = filterParams;
        }
    }
}
