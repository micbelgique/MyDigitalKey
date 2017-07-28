using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyDigitalKey.Web.Models.ViewModels;
using System.Net.Http;
using MyDigitalKey.Web.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Web.Controllers
{
    public class UserViewController : Controller
    {
        
        private List<UserDto> users = new List<UserDto>();

        public UserViewController()
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31672/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetStringAsync("api/user").Result;
                users = JsonConvert.DeserializeObject<List<UserDto>>(response);
            }
        }

        public IActionResult Index()
        {
            UserViewModel vm = new UserViewModel();
            List<string> names = new List<string>();
            foreach(var user in users)
            {
                names.Add(user.FirstName + " " + user.LastName);
            }
            ViewBag.Names = names;
            return View(vm);
        }
        
        public IActionResult Search(string search)
        {
            UserViewModel vm = new UserViewModel();
            vm.User = users.First(m => (m.FirstName.ToLower() + " " + m.LastName.ToLower()).Contains(search.ToLower()));
            List<string> names = new List<string>();
            foreach (var user in users)
            {
                names.Add(user.FirstName + " " + user.LastName);
            }
            ViewBag.Names = names;
            return View("Index", new UserViewModel());
        }

        public IActionResult Details(string name)
        {
            UserViewModel vm = new UserViewModel();
            vm.User = users.Find(m => (m.FirstName + " " + m.LastName).Equals(name));
            List<string> names = new List<string>();
            foreach (var user in users)
            {
                names.Add(user.FirstName + " " + user.LastName);
            }
            ViewBag.Names = names;
            return View("Index", vm);
        }

    }
}