using FinalApi.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.Dal.DAL.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(sc => new { sc.ProductId, sc.CategoryId }); 

            builder.HasOne(sc => sc.Product)
                   .WithMany(s => s.ProductCategories)
                   .HasForeignKey(sc => sc.ProductId);

            builder.HasOne(sc => sc.Category)
                   .WithMany(c => c.ProductCategories)
                   .HasForeignKey(sc => sc.CategoryId);
        }
    }
}
