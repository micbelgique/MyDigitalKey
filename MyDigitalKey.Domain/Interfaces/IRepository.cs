using System;
using System.Collections.Generic;

namespace MyDigitalKey.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity FindById(Guid id);
        IEnumerable<TEntity> FindAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}