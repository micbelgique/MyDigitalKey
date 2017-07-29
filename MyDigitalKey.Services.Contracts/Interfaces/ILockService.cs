using System;
using System.Collections.Generic;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Services.Contracts.Interfaces
{
    public interface ILockService
    {
        IEnumerable<LockDto> FindAll();
        void Register(Guid id, string lockName);
    }
}