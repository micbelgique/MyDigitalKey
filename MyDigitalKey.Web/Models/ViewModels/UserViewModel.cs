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
            Usernames = new List<string>();
            User = new User();
        }
        public string ResearchString { get; set; }
        public List<string> Usernames { get; set; }

        public User User { get; set; }
    }
}
