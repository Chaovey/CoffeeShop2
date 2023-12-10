using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Customers;
using CoffeeShop2.Models.Menus;
using CoffeeShop2.Result;

public class MenuService : IMenuServer
{
    private readonly IMenuRepo _repo;

    public MenuService(IMenuRepo repo) {
        _repo = repo;
    }
    public Result<string?> Create(MenuCreateReq rep)
    {
        var menu = new Menu()
        {
            Id=Guid.NewGuid().ToString(),
            menuId=rep.menuKey,
            Name=rep.Name,
            Description=rep.Description,
            Price=rep.Price,

        };
        try
        {
            _repo.Create(menu);
            return Result<string?>.Success(menu.Id, "Successfully Created");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public Result<string?> Delete(string key)
    {
        var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
        if (found == null) return Result<string?>.Fail($"No Menu with id/code, {key}"); ;
        try
        {
            var result = _repo.Delete(found);
            return result == true ? Result<string?>.Success(found.Id, "Successfully deleted")
                    : Result<string?>.Fail($"Failed to delete Menu with id/code, {key}");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Result<List<MenuResponse>> GetAll()
    {
        var result = _repo.GetAll().Select(x => new MenuResponse()
        {
            Id = x.Id,
            menuCode=x.menuId,
            Name=x.Name,
            Description=x.Description,
            Price=x.Price,
        }).ToList();
        return Result<List<MenuResponse>>.Success(result);
    }

    public Result<MenuResponse?> Read(string key)
    {
        var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
        return found == null ? Result<MenuResponse?>.Fail("No Menu with id/code") : Result<MenuResponse?>.Success(
            new MenuResponse()
            {
                Id = found.Id,
                menuCode=found.menuId, 
                Name=found.Name,
                Description=found.Description,
                Price=found.Price,
            },
            "Successfuly Read"
        );
    }

    public Result<string?> Update(MenuUpdateReq rep)
    {

        var menu = new Menu()
        {
            Id = rep.Id,
            menuId=rep.menuKey,
            Name=rep.Name,
            Description=rep.Description,
            Price=rep.Price,
        };
        try
        {
            _repo.Update(menu);
            return Result<string?>.Success(menu.Id, "Successfuly Update");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
