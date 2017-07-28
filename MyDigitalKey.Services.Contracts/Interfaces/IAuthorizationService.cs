using System;
using System.Collections.Generic;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Services.Contracts.Interfaces
{
    public interface IAuthorizationService
    {
        bool IsAuthorized(int digitalKeyBusinessId, Guid lockId);
        IEnumerable<AuthorizationDto> FindAll();
        void Add(AuthorizationDto authorization);
    }
}