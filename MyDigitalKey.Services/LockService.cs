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

        public void Register(string lockName)
        {
            lockRepository.Add(Lock.Create(lockName));
        }

        private void CreateSampleLock()
        {
            lockRepository.Add(Lock.Create("Porte d'entrée"));
            lockRepository.Add(Lock.Create("Cabane jardin"));
            lockRepository.Add(Lock.Create("Porte arrière"));
        }
    }
}