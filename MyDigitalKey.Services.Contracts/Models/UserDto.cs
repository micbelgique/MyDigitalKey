﻿using System;

namespace MyDigitalKey.Services.Contracts.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DigitalKeyDto Key { get; set; }
    }
}