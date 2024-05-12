namespace Project.DAL.Repositories.Generic;

public interface IGenericRepository<T>
{
    IEnumerable<T> GetAll();
    T? Getone(int id);
    void Add(T t);
    void Update(T t);
    void Delete(T t);
}
