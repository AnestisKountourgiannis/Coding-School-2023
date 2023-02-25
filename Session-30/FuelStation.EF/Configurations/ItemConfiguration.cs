using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Configurations {
    public class ItemConfiguration : IEntityTypeConfiguration<Item> {
        public void Configure(EntityTypeBuilder<Item> builder) {

            //Table Name
            builder.ToTable("Items");

            //Primary Key
            builder.HasKey(item => item.Id);
            builder.Property(item => item.Id).ValueGeneratedOnAdd();

            //Properties
            builder.Property(item => item.Code).HasMaxLength(10).IsRequired();
            builder.Property(item => item.Description).HasMaxLength(100).IsRequired();
            builder.Property(item => item.ItemType).IsRequired();
            builder.Property(item => item.Price).HasPrecision(5,2).IsRequired();
            builder.Property(item => item.Cost).HasPrecision(5,2).IsRequired();
        }
    }
}
