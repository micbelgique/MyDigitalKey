using System;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Domain.Models
{
    public class Lock : IAggregateRoot
    {
        private Lock(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; }

        public Guid Id { get; }

        public static Lock Create(Guid id, string name)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new Lock(id, name);
        }
    }
}