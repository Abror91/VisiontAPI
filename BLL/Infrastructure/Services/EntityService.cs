using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vision.DAL.Infrastructure;

namespace Vision.BLL.Infrastructure.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public EntityService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get => _mapper; }
        public IRepository<TEntity> Repository { get => _repository; }

        public virtual IQueryable<TEntity> Query(DbSet<TEntity> query)
        {
            return query;
        }

        public IQueryable<TEntity> Query(Func<DbSet<TEntity>, IQueryable<TEntity>> action)
        {
            if (action == null)
                return Repository.Query();

            return action(Repository.Query());
        }

        public IQueryable<TEntity> Query()
        {
            return Query(query => Query(query));
        }

        public virtual IEnumerable<T> GetAll<T>()
        {
            IEnumerable<TEntity> result = Query();
            return _mapper.Map<IEnumerable<T>>(result);
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> result = Query().Where(predicate);
            return _mapper.Map<IEnumerable<T>>(result);
        }

        public virtual SelectList GetAsSelectList()
        {
            return new SelectList(Query());
        }

        public virtual T GetById<T>(long id)
        {
            var entity = _repository.GetById(id);
            return _mapper.Map<T>(entity);
        }

        public virtual TEntity Create<T>(T model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            _repository.Add(entity);
            _repository.SaveChanges();
            return entity;
        }

        public virtual TEntity Update<T>(long id, T model)
        {
            TEntity entity = _repository.GetById(id);
            entity = _mapper.Map<T, TEntity>(model, entity);
            _repository.Edit(entity);
            _repository.SaveChanges();
            return entity;
        }

        public virtual TEntity Save<T>(T model) where T : IViewModel
        {
            if (model.Id > 0)
                return Update(model.Id, model);
            else
                return Create(model);
        }

        public virtual bool Delete(long id)
        {
            TEntity entity = _repository.GetById(id);
            _repository.Delete(entity);
            return _repository.SaveChanges();
        }

        public virtual bool MarkAsDeleted(long id)
        {
            TEntity entity = _repository.GetById(id);
            if (entity is IRemovableEntity removableEntity)
                removableEntity.IsDeleted = true;
            else
                throw new Exception("Entity does not inherit from IRemovableEntity");
            _repository.Edit(entity);
            return _repository.SaveChanges();
        }

        public virtual bool MarkAsDeleted(TEntity entity)
        {
            if (entity is IRemovableEntity removableEntity)
                removableEntity.IsDeleted = true;
            else
                throw new Exception("Entity does not inherit from IRemovableEntity");
            _repository.Edit(entity);
            return _repository.SaveChanges();
        }

        public bool Commit()
        {
            return _repository.SaveChanges();
        }
    }
}
