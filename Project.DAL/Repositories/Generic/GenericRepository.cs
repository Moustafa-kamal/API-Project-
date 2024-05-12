

using Microsoft.EntityFrameworkCore;
using Project.DAL.Data;

namespace Project.DAL.Repositories.Generic;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly APIContext _context;

    public GenericRepository(APIContext context)
    {
        _context = context;
    }

    public void Add(T t)
    {
        _context.Set<T>().Add(t);
    }

    public void Delete(T t)
    {
       _context.Set<T>().Remove(t);
    }

    public IEnumerable<T> GetAll()
    {
        return  _context.Set<T>().ToList();
    }

    public T? Getone(int id)
    {
       return  _context.Set<T>().Find(id);
    }

    public void Update(T t)
    {
        _context.Set<T>().Update(t);
    }
}
