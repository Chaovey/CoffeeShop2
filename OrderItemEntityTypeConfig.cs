using CoffeeShop2.Models.OrderItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class OrderItemEntityTypeConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("tborderitem");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName(nameof(OrderItem.Id))
                .HasColumnType("varchar")
                .HasMaxLength(36)
                ;
        builder.Property(x => x.orderItemId)
               .IsRequired()
               .HasColumnName(nameof(OrderItem.orderItemId))
               .HasColumnType("varchar")
               .HasMaxLength(50);
        ;
        builder.Property(x => x.quantity)
                .IsRequired()
                .HasColumnName(nameof(OrderItem.quantity))
                .HasColumnType("int")
                ;
        builder.HasOne(x => x.order)
               .WithMany(o => o.orderItem)
               .HasForeignKey(o => o.orderId)
               .OnDelete(DeleteBehavior.NoAction)
               ;
        builder.HasOne(x => x.item)
               .WithMany(o => o.orderitem)
               .HasForeignKey(o => o.itemId)
               .OnDelete(DeleteBehavior.NoAction)
               ;
    }
}