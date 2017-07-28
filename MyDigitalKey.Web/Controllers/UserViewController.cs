using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyDigitalKey.Web.Models.ViewModels;

namespace MyDigitalKey.Web.Controllers
{
    public class UserViewController : Controller
    {
        public IActionResult Index()
        {

            return View(new UserViewModel());
        }
        
        public IActionResult Search(UserViewModel model)
        {
            return View("Index", new UserViewModel());
        }
    }
}