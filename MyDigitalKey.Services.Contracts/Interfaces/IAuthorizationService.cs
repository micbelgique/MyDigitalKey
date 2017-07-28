using System;

namespace MyDigitalKey.Services.Contracts.Interfaces
{
    public interface IAuthorizationService
    {
        bool IsAuthorized(int digitalKeyBusinessId, Guid lockId);
    }
}