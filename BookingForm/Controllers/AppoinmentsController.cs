using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingForm.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using Newtonsoft.Json;
using System.Globalization;
using reCAPTCHA.AspNetCore;

namespace BookingForm.Controllers
{
    public class AppoinmentsController : Controller
    {
        private readonly BookingFormContext _context;
        //private readonly List<Sale> sales;
        private IRecaptchaService _recaptcha;
        private readonly List<Admin> admins;

        public AppoinmentsController(BookingFormContext context, IRecaptchaService recaptcha)
        {
            _recaptcha = recaptcha; 
            _context = context;
            StreamReader r = new StreamReader("sales.json");
            string json = r.ReadToEnd();
            //sales = JsonConvert.DeserializeObject<List<Sale>>(json);
            StreamReader a = new StreamReader("admins.json");
            string jsona = a.ReadToEnd();
            admins = JsonConvert.DeserializeObject<List<Admin>>(jsona);
        }
        public static string So_chu(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";

            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";

            // Dau [+ , - ]
            if (gNum < 0)
                dau = "[-]";
            dau = "";

            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

            ///don vi hang mod
            int im = m + 1;
            if (mod > 0)
                lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai

            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";

            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";

            return lso_chu.ToString().Trim();

        }
        private static string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }
        private static string Donvi(string so)
        {
            string Kdonvi = "";

            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }
        private static string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";

            }
            return Ktach;

        }

        //[HttpPost]
        public async Task<IActionResult> Views(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appoinment = await _context.appoinment
                .FirstOrDefaultAsync(m => m.ID == id);
            //Random rand = new Random();
            //int rd = rand.Next(100, 151);
            //ViewBag.rd = appoinment.Priority;
            if(appoinment == null)
            {
                appoinment = await _context.appoinment.FirstOrDefaultAsync(m => m.ID == id);
            }
            ViewBag.Money_Letters = So_chu(appoinment.Money);
            string temp = (appoinment.Money).ToString("N", new CultureInfo("is-IS"));
            ViewBag.New_Money = temp.Substring(0, temp.Length - 3) + " VNĐ";
            if (appoinment == null)
            {
                return NotFound();
            }

            return View(appoinment);
        }

        //[HttpPost]
        public async Task<IActionResult> Draft(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appoinment = await _context.appoinment
                .FirstOrDefaultAsync(m => m.ID == id);
            //Random rand = new Random();
            //int rd = rand.Next(100, 151);
            //ViewBag.rd = appoinment.Priority;
            if (appoinment == null)
            {
                appoinment = await _context.appoinment.FirstOrDefaultAsync(m => m.ID == id);
            }
            ViewBag.Money_Letters = So_chu(appoinment.Money);
            string temp = (appoinment.Money).ToString("N", new CultureInfo("is-IS"));
            ViewBag.New_Money = temp.Substring(0, temp.Length - 3) + " VNĐ";
            if (appoinment == null)
            {
                return NotFound();
            }

            return View(appoinment);
        }

        [HttpPost]
        public async Task<IActionResult> Logging([FromBody] Logger log)
        {
            _context.Loggers.Add(log);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //[HttpPost]
        public async Task<IActionResult> Print(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appoinment = await _context.appoinment
                .FirstOrDefaultAsync(m => m.ID == id);
            //Random rand = new Random();
            //int rd = rand.Next(100, 151);
            //ViewBag.rd = appoinment.Priority;
            if (appoinment == null)
            {
                appoinment = await _context.appoinment.FirstOrDefaultAsync(m => m.ID == id);
            }
            ViewBag.Money_Letters = So_chu(appoinment.Money);
            string temp = (appoinment.Money).ToString("N", new CultureInfo("is-IS"));
            ViewBag.New_Money = temp.Substring(0, temp.Length - 3) + " VNĐ";
            if (appoinment == null)
            {
                return NotFound();
            }

            return View(appoinment);
        }

        // GET: Appoinments
        public async Task<IActionResult> Index()
        {

            return View(await _context.appoinment.Where(a => a.IsActive == true).ToListAsync());
        }

        // GET: Appoinments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appoinment = await _context.appoinment
                .FirstOrDefaultAsync(m => m.ID == id);
            if (appoinment == null)
            {
                return NotFound();
            }

            return View(appoinment);
        }

        // GET: Appoinments/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Appoinments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Customer,Gender,Address,Phone,Email,Job,WorkPlace,Cmnd,Day,Place,Money,Purpose,Requires,Price,Details,DType,Cash,NCH1,NCH2,NCH21,NCH3,NMS,NS,NSHH,NSH,HKTT,password,Contract")] Appoinment appoinment)
        {
            //if (ModelState.IsValid)
            //{
            var sales = await _context.sale.ToListAsync();
            var cur_sale = sales.FirstOrDefault(s => s.pass == appoinment.password);
            TempData["name"] = cur_sale.display;
            appoinment.sale = cur_sale.email;
            appoinment.SaleDetails = cur_sale.info;
            string str = "";
            if(appoinment.sale == null)
            {
                return View();
            }
            var tmp = await _context.sale.FirstOrDefaultAsync(m => m.email == appoinment.sale && m.pass == appoinment.password);
            if (tmp == null)
            {
                return View();
            }
            else
            {
                //var recaptcha = await _recaptcha.Validate(Request);
                //if (!recaptcha.success)
                //{
                //    ModelState.AddModelError("Recaptcha", "There was an error validating recatpcha. Please try again!");
                //    return View();
                //}
                List<Appoinment> appoinments = await _context.appoinment.ToListAsync();
                if (appoinments.Count > 0)
                {
                    appoinment.Contract = _context.appoinment.Where(a => a.IsActive == true).Max(c => c.Contract) + 1;
                    if (appoinment.NCH1 > 0 || appoinment.NCH2 > 0 || appoinment.NCH3 > 0 || appoinment.NCH21 > 0)
                    {
                        appoinment.ph = _context.appoinment.Where(a => a.IsActive == true).Max(c => c.ph) + appoinment.NCH2 + appoinment.NCH1 + appoinment.NCH3 + appoinment.NCH21;
                        str += "Căn hộ: " + Convert.ToString(appoinment.ph) + "\n";
                    }
                    if (appoinment.NSH > 0)
                    {
                        appoinment.psh = _context.appoinment.Where(a => a.IsActive == true).Max(c => c.psh) + appoinment.NSH;
                        str += "Nhà phố: " + Convert.ToString(appoinment.psh) + "\n";
                    }
                    if (appoinment.NSHH > 0)
                    {
                        appoinment.pshh = _context.appoinment.Where(a => a.IsActive == true).Max(c => c.pshh) + appoinment.NSHH;
                        str += "Shophouse: " + Convert.ToString(appoinment.pshh) + "\n";
                    }
                    if (appoinment.NMS > 0)
                    {
                        appoinment.pms = _context.appoinment.Where(a => a.IsActive == true).Max(c => c.pms) + appoinment.NMS;
                        str += "Biệt thự: " + Convert.ToString(appoinment.pms) + "\n";
                    }
                    if (appoinment.NS > 0)
                    {
                        appoinment.pns = _context.appoinment.Where(a => a.IsActive == true).Max(c => c.pns) + appoinment.NS;
                        str += "Shop (kios chung cư): " + Convert.ToString(appoinment.pns) + "\n";
                    }

                }                
                appoinment.supporter = false;
                appoinment.New = true;
                appoinment.Official = false;
                appoinment.cTime = DateTime.Now.ToString("ddMMyyyy HH:mm:ss.FFFFFFF");
                appoinment.Confirm = false;
                appoinment.IsActive = true;
                _context.Add(appoinment);
                AppModal modal = new AppModal();
                modal.appoinment = appoinment;
                modal.sale = cur_sale;
                await _context.SaveChangesAsync();
                
                TempData["ct"] = appoinment.Contract;
                TempData["pt"] = str;
                return View("Confirm",modal);
            }
            //}
            //return NotFound();
        }

        public IActionResult Home(Sale sale)
        {
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Confirm(AppModal app)
        {
            return View(app);
        }


        // GET: Appoinments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appoinment = await _context.appoinment.FindAsync(id);
            if (appoinment == null)
            {
                return NotFound();
            }
            return View("Edit", appoinment);
        }



        // POST: Appoinments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Customer, Gender, Address,Phone,Email, Job, WorkPlace,Cmnd, Day, Place, Money, Purpose, Requires, Details, DType, Cash, NCH1,NCH2, NCH21, NCH3, NMS,NSH,NSHH,NS, HKTT, Contract, cTime, dTime, Deposit, Note, IsActive")]Appoinment appoinment)
        {
            //if (ModelState.IsValid)
            //{
            try
            {
                var tmp = await _context.appoinment.FindAsync(id);
                tmp.Customer = appoinment.Customer;
                tmp.Cmnd = appoinment.Cmnd;
                tmp.Day = appoinment.Day;
                tmp.Place = appoinment.Place;
                tmp.DType = appoinment.DType; 
                tmp.cTime = appoinment.cTime;
                tmp.dTime = appoinment.dTime;
                tmp.Gender = appoinment.Gender;
                tmp.Address = appoinment.Address;
                tmp.Phone = appoinment.Phone;
                tmp.Email = appoinment.Email;
                tmp.Job = appoinment.Job;
                tmp.Money = appoinment.Money;
                tmp.Purpose = appoinment.Purpose;
                tmp.Requires = appoinment.Requires;
                tmp.Details = appoinment.Details;
                tmp.Cash = appoinment.Cash;
                tmp.NCH1 = appoinment.NCH1;
                tmp.NCH2 = appoinment.NCH2;
                tmp.NCH21 = appoinment.NCH21;
                tmp.NCH3 = appoinment.NCH3;
                tmp.NMS = appoinment.NMS;
                tmp.NS = appoinment.NS;
                tmp.NSH = appoinment.NSH;
                tmp.NSHH = appoinment.NSHH;
                tmp.HKTT = appoinment.HKTT;
                tmp.Contract = appoinment.Contract;
                tmp.Deposit = appoinment.Deposit;
                tmp.Note = appoinment.Note;
                tmp.IsActive = appoinment.IsActive;
                _context.Update(tmp);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }
            Admin ad = new Admin();
            try
            {
                ad = admins[0];
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("_Home", "Admin");
            //}
            //return View();
        }

        private static string Extract(string time)
        {
            string[] template = time.Split("T");
            string new_cd = template[0];
            string new_ct = template[1];
            string[] temp = new_cd.Split("-");
            string new_ctime = temp[2] + temp[1] + temp[0] + " " + new_ct + ":00.0000000";
            return new_ctime;
        }

        // GET: Appoinments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appoinment = await _context.appoinment
                .FirstOrDefaultAsync(m => m.ID == id);
            if (appoinment == null)
            {
                return NotFound();
            }

            return View(appoinment);
        }

        public async Task UpdatePriority(int id)
        {
            var appoinments = _context.appoinment.Where(a => a.Contract > id && a.IsActive == true).OrderBy(a => a.ID).ToList();
            var tmp = await _context.appoinment.FirstOrDefaultAsync(m => m.Contract == id);
            int ph = tmp.NCH1 + tmp.NCH2 + tmp.NCH3 + tmp.NCH21;
            int psh = tmp.NSH;
            int pshh = tmp.NSHH;
            int pms = tmp.NMS;
            int pns = tmp.NS;

            if (appoinments != null)
            {
                foreach (var a in appoinments)
                {
                    a.ph -= ph;
                    a.psh -= psh;
                    a.pshh -= pshh;
                    a.pms -= pms;
                    a.pns -= pns;
                }
            }
            await _context.SaveChangesAsync();
        }

        // POST: Appoinments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var a = await _context.appoinment.FirstOrDefaultAsync(m => m.Contract == id);
            await UpdatePriority(a.Contract);
            a.IsActive = false;
            _context.appoinment.Update(a);
            
            await _context.SaveChangesAsync();
            Admin ad = new Admin();
            try
            {
                ad = admins[0];
            }
            catch (Exception)
            {

                throw;
            }
            var meetings = await _context.appoinment.Where(ap => ap.IsActive == true).ToListAsync();
            var meeting = _context.appoinment.First();
            int ph = _context.appoinment.Max(m => m.ph);
            int psh = _context.appoinment.Max(m => m.psh);
            int pshh = _context.appoinment.Max(m => m.pshh);
            int pms = _context.appoinment.Max(m => m.pms);
            int pns = _context.appoinment.Max(m => m.pns);
            AdminModal modal = new AdminModal();
            modal.admin = ad;
            modal.appoinment = meeting;
            modal.appoinments = meetings;
            modal.officials = new List<int>();
            modal.officials.Add(ph + 1);
            modal.officials.Add(psh + 1);
            modal.officials.Add(pshh + 1);
            modal.officials.Add(pms + 1);
            modal.officials.Add(pns + 1);
            return View("/Views/Admin/Home.cshtml", modal);
        }

        private bool AppoinmentExists(int id)
        {
            return _context.appoinment.Any(e => e.ID == id);
        }
    }
}
