using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Menus;
using CoffeeShop2.Models.Orders;
using CoffeeShop2.Result;
namespace CoffeeShop2.Services
{
    public class OrderServices : IOrderServer
    {
        private readonly IOrderRepo _repo;

        public OrderServices(IOrderRepo repo)
        {
            _repo = repo;
        }
        public Result<string?> Create(OrderCreateReq rep)
        {
            var order = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                orderId=rep.orderKey,
                orderStatus=rep.orderStatus,
                Price=rep.Price,
                MenuId=rep.MenuId,
                CustomerId=rep.CustomerId,
            };
            try
            {
                _repo.Create(order);
                return Result<string?>.Success(order.Id, "Successfully Created");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Result<string?> Delete(string key)
        {
            var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
            if (found == null) return Result<string?>.Fail($"No Order with id/code, {key}"); ;
            try
            {
                var result = _repo.Delete(found);
                return result == true ? Result<string?>.Success(found.Id, "Successfully deleted")
                        : Result<string?>.Fail($"Failed to delete Order with id/code, {key}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Result<List<OrderResponse>> GetAll()
        {
            var result = _repo.GetAll().Select(x => new OrderResponse()
            {
                Id = x.Id,
                orderCode=x.orderId,
                orderStatus=x.orderStatus,
                Price=x.Price,
                MenuId = x.MenuId,
                CustomerId =x.CustomerId,
            }).ToList();
            return Result<List<OrderResponse>>.Success(result);
        }

        public Result<OrderResponse?> Read(string key)
        {
            var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
            return found == null ? Result<OrderResponse?>.Fail("No Order with id/code") : Result<OrderResponse?>.Success(
                new OrderResponse()
                {
                    Id = found.Id,
                    orderCode=found.orderId,
                    orderStatus = found.orderStatus,
                    Price = found.Price,
                    MenuId=found.MenuId,
                    CustomerId=found.CustomerId,
                },
                "Successfuly Read"
            );
        }

        public Result<string?> Update(OrderUpdateReq rep)
        {

            var order = new Order()
            {
                Id = rep.Id,
                orderId=rep.orderKey,
                orderStatus=rep.ordderStatus,
                Price=rep.Price,
                MenuId=rep.MenuId,
                CustomerId=rep.CustomerId,
            };
            try
            {
                _repo.Update(order);
                return Result<string?>.Success(order.Id, "Successfuly Update");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
