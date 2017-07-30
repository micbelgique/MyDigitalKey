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

        public DateTime StartDate { get; }
        public DateTime? EndDate { get; private set; }
        public bool IsActive { get; private set; }
        public Guid Id { get; }

        public static Authorization Create(Guid lockId, Guid digitalKeyId)
        {
            return new Authorization(digitalKeyId, lockId);
        }

        public void Revoke()
        {
            EndDate = DateTime.Now;
            IsActive = false;
        }

        public void Suspend()
        {
            IsActive = false;
        }

        public void Resume()
        {
            IsActive = true;
        }
    }
}