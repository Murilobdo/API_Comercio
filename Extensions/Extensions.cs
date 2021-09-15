using System.Text;
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
            cfg.CreateMap<AddProductCommand, ProductEntity>().ConstructUsing(p => new ProductEntity(Guid.NewGuid()));
            cfg.CreateMap<UpdateProductCommand, ProductEntity>();
        }

        public static string GetFullMessage(this Exception exception)
        {
            StringBuilder errorMessage = new StringBuilder();

            do{
                errorMessage.Append(exception.Message);
                exception = exception.InnerException;
            }while(exception != null);

            return errorMessage.ToString();
        }
    }
}