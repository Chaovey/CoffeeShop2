using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Orders;
using Microsoft.EntityFrameworkCore;
namespace CoffeeShop2.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly IDbContext _dbContext;

        public OrderRepo(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Order entity)
        {
            try
            {
                _dbContext.Order.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Create {ex.Message}");
            }
        }

        public bool Delete(Order entity)
        {
            try
            {
                _dbContext.Order.Remove(entity);
                return (_dbContext.SaveChanges() > 0);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Delete {ex.Message}");
            }
        }

        public IQueryable<Order> GetAll()
        {
            try
            {
                return _dbContext.Order.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to ReadAll {ex.Message}");
            }
        }

        public bool Update(Order entity)
        {
            try
            {
                _dbContext.Order.Update(entity);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Update {ex.Message}");
            }
        }
    }
}
