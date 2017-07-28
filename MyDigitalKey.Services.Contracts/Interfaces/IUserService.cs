using System.Collections.Generic;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Services.Contracts.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> FindAll();

        void Add(UserDto user);
    }
}