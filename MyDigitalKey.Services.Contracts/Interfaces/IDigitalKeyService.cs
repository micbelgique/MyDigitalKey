using System;

namespace MyDigitalKey.Services.Contracts.Interfaces
{
    public interface IDigitalKeyService
    {
        void Register(Guid id);
    }
}