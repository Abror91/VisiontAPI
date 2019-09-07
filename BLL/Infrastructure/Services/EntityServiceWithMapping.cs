using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vision.DAL.Infrastructure;

namespace Vision.BLL.Infrastructure.Services
{
    public class EntityServiceWithMapping<TEntity, TModel> : EntityService<TEntity>, IEntityServiceWithMapping<TEntity, TModel>, IEntityService<TEntity>
        where TEntity : class, IEntity
        where TModel : class, IViewModel
    {
        public EntityServiceWithMapping(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public virtual IEnumerable<TModel> GetAll()
        {
            return GetAll();
        }

        public virtual TModel GetById(long id)
        {
            return GetById<TModel>(id);
        }

        public virtual IEnumerable<TModel> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return Filter<TModel>(predicate);
        }

        public virtual TEntity Create(TModel model)
        {
            return Create<TModel>(model);
        }

        public virtual TEntity Update(long id, TModel model)
        {
            return Update<TModel>(id, model);
        }
    }
}
