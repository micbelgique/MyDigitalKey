using System;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Domain.Models
{
    public class DigitalKey : IAggregateRoot
    {
        private DigitalKey()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public static DigitalKey Create()
        {
            return new DigitalKey();
        }
    }
}