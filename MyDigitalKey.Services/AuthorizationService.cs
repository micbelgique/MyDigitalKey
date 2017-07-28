using System;
using AutoMapper;
using MyDigitalKey.Domain.Interfaces;
using MyDigitalKey.Domain.Models;
using MyDigitalKey.Services.Contracts.Interfaces;

namespace MyDigitalKey.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IRepository<Authorization> authorizationRepository;
        private readonly IMapper mapper;

        public AuthorizationService(IMapper mapper, IRepository<Authorization> authorizationRepository)
        {
            this.mapper = mapper;
            this.authorizationRepository = authorizationRepository;
        }

        public bool IsAuthorized(int digitalKeyBusinessId, Guid lockId)
        {
            return true;
        }
    }
}