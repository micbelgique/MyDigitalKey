using System.Collections.Generic;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Domain
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity FindById(int id);
        IEnumerable<TEntity> FindAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}