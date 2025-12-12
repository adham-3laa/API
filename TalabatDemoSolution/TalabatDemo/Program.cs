using DomainLayer.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PersintenceLayer;
using PersintenceLayer.Data;
using PersintenceLayer.Identity;
using PersintenceLayer.Repositorys;
using ServiceAbstractionLayer;
using ServiceLayer;
using ServiceLayer.MappingProfiles;
using System.Threading.Tasks;
using TalabatDemo.CustomMiddleWares;
using TalabatDemo.Extensions;
using TalabatDemo.Factories;
using TalabatDemo.Filters;
using DomainLayer.Models.Identity;

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

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<StoreIdentityDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddApplicationServices(builder.Configuration);

            builder.Services.AddWebApplicationServises(builder.Configuration);
            #endregion

            var app = builder.Build();

            await app.SeedDatabaseAsync();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCustomExceptionMiddleware();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
