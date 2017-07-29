using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyDigitalKey.Services.Contracts.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MyDigitalKey.Web.Models.ViewModels;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace MyDigitalKey.Web.Controllers
{
    public class LockViewController : Controller
    {
        private List<LockDto> Locks = new List<LockDto>();

        public LockViewController()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31672/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetStringAsync("api/lock").Result;
                Locks = JsonConvert.DeserializeObject<List<LockDto>>(response);
            }
        }

        public IActionResult Index()
        {
            LockViewModel vm = new LockViewModel();
            List<string> names = new List<string>();
            foreach (var l in Locks)
            {
                names.Add(l.Name);
            }
            ViewBag.LocksName = names;
            return View(vm);
        }

        

        public IActionResult Details(string name)
        {
            LockViewModel vm = new LockViewModel();
            vm.Lock = Locks.Find(m => (m.Name).Equals(name));
            List<string> names = new List<string>();
            foreach (var l in Locks)
            {
                names.Add(l.Name);
            }
            ViewBag.LocksName = names;
            return View("Index", vm);
        }
    }
}