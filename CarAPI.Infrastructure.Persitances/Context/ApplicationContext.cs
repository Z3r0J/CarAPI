using CarAPI.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPI.Infrastructure.Persistance.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder builder) {

            #region Tables

            builder.Entity<Brand>().ToTable("Brand");
            builder.Entity<Car>().ToTable("Car");

            #endregion

            #region Primary Key

            builder.Entity<Car>().HasKey(c => c.Id);

            builder.Entity<Brand>().HasKey(b => b.Id);

            #endregion

            #region Foreign Key

            builder.Entity<Brand>()
                .HasMany(b => b.Cars)
                .WithOne(c => c.Brand)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Properties Configuration

            builder.Entity<Brand>()
                .Property(b => b.Name)
                .IsRequired();


            builder.Entity<Car>()
                .Property(b => b.Model)
                .IsRequired();

            builder.Entity<Car>()
                .Property(b => b.PhotoUrl)
                .IsRequired();

            builder.Entity<Car>()
                .Property(b => b.Speed)
                .IsRequired();

            builder.Entity<Car>()
                .Property(b => b.Year)
                .IsRequired();

            #endregion

        }
    }
}
