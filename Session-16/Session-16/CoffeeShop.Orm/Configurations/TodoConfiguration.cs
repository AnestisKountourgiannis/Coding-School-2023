using ClassLibrary1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Orm.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todo");
            builder.HasKey(todo => todo.Id);
            builder.Property(todo => todo.Title).HasMaxLength(50);
        }
    }
}
