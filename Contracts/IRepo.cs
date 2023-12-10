namespace CoffeeShop2.Contracts;

public interface IRepo<IEntity> where IEntity : IKey
{
    void Create(IEntity entity);
    IQueryable<IEntity> GetAll();
    bool Update(IEntity entity);
    bool Delete(IEntity entity);
}
