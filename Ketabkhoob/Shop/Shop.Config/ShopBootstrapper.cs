using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application._Utilities;
using Shop.Application.Categories;
using Shop.Application.Products;
using Shop.Application.Sellers;
using Shop.Application.Users;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure;
using Shop.Infrastructure.Persistent.EF.CategoryAgg;
using Shop.Query.Categories.DTOs;

namespace Shop.Config
{
    public static class ShopBootstrapper
    {
        public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstraper.Init(services, connectionString);
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(Directories).Assembly);//commands
                config.RegisterServicesFromAssemblies(typeof(CategoryDto).Assembly);//queries
            });

            services.AddTransient<IProductDomainservice,ProductDomainService>();
            services.AddTransient<ICategoryDomainService,CategoryDomainService>();
            services.AddTransient<ISellerDomainService,SellerDomainService>();
            services.AddTransient<IUserDomainService,UserDomainService>();

            services.AddValidatorsFromAssembly(typeof(Directories).Assembly);
        }
    }
}
