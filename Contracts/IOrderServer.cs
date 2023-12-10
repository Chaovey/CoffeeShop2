using CoffeeShop2.Models.Orders;
namespace CoffeeShop2.Contracts;

public interface IOrderServer : 
    IServer<OrderResponse, OrderCreateReq, OrderUpdateReq>
{

}
