using System;
using System.Collections.Generic;
using AutoMapper;
using MyDigitalKey.Domain.Interfaces;
using MyDigitalKey.Domain.Models;
using MyDigitalKey.Services.Contracts.Interfaces;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> userRepository;

        public UserService(IMapper mapper, IRepository<User> userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;

            CreateSampleUser();
        }

        public IEnumerable<UserDto> FindAll()
        {
            return mapper.Map<IEnumerable<UserDto>>(userRepository.FindAll());
        }

        public void Add(UserDto userDto)
        {
            var user = User.Create(Guid.NewGuid(), userDto.LastName, userDto.FirstName);

            if (userDto.Key != null)
            {
                user.SetKey(DigitalKey.Create(userDto.Key.Id));
            }

            userRepository.Add(user);
        }

        private void CreateSampleUser()
        {
            var user = User.Create(Guid.Parse("5a643ecd-c7ac-40fd-a435-9f5e115f8e4e"), "Bocken", "Augustin");
            user.SetKey(DigitalKey.Create(Guid.Parse("48029810-08ec-4883-bb0d-35d973ac9de3")));
            userRepository.Add(user);
            
            userRepository.Add(User.Create(Guid.Parse("9aa51c80-0b93-4a1f-a29b-9cda8e9ca31b"), "Linon", "Barbara"));

            user = User.Create(Guid.Parse("eb01eaa2-8ba9-4469-9d35-747c502b2dd5"), "Quinet", "Romain");
            user.SetKey(DigitalKey.Create(Guid.Parse("1c6683d1-5090-40e6-8098-f1c2660ea50b")));
            userRepository.Add(user);


            userRepository.Add(User.Create(Guid.Parse("804e0a22-2bb4-4776-8166-4427600ec7a0"), "Nguyen", "Duy"));
        }
    }
}