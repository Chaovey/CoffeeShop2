using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Customers;
using CoffeeShop2.Models.Items;
using CoffeeShop2.Models.Menus;
using CoffeeShop2.Models.OrderItems;
using CoffeeShop2.Models.Orders;
using CoffeeShop2.Models.Payments;
using Microsoft.EntityFrameworkCore;

public class SqlContext : DbContext, IDbContext
{
    public SqlContext(DbContextOptions<SqlContext> options) : base(options)
    {
        Menu=Set<Menu>();
        Customer=Set<Customer>();
        Order=Set<Order>();
        Payment=Set<Payment>();
        Item=Set<Item>();
        OrderItem=Set<OrderItem>();
    }
    public DbSet<Menu> Menu { get; set; } = default!;
    public DbSet<Customer> Customer { get; set; } = default!;
    public DbSet<Order> Order { get; set; } = default!;
    public DbSet<Payment> Payment { get; set; } = default!;
    public DbSet<Item> Item { get; set; } = default!;
    public DbSet<OrderItem> OrderItem { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MenuEntityTypeConfig());
        modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfig());
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfig());
        modelBuilder.ApplyConfiguration(new PaymentEntityTypeConfig());
        modelBuilder.ApplyConfiguration(new ItemEntityTypeConfig());
        modelBuilder.ApplyConfiguration(new OrderItemEntityTypeConfig());
    }
}
