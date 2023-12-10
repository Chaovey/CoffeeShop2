using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Payments;
using Microsoft.EntityFrameworkCore;
namespace CoffeeShop2.Repo
{
    public class PaymentRepo : IPaymentRepo
    {
        private readonly IDbContext _dbContext;

        public PaymentRepo(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Payment entity)
        {
            try
            {
                _dbContext.Payment.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Create {ex.Message}");
            }
        }

        public bool Delete(Payment entity)
        {
            try
            {
                _dbContext.Payment.Remove(entity);
                return (_dbContext.SaveChanges() > 0);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Delete {ex.Message}");
            }
        }

        public IQueryable<Payment> GetAll()
        {
            try
            {
                return _dbContext.Payment.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to ReadAll {ex.Message}");
            }
        }

        public bool Update(Payment entity)
        {
            try
            {
                _dbContext.Payment.Update(entity);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Update {ex.Message}");
            }
        }
    }
}
