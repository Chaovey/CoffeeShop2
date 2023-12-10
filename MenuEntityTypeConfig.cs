using CoffeeShop2.Models.Menus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class MenuEntityTypeConfig : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("tbmenu");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName(nameof(Menu.Id))
                .HasColumnType("varchar")
                .HasMaxLength(36)
                ;
        builder.Property(x => x.menuId)
               .IsRequired()
               .HasColumnName(nameof(Menu.menuId))
               .HasColumnType("varchar")
               .HasMaxLength(50)
               ;
        builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName(nameof(Menu.Name))
                .HasColumnType("varchar")
                .HasMaxLength(50);
                ;
        builder.Property(x => x.Description)
                .IsRequired(false)
                .HasColumnName (nameof(Menu.Description))
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                ;
        builder.Property(x => x.Price)
               .IsRequired()
               .HasColumnName(nameof(Menu.Price))
               .HasColumnType("decimal(18,3)")
               ;
    }
}
