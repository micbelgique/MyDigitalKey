using MyDigitalKey.Services.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDigitalKey.Web.Models.ViewModels
{
    public class LockViewModel
    {
        public LockViewModel()
        {
            Lock = new LockDto();
        }
        public LockDto Lock { get; set; }
    }
}
