using System;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Domain.Models
{
    public class Lock : IAggregateRoot
    {
        private Lock(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public string Name { get; }

        public Guid Id { get; }

        public static Lock Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new Lock(name);
        }
    }
}