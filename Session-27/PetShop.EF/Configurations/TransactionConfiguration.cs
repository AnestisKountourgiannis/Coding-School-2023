using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetShop.Model;

namespace PetShop.EF.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            // Table Name
            builder.ToTable("Transactions");

            // Primary Key
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(t => t.Date).IsRequired();
            builder.Property(t => t.PetPrice).HasPrecision(4, 2).IsRequired();
            builder.Property(t => t.PetFoodQty).IsRequired();
            builder.Property(t => t.PetFoodPrice).HasPrecision(4, 2).IsRequired();
            builder.Property(t => t.TotalPrice).HasPrecision(5, 2).IsRequired();

            // Relations
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Employee)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Pet)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.PetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.PetFood)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.PetFoodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
