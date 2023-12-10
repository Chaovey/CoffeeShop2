using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Orders;
using CoffeeShop2.Models.Payments;
using CoffeeShop2.Result;

namespace CoffeeShop2.Services
{
    public class PaymentServices : IPaymentServer
    {
        private readonly IPaymentRepo _repo;

        public PaymentServices(IPaymentRepo repo)
        {
            _repo = repo;
        }
        public Result<string?> Create(PaymentCreateReq rep)
        {
            var payment = new Payment()
            {
                Id = Guid.NewGuid().ToString(),
                paymentId=rep.paymentKey,
                paymentAmount=rep.paymentAmount,
                paymentDate=rep.paymentDate,
                CustomerId = rep.CustomerId,
                orderId=rep.orderId,
            };
            try
            {
                _repo.Create(payment);
                return Result<string?>.Success(payment.Id, "Successfully Created");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Result<string?> Delete(string key)
        {
            var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
            if (found == null) return Result<string?>.Fail($"No Payment with id/code, {key}"); ;
            try
            {
                var result = _repo.Delete(found);
                return result == true ? Result<string?>.Success(found.Id, "Successfully deleted")
                        : Result<string?>.Fail($"Failed to delete Payment with id/code, {key}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Result<List<PaymentResponse>> GetAll()
        {
            var result = _repo.GetAll().Select(x => new PaymentResponse()
            {
                Id = x.Id,
                paymentCode=x.paymentId,
                paymentAmount=x.paymentAmount,
                paymentDate=x.paymentDate,
                CustomerId = x.CustomerId,
                orderId=x.orderId,
            }).ToList();
            return Result<List<PaymentResponse>>.Success(result);
        }

        public Result<PaymentResponse?> Read(string key)
        {
            var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
            return found == null ? Result<PaymentResponse?>.Fail("No Payment with id/code") : Result<PaymentResponse?>.Success(
                new PaymentResponse()
                {
                    Id = found.Id,
                    paymentCode=found.paymentId,
                    paymentAmount=found.paymentAmount,
                    paymentDate=found.paymentDate,
                    CustomerId = found.CustomerId,
                    orderId=found.orderId,
                },
                "Successfuly Read"
            );
        }

        public Result<string?> Update(PaymentUpdateReq rep)
        {

            var paymnet = new Payment()
            {
                Id = rep.Id,
                paymentId=rep.paymentKey,
                paymentAmount=rep.paymentAmount,
                paymentDate=rep.paymentDate,
                CustomerId = rep.CustomerId,
                orderId = rep.orderId,
            };
            try
            {
                _repo.Update(paymnet);
                return Result<string?>.Success(paymnet.Id, "Successfuly Update");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
