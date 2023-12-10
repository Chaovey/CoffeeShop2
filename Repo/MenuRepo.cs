using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Menus;
using Microsoft.EntityFrameworkCore;
public class MenuRepo : IMenuRepo
{
    private readonly IDbContext _dbContext;

    public MenuRepo(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(Menu entity)
    {
        try
        {
            _dbContext.Menu.Add(entity);
            _dbContext.SaveChanges();
        }catch (Exception ex)
        {
            throw new Exception($"Failed to Create {ex.Message}");
        }
    }

    public bool Delete(Menu entity)
    {
        try
        {
            _dbContext.Menu.Remove(entity);
            return (_dbContext.SaveChanges() > 0);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to Delete {ex.Message}");
        }
    }

    public IQueryable<Menu> GetAll()
    {
        try
        {
            return _dbContext.Menu.AsQueryable();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to ReadAll {ex.Message}");
        }
    }

    public bool Update(Menu entity)
    {
        try
        {
            _dbContext.Menu.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to Update {ex.Message}");
        }
    }
    
}
