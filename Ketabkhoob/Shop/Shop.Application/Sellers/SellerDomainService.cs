using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        public bool DbContainsNationalCode(string code)
        {
            throw new NotImplementedException();
        }

        public bool ValidSeller(Seller seller)
        {
            throw new NotImplementedException();
        }
    }
}
