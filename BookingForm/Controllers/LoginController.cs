using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookingForm.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookingForm.Controllers
{
    public class LoginController : Controller
    {
        private readonly BookingFormContext _context;
        private static Sale cur_sale;
        //SaleAPI _api = new SaleAPI();
        //private IdentityApiController identityApiController;
        
        public LoginController(BookingFormContext context)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://id.annhome.vn/");
            //identityApiController = new IdentityApiController(client); 
            _context = context;
            //StreamReader r = new StreamReader("sales.json");
            //string json = r.ReadToEnd();
            //sales = JsonConvert.DeserializeObject<List<Sale>>(json);
        }

        public IActionResult ViewProfile()
        {
            return RedirectToAction("ViewProfile", "Sales", new { cur_sale.ID });
        }

        [Authorize]
        public IActionResult Secure()
        {
            ViewData["Message"] = "Secure page.";

            return View();
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> CallApiUsingClientCredentials()
        {
            var tokenClient = new TokenClient("http://id.annhome.vn/connect/token", "mvc", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("booking");

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);
            var content = await client.GetStringAsync("http://id.annhome.vn/identity");

            ViewBag.Json = JArray.Parse(content).ToString();
            return View("Json");
        }

        public async Task<IActionResult> CallApiUsingUserAccessToken()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            var content = await client.GetStringAsync("http://id.annhome.vn/identity");

            ViewBag.Json = JArray.Parse(content).ToString();
            return View("Json");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tutor()
        {
            return View();
        }

        public IActionResult Switch()
        {
            return RedirectToAction("Index", "Admin", new { });
        }

        public async Task<List<Sale>> get(string email)
        {
            List<Sale> new_sales = new List<Sale>();
            var sales = await _context.sale.ToListAsync();
            foreach (Sale sale in sales)
            {
                if (email.Equals("vinh.hoang@annhome.vn"))
                {
                    if (sale.email == "vinh.hoang@annhome.vn" || sale.email == "truong.nguyen@annhome.vn" || sale.email == "kai.pham@annhome.vn" || sale.email == "clinton.hoang@annhome.vn" ||
                    sale.email == "victory.le@annhome.vn" || sale.email == "clinton.vu@annhome.vn" || sale.email == "clinton.pham@annhome.vn" || sale.email == "clinton.than@annhome.vn" || sale.email == "tom.nguyen@annhome.vn")
                    {
                        new_sales.Add(sale);
                    }
                }
                else if (email.Equals("kai.pham@annhome.vn"))
                {
                    if (sale.email == "kai.pham@annhome.vn" || sale.email == "clinton.hoang@annhome.vn" || sale.email == "victory.le@annhome.vn")
                    {
                        new_sales.Add(sale);
                    }
                }
                else if (email.Equals("truong.nguyen@annhome.vn"))
                {
                    if (sale.email == "truong.nguyen@annhome.vn" || sale.email == "clinton.pham@annhome.vn" || sale.email == "clinton.vu@annhome.vn" || sale.email == "tom.nguyen@annhome.vn")
                    {
                        new_sales.Add(sale);
                    }
                }
            }
            return new_sales;
        }

        [HttpPost]
        public async Task<IActionResult> Home(Sale sale)
        {
            //HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("ProvinceAPI/");
            //if (res.IsSuccessStatusCode)
            //{
            //    var result = res.Content.ReadAsStringAsync().Result;
            //    Console.WriteLine(result);
            //}
            int count = 0;
            var meetings = _context.appoinment.Where(b => b.sale.Contains(sale.email)).OrderBy(m => m.Contract).ToList();
            count = meetings.Count;
            var meeting = _context.appoinment.First();
            sale.email = sale.email.Trim();
            
            ViewBag.sale = sale.email;
            var sales = await _context.sale.ToListAsync();
            var tmp_sale = await _context.sale.FirstAsync(s => s.email.ToLower().Equals(sale.email.ToLower()) && s.pass.Equals(sale.pass));
            if (tmp_sale != null)
            {
                sale.name = tmp_sale.name;
                sale.phone = tmp_sale.phone;
                sale.info = tmp_sale.info;
                sale = tmp_sale;
                cur_sale = tmp_sale;
                ViewBag.crus = sale;
                AppModal modal = new AppModal();
                modal.sale = sale;
                modal.appoinments = meetings;
                return View(modal);
            }
            return View("Index");
        }

        public async Task<IActionResult> Manager(int? id)
        {
            var meetings = await _context.appoinment.Where(m => m.New == true).ToListAsync();
            DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            if (id == 0)
            {
                meetings = await _context.appoinment.Where(m => m.cTime != null && DateTime.ParseExact(m.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF",
                                     System.Globalization.CultureInfo.InvariantCulture).Day == DateTime.Now.Day && m.Confirm == true).ToListAsync();
            }
            else if (id == 1)
            {
                meetings = await _context.appoinment.Where(m => m.cTime != null && DateTime.ParseExact(m.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF",
                                     System.Globalization.CultureInfo.InvariantCulture).Day >= dt.Day && DateTime.ParseExact(m.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF",
                                     System.Globalization.CultureInfo.InvariantCulture).Day <= dt.Day + 6 && m.Confirm == true).ToListAsync();
            }
            else if (id == 2)
            {
                meetings = await _context.appoinment.Where(m => m.cTime != null && DateTime.ParseExact(m.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF",
                                     System.Globalization.CultureInfo.InvariantCulture).Month == DateTime.Now.Month && m.Confirm == true).ToListAsync();
            }
            else
            {
                meetings = await _context.appoinment.Where(m => m.cTime != null && DateTime.ParseExact(m.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF",
                                     System.Globalization.CultureInfo.InvariantCulture).Year == DateTime.Now.Year && m.Confirm == true).ToListAsync();
            }
            Management manager = new Management();
            manager.sales = await get(Convert.ToString(TempData["sale"]));
            manager.appoinments = meetings;
            manager.manager = _context.sale.FirstOrDefault(m => m.email == Convert.ToString(TempData["sale"]));
            return View("Manager", manager);
        }

        public async Task<IActionResult> Chart()
        {
            var meetings = await _context.appoinment.Where(m => m.New == true).ToListAsync();
            var sales = await _context.sale.ToListAsync();
            Management manager = new Management();
            manager.sales = await get(Convert.ToString(TempData["sale"]));
            manager.appoinments = meetings;
            manager.manager = sales.Find(m => m.email == Convert.ToString(TempData["sale"]));
            return View("Chart", manager);
        }

        [HttpGet]
        public IActionResult AddMeeting(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Sale sale = new Sale();
            //var temp = await _context.sale.FirstOrDefaultAsync(s => s.ID == id);
            //sale = temp;
            //TempData["email"] = sale.email;
            return RedirectToAction("Create", "Appoinments", new { id });
        }

        //[HttpGet]
        //public async Task<IActionResult> Draft(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    //Sale sale = new Sale();
        //    //var temp = await _context.sale.FirstOrDefaultAsync(s => s.ID == id);
        //    //sale = temp;
        //    //TempData["email"] = sale.email;
        //    return RedirectToAction("Draft", "Appoinments", new { id });
        //}

        // public IActionResult Meetings(int? id)
        // {
        //     if (id == null)
        //     {
        //         return View("~/Views/Shared/Error.cshtml");
        //     }
        //     Sale tmp = new Sale();
        //     foreach (Sale sale in sales)
        //     {
        //         if (sale.ID == id)
        //         {
        //             tmp = sale;
        //         }
        //     }
        //     var meetings = _context.appoinment
        //.Where(b => b.sale.Contains(tmp.email))
        //.ToList();
        //     return View("~/Views/Sales/Meetings.cshtml", meetings);
        // }

        public async Task<IActionResult> AppDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Appoinment a = await _context.appoinment
       .FirstOrDefaultAsync(b => b.ID == id);
            if (a == null)
            {
                return NotFound();
            }
            var sales = await _context.sale.ToListAsync();
            foreach (Sale sale in sales)
            {
                if (sale.email.Equals(a.sale))
                {
                    TempData["name"] = sale.name;
                }
            }
            
            return RedirectToAction("Print", "Appoinments", new { id });
        }

        public async Task<IActionResult> Views(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Appoinment a = await _context.appoinment
       .FirstOrDefaultAsync(b => b.ID == id);
            if (a == null)
            {
                return NotFound();
            }
            var sales = await _context.sale.ToListAsync();
            foreach (Sale sale in sales)
            {
                if (sale.email.Equals(a.sale))
                {
                    TempData["name"] = sale.name;
                }
            }
            return RedirectToAction("Views", "Appoinments", new { id });
        }

    }
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}