using Doan.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Configurations
{
    public class ProductReceiptConfiguration : IEntityTypeConfiguration<ProductReceipt>
    {
        public void Configure(EntityTypeBuilder<ProductReceipt> builder)
        {
            builder.ToTable("ProductReceipts");
            builder.HasKey(x => new { x.ProductId, x.ReceiptId });

            builder.HasOne(x => x.Receipt).WithMany(x => x.ProductReceipts).HasForeignKey(x => x.ReceiptId);
            builder.HasOne(x => x.Product).WithMany(x => x.productReceipts).HasForeignKey(x => x.ProductId);
        }
    }
}