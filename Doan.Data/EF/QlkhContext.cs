using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Doan.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Doan.Data.Entites;
using Microsoft.AspNetCore.Identity;
using Doan.Data.ModelExtensions;

namespace Doan.Data.EF
{
    public class QlkhContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public QlkhContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Config Fluent API
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfigration());
            modelBuilder.ApplyConfiguration(new ProductInVoiceConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfigration());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new ProductReceiptConfiguration());

            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            //Seed data
            modelBuilder.Seed();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ProductInvoice> ProductInvoices { get; set; }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ProductReceipt> ProductReceipts { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}