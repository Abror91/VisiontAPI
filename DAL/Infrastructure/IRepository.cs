using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vision.DAL.Infrastructure
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Edit(T entity);
        void EditRange(params T[] entities);
        bool SaveChanges();
        void MarkAsRemoved(long id);
        DbSet<T> Query();
        void Delete(T entity); 
    }
}
