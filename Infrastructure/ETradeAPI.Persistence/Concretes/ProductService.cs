using ETradeAPI.Application.Abstractions;
using ETradeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts() => new()
        {
            new() { Id=Guid.NewGuid(),Name="product 1",Stock=10,Price=100,CreatedDate=DateTime.Now },
            new() { Id=Guid.NewGuid(),Name="product 2",Stock=20,Price=200,CreatedDate=DateTime.Now },
            new() { Id=Guid.NewGuid(),Name="product 3",Stock=30,Price=300,CreatedDate=DateTime.Now },
            new() { Id=Guid.NewGuid(),Name="product 4",Stock=40,Price=400,CreatedDate=DateTime.Now }
        };
        
    }
}
