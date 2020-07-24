using Doan.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("Receipts");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Receipts).HasForeignKey(x => x.SupplierId);
        }
    }
}