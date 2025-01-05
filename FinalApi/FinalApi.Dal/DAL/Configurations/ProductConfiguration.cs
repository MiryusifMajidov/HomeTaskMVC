using FinalApi.Model.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.Dal.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);

           
            builder.HasOne(p => p.Color)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.ColorId)
                   .OnDelete(DeleteBehavior.Restrict);

           
            builder.HasOne(p => p.Size)
                   .WithMany(s => s.Products)
                   .HasForeignKey(p => p.SizeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
