using Doan.Data.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.ModelExtensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var ADMIN_ID = "0001";
            var CUSTOMER_ID = "K001";
            var SUPPLIER_ID = "NC01";
            // any guid, but nothing is against to use the same one
            var ROLE_ID = "001";
            var ROLE_ID_CUS = "002";

            //create role
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = ROLE_ID,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator for app"
                },
                new AppRole
                {
                    Id = ROLE_ID_CUS,
                    Name = "customer",
                    NormalizedName = "customer",
                    Description = "customer for app"
                }
                );

            var hasher = new PasswordHasher<AppUser>();
            //create user
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = ADMIN_ID,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "tieplk@gmail.com",
                    NormalizedEmail = "tieplk@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abc123456@"),
                    SecurityStamp = string.Empty,
                    FirstName = "Tiep",
                    LastName = "Le",
                    DoB = new DateTime(2020, 06, 22)
                },
                new AppUser
                {
                    Id = CUSTOMER_ID,
                    UserName = "customer",
                    NormalizedUserName = "customer",
                    Email = "customer@gmail.com",
                    NormalizedEmail = "customer@gmail.com",
                    FirstName = "Nguyễn Văn",
                    LastName = "Minh",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abc123456@"),
                    SecurityStamp = string.Empty,
                    DoB = new DateTime(2020, 06, 22)
                },
                 new AppUser
                 {
                     Id = SUPPLIER_ID,
                     UserName = "supplier",
                     NormalizedUserName = "supplier",
                     Email = "supplier@gmail.com",
                     NormalizedEmail = "supplier@gmail.com",
                     EmailConfirmed = true,
                     PasswordHash = hasher.HashPassword(null, "Abc123456@"),
                     SecurityStamp = string.Empty,
                     DoB = new DateTime(2020, 06, 22),
                     Name = "Công ty Phân phối ABC",
                     Address = "142 Tô Hiến Thành Hà Nội",
                     NameContact = "Anh Hải"
                 }
              );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID_CUS,
                    UserId = CUSTOMER_ID
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = "H001",
                    Name = "Bánh",
                    Unit = "Hộp",
                },
                new Product
                {
                    Id = "H002",
                    Name = "Kẹo",
                    Unit = "Lốc",
                });

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = 0001,
                    DateContract = DateTime.Now,
                    CustomerId = "K001",
                    Discount = 10,
                });
            modelBuilder.Entity<Bill>().HasData(
                new Bill
                {
                    Id = "T001",
                    BillDate = DateTime.Now,
                    CustomerId = "K001",
                    Price = 1000,
                });
            modelBuilder.Entity<ProductInvoice>().HasData(
                new ProductInvoice
                {
                    ProductId = "H001",
                    InvoiceId = 0001,
                    Quantity = 10,
                    Price = 50
                });

            modelBuilder.Entity<Receipt>().HasData(
               new Receipt
               {
                   Id = "N001",
                   DateAdd = DateTime.Now,
                   SupplierId = "NC01",
               });
        }
    }
}