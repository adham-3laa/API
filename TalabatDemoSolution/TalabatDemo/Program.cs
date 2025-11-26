
using DomainLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PersintenceLayer;
using PersintenceLayer.Data;
using PersintenceLayer.Repositorys;
using ServiceAbstractionLayer;
using ServiceLayer;
using ServiceLayer.MappingProfiles;
using System.Threading.Tasks;
using TalabatDemo.CustomMiddleWares;
using TalabatDemo.Extensions;
using TalabatDemo.Factories;
using TalabatDemo.Filters;

namespace TalabatDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSwaggerService();


            builder.Services.AddInfrastructureServices(builder.Configuration);


            builder.Services.AddApplicationServices();

           builder.Services.AddWebApplicationServises();

            #endregion

            var app = builder.Build();

            await app.SeedDatabaseAsync();


            app.UseCustomExceptionMiddleware();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app .UseAuthentication ();
            app.UseStaticFiles();


            app.MapControllers();

            app.Run();
        }
    }
}
