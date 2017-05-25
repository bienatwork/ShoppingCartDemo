﻿using System;
using System.Threading.Tasks;
using NT.CatalogService.Core;
using NT.CatalogService.Infrastructure;
using NT.Core.SharedKernel;

namespace NT.CatalogService.Migrator
{
    public static class CatalogContextSeeder
    {
        public static async Task Seed(CatalogDbContext dbContext)
        {
            var product = new Product
            {
                Id = new Guid("85db18f3-9c27-47d8-bd45-86dd67068960"),
                Name = "Product 1",
                Model = "Model A",
                Price = 100,
                Quantity = 10,
                DateAdded = DateTimeOffset.UtcNow.DateTime,
                Status = Status.Published
            };

            var supplier = new Supplier
            {
                Id = new Guid("83fd9e15-eadd-44da-8c1a-e7626a767775"),
                ContactName = "Nguyen Van A",
                CompanyName = "Company A",
                ContactTitle = "Provider",
                AddressInfo = new AddressInfo(Guid.NewGuid(), "123 Addrress", "HCM", "Region A", "7000", "VN"),
                ContactInfo = new ContactInfo(Guid.NewGuid(), "123456789", "1234567890", "nguyenvana@companya.com.vn"),
                Products = new System.Collections.Generic.List<Product> { product }                
            };

            await dbContext.Set<Supplier>().AddAsync(supplier);
            await dbContext.SaveChangesAsync();
        }
    }
}