using CoffeeShop.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.EF.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            
            builder.ToTable("ProductCategories");

            
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            
            builder.Property(t => t.Code).HasMaxLength(20).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(150).IsRequired();
            builder.Property(t => t.ProductType).IsRequired();

            
        }
    }
}
