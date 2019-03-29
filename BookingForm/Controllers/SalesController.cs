using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingForm.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace BookingForm
{
    public class SalesController : Controller
    {
        private readonly UserManager<Sale> _userManager;
        private readonly BookingFormContext _context;
        private static Sale sale;
        private readonly IHostingEnvironment _environment;

        public SalesController(BookingFormContext context, IHostingEnvironment environment, UserManager<Sale> userManager)
        {
            _userManager = userManager;
            _environment = environment;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<int> temp = new List<int>();
            List<Sale> sales = await _context.sale.ToListAsync();
            int count = 0;
            foreach (var sale in sales)
            {
                var meetings = _context.appoinment.Where(b => b.Sale == sale).ToList();
                temp.Insert(count, meetings.Count);
                count++;
            }

            ViewBag.lc = temp;
            return View(await _context.sale.ToListAsync());
        }

        // GET: Sales
        public async Task<IActionResult> ViewProfile(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View("Setting", await _context.sale.FindAsync(id));
        }



        //[HttpPost(Name = "ChangePassword")]
        //public async Task<IActionResult> ChangePassword([Bind("ID)")] int id, [Bind("rnp)")] string pw)
        //{
        //    var tmp = await _context.sale.FindAsync(id);
        //    if (tmp != null)
        //    {
        //        tmp.pass = pw;
        //        _context.Update(tmp);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(ViewProfile), sale.ID);
        //    }
        //    return RedirectToAction(nameof(ViewProfile), sale.ID);
        //}

        public async Task<FileResult> GetPhoto(int? id)
        {
            var s = await _context.sale.FindAsync(id);
            if (s.Portrait != null)
            {
                return File(s.Portrait, "img/png");
            }
            var image = System.IO.File.OpenRead("~image//Profile//photo.jpg");
            return File(image, "image/jpg");
        }

        //[HttpPost]
        //public async Task<IActionResult> SaveProfile([Bind("ID, name, phone, info, display, birthday, gender, portrait, address")] Sale sale, IFormFile portrait)
        //{
        //    var tmp = await _context.sale.FindAsync(sale.Id);
        //    tmp.Name = sale.Name;
        //    tmp.Info = sale.Info;
        //    tmp.Display = sale.Display;
        //    tmp.Gender = sale.Gender;
        //    tmp.Address = sale.Address;
        //    tmp.DOB = sale.DOB;
        //    var newFileName = string.Empty;
        //    var filePath = Path.GetTempFileName();
        //    //if (HttpContext.Request.Form.Files != null)
        //    //{
        //    //var fileName = string.Empty;
        //    //string PathDB = string.Empty;
        //    //var files = HttpContext.Request.Form.Files;
        //    long size = portrait.Length;
        //    if (size > 0)
        //    {
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await portrait.CopyToAsync(stream);
        //        }
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            await portrait.CopyToAsync(memoryStream);
        //            tmp.portrait = memoryStream.ToArray();
        //        }

        //    }
        //    _context.sale.Update(tmp);
        //    await _context.SaveChangesAsync();
        //    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK);
        //}

        //[HttpPost]
        //public IActionResult Image(IFormFile file)
        //{

        //    List<string> errors = new List<string>(); // added this just to return something

        //    if (file != null)
        //    {
        //        // do something
        //    }

        //    return Json(errors, JsonRequestBehavior.AllowGet);
        //}

        // GET: Sales/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sale = await _context.sale
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (sale == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sale);
        //}

        // GET: Sales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,phone,email,pass")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        public async Task<IActionResult> Meetings(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sale = await _userManager.GetUserAsync(User);
            var meetings = _context.appoinment
        .Where(b => b.Sale == sale).ToListAsync();
            return View(meetings);
        }

        public IActionResult AppDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Details", "Appoinments", new { id });
        }

        public IActionResult Views(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Details", "Appoinments", new { id });
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,name,phone,email,pass")] Sale sale)
        //{
        //    if (id != sale.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(sale);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SaleExists(sale.ID))
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
        //    return View(sale);
        //}

        //// GET: Sales/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sale = await _context.sale
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (sale == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sale);
        //}

        //// POST: Sales/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var sale = await _context.sale.FindAsync(id);
        //    _context.sale.Remove(sale);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SaleExists(int id)
        //{
        //    return _context.sale.Any(e => e.ID == id);
        //}
    }
}
