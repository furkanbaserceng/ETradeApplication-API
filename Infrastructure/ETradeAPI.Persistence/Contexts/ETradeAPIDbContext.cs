﻿using ETradeAPI.Domain;
using ETradeAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Contexts
{
    public class ETradeAPIDbContext : DbContext
    {
        public ETradeAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {

                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _=>DateTime.UtcNow

                };


            }


            return await base.SaveChangesAsync(cancellationToken);
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
