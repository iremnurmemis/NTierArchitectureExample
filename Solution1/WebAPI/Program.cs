using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddSingleton<IProductService, ProductManager>();
            //builder.Services.AddSingleton<IProductDal, EfProductDal>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutofacBusinessModule()); });
 
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
