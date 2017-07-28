using Microsoft.AspNetCore.Mvc.Rendering;
using MyDigitalKey.Services.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDigitalKey.Web.Models.ViewModels
{
    public class AuthorizationsViewModel
    {
        public AuthorizationsViewModel()
        {
            Authorizations = new List<AuthorizationDto>();
        }
        public List<AuthorizationDto> Authorizations { get; set; }

        public SelectListItem SelectedUserName { get; set; }
        public SelectListItem SelectedLockName { get; set; }
        public bool CanOpen { get; set;}

        public SelectList UserNames { get; set; }
        public SelectList LockNames { get; set; }
    }
}
