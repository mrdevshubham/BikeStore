using BikeStore.Data.Repositories;
using BikeStore.Data.Repositories.Impl;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Extensions
{
    public static class BikeStoreServiceExtensions
    {

        public static IServiceCollection GetRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            return services;
        }

    }
}
