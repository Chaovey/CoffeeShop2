using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Menus;
using CoffeeShop2.Models.OrderItems;
using Microsoft.EntityFrameworkCore;
namespace CoffeeShop2.Repo
{
    public class OrderItemRepo : IOrderItemRepo
    {
        private readonly IDbContext _dbContext;

        public OrderItemRepo(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(OrderItem entity)
        {
            try
            {
                _dbContext.OrderItem.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Create {ex.Message}");
            }
        }

        public bool Delete(OrderItem entity)
        {
            try
            {
                _dbContext.OrderItem.Remove(entity);
                return (_dbContext.SaveChanges() > 0);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Delete {ex.Message}");
            }
        }

        public IQueryable<OrderItem> GetAll()
        {
            try
            {
                return _dbContext.OrderItem.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to ReadAll {ex.Message}");
            }
        }

        public bool Update(OrderItem entity)
        {
            try
            {
                _dbContext.OrderItem.Update(entity);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Update {ex.Message}");
            }
        }
    }
}
