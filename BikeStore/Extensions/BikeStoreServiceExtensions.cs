using BikeStore.Business.Service;
using BikeStore.Business.Service.Impl;
using BikeStore.Data.Repositories;
using BikeStore.Data.Repositories.Impl;
using BikeStore.Data.Repositories.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Extensions
{
    public static class BikeStoreServiceExtensions
    {

        public static IServiceCollection GetBikeStoreRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection GetBikeStoreCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IStoreService, StoreService>();

            return services;
        }

    }
}
