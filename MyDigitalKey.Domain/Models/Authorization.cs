using System;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Domain.Models
{
    public class Authorization : IAggregateRoot
    {
        private Authorization(int digitalKeyId, Guid lockId)
        {
            DigitalKeyId = digitalKeyId;
            LockId = lockId;
            Id = Guid.NewGuid();
        }

        public int DigitalKeyId { get; }
        public Guid LockId { get; }
        public Guid Id { get; }

        public static Authorization Create(int digitalKeyId, Guid lockId)
        {
            return new Authorization(digitalKeyId, lockId);
        }
    }
}