using CoffeeShop2.Models;
using CoffeeShop2.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class CustomerEntityTypeConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("tbcustomer");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName(nameof(Customer.Id))
                .HasColumnType("varchar")
                .HasMaxLength(36)
                ;
        builder.Property(x => x.CustomerId)
               .IsRequired()
               .HasColumnName(nameof(Customer.CustomerId))
               .HasColumnType("varchar")
               .HasMaxLength(50)
               ;
        builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName(nameof(Customer.Name))
                .HasColumnType("varchar")
                .HasMaxLength(50)
                ;
        builder.Property(x => x.Phone)
                .IsRequired(false)
                .HasColumnName(nameof(Customer.Phone))
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                ;
        builder.Property(x => x.Order_history)
               .IsRequired()
               .HasColumnName(nameof(Customer.Order_history))
               .HasColumnType("int")
               ;
    }
}
