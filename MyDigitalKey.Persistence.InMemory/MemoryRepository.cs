using System;
using System.Collections.Generic;
using System.Linq;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Persistence.InMemory
{
    public class MemoryRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        protected static List<TEntity> Entities = new List<TEntity>();

        public IEnumerable<TEntity> FindAll()
        {
            return Entities;
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void Clear()
        {
            Entities.Clear();
        }

        public TEntity FindById(Guid id)
        {
            return Entities.FirstOrDefault(x => x.Id == id);
        }
    }
}