using ExampleWebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class EFDBContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<City> City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<User> User { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="modelBuilder"></param>
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<City>().HasData(
        //        new City
        //        {
        //            Id = 1,
        //            Name = "Харьков",
        //        },
        //        new City
        //        {
        //            Id = 2,
        //            Name = "Киев",
        //        },
        //        new City
        //        {
        //            Id = 3,
        //            Name = "Минск",
        //        }
        //    );

        //    modelBuilder.Entity<User>().HasData(
        //        new User { Id = 1, Name = "Иван Иванов", CityId = 1 },
        //        new User { Id = 2, Name = "Петров Петр", CityId = 2 },
        //        new User { Id = 3, Name = "Семен Семен", CityId = 3 }
        //          );
        //}

    }
}


