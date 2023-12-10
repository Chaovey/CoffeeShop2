using CoffeeShop2.Contracts;
using CoffeeShop2.Models.Customers;
using CoffeeShop2.Result;

public class CustomerServer : ICustomerServer
{
    private readonly ICustomerRepo _repo;
    public CustomerServer(ICustomerRepo repo)
    {
        _repo = repo;
    }

    public Result<string?> Create(CustomerCreateReq rep)
    {
        var customer = new Customer()
        {
            Id = Guid.NewGuid().ToString(),
            CustomerId = rep.customerKey,
            Name = rep.Name,
            Phone = rep.Phone,
            Order_history = rep.Order_history
        };
        try
        {
            _repo.Create(customer);
            return Result<string?>.Success(customer.Id, "Successfully Created");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public Result<string?> Delete(string key)
    {
        var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
        if (found == null) return Result<string?>.Fail($"No Customer with id/code, {key}"); ;
        try
        {
            var result = _repo.Delete(found);
            return result == true ? Result<string?>.Success(found.Id, "Successfully deleted")
                    : Result<string?>.Fail($"Failed to delete Customer with id/code, {key}");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Result<List<CustomerResponse>> GetAll()
    {
        var result = _repo.GetAll().Select(x => new CustomerResponse()
        {
            Id = x.Id,
            customerCode = x.CustomerId,
            Name = x.Name,
            Phone = x.Phone,
            Order_history = x.Order_history,
        }).ToList();
        return Result<List<CustomerResponse>>.Success(result);
    }

    public Result<CustomerResponse?> Read(string key)
    {
        var found = _repo.GetAll().FirstOrDefault(x => x.Id == key);
        return found == null ? Result<CustomerResponse?>.Fail("No Customer with id/code") : Result<CustomerResponse?>.Success(
            new CustomerResponse()
            {
                Id = found.Id,
                customerCode = found.CustomerId,
                Name = found.Name,
                Phone = found.Phone,
                Order_history = found.Order_history
            },
            "Successfuly Read"
        );
    }

    public Result<string?> Update(CustomerUpdateReq rep)
    {

        var customer = new Customer()
        {
            Id = rep.Id,
            CustomerId = rep.customerKey,
            Name = rep.Name,
            Phone = rep.Phone,
            Order_history = rep.Order_history,
        };
        try
        {
            _repo.Update(customer);
            return Result<string?>.Success(customer.Id, "Successfuly Update");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}