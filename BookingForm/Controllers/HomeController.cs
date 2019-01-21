﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookingForm.Models;
using IdentityModel.Client;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using Request = BookingForm.Models.Request;

namespace BookingForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Sale> _userManager;
        private readonly BookingFormContext _context;
        private static Sale cur_sale;
        //SaleAPI _api = new SaleAPI();
        //private IdentityApiController identityApiController;
        
        public HomeController(BookingFormContext context, UserManager<Sale> userManager)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://id.annhome.vn/");
            //identityApiController = new IdentityApiController(client); 
            _context = context;
            _userManager = userManager;
            //StreamReader r = new StreamReader("sales.json");
            //string json = r.ReadToEnd();
            //sales = JsonConvert.DeserializeObject<List<Sale>>(json);
        }

        public async Task<bool> IsAuthorized(Sale sale, string resource, string operation)
        {
            var roles = await _userManager.GetRolesAsync(sale);
            var grants = await _context.Grants.Where(g => g.Operation == operation && g.Resource == resource && g.Permission == "Allow").ToListAsync();
            if (sale == null)
            {
                return false;
            }
            if (grants != null)
            {
                foreach (var grant in grants)
                {
                    if (roles.Contains(grant.RoleName))
                    {
                        return true;
                    }
                }
            }
            Log.Warning("Access denied! User " + sale.Name + " tried to " + operation + " " + resource + ".");
            return false;
        }

        [HttpGet]
        public async Task<IActionResult> Contracts(Guid id)
        {
            ViewBag.plan = await _context.Plans.ToListAsync();
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Create");
            TempData["StatusMessage"] = TempData["StatusMessage"];
            if (!authorized)
            {
                return View("AccessDenied");
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound("Can't find any contact with id " + id);
            }
            TempData["Customer"] = contact.Name;
            TempData["Phone"] = contact.Phone;
            TempData["Email"] = contact.Email;
            return RedirectToAction("Create", "Appoinments");
        }

        public async Task<IActionResult> AddContact()
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contacts", "Create");
            TempData["StatusMessage"] = TempData["StatusMessage"];
            if (!authorized)
            {
                return View("AccessDenied");
            }
            ViewBag.sales = await _context.sale.Where(s => s.Type == "Internal").ToListAsync();
            return View();
        }

        public async Task<IActionResult> Contacts()
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contacts", "List");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            var contacts = await _context.Contacts.Where(c => c.Provider == curUser).ToListAsync();
            foreach (Contact contact in contacts)
            {
                if (contact.AppoinmentId != null)
                {
                    contact.Appoinment = await _context.appoinment.FindAsync(contact.AppoinmentId);
                }
                if (contact.SupporterId != null)
                {
                    contact.Supporter = await _context.sale.FindAsync(contact.SupporterId);
                }
                _context.Update(contact);
            }
            return View(contacts);
        }

        // POST: Collabor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddContact([Bind("Name,Phone,Email,Note,Condition,CNumber,PNumber,Ch,Price,Policy,Charges,Totals,PDate, q4a, q5a" +
            ",q5b,q5c,q5d,q6a,q6b,q6c,q7a,q7b,q7c,q7d,q7e,q7f,q7g,q7h,q7i,q7j,q7k,q7l,q7m,SupporterId")] Contact contact)
        {
            //if (ModelState.IsValid)
            //{
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contacts", "Create");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            var tmp = _context.Contacts.SingleOrDefault(m => m.Phone == contact.Phone);
            if (tmp != null)
            {
                TempData["StatusMessage"] = "Khách hàng đã tồn tại trong hệ thống";
                return RedirectToAction("AddContact");
            }
            contact.Signed = false;
            contact.PDate = DateTime.Now;
            _context.Contacts.Add(contact);
            contact.Provider = curUser;
            contact.Charges = 0.25;
            TempData["StatusMessage"] = "Thêm thành công";
            if (contact.q4a == null || (contact.q5a == false && contact.q5b == false && contact.q5c == false && contact.q5d == false)
                || (contact.q6b == false && contact.q6c == false && contact.q6a == false) || (contact.q7l == false && contact.q7k == false &&
                contact.q7a == false && contact.q7b == false && contact.q7e == false && contact.q7h == false && contact.q7j == false &&
                contact.q7d == false && contact.q7c == false && contact.q7f == false && contact.q7g == false && contact.q7i == false &&
                contact.q7m == false) || contact.Note == null)
            {
                contact.Charges = 0.25;
                await _context.SaveChangesAsync();
                return RedirectToAction("AddContact");
            }
            else
            {
                contact.Charges = 0.6;
                await _context.SaveChangesAsync();
                return RedirectToAction("AddContact");
            }
            //if (contact.note != null)
            //{
            //    contact.charges = 1.0;
            //}
            //if (contact.q6a == true || contact.q6b == true || contact.q6c == true || contact.q6d == true || contact.q6e == true ||
            //    contact.q6f == true || contact.q6g == true || contact.q6h == true || contact.q6i == true || contact.q6j == true ||
            //    contact.q6k == true || contact.q6l == true || contact.q6m == true)
            //{
            //    contact.charges = 1.0;
            //}
            //await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Home));
            //}
        }

        public IActionResult ViewProfile()
        {
            return RedirectToAction("ViewProfile", "Sales", new { cur_sale.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Request()
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Create");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Request([Bind("Subject", "Contents", "RequestName")] Request request)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Create");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            request.Owner = await _userManager.GetUserAsync(User);
            request.Status = Status.Pending;
            request.Contents += "-From[" + request.Owner.Name + "]";
            if (!ModelState.IsValid)
            {
                TempData["StatusMessage"] = "Request submission failed!";
                return View();
            }
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            //string contents = "Bạn nhận được một yêu cầu từ " + curUser.Name + " vào lúc " + DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy");
            //SendMail(request.Subject, new MailboxAddress("Huong Ngo", "huong.ngo@annhome.vn"), contents);
            TempData["StatusMessage"] = "Your request has been submitted.\nWe'll look into it as soon as possible.";
            return RedirectToPage("/Request");
        }

        public IActionResult ChangeRequest(string type)
        {
            if (type == "Withdraw")
            {
                return PartialView("WithdrawForm");
            }
            else if(type == "Reserve")
            {
                return PartialView("Reserve");
            }
            return PartialView("Index");
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

        public async Task<IActionResult> Index()
        {
            await Badge();
            return View();
        }

        private async Task Badge()
        {
            var curUser = await _userManager.GetUserAsync(User);
            if (User.IsInRole("Manager"))
            {
                curUser.NOfRequests = _context.Requests.Where(r => r.Status == Status.Approved).Count();
                curUser.NOfMeetings = _context.appoinment.Where(r => r.IsActive == true && r.Confirm == false).Count();
                //curUser.NOfFeedbacks = _context.Feedbacks.Count();
            }
            else if (User.IsInRole("Administrator"))
            {
                curUser.NOfRequests = _context.Requests.Where(r => r.Status == Status.Pending).Count();
                curUser.NOfMeetings = _context.appoinment.Where(r => r.IsActive == true && r.Confirm == false).Count();
                //curUser.NOfFeedbacks = _context.Feedbacks.Count();
            }
            else if (User.IsInRole("Sale") || User.IsInRole("Leader") || User.IsInRole("TeamLeader"))
            {
                curUser.NOfRequests = _context.Requests.Where(r => r.Status == Status.Pending && r.Contents.Contains(curUser.Name)).Count();
                curUser.NOfMeetings = _context.appoinment.Where(r => r.IsActive == true && r.Confirm == false && r.SEmail == curUser.Email).Count();
                //curUser.NOfFeedbacks = _context.Feedbacks.Count();
            }
            await _context.SaveChangesAsync();
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

        [HttpGet]
        public async Task<IActionResult> Feedback()
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Feedbacks", "Create");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            return View();
        }

        public async Task<IActionResult> Passport(Guid? id)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (id != null)
            {
                return RedirectToAction("Passport", "Appoinments", new { id });
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Feedback([Bind("SaleId, Content")] Feedback feedback)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Feedbacks", "Create");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (!ModelState.IsValid)
            {
                TempData["StatusMessage"] = "Feedback submission failed!";
                return View();
            }
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            string contents = "You got a new feedback from " + curUser.Name + " at " + DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
            SendMail("Feedback", new MailboxAddress("Duy Khang", "khang.trinh@annhome.vn"), contents);
            TempData["StatusMessage"] = "Your information has been submitted..\nThank you for having taken your time to provide us with your valuable feedback!";
            return RedirectToPage("/Feedback");
        }

        private static void SendMail(string subject, MailboxAddress reciever, string contents)
        {
            var message = new MimeMessage();
            message.To.Add(reciever);
            message.From.Add(new MailboxAddress("AnnSmart", "annsmart@annhome.vn"));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = contents
            };
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp-mail.outlook.com", 587, false);

                client.Authenticate("annsmart@annhome.vn", "kh@ng1512");//Nnhm2018

                client.Send(message);
                client.Disconnect(true);

            }
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
                    if (sale.Email == "vinh.hoang@annhome.vn" || sale.Email == "truong.nguyen@annhome.vn" || sale.Email == "kai.pham@annhome.vn" || sale.Email == "clinton.hoang@annhome.vn" ||
                    sale.Email == "victory.le@annhome.vn" || sale.Email == "clinton.vu@annhome.vn" || sale.Email == "clinton.pham@annhome.vn" || sale.Email == "clinton.than@annhome.vn" || sale.Email == "tom.nguyen@annhome.vn")
                    {
                        new_sales.Add(sale);
                    }
                }
                else if (email.Equals("kai.pham@annhome.vn"))
                {
                    if (sale.Email == "kai.pham@annhome.vn" || sale.Email == "clinton.hoang@annhome.vn" || sale.Email == "victory.le@annhome.vn")
                    {
                        new_sales.Add(sale);
                    }
                }
                else if (email.Equals("truong.nguyen@annhome.vn"))
                {
                    if (sale.Email == "truong.nguyen@annhome.vn" || sale.Email == "clinton.pham@annhome.vn" || sale.Email == "clinton.vu@annhome.vn" || sale.Email == "tom.nguyen@annhome.vn")
                    {
                        new_sales.Add(sale);
                    }
                }
            }
            return new_sales;
        }

        //[HttpPost]
        public async Task<IActionResult> Dashboard()
        {
            //HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("ProvinceAPI/");
            //if (res.IsSuccessStatusCode)
            //{
            //    var result = res.Content.ReadAsStringAsync().Result;
            //    Console.WriteLine(result);
            //}
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "List");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            var sale = await _userManager.GetUserAsync(User);
            await Badge();
            if (sale != null)
            {
                
                sale.Meetings = await _context.appoinment.Where(m => m.Sale == sale).Where(ap => ap.IsActive == true).OrderBy(a => a.Contract).ToListAsync();
                //await _userManager.UpdateAsync(sale);
                int count = 0;
                //var meetings = _context.appoinment.Where(b => b.sale.Contains(sale.Email)).OrderBy(m => m.Contract).ToList();
                //count = meetings.Count;
                var meeting = _context.appoinment.First();
                sale.Email = sale.Email.Trim();
                ViewBag.sale = sale.Email;
                ViewBag.crus = sale;
                AppModal modal = new AppModal();
                modal.sale = sale;
                return View(modal);
            }
            return RedirectToAction("Index");
            //modal.appoinments = meetings;
            
        }

        public bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var da1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var da2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));

            return da1 == da2;
        }

        [Authorize(Roles = "Leader, Administrator, TeamLeader")]
        public async Task<IActionResult> Manager(int? id)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "List");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            var meetings = await _context.appoinment.Where(m => m.New == true).ToListAsync();
            DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            if (id == 0)
            {
                meetings = await _context.appoinment.Where(m => m.IsActive == true && m.Confirm == true && m.cTime.Substring(0,8).Contains(DateTime.Now.ToString("ddMMyyyy"))).ToListAsync();
            }
            else if (id == 1)
            {
                meetings = await _context.appoinment.Where(m => m.Confirm == true && m.IsActive == true && DatesAreInTheSameWeek(DateTime.Now.Date, DateTime.ParseExact(m.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null))).ToListAsync();
            }
            else if (id == 2)
            {
                meetings = await _context.appoinment.Where(m => m.IsActive == true && m.Confirm == true && m.cTime.Substring(2,6).Contains(DateTime.Now.ToString("MMyyyy"))).ToListAsync();
            }
            else if(id == 3)
            {
                meetings = await _context.appoinment.Where(m => m.Confirm == true && m.IsActive == true && m.cTime.Substring(4,4).Contains(DateTime.Now.ToString("yyyy"))).ToListAsync();
            }
            else
            {
                meetings = await _context.appoinment.Where(m => m.Confirm == true && m.IsActive == true).ToListAsync();
            }
            Management manager = new Management();
            manager.sales = new List<Sale>();
            string[] Ids = curUser.Members.Split(";");
            foreach (string guid in Ids)
            {
                manager.sales.Add(await _context.sale.FindAsync(new Guid(guid)));
            }
            manager.appoinments = meetings;
            manager.manager = curUser;
            return View("Manager", manager);
        }

        public async Task<IActionResult> Chart()
        {
            var meetings = await _context.appoinment.Where(m => m.New == true).ToListAsync();
            var sales = await _context.sale.ToListAsync();
            Management manager = new Management();
            manager.sales = await get(Convert.ToString(TempData["sale"]));
            manager.appoinments = meetings;
            manager.manager = sales.Find(m => m.Email == Convert.ToString(TempData["sale"]));
            return View("Chart", manager);
        }

        public IActionResult Book()
        {
            return RedirectToAction("Create", "Appoinments");
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

        public async Task<IActionResult> AppDetails(Guid? id)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (id == null)
            {
                return NotFound();
            }
            Appoinment a = await _context.appoinment
       .FirstOrDefaultAsync(b => b.Id == id);
            //PasswordHasher<Sale> hasher = new PasswordHasher<Sale>();
            //PasswordVerificationResult result = hasher.VerifyHashedPassword(curUser, curUser.PasswordHash, a.password);
            //if (a.password != curUser.PasswordHash)
            //    return NotFound();
            
            if (a == null)
            {
                return NotFound();
            }
            var sale = await _userManager.GetUserAsync(User);
            
            TempData["name"] = sale.Name;
   
            return RedirectToAction("Print", "Appoinments", new { id });
        }

        public async Task<IActionResult> Views(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            Appoinment a = await _context.appoinment
       .FirstOrDefaultAsync(b => b.Id == id);
            //PasswordHasher<Sale> hasher = new PasswordHasher<Sale>();
            //PasswordVerificationResult result = hasher.VerifyHashedPassword(curUser, curUser.PasswordHash, a.password);
            //if (a.password != curUser.PasswordHash)
            //    return NotFound();
            if (a == null)
            {
                return NotFound();
            }
            var sale = await _userManager.GetUserAsync(User);

            TempData["name"] = sale.Name;

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