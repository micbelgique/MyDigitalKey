using System;

namespace MyDigitalKey.Services.Contracts.Models
{
    public class AuthorizationDto
    {
        public AuthorizationDto()
        {
            User = new UserDto();
            Lock = new LockDto();
        }

        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public LockDto Lock { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}