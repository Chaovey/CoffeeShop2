using CoffeeShop2.Result;
namespace CoffeeShop2.Contracts;

public interface IServer<TR,TC,TU>
    where TR:IResponse
    where TC:ICreateRep
    where TU : IUpdateRep
{
    Result<string?> Create(TC rep);
    Result<List<TR>> GetAll();
    Result<TR> Read(string key);
    Result<string?> Update(TU rep);
    Result<string?> Delete(string key);
}
