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
using API_MongoDB.Domain.Company.Commands;
using API_MongoDB.Domain.Company;

namespace API.Extensions
{
    public static class Extensions
    {
       

        public static void AddInjectionDependency(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<ICompanyRepository, CompanyRepository>();
            service.AddScoped<AppDbContext>();
        }

        public static void ConfigureHandlers(this IServiceCollection service)
        {
            //--------------PRODUCT--------------
            service.AddScoped<IRequestHandler<AddProductCommand, string>, ProductHandler>();
            service.AddScoped<IRequestHandler<UpdateProductCommand, string>, ProductHandler>();
            service.AddScoped<IRequestHandler<DeleteProductCommand, string>, ProductHandler>();

            //--------------COMPANY--------------
            service.AddScoped<IRequestHandler<LoginCompanyCommand, string>, CompanyHandler>();


            
        }

        public static void ConfigureMapper(this IMapperConfigurationExpression cfg)
        {
            //--------------DOMAIN--------------
            //PRODUCT
            cfg.CreateMap<AddProductCommand, ProductEntity>().ConstructUsing(p => new ProductEntity(Guid.NewGuid()));
            cfg.CreateMap<UpdateProductCommand, ProductEntity>();

            //COMPANY

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