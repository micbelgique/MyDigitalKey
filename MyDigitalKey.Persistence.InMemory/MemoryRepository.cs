using System;
using System.Collections.Generic;
using MyDigitalKey.Domain;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Persistence.InMemory
{
    public class MemoryRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        public TEntity FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}