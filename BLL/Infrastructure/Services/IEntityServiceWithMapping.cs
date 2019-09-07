using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.DAL.Infrastructure;

namespace Vision.BLL.Infrastructure.Services
{
    public interface IEntityServiceWithMapping<TEntity, TModel> : IEntityService<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TModel> GetAll();
        TModel GetById(long id);
        TEntity Create(TModel model);
        TEntity Update(long id, TModel model);
    }
}
