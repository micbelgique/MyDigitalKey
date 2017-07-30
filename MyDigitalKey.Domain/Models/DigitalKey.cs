using System;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Domain.Models
{
    public class DigitalKey : IAggregateRoot
    {
        private DigitalKey(Guid id, long businessId)
        {
            Id = id;
            BusinessId = businessId;
        }

        private DigitalKey(Guid id)
        {
            Id = id;
        }

        public long BusinessId { get; }

        public Guid Id { get; }

        public static DigitalKey Create(Guid id, long businessId)
        {
            return new DigitalKey(id, businessId);
        }

        public static DigitalKey Create(Guid id)
        {
            return new DigitalKey(id);
        }
    }
}