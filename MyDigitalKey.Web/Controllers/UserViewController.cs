using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyDigitalKey.Web.Models.ViewModels;
using System.Net.Http;
using MyDigitalKey.Web.Models;
using System.Net.Http.Headers;

namespace MyDigitalKey.Web.Controllers
{
    public class UserViewController : Controller
    {
        private HttpClient client = new HttpClient();

        public UserViewController()
        {
            client.BaseAddress = new Uri("http://localhost:31672/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IActionResult Index()
        {
            var response = client.GetAsync("api/user").Result;

            return View(new UserViewModel());
        }
        
        public IActionResult Search(UserViewModel model)
        {
            return View("Index", new UserViewModel());
        }
    }
}