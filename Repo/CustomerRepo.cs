using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Customers;
using Microsoft.EntityFrameworkCore;
public class CustomerRepo : ICustomerRepo
{
    private readonly IDbContext _dbContext;

    public CustomerRepo(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(Customer entity)
    {
        try
        {
            _dbContext.Customer.Add(entity);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to Create {ex.Message}");
        }
    }

    public bool Delete(Customer entity)
    {
        try
        {
            _dbContext.Customer.Remove(entity);
            return (_dbContext.SaveChanges() > 0);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to Delete {ex.Message}");
        }
    }

    public IQueryable<Customer> GetAll()
    {
        try
        {
            return _dbContext.Customer.AsQueryable();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to ReadAll {ex.Message}");
        }
    }

    public bool Update(Customer entity)
    {
        try
        {
            _dbContext.Customer.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to Update {ex.Message}");
        }
    }
}