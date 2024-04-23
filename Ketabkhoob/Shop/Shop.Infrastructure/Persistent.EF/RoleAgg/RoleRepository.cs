using Shop.Domain.RoleAgg;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.EF.RoleAgg
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ShopContext shopContext) : base(shopContext)
        {
        }
    }
}
