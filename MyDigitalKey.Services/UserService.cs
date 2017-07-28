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
        }

        public IEnumerable<UserDto> GetAll()
        {
            userRepository.Add(User.Create("Bocken", "Augustin"));
            userRepository.Add(User.Create("Linon", "Barbara"));
            userRepository.Add(User.Create("Quinet", "Romain"));
            userRepository.Add(User.Create("Nguyen", "Duy"));

            return mapper.Map<IEnumerable<UserDto>>(userRepository.FindAll());
        }
    }
}