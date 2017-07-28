using System;

namespace MyDigitalKey.Web.Models
{
    public class AuthorizationDto
    {
        public Guid Id { get; set; }
        public DigitalKeyDto DigitalKey { get; set; }
        public LockDto Lock { get; set; }
        public bool CanOpen { get; set; }
    }
}