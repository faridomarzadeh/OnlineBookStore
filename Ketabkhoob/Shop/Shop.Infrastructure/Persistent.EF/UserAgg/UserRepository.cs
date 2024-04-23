using Shop.Domain.UserAgg;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.EF.UserAgg
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ShopContext shopContext) : base(shopContext)
        {
        }
    }
}
