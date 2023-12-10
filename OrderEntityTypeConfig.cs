using CoffeeShop2.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class OrderEntityTypeConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("tborder");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName(nameof(Order.Id))
                .HasColumnType("varchar")
                .HasMaxLength(36)
                ;
        builder.Property(x => x.orderId)
               .IsRequired()
               .HasColumnName(nameof(Order.orderId))
               .HasColumnType("varchar")
               .HasMaxLength(50);
        ;
        builder.Property(x => x.orderStatus)
                .IsRequired()
                .HasColumnName(nameof(Order.orderStatus))
                .HasColumnType("varchar")
                .HasMaxLength(50);
        ;
        builder.Property(x => x.Price)
               .IsRequired()
               .HasColumnName(nameof(Order.Price))
               .HasColumnType("decimal(18,3)")
               ;
        builder.HasOne(x => x.menus)
               .WithMany(o => o.order)
               .HasForeignKey(o => o.MenuId)
               .OnDelete(DeleteBehavior.NoAction)
               ;
        builder.HasOne(x => x.customer)
               .WithMany(o => o.order)
               .HasForeignKey(o => o.CustomerId)
               .OnDelete(DeleteBehavior.NoAction)
               ;
    }
}
