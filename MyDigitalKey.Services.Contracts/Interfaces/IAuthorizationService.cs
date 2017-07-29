using System;
using System.Collections.Generic;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Services.Contracts.Interfaces
{
    public interface IAuthorizationService
    {
        bool IsAuthorized(Guid lockId, int digitalKeyBusinessId);
        IEnumerable<AuthorizationDto> FindAll();
        void Add(AuthorizationDto authorization);
        void Revoke(Guid authorizationId);
        void Suspend(Guid authorizationId);
        void Resume(Guid authorizationId);
    }
}