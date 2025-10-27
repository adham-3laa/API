using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersintenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersintenceLayer
{
    public class DataSeeding (StoreDbContext _storeDbContext) : IDataSeeding
    {
        public void DataSeed()
        {
            try
            {
                if (_storeDbContext.Database.GetPendingMigrations().Any())
                {
                    _storeDbContext.Database.Migrate();
                }

                if (!_storeDbContext.ProductBrands.Any())
                {
                    var PrductBrandsData = File.ReadAllText(@"..\PersintenceLayer\Data\DataSeed\brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(PrductBrandsData);
                    if (brands is not null && brands.Any())
                    {
                        _storeDbContext.ProductBrands.AddRange(brands);
                    }
                }

                if (!_storeDbContext.ProductTypes.Any())
                {
                    var PrducttypesData = File.ReadAllText(@"..\PersintenceLayer\Data\DataSeed\types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(PrducttypesData);
                    if (types is not null && types.Any())
                    {
                        _storeDbContext.ProductTypes.AddRange(types);
                    }
                }

                if (!_storeDbContext.Products.Any())
                {
                    var PrductsData = File.ReadAllText(@"..\PersintenceLayer\Data\DataSeed\prducts.json");

                    var prducts = JsonSerializer.Deserialize<List<Product>>(PrductsData);
                    if (prducts is not null && prducts.Any())
                    {
                        _storeDbContext.Products.AddRange(prducts);
                    }
                }
                _storeDbContext.SaveChanges();
            }
            catch (Exception)
            {

                //ToDo
            }

        }
    }
}
