using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyDigitalKey.Domain.Interfaces;
using MyDigitalKey.Domain.Models;
using MyDigitalKey.Services.Contracts.Interfaces;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IRepository<Authorization> authorizationRepository;
        private readonly IMapper mapper;
        private readonly IRepository<User> userRepository;

        public AuthorizationService(IMapper mapper,
            IRepository<Authorization> authorizationRepository,
            IRepository<User> userRepository)
        {
            this.mapper = mapper;
            this.authorizationRepository = authorizationRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<AuthorizationDto> FindAll()
        {
            return mapper.Map<IEnumerable<AuthorizationDto>>(authorizationRepository.FindAll());
        }

        public void Add(AuthorizationDto authorizationDto)
        {
            var authorization = Authorization.Create(authorizationDto.Lock.Id, authorizationDto.User.Key.Id, authorizationDto.IsActive);            
            authorizationRepository.Add(authorization);
        }

        public void Revoke(Guid authorizationId)
        {
            var authorization = authorizationRepository.FindById(authorizationId);
            authorization?.Revoke();
        }

        public void Suspend(Guid authorizationId)
        {
            var authorization = authorizationRepository.FindById(authorizationId);
            authorization?.Suspend();
        }

        public void Resume(Guid authorizationId)
        {
            var authorization = authorizationRepository.FindById(authorizationId);
            authorization?.Resume();
        }

        public bool IsAuthorized(Guid lockId, int digitalKeyBusinessId)
        {
            var user = userRepository.FindAll().SingleOrDefault(x => x.Key.BusinessId == digitalKeyBusinessId);
            if (user == null)
            {
                return false;
            }
            var authorization = authorizationRepository.FindAll().SingleOrDefault(x => x.LockId == lockId && x.DigitalKeyId == user.Key.Id);

            if (authorization == null)
            {
                return false;
            }
            if (!authorization.IsActive)
            {
                return false;
            }

            var now = DateTime.Now;

            if (now >= authorization.StartDate)
            {
                if (authorization.EndDate.HasValue && now > authorization.EndDate.Value)
                {
                    return false;
                }
                return true;
            }
            return false;
        }        
    }
}