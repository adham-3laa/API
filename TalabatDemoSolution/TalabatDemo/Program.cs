
using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using PersintenceLayer;
using PersintenceLayer.Data;
using PersintenceLayer.Repositorys;
using ServiceAbstractionLayer;
using ServiceLayer;
using ServiceLayer.MappingProfiles;
using System.Threading.Tasks;

namespace TalabatDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }
            );
            builder.Services.AddScoped<IDataSeeding,DataSeeding>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            //builder.Services.AddAutoMapper(p=>p.AddProfile(new productProfile()));
            builder.Services.AddAutoMapper((x) => { },typeof(ServiceLayerAssemblyReference).Assembly);
            #endregion



            var app = builder.Build();

               using   var scope=  app.Services.CreateScope();
             var seedObj =  scope.ServiceProvider.GetRequiredService<IDataSeeding>();
             await  seedObj.DataSeedAsync();

            // Configure the HTTP request pipeline.
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
