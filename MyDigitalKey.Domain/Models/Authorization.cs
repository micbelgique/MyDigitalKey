using System;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Domain.Models
{
    public class Authorization : IAggregateRoot
    {
        private Authorization(Guid digitalKeyId, Guid lockId)
        {
            DigitalKeyId = digitalKeyId;
            LockId = lockId;
            Id = Guid.NewGuid();
        }

        public Guid DigitalKeyId { get; }
        public Guid LockId { get; }
        public Guid Id { get; }

        public static Authorization Create(Guid lockId, Guid digitalKeyId)
        {
            return new Authorization(digitalKeyId, lockId);
        }
    }
}