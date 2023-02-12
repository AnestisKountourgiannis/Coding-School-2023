using CoffeeShop.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.EF.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            /
            builder.ToTable("Customers");

            
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

           
            builder.Property(t => t.Code).HasMaxLength(20).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(150).IsRequired();

           

        }
    }
}
