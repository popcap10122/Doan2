using Doan.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Configurations
{
    public class UserCustomerConfiguration : IEntityTypeConfiguration<UserCustomer>
    {
        public void Configure(EntityTypeBuilder<UserCustomer> builder)
        {
            builder.ToTable("UserCustomers");

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(200).IsRequired();

            builder.HasOne(x => x.AppUser).WithOne(x => x.UserCustomer).HasForeignKey<UserCustomer>(x => x.UserId);
        }
    }
}