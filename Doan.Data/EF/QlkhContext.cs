using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Doan.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Doan.Data.Entites;
using Microsoft.AspNetCore.Identity;

namespace Doan.Data.EF
{
    public class QlkhContext : IdentityDbContext<AppUser, AppRole, Guid>
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
            modelBuilder.ApplyConfiguration(new UserCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new UserSuplierConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ProductInvoice> ProductInvoices { get; set; }
        public DbSet<UserCustomer> UserCustomers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ProductReceipt> ProductReceipts { get; set; }
        public DbSet<UserSupplier> UserSuppliers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}