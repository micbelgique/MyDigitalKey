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
            StartDate = DateTime.Now;
        }

        public Guid DigitalKeyId { get; }
        public Guid LockId { get; }
        public Guid Id { get; }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsActive { get; private set; }

        public static Authorization Create(Guid lockId, Guid digitalKeyId)
        {
            return new Authorization(digitalKeyId, lockId);
        }
    }
}