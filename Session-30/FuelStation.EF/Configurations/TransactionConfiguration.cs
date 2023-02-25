using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Configurations {
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction> {
        public void Configure(EntityTypeBuilder<Transaction> builder) {

            // Table Name
            builder.ToTable("Transactions");

            // Primary Key
            builder.HasKey(transaction => transaction.Id);
            builder.Property(transaction => transaction.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(transaction => transaction.Date).IsRequired();
            builder.Property(transaction => transaction.PaymentMethod).IsRequired();
            builder.Property(transaction => transaction.TotalValue).HasPrecision(5,2).IsRequired();

            //Relations
            builder.HasOne(transaction => transaction.Customer)
                .WithMany(customer => customer.Transactions)
                .HasForeignKey(transaction => transaction.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(transaction => transaction.Employee)
                .WithMany(employee => employee.Transactions)
                .HasForeignKey(transaction => transaction.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
