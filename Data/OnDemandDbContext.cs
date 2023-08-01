using CarWashSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarWashSystem.Data
{
    public class OnDemandDbContext:DbContext
    {
        public OnDemandDbContext(DbContextOptions dbcontextOptions) : base(dbcontextOptions) { }

        public DbSet<AddOn> AddOns { set; get; }
        public DbSet<Car> Cars { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<Payment> Payments { set; get; }

        public DbSet<WashPackage> WashPackages { set; get; }
        public DbSet<User> Users { set; get; }
    }
}
