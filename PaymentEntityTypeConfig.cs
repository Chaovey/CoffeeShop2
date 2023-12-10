using CoffeeShop2.Models.OrderItems;
using CoffeeShop2.Models.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class PaymentEntityTypeConfig : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("tbpayment");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName(nameof(Payment.Id))
                .HasColumnType("varchar")
                .HasMaxLength(36)
                ;
        builder.Property(x => x.paymentId)
               .IsRequired()
               .HasColumnName(nameof(Payment.paymentId))
               .HasColumnType("varchar")
               .HasMaxLength(50);
        builder.Property(x => x.paymentAmount)
                .IsRequired()
                .HasColumnName(nameof(Payment.paymentAmount))
                .HasColumnType("decimal(18,3)")
                ;
        builder.Property(x => x.paymentDate)
               .IsRequired()
               .HasColumnName(nameof(Payment.paymentDate))
               .HasColumnType("datetime")
               ;
        builder.HasOne(x => x.customers)
               .WithOne(o => o.payment)
               .HasForeignKey<Payment>(o => o.CustomerId)
               .OnDelete(DeleteBehavior.NoAction)
               ;
        builder.HasOne(x => x.orders)
               .WithMany(o => o.payment)
               .HasForeignKey(o => o.orderId)
               .OnDelete(DeleteBehavior.NoAction)
               ;
    }
}
