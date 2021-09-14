using Microsoft.Extensions.DependencyInjection;
using API.Models;
using API.Data;
using Microsoft.Extensions.Configuration;
using System;
using API.Interfaces;
using API.Data.Repository;
using AutoMapper;
using API.Domain.Product.Command;

namespace API.Extensions
{
    public static class Extensions
    {
        public static void ConfigureMongoDb(this IConfiguration config)
        {
            MongoDbContext.ConnectionString = config.GetSection("MongoConnection:ConnectionString").Value;
            MongoDbContext.DatabaseName = config.GetSection("MongoConnection:Database").Value;
            MongoDbContext.IsSSL = Convert.ToBoolean(config.GetSection("MongoConnection:IsSSL").Value);
        }

        public static void AddInjectionDependency(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void ConfigureMapper(this IMapperConfigurationExpression cfg)
        {
            //--------------DOMAIN--------------
            //PRODUCT
            cfg.CreateMap<AddProductCommand, ProductEntity>();
            cfg.CreateMap<UpdateProductCommand, ProductEntity>();
        }
    }
}