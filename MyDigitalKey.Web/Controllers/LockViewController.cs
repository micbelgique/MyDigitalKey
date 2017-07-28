using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyDigitalKey.Web.Controllers
{
    public class LockViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}