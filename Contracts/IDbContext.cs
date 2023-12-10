using CoffeeShop2.Models.Customers;
using CoffeeShop2.Models.Items;
using CoffeeShop2.Models.Menus;
using CoffeeShop2.Models.OrderItems;
using CoffeeShop2.Models.Orders;
using CoffeeShop2.Models.Payments;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop2.Contracts;

public interface IDbContext
{
    DbSet<Menu> Menu { get; set; }
    DbSet<Customer> Customer { get; set; }
    DbSet<Order> Order { get; set; }
    DbSet<Payment> Payment { get; set; }
    DbSet<Item> Item { get; set; }
    DbSet<OrderItem> OrderItem { get; set; }
    int SaveChanges();
}

