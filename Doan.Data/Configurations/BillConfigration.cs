using Doan.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Configurations
{
    public class BillConfigration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Bills).HasForeignKey(x => x.CustomerId);
        }
    }
}