using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Items;
using Microsoft.EntityFrameworkCore;
namespace CoffeeShop2.Repo
{
    public class ItemRepo : IItemRepo
    {
        private readonly IDbContext _dbContext;

        public ItemRepo(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Item entity)
        {
            try
            {
                _dbContext.Item.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Create {ex.Message}");
            }
        }

        public bool Delete(Item entity)
        {
            try
            {
                _dbContext.Item.Remove(entity);
                return (_dbContext.SaveChanges() > 0);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Delete {ex.Message}");
            }
        }

        public IQueryable<Item> GetAll()
        {
            try
            {
                return _dbContext.Item.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to ReadAll {ex.Message}");
            }
        }

        public bool Update(Item entity)
        {
            try
            {
                _dbContext.Item.Update(entity);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Update {ex.Message}");
            }
        }
    }
}
