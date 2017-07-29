using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyDigitalKey.Services.Contracts.Models;
using MyDigitalKey.Web.Configurations;
using MyDigitalKey.Web.Models.ViewModels;
using Newtonsoft.Json;

namespace MyDigitalKey.Web.Controllers
{
    public class UserViewController : Controller
    {
        private readonly List<UserDto> users = new List<UserDto>();

        public UserViewController(IOptions<AppSettings> optionsAccessor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(optionsAccessor.Value.ApiBaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetStringAsync("api/user").Result;
                users = JsonConvert.DeserializeObject<List<UserDto>>(response);
            }
        }

        public IActionResult Index()
        {
            var vm = new UserViewModel();
            var names = new List<string>();
            foreach (var user in users)
            {
                names.Add(user.FirstName + " " + user.LastName);
            }
            ViewBag.Names = names;
            return View(vm);
        }

        public IActionResult Search(string search)
        {
            var vm = new UserViewModel();
            vm.User = users.First(m => (m.FirstName.ToLower() + " " + m.LastName.ToLower()).Contains(search.ToLower()));
            var names = new List<string>();
            foreach (var user in users)
            {
                names.Add(user.FirstName + " " + user.LastName);
            }
            ViewBag.Names = names;
            return View("Index", new UserViewModel());
        }

        public IActionResult Details(string name)
        {
            var vm = new UserViewModel();
            vm.User = users.Find(m => (m.FirstName + " " + m.LastName).Equals(name));
            var names = new List<string>();
            foreach (var user in users)
            {
                names.Add(user.FirstName + " " + user.LastName);
            }
            ViewBag.Names = names;
            return View("Index", vm);
        }
    }
}