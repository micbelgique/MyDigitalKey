using MyDigitalKey.Services.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDigitalKey.Web.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            User = new UserDto();
        }

        public string ResearchString { get; set; }
        public UserDto User { get; set; }
    }
}
