using CoffeeShop2.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ItemEntityTypeConfig : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("tbitem");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName(nameof(Item.Id))
                .HasColumnType("varchar")
                .HasMaxLength(36)
                ;
        builder.Property(x => x.itemId)
               .IsRequired()
               .HasColumnName(nameof(Item.itemId))
               .HasColumnType("varchar")
               .HasMaxLength(50)
               ;
        builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName(nameof(Item.Name))
                .HasColumnType("varchar")
                .HasMaxLength(50)
                ;
        builder.Property(x => x.Description)
                .IsRequired(false)
                .HasColumnName(nameof(Item.Description))
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                ;
        builder.Property(x => x.size)
               .IsRequired()
               .HasColumnName(nameof(Item.size))
               .HasColumnType("varchar")
               .HasMaxLength(50)
               ;
    }
}