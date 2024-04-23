using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg;
using Shop.Domain.GeneralEntities.Repositories;
using Shop.Domain.OrderAgg;
using Shop.Domain.ProductAgg;
using Shop.Domain.RoleAgg;
using Shop.Domain.SellerAgg;
using Shop.Domain.UserAgg;
using Shop.Infrastructure.Persistent.EF.CategoryAgg;
using Shop.Infrastructure.Persistent.EF.GeneralEntities.Repositories;
using Shop.Infrastructure.Persistent.EF.OrderAgg;
using Shop.Infrastructure.Persistent.EF.ProductAgg;
using Shop.Infrastructure.Persistent.EF.RoleAgg;
using Shop.Infrastructure.Persistent.EF.SellerAgg;
using Shop.Infrastructure.Persistent.EF.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure
{
    public class InfrastructureBootstraper
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IBannerRepository, BannerRepository>();
            services.AddTransient<ISliderRepository, SliderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
