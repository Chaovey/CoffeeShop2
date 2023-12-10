using CoffeeShop2.Models.Items;

namespace CoffeeShop2.Contracts;

public interface IItemServer :
    IServer<ItemResponse, ItemCreateReq, ItemUpdateReq>
{

}