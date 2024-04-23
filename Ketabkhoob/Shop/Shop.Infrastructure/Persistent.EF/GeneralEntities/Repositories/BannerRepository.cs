using Shop.Domain.GeneralEntities;
using Shop.Domain.GeneralEntities.Repositories;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.EF.GeneralEntities.Repositories
{
    public class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public BannerRepository(ShopContext shopContext) : base(shopContext)
        {
        }
    }
}
