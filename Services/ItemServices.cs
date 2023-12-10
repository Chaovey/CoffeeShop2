using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Customers;
using CoffeeShop2.Models.Items;
using CoffeeShop2.Result;

namespace CoffeeShop2.Services
{
    public class ItemServices : IItemServer
    {
        private readonly IItemRepo _repo;
        public ItemServices(IItemRepo repo)
        {
            _repo = repo;
        }

        public Result<string?> Create(ItemCreateReq rep)
        {
            var item = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                itemId = rep.itemKey,
                Name = rep.Name,
                Description = rep.Description,
                size = rep.size,
            };
            try
            {
                _repo.Create(item);
                return Result<string?>.Success(item.Id, "Successfully Created");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Result<string?> Delete(string key)
        {
            var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
            if (found == null) return Result<string?>.Fail($"No Item with id/code, {key}"); ;
            try
            {
                var result = _repo.Delete(found);
                return result == true ? Result<string?>.Success(found.Id, "Successfully deleted")
                        : Result<string?>.Fail($"Failed to delete Item with id/code, {key}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Result<List<ItemResponse>> GetAll()
        {
            var result = _repo.GetAll().Select(x => new ItemResponse()
            {
                Id = x.Id,
                itemCode = x.itemId,
                Name = x.Name,
                Description = x.Description,
                size = x.size,
            }).ToList();
            return Result<List<ItemResponse>>.Success(result);
        }

        public Result<ItemResponse?> Read(string key)
        {
            var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
            return found == null ? Result<ItemResponse?>.Fail("No Item with id/code") : Result<ItemResponse?>.Success(
                new ItemResponse()
                {
                    Id = found.Id,
                    itemCode = found.itemId,
                    Name = found.Name,
                    Description = found.Description,
                    size = found.size,
                },
                "Successfuly Read"
            );
        }

        public Result<string?> Update(ItemUpdateReq rep)
        {

            var item = new Item()
            {
                Id = rep.Id,
                itemId = rep.itemKey,
                Name = rep.Name,
                Description = rep.Description,
                size = rep.size,
            };
            try
            {
                _repo.Update(item);
                return Result<string?>.Success(item.Id, "Successfuly Update");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
