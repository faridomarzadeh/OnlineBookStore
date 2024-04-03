using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg
{
    public static class SellerConstants
    {
        public static class ExceptionMessages
        {
            public static string INVALID_PRICE => "The Item price is not valid";
            public static string INVALID_COUNT => "The Item count is not valid";
        }
        public static int MINIMUM_PRICE = 1;
        public static int MINIMUM_COUNT = 0;
    }
}
