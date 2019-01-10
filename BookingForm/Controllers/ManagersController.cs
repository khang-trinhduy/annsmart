using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingForm.Models;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using MimeKit;
using MailKit.Net.Smtp;

namespace BookingForm.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagersController : Controller
    {
        private readonly BookingFormContext _context;
        private static Manager _currentManager;

        public ManagersController(BookingFormContext context)
        {
            _context = context;
        }

        // GET: Managers
        public async Task<IActionResult> Employee()
        {
            ManagerModal modal = new ManagerModal();
            modal.sales = await _context.sale.ToListAsync();
            modal.appoinments = await _context.appoinment.ToListAsync();
            return View(modal);
        }

        public async Task<IActionResult> Request()
        {
            var requests = await _context.Requests.Where(r => r.Status == Status.Approved).ToListAsync();
            if (requests == null)
            {
                return NotFound("Can't load any requests!");
            }
            return View(requests);
        }

        public async Task<IActionResult> Dashboard(Guid ? id)
        {
            var sale =  await _context.sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound($"Unable to load user with ID '{id}'.");
            }
            sale.Meetings = await _context.appoinment.Where(m => m.SEmail == sale.Email).ToListAsync();
            return View(sale);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Approve(Guid? id)
        {
            if (id == null)
            {
                return NotFound("Can't find request's id");
            }
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound("Can't load request with id: " + id);
            }
            return View(request);
        }

        public async Task<IActionResult> Chart()
        {
            var meetings = await _context.appoinment.ToListAsync();
            int m0 = DateTime.Now.Month;
            int m1 = DateTime.Now.AddMonths(-4).Month;
            int m2 = DateTime.Now.AddMonths(-3).Month;
            int m3 = DateTime.Now.AddMonths(-2).Month;
            int m4 = DateTime.Now.AddMonths(-1).Month;
            int n = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.ToString("MMyyyy")) && m.IsActive == true && m.Confirm == true).Count();
            int n1 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-4).ToString("MMyyyy")) && m.IsActive == true && m.Confirm == true).Count();
            int n2 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-3).ToString("MMyyyy")) && m.IsActive == true && m.Confirm == true).Count();
            int n3 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-2).ToString("MMyyyy")) && m.IsActive == true && m.Confirm == true).Count();
            int n4 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-1).ToString("MMyyyy")) && m.IsActive == true && m.Confirm == true).Count();
            int c = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.ToString("MMyyyy")) && m.IsActive == false && m.Confirm == true).Count();
            int c1 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-4).ToString("MMyyyy")) && m.IsActive == false && m.Confirm == true).Count();
            int c2 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-3).ToString("MMyyyy")) && m.IsActive == false && m.Confirm == true).Count();
            int c3 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-2).ToString("MMyyyy")) && m.IsActive == false && m.Confirm == true).Count();
            int c4 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-1).ToString("MMyyyy")) && m.IsActive == false && m.Confirm == true).Count();
            ViewBag.data = new List<int> { n, n1, n2, n3, n4, c, c1, c2, c3, c4, m0, m1, m2, m3, m4 };
            return View();
        }

        public async Task<IActionResult> Profit()
        {
            var meetings = await _context.appoinment.ToListAsync();
            double n = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.ToString("MMyyyy")) && m.IsActive == true && m.Confirm == true).Sum(m => m.Cash);
            double n1 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-4).ToString("MMyyyy")) && m.IsActive == true && m.Confirm == true).Sum(m => m.Cash);
            double n2 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-3).ToString("MMyyyy")) && m.IsActive == true && m.Confirm == true).Sum(m => m.Cash);
            double n3 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-2).ToString("MMyyyy")) && m.IsActive == true && m.Confirm == true).Sum(m => m.Cash);
            double n4 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-1).ToString("MMyyyy")) && m.IsActive == true && m.Confirm == true).Sum(m => m.Cash);
            double c = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.ToString("MMyyyy")) && m.IsActive == false && m.Confirm == true).Sum(m => m.Cash);
            double c1 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-4).ToString("MMyyyy")) && m.IsActive == false && m.Confirm == true).Sum(m => m.Cash);
            double c2 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-3).ToString("MMyyyy")) && m.IsActive == false && m.Confirm == true).Sum(m => m.Cash);
            double c3 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-2).ToString("MMyyyy")) && m.IsActive == false && m.Confirm == true).Sum(m => m.Cash);
            double c4 = meetings.Where(m => m.cTime.Substring(2, 6).Contains(DateTime.Now.AddMonths(-1).ToString("MMyyyy")) && m.IsActive == false && m.Confirm == true).Sum(m => m.Cash);
            ViewBag.data = new List<double> { n, n1, n2, n3, n4, c, c1, c2, c3, c4 };
            return View("_Profit");
        }

        [HttpPost]
        public async Task<IActionResult> Save(string text, int page)
        {
           using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"E:\Work\Customers-Rever\Customer.txt", true))
            {
                file.WriteLine(text);
            }
            TempData["page"] = page + 1;
            return View("Crawler");
        }

        [HttpPost]
        public async Task<IActionResult> Approve([Bind("Id", "Status", "RequestName", "Subject", "Contents")] Request request)
        {
            if (!ModelState.IsValid)
            {
                TempData["StatusMessage"] = "Can't find request!";
                return View();
            }
            TempData["StatusMessage"] = "Request has been updated!";
            var tmp = await _context.Requests.FindAsync(request.Id);
            tmp.Status = request.Status;
            if (request.Status == Status.Accepted)
            {
                string contents = "Yêu cầu của bạn đã được thông qua.";
                SendMail(request.Subject, new MailboxAddress("Hương Ngô", "huong.ngo@annhome.vn"), contents);
            }
            _context.Update(tmp);
            await _context.SaveChangesAsync();
            return View();
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

        public async Task<IActionResult> Target(int? id)
        {
            ManagerModal modal = new ManagerModal();
            var apps = await _context.appoinment.Where(m => m.Official == true).OrderBy(m => m.Contract).ToListAsync();
            modal.appoinments = apps;
            var sales = await _context.sale.OrderBy(m => m.Id).ToListAsync();
            modal.sales = sales;
            return View("Target", modal);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email", "Password")]Manager manager)
        {
            string email = manager.Email.ToLower().Trim();
            var temp = await _context.Manager.FirstOrDefaultAsync(m => m.Email == email && m.Password == manager.Password);
            if (temp == null)
            {
                return NotFound();
            }
            //await _context.sale.AddRangeAsync(sales);
            //await _context.SaveChangesAsync();
            _currentManager = temp;
            ManagerModal modal = new ManagerModal();
            modal.sales = await _context.sale.OrderBy(s => s.Id).ToListAsync();
            modal.appoinments = await _context.appoinment.OrderBy(a => a.Contract).ToListAsync();
            return View("Home", modal);
        }

        // GET: Managers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager
                .FirstOrDefaultAsync(m => m.ID == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // GET: Managers/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Managers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,fullName,phone,email,portrait,password")] Manager manager)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(manager);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(manager);
        //}

        //// GET: Managers/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var manager = await _context.Manager.FindAsync(id);
        //    if (manager == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(manager);
        //}

        //// POST: Managers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,fullName,phone,email,portrait,password")] Manager manager)
        //{
        //    if (id != manager.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(manager);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ManagerExists(manager.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(manager);
        //}

        //// GET: Managers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var manager = await _context.Manager
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (manager == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(manager);
        //}

        //// POST: Managers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var manager = await _context.Manager.FindAsync(id);
        //    _context.Manager.Remove(manager);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ManagerExists(int id)
        {
            return _context.Manager.Any(e => e.ID == id);
        }
    }
}
