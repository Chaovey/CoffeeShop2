using CoffeeShop2.Models.Menus;

namespace CoffeeShop2.Contracts;

public interface IMenuServer:
    IServer<MenuResponse,MenuCreateReq,MenuUpdateReq>
{

}
