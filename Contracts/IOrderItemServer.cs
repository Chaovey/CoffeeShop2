using CoffeeShop2.Models.OrderItems;

namespace CoffeeShop2.Contracts;

public interface IOrderItemServer :
    IServer<OrderItemResponse, OrderItemCreateReq, OrderItemUpdateReq>
{

}