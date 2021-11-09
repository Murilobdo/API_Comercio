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
using MediatR;
using API.Domain.Product;

namespace API.Extensions
{
    public static class Extensions
    {
       

        public static void AddInjectionDependency(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<AppDbContext>();
        }

        public static void ConfigureHandlers(this IServiceCollection service)
        {
            //--------------PRODUCT--------------
            service.AddScoped<IRequestHandler<AddProductCommand, string>, EmpregadorHandler>();
            service.AddScoped<IRequestHandler<UpdateProductCommand, string>, EmpregadorHandler>();
            service.AddScoped<IRequestHandler<DeleteProductCommand, string>, EmpregadorHandler>();

            
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