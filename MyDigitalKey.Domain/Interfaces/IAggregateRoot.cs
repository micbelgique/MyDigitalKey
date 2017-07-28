using System;

namespace MyDigitalKey.Domain.Interfaces
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}