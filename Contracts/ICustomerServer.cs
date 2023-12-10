using CoffeeShop2.Models.Customers;
namespace CoffeeShop2.Contracts;

public interface ICustomerServer : 
    IServer<CustomerResponse, CustomerCreateReq, CustomerUpdateReq>
{

}
