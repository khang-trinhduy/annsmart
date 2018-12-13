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

namespace BookingForm.Controllers
{
    public class ManagersController : Controller
    {
        private readonly BookingFormContext _context;
        private static Manager _currentManager;
        private readonly List<Sale> sales;

        public ManagersController(BookingFormContext context)
        {
            _context = context;
            StreamReader r = new StreamReader("sales.json");
            string json = r.ReadToEnd();
            sales = JsonConvert.DeserializeObject<List<Sale>>(json);
        }

        // GET: Managers
        public async Task<IActionResult> Home(ManagerModal modal)
        {
            return View(modal);
        }

        public async Task<IActionResult> Profit(int? id)
        {
            ManagerModal modal = new ManagerModal();
            modal.manager = _currentManager;
            var apps = await _context.appoinment.Where(m => m.Official == true).OrderBy(m => m.Contract).ToListAsync();
            modal.appoinments = apps;
            var sales = await _context.sale.OrderBy(m => m.ID).ToListAsync();
            modal.sales = sales;
            return View("Home", modal);
        }

        public async Task<IActionResult> Target(int? id)
        {
            ManagerModal modal = new ManagerModal();
            modal.manager = _currentManager;
            var apps = await _context.appoinment.Where(m => m.Official == true).OrderBy(m => m.Contract).ToListAsync();
            modal.appoinments = apps;
            var sales = await _context.sale.OrderBy(m => m.ID).ToListAsync();
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
            modal.manager = temp;
            modal.sales = await _context.sale.OrderBy(s => s.ID).ToListAsync();
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
