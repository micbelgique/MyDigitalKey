using System;
using System.Collections.Generic;
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

        public AuthorizationService(IMapper mapper, IRepository<Authorization> authorizationRepository)
        {
            this.mapper = mapper;
            this.authorizationRepository = authorizationRepository;
            CreateSampleAuthorization();
        }

        public bool IsAuthorized(int digitalKeyBusinessId, Guid lockId)
        {
            return true;
        }

        public IEnumerable<AuthorizationDto> FindAll()
        {
            return mapper.Map<IEnumerable<AuthorizationDto>>(authorizationRepository.FindAll());
        }

        public void Add(AuthorizationDto authorizationDto)
        {
            var authorization = Authorization.Create(authorizationDto.User.Key.BusinessId, authorizationDto.Lock.Id);
            authorizationRepository.Add(authorization);
        }

        private void CreateSampleAuthorization()
        {
            Add(new AuthorizationDto
            {
                Lock = new LockDto
                {
                    Id = Guid.Parse("4edfb100-cef8-4153-ae95-c61082c6ddda")
                },
                User = new UserDto
                {
                    Key = new DigitalKeyDto
                    {
                        BusinessId = 1
                    }
                },
                CanOpen = true
            });

            Add(new AuthorizationDto
            {
                Lock = new LockDto
                {
                    Id = Guid.Parse("2f01b3b2-f7d4-4718-96ea-05fbf6612d5a")
                },
                User = new UserDto
                {
                    Key = new DigitalKeyDto
                    {
                        BusinessId = 1
                    }
                },
                CanOpen = false
            });
        }
    }
}