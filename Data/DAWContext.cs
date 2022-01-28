using DAW.Models;
using DAW.Models._1_1;
using DAW.Models._1_M;
using DAW.Models.M_M;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Data
{
    public class DAWContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<DetailsClient> Details { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DAWContext(DbContextOptions<DAWContext> options) : base(options)
        { 
            
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            // One to Many
            modelBuilder.Entity<Shop>()
                        .HasMany(prod => prod.Products)
                        .WithOne(shop => shop.Shop);

            // Many to Many
            modelBuilder.Entity<Order>().HasKey(order => new { order.ClientId, order.ProductId });

            modelBuilder.Entity<Order>()
                        .HasOne<Client>(order => order.Client)
                        .WithMany(client => client.Orders)
                        .HasForeignKey(order => order.ClientId);

            modelBuilder.Entity<Order>()
                        .HasOne<Product>(order => order.Product)
                        .WithMany(product => product.Orders)
                        .HasForeignKey(order => order.ProductId);

            // One to One
            modelBuilder.Entity<DetailsClient>()
                        .HasOne(date => date.Client)
                        .WithOne(utiliz => utiliz.DetailsClient)
                        .HasForeignKey<Client>(utiliz => utiliz.DetailsClientId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
