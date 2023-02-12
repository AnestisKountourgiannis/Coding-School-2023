using CoffeeShop.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.EF.Configurations
{
    public class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine>
    {
        public void Configure(EntityTypeBuilder<TransactionLine> builder)
        {
            
            builder.ToTable("TransactionLines");

            
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            
            builder.Property(t => t.Quantity).IsRequired();
            builder.Property(t => t.Discount).HasPrecision(3, 2).IsRequired();
            builder.Property(t => t.Price).HasPrecision(3, 2).IsRequired();
            builder.Property(t => t.TotalPrice).HasPrecision(9, 2).IsRequired();

            
            builder.HasOne(t => t.Transaction)
                .WithMany(t => t.TransactionLines)
                .HasForeignKey(t => t.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Product)
                .WithMany(t => t.TransactionLines)
                .HasForeignKey(t => t.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
