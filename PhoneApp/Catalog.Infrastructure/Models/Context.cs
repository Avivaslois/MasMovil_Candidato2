using Catalog.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Models
{
    namespace Catalog.Infrastructure.Models
    {
        public class Context : DbContext
        {
            public Context(DbContextOptions<Context> options) : base(options) { }

            public Context()
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data source = phoneAppDB.db");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //Initial data inserted on migration (Code First)
                modelBuilder.Entity<Phone>().HasData(
                    new Phone
                    {
                        Id = 1,
                        Name = "Samsung Galaxy S9 256GB",
                        Description = "Galaxy S9 256GB (Unlocked)",
                        Price = new decimal(959.99),
                        ImgUrl = "http://s7d2.scene7.com/is/image/SamsungUS/S9Plus_front_gold?$product-details-jpg$"
                    },
                    new Phone
                    {
                        Id = 2,
                        Name = "Samsung Galaxy S9 128GB",
                        Description = "Galaxy S9 128GB (Unlocked)",
                        Price = new decimal(889.99),
                        ImgUrl = "http://s7d2.scene7.com/is/image/SamsungUS/S9Plus_l30_gold?$product-details-jpg$"
                    },
                    new Phone
                    {
                        Id = 3,
                        Name = "Samsung Galaxy S8 64GB",
                        Description = "Galaxy S8 64GB (Unlocked)",
                        Price = new decimal(589.99),
                        ImgUrl = "http://s7d2.scene7.com/is/image/SamsungUS/S8Plus_Black_Front_032317?$product-details-jpg$"
                    },
                    new Phone
                    {
                        Id = 4,
                        Name = "Samsung Galaxy S8 Active 64GB",
                        Description = "Samsung Galaxy S8 Active 64GB (Sp)",
                        Price = new decimal(850.00),
                        ImgUrl = "http://s7d2.scene7.com/is/image/SamsungUS/spr_g892u_s8_active_gy_v_front_lock?$default-jpg$"
                    },
                    new Phone
                    {
                        Id = 5,
                        Name = "Samsung Galaxy S7 32GB",
                        Description = "Galaxy S7 32GB (TMob)",
                        Price = new decimal(473.00),
                        ImgUrl = "http://s7d2.scene7.compubli/is/image/SamsungUS/SMG930s7_hero_102116?$default-jpg$"
                    });

            }

            public DbSet<Phone> Phones { get; set; }
        }
    }
}
