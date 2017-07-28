using System;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Domain.Models
{
    public class DigitalKey : IAggregateRoot
    {
        private DigitalKey(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public static DigitalKey Create(Guid id)
        {
            return new DigitalKey(id);
        }
    }
}