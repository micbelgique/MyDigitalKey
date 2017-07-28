using System;
using AutoMapper;
using MyDigitalKey.Domain.Interfaces;
using MyDigitalKey.Domain.Models;
using MyDigitalKey.Services.Contracts.Interfaces;

namespace MyDigitalKey.Services
{
    public class DigitalKeyService : IDigitalKeyService
    {
        private readonly IRepository<DigitalKey> digitalKeyRepository;
        private readonly IMapper mapper;

        public DigitalKeyService(IMapper mapper, IRepository<DigitalKey> digitalKeyRepository)
        {
            this.mapper = mapper;
            this.digitalKeyRepository = digitalKeyRepository;
        }

        public void Register(Guid id)
        {
            digitalKeyRepository.Add(DigitalKey.Create(id));
        }
    }
}