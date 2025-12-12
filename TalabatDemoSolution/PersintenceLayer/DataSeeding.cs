using DomainLayer.Contracts;
using DomainLayer.Models.Products;
using Microsoft.EntityFrameworkCore;
using PersintenceLayer.Data;
using PersintenceLayer.Identity;
using System.Text.Json;

namespace PersintenceLayer
{
    public class DataSeeding(StoreDbContext _storeDbContext,
    StoreIdentityDbContext identityContext,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            try
            {
                if ((await _storeDbContext.Database.GetPendingMigrationsAsync()).Any())
                {
                  await  _storeDbContext.Database.MigrateAsync();
                }
                var projectRoot = Path.Combine(AppContext.BaseDirectory, @"..\..\..\..", "PersintenceLayer", "Data", "DataSeed");
                var dataPath = Path.GetFullPath(projectRoot);

                if (!_storeDbContext.ProductBrands.Any())
                {
                    //var PrductBrandsData =await File.ReadAllTextAsync(@"..\PersintenceLayer\Data\DataSeed\brands.json");
                    var brandsPath = Path.Combine(dataPath,"brands.json");
                    var PrductBrandsData =  File.OpenRead(brandsPath);
                    var brands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(PrductBrandsData);

                    if (brands is not null && brands.Any())
                    {
                       await  _storeDbContext.ProductBrands.AddRangeAsync(brands);
                    }
                }

                if (!_storeDbContext.ProductTypes.Any())
                {
                    var PrducttypesPath = Path.Combine(dataPath,"types.json");
                    var PrducttypesData = File.OpenRead(PrducttypesPath);

                    var types = await JsonSerializer.DeserializeAsync<List<ProductType>>(PrducttypesData);
                    if (types is not null && types.Any())
                    {
                      await  _storeDbContext.ProductTypes.AddRangeAsync(types);
                    }
                }

                if (!_storeDbContext.Products.Any())
                {
                    var PrductPath = Path.Combine(dataPath,"products.json");
                    var PrductsData = File.OpenRead(PrductPath);

                    var prducts = await JsonSerializer.DeserializeAsync<List<Product>>(PrductsData);
                    if (prducts is not null && prducts.Any())
                    {
                        await _storeDbContext.Products.AddRangeAsync(prducts);
                    }
                }
                await   _storeDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                //ToDo
            }

        }
        public async Task InitializeIdentityAsync()
        {
            
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }

            if (!userManager.Users.Any())
            {
                var superAdminUser = new ApplicationUser
                {
                    DisplayName = "Super Admin",
                    Email = "SuperAdmin@gmail.com",
                    UserName = "SuperAdmin",
                    PhoneNumber = "0123465789"
                };

                var adminUser = new ApplicationUser
                {
                    DisplayName = "Admin",
                    Email = "Admin@gmail.com",
                    UserName = "Admin",
                    PhoneNumber = "0123465789"
                };

                await userManager.CreateAsync(superAdminUser, "Passw0rd");
                await userManager.CreateAsync(adminUser, "Passw0rd");


                await userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
                await userManager.AddToRoleAsync(adminUser, "Admin");

            }

        }
    }
}
