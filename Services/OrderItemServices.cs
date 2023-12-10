using CoffeeShop2.Contracts;
using CoffeeShop2.Models.OrderItems;
using CoffeeShop2.Result;

namespace CoffeeShop2.Services
{
    public class OrderItemServices : IOrderItemServer
    {
        private readonly IOrderItemRepo _repo;
        public OrderItemServices(IOrderItemRepo repo)
        {
            _repo = repo;
        }

        public Result<string?> Create(OrderItemCreateReq rep)
        {
            var orderitem = new OrderItem()
            {
                Id = Guid.NewGuid().ToString(),
                orderItemId=rep.orderItemKey,
                quantity=rep.quantity,
                orderId=rep.orderId,
                itemId=rep.itemId
            };
            try
            {
                _repo.Create(orderitem);
                return Result<string?>.Success(orderitem.Id, "Successfully Created");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Result<string?> Delete(string key)
        {
            var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
            if (found == null) return Result<string?>.Fail($"No OrderItem with id/code, {key}"); ;
            try
            {
                var result = _repo.Delete(found);
                return result == true ? Result<string?>.Success(found.Id, "Successfully deleted")
                        : Result<string?>.Fail($"Failed to delete OrderItem with id/code, {key}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Result<List<OrderItemResponse>> GetAll()
        {
            var result = _repo.GetAll().Select(x => new OrderItemResponse()
            {
                Id = x.Id,
                orderItemCode=x.orderItemId,
                quantity=x.quantity,
                orderId=x.orderId,
                itemId=x.itemId
            }).ToList();
            return Result<List<OrderItemResponse>>.Success(result);
        }

        public Result<OrderItemResponse?> Read(string key)
        {
            var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
            return found == null ? Result<OrderItemResponse?>.Fail("No OrderItem with id/code") : Result<OrderItemResponse?>.Success(
                new OrderItemResponse()
                {
                    Id = found.Id,
                    orderItemCode=found.orderItemId,
                    quantity=found.quantity,
                    orderId=found.orderId,
                    itemId=found.itemId
                },
                "Successfuly Read"
            );
        }

        public Result<string?> Update(OrderItemUpdateReq rep)
        {

            var orderitem = new OrderItem()
            {
                Id = rep.Id,
                orderItemId=rep.orderItemKey,
                quantity = rep.quantity,
                orderId=rep.orderId,
                itemId = rep.itemId,
            };
            try
            {
                _repo.Update(orderitem);
                return Result<string?>.Success(orderitem.Id, "Successfuly Update");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
