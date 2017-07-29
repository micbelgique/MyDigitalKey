using System;
using System.Collections.Generic;
using AutoMapper;
using MyDigitalKey.Domain.Interfaces;
using MyDigitalKey.Domain.Models;
using MyDigitalKey.Services.Contracts.Interfaces;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Services
{
    public class LockService : ILockService
    {
        private readonly IRepository<Lock> lockRepository;
        private readonly IMapper mapper;

        public LockService(IMapper mapper, IRepository<Lock> lockRepository)
        {
            this.mapper = mapper;
            this.lockRepository = lockRepository;

            CreateSampleLock();
        }

        public IEnumerable<LockDto> FindAll()
        {
            return mapper.Map<IEnumerable<LockDto>>(lockRepository.FindAll());
        }

        public void Register(Guid id, string lockName)
        {
            lockRepository.Add(Lock.Create(id, lockName));
        }

        private void CreateSampleLock()
        {
            lockRepository.Add(Lock.Create(Guid.Parse("4edfb100-cef8-4153-ae95-c61082c6ddda"), "Porte d'entrée"));
            lockRepository.Add(Lock.Create(Guid.Parse("2f01b3b2-f7d4-4718-96ea-05fbf6612d5a"), "Cabane jardin"));
            lockRepository.Add(Lock.Create(Guid.Parse("d28e67bc-6ea3-4eec-ab5c-b419e811aab6"), "Porte arrière"));
        }
    }
}