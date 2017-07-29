using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using MyDigitalKey.Services.Contracts.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MyDigitalKey.Web.Models.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyDigitalKey.Web.Configurations;

namespace MyDigitalKey.Web.Controllers
{
    public class AuthorizationViewController : Controller
    {
        private List<AuthorizationDto> Authorizations { get; set; }
        private List<UserDto> Users { get; set; }
        private List<LockDto> Locks { get; set; }
        public AuthorizationViewController(IOptions<AppSettings> optionsAccessor)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(optionsAccessor.Value.ApiBaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string response = "";
                try
                {
                    response = client.GetStringAsync("api/lock").Result;
                    Locks = JsonConvert.DeserializeObject<List<LockDto>>(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DateTime.Now + ": (AuthorizationViewController) : (Index) : " + ex.Message + "\n" + ex.StackTrace);
                }
                try
                {
                    response = client.GetStringAsync("api/user").Result;
                    Users = JsonConvert.DeserializeObject<List<UserDto>>(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DateTime.Now + ": (AuthorizationViewController) : (Index) : " + ex.Message + "\n" + ex.StackTrace);
                }
                try
                {
                    response = client.GetStringAsync("api/authorization").Result;
                    Authorizations = JsonConvert.DeserializeObject<List<AuthorizationDto>>(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DateTime.Now + ": (AuthorizationViewController) : (Index) : " + ex.Message + "\n" + ex.StackTrace);
                }

                

                foreach (var autho in Authorizations)
                {
                    try
                    {
                        autho.Lock = Locks.First(m => m.Id == autho.Lock.Id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(DateTime.Now + ": (AuthorizationViewController) : (Index) : " + ex.Message + "\n" + ex.StackTrace);
                    }
                    try
                    {
                        autho.User = Users.First(m => (m.Key!= null) &&  (m.Key.Id == autho.User.Key.Id));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(DateTime.Now + ": (AuthorizationViewController) : (Index) : " + ex.Message + "\n" + ex.StackTrace);
                    }
                }
                
            }
        }
        public IActionResult Index()
        {
            AuthorizationsViewModel vm = new AuthorizationsViewModel();
            {
                List<string> userNames = new List<string>();
                foreach (var user in Users)
                {
                    userNames.Add(user.FirstName + " " + user.LastName);
                }
                vm.UserNames = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(userNames);
            }
            {
                List<string> lockName = new List<string>();
                foreach (var l in Locks)
                {
                    lockName.Add(l.Name);
                }
                vm.LockNames = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(lockName);
            }
            vm.Authorizations = Authorizations;
            return View("Index",vm);
        }

        public IActionResult Insert(AuthorizationsViewModel model)
        {

            return Index();
        }
    }
}