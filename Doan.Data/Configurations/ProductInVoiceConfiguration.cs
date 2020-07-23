using Doan.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.Data.Configurations
{
    public class ProductInVoiceConfiguration : IEntityTypeConfiguration<ProductInvoice>
    {
        public void Configure(EntityTypeBuilder<ProductInvoice> builder)
        {
            builder.ToTable("ProductInvoices");
            builder.HasKey(x => new { x.ProductId, x.InvoiceId });
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.productInvoices).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Invoice).WithMany(x => x.productInvoices).HasForeignKey(x => x.InvoiceId);
        }
    }
}