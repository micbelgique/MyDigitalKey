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
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.Text;

namespace MyDigitalKey.Web.Controllers
{
    public class AuthorizationViewController : Controller
    {
        private List<AuthorizationDto> Authorizations { get; set; }
        private List<UserDto> Users { get; set; }
        private List<LockDto> Locks { get; set; }
        public string ApiBaseAddress { get; set; }
        public AuthorizationViewController(IOptions<AppSettings> optionsAccessor)
        {
            ApiBaseAddress = optionsAccessor.Value.ApiBaseAddress;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseAddress);
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
        [HttpGet]
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
        [HttpPost]
        public IActionResult Index(IFormCollection avm)
        {
            var newAuth = new AuthorizationDto();
            foreach(var key in avm.Keys)
            {
                var val = avm[key];
                try
                {
                    switch (key)
                    {
                        case "SelectedUserName":
                            newAuth.User = Users.First(m => (m.FirstName + " " + m.LastName).Equals((string)val));
                            break;
                        case "SelectedLockName":
                            newAuth.Lock = Locks.First(m => m.Name.Equals((string)val));
                            break;
                        case "StartDate":
                            {
                                Regex rex = new Regex("(\\d+)-(\\d+)-(\\d+)T(\\d+):(\\d+):(\\d+).(\\d+).(.*)");
                                var matches = rex.Matches((string)val);
                                var match = matches[0];

                                newAuth.StartDate = new DateTime(int.Parse(match.Groups[1].Value),
                                                                int.Parse(match.Groups[2].Value),
                                                                int.Parse(match.Groups[3].Value),
                                                                int.Parse(match.Groups[4].Value),
                                                                int.Parse(match.Groups[5].Value),
                                                                int.Parse(match.Groups[6].Value));
                            }
                            break;
                        case "EndDate":
                            if (!string.IsNullOrEmpty(val))
                            {
                                Regex rex = new Regex("(\\d+)-(\\d+)-(\\d+)T(\\d+):(\\d+):(\\d+).(\\d+).(.*)");
                                var matches = rex.Matches((string)val);
                                var match = matches[0];

                                newAuth.StartDate = new DateTime(int.Parse(match.Groups[1].Value),
                                                                int.Parse(match.Groups[2].Value),
                                                                int.Parse(match.Groups[3].Value),
                                                                int.Parse(match.Groups[4].Value),
                                                                int.Parse(match.Groups[5].Value),
                                                                int.Parse(match.Groups[6].Value));
                            }
                            break;
                    }
                }
               catch(Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                }
            }
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var rawContent = JsonConvert.SerializeObject(newAuth);
                HttpContent content = new ByteArrayContent(Encoding.UTF8.GetBytes(rawContent));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                try
                {
                    client.PostAsync("api/authorization", content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DateTime.Now + ": (AuthorizationViewController) : (Index) : " + ex.Message + "\n" + ex.StackTrace);
                }
            }
            return Index();
        }
    }
}