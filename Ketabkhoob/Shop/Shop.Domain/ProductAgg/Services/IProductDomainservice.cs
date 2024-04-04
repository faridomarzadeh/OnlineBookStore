using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg.Services
{
    public interface IProductDomainservice
    {
        bool SlugExists(string slugName);
    }
}
