using CoffeeShop2.Models.Payments;

namespace CoffeeShop2.Contracts;

public interface IPaymentServer :
    IServer<PaymentResponse, PaymentCreateReq, PaymentUpdateReq>
{

}