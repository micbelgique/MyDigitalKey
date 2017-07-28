using System;

namespace MyDigitalKey.Web.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DigitalKeyDto Keys { get; set; }
    }
}