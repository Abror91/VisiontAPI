using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vision.DAL.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        public Repository(ApplicationDBContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public ApplicationDBContext Context;
        private DbSet<T> DbSet { get; }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsEnumerable();
        }

        public T GetById(long id)
        {
            return Context.Set<T>().FirstOrDefault(s => s.Id == id);
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public bool SaveChanges()
        {
            return Context.SaveChanges() > 0;
        }

        public DbSet<T> Query()
        {
            return Context.Set<T>();
        }

        public void Edit(T entity)
        {
            EntityEntry dbEntityEntry = Context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void EditRange(params T[] entities)
        {
            for (var i = 0; i < entities.Length; i++)
                Edit(entities[i]);
        }

        public void MarkAsRemoved(long id)
        {
            var entity = GetById(id);
            if (entity is IRemovableEntity removableEntity)
                removableEntity.IsDeleted = true;
            else
                throw new Exception("Entity does not inherit from IRemovableEntity");
            Edit(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}
