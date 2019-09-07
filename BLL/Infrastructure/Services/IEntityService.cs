using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.DAL.Infrastructure;

namespace Vision.BLL.Infrastructure.Services
{
    public interface IEntityService<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<T> GetAll<T>();
        SelectList GetAsSelectList();
        T GetById<T>(long id);
        TEntity Create<T>(T model);
        TEntity Update<T>(long id, T model);
        TEntity Save<T>(T model) where T : IViewModel;
        bool Delete(long id);
        bool MarkAsDeleted(long id);
        bool MarkAsDeleted(TEntity entity);
        IRepository<TEntity> Repository { get; }
        IMapper Mapper { get; }
        bool Commit();
    }
}
