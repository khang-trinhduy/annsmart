using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingForm.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;

namespace BookingForm.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHostingEnvironment _environment;
        //private readonly IFileProvider fileProvider;
        private readonly BookingFormContext _context;
        private readonly List<Admin> admins;
        private readonly List<Sale> sales;
        private static Admin administrator;
        public AdminController(BookingFormContext context, IHostingEnvironment hostingEnvironment)
        {
            _environment = hostingEnvironment;
            _context = context;
            StreamReader r = new StreamReader("admins.json");
            string json = r.ReadToEnd();
            admins = JsonConvert.DeserializeObject<List<Admin>>(json);
            StreamReader s = new StreamReader("sales.json");
            string jsonn = s.ReadToEnd();
            sales = JsonConvert.DeserializeObject<List<Sale>>(jsonn);
        }

        public async Task<IActionResult> _export(int? id)
        {
            string sWebRootFolder = _environment.WebRootPath;
            //string fname = @"Thông tin đặt giữ chỗ dự án Vincity" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            string sFileName = @"Thông tin đặt giữ chỗ dự án Vincity_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Tổng hợp báo cáo KH cọc Vincity");
                IRow row = excelSheet.CreateRow(0);
                
                //row.CreateCell(0).SetCellValue("Ngày đặt GC");
                row.CreateCell(0).SetCellValue("Số HĐ");
                row.CreateCell(1).SetCellValue("TG ký HĐ");
                row.CreateCell(2).SetCellValue("TG vào tiền");
                row.CreateCell(3).SetCellValue("Họ tên");
                row.CreateCell(4).SetCellValue("Giới tính");
                row.CreateCell(5).SetCellValue("SĐT");
                row.CreateCell(6).SetCellValue("CMND/Passport");
                row.CreateCell(7).SetCellValue("Ngày cấp");
                row.CreateCell(8).SetCellValue("Nơi cấp");
                row.CreateCell(9).SetCellValue("Số tiền đặt chỗ");
                row.CreateCell(10).SetCellValue("N/C vay");
                row.CreateCell(11).SetCellValue("Số thứ tự");
                row.CreateCell(12).SetCellValue("Nhu cầu khách");
                row.CreateCell(13).SetCellValue("HKTT + Địa chỉ LL");
                row.CreateCell(14).SetCellValue("Email");
                row.CreateCell(15).SetCellValue("Nghề nghiệp + Nơi làm việc");
                row.CreateCell(16).SetCellValue("Sale chăm sóc");
                var appoinments = await _context.appoinment.Where(ap => ap.IsActive == true).OrderBy(a => a.Contract).ToListAsync();
                int count = 1;
                foreach (var appoinment in appoinments)
                {
                    row = excelSheet.CreateRow(count);
                    row.CreateCell(0).SetCellValue(appoinment.Contract);
                    try
                    {
                        DateTime contract = DateTime.ParseExact(appoinment.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime deposit = DateTime.ParseExact(appoinment.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF", System.Globalization.CultureInfo.InvariantCulture);
                        row.CreateCell(1).SetCellValue(Convert.ToString(contract.Date));
                        row.CreateCell(2).SetCellValue(Convert.ToString(contract.Date));
                    }
                    catch (Exception)
                    {
                        row.CreateCell(1).SetCellValue(appoinment.cTime);
                        row.CreateCell(2).SetCellValue(appoinment.dTime);
                    }
                    
                    row.CreateCell(3).SetCellValue(appoinment.Customer);
                    row.CreateCell(4).SetCellValue(appoinment.Gender);
                    row.CreateCell(5).SetCellValue(appoinment.Phone);
                    row.CreateCell(6).SetCellValue(appoinment.Cmnd);
                    row.CreateCell(7).SetCellValue(Convert.ToString(appoinment.Day.ToString("dd/MM/yyyy")));
                    row.CreateCell(8).SetCellValue(Convert.ToString(appoinment.Place));
                    row.CreateCell(9).SetCellValue(String.Format("{0:N0}", appoinment.Cash));
                    string priority = "";
                    if (appoinment.NCH1 + appoinment.NCH21 + appoinment.NCH2 + appoinment.NCH3 > 0)
                    {
                        priority += "CH(";
                        for (int i = appoinment.NCH1 + appoinment.NCH21 + appoinment.NCH2 + appoinment.NCH3 - 1; i >= 0; i--)
                        {
                            priority += Convert.ToString(appoinment.ph - i) + " ";
                        }
                        priority = priority.TrimEnd();
                        priority += ") ";
                    }
                    if (appoinment.NMS > 0)
                    {
                        priority += "BT(";
                        for (int i = appoinment.NMS - 1; i >= 0; i--)
                        {
                            priority += Convert.ToString(appoinment.pms - i) + " ";
                        }
                        priority = priority.TrimEnd();
                        priority += ") ";
                    }
                    if (appoinment.NSH > 0)
                    {
                        priority += "NP(";
                        for (int i = appoinment.NSH - 1; i >= 0; i--)
                        {
                            priority += Convert.ToString(appoinment.psh - i) + " ";
                        }
                        priority = priority.TrimEnd();
                        priority += ") ";
                    }
                    if (appoinment.NSHH > 0)
                    {
                        priority += "NPTM(";
                        for (int i = appoinment.NSHH - 1; i >= 0; i--)
                        {
                            priority += Convert.ToString(appoinment.pshh - i) + " ";
                        }
                        priority = priority.TrimEnd();
                        priority += ") ";
                    }
                    if (appoinment.NS > 0)
                    {
                        priority += "KIOS(";
                        for (int i = appoinment.NS - 1; i >= 0; i--)
                        {
                            priority += Convert.ToString(appoinment.pns - i) + " ";
                        }
                        priority = priority.TrimEnd();
                        priority += ") ";
                    }
                    priority = priority.Trim();
                    row.CreateCell(11).SetCellValue(priority);
                    row.CreateCell(12).SetCellValue(appoinment.Requires);
                    string loans = "";
                    if (appoinment.Price > 0)
                    {
                        loans += "Có (" + string.Format("{0:N0}", appoinment.Price) + ")";
                    }
                    else
                    {
                        loans = "Không";
                    }
                    row.CreateCell(13).SetCellValue("HKTT:" + appoinment.HKTT + "\n" + "Địa chỉ LL: " + appoinment.Address);
                    row.CreateCell(10).SetCellValue(loans);
                    row.CreateCell(14).SetCellValue(appoinment.Email);
                    row.CreateCell(15).SetCellValue(appoinment.Job + " " + appoinment.WorkPlace);
                    row.CreateCell(16).SetCellValue(appoinment.SaleDetails);
                    count++;
                }

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }

        public async Task<IActionResult> _loans()
        {
            string sWebRootFolder = _environment.WebRootPath;
            //string fname = @"Thông tin đặt giữ chỗ dự án Vincity" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            string sFileName = @"Thông tin khách có nhu cầu vay_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Tổng hợp báo cáo KH cọc Vincity");
                IRow row = excelSheet.CreateRow(0);

                //row.CreateCell(0).SetCellValue("Ngày đặt GC");
                row.CreateCell(0).SetCellValue("STT");
                row.CreateCell(1).SetCellValue("Họ tên");
                row.CreateCell(2).SetCellValue("Giới tính");
                row.CreateCell(3).SetCellValue("SĐT");
                row.CreateCell(4).SetCellValue("CMND/Passport");
                row.CreateCell(5).SetCellValue("Ngày cấp");
                row.CreateCell(6).SetCellValue("Nơi cấp");
                row.CreateCell(7).SetCellValue("Số tiền cần vay(triệu đồng)");
                row.CreateCell(8).SetCellValue("HKTT");
                row.CreateCell(9).SetCellValue("ĐCLL");
                row.CreateCell(10).SetCellValue("Email");
                row.CreateCell(11).SetCellValue("Nghề nghiệp");
                row.CreateCell(12).SetCellValue("Nơi làm việc");
                var appoinments = await _context.appoinment.Where(a => a.Price > 0 && a.IsActive == true).ToListAsync();
                int count = 1;
                foreach (var appoinment in appoinments)
                {
                    row = excelSheet.CreateRow(count);
                    row.CreateCell(0).SetCellValue(count);
                    row.CreateCell(1).SetCellValue(appoinment.Customer);
                    row.CreateCell(2).SetCellValue(appoinment.Gender);
                    row.CreateCell(3).SetCellValue(appoinment.Phone);
                    row.CreateCell(4).SetCellValue(appoinment.Cmnd);
                    row.CreateCell(5).SetCellValue(appoinment.Day.ToString("dd/MM/yyyy"));
                    row.CreateCell(6).SetCellValue(appoinment.Place);
                    row.CreateCell(7).SetCellValue(String.Format("{0:N0}",appoinment.Price));
                    row.CreateCell(8).SetCellValue(appoinment.HKTT);
                    row.CreateCell(9).SetCellValue(appoinment.Address);
                    row.CreateCell(10).SetCellValue(appoinment.Email);
                    row.CreateCell(11).SetCellValue(appoinment.Job);
                    row.CreateCell(12).SetCellValue(appoinment.WorkPlace);
                    count++;
                }

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }

        public IActionResult ImportCustomer()
        {
            string rootFolder = _environment.WebRootPath;
            string fileName = @"new_transactions.xlsx";
            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Transaction"];
                int totalRows = workSheet.Dimension.Rows;
                List<Transaction> transactions = new List<Transaction>();
                for (int i = 1; i <= totalRows; i++)
                {
                    try
                    {
                        //appoinments.Add(new Appoinment
                        //{
                        //    Customer = workSheet.Cells[i, 1].Value.ToString(),
                        //    Gender = workSheet.Cells[i, 9].Value.ToString(),
                        //    Address = workSheet.Cells[i, 4].Value.ToString(),
                        //    Phone = workSheet.Cells[i, 2].Value.ToString(),
                        //    Email = workSheet.Cells[i, 3].Value.ToString(),
                        //    //Job = workSheet.Cells[i, 10].Value.ToString(),
                        //    //WorkPlace = workSheet.Cells[i, 7].Value.ToString(),
                        //    Cmnd = workSheet.Cells[i, 5].Value.ToString(),
                        //    //Day = Convert.ToDateTime(workSheet.Cells[i, 6].Value),
                        //    Place = workSheet.Cells[i, 11].Value.ToString(),
                        //    Money = Convert.ToDouble(workSheet.Cells[i, 15].Value),
                        //    Purpose = workSheet.Cells[i, 13].Value.ToString(),
                        //    Requires = workSheet.Cells[i, 14].Value.ToString(),
                        //    Price = Convert.ToDouble(workSheet.Cells[i, 12].Value),
                        //    //Details = workSheet.Cells[i, 8].Value.ToString(),
                        //    DType = workSheet.Cells[i, 18].Value.ToString(),
                        //    Cash = Convert.ToDouble(workSheet.Cells[i, 17].Value),
                        //    NCH1 = Convert.ToInt16(workSheet.Cells[i, 19].Value),
                        //    NCH2 = Convert.ToInt16(workSheet.Cells[i, 20].Value),
                        //    NCH3 = Convert.ToInt16(workSheet.Cells[i, 21].Value),
                        //    NMS = Convert.ToInt16(workSheet.Cells[i, 22].Value),
                        //    NSH = Convert.ToInt16(workSheet.Cells[i, 23].Value),
                        //    NSHH = Convert.ToInt16(workSheet.Cells[i, 16].Value),
                        //    HKTT = workSheet.Cells[i, 24].Value.ToString(),
                        //    sale = workSheet.Cells[i, 26].Value.ToString(),
                        //    //SaleID = workSheet.Cells[i, 26].Value.ToString(),
                        //    password = workSheet.Cells[i, 25].Value.ToString(),
                        //    Contract = Convert.ToInt16(workSheet.Cells[i, 28].Value),
                        //    Confirm = Convert.ToBoolean(workSheet.Cells[i, 30].Value),
                        //    //cTime = workSheet.Cells[i, 31].Value.ToString(),
                        //    // dTime = workSheet.Cells[i, 32].Value.ToString(),
                        //    ph = Convert.ToInt16(workSheet.Cells[i, 34].Value),
                        //    psh = Convert.ToInt16(workSheet.Cells[i, 36].Value),
                        //    pshh = Convert.ToInt16(workSheet.Cells[i, 29].Value),
                        //    pms = Convert.ToInt16(workSheet.Cells[i, 35].Value),
                        //    SaleDetails = workSheet.Cells[i, 33].Value.ToString(),
                        //    //Deposit = workSheet.Cells[i, 37].Value.ToString(),
                        //    // Note = workSheet.Cells[i, 38].Value.ToString(),
                        //    Official = Convert.ToBoolean(workSheet.Cells[i, 37].Value),
                        //    NCH21 = Convert.ToInt16(workSheet.Cells[i, 38].Value),
                        //    NS = Convert.ToInt16(workSheet.Cells[i, 39].Value),
                        //});
                        transactions.Add(new Transaction
                        {
                            Hieuthietbi = workSheet.Cells[i, 1].Value.ToString(),
                            Sohieudv = workSheet.Cells[i, 2].Value.ToString(),
                            Diachi = workSheet.Cells[i, 3].Value.ToString(),
                            Loaithe = workSheet.Cells[i, 4].Value.ToString(),
                            Ngaygd = workSheet.Cells[i, 5].Value.ToString(),
                            Giogd = workSheet.Cells[i, 6].Value.ToString(),
                            Ngayxl = workSheet.Cells[i, 7].Value.ToString(),
                            Sothe = workSheet.Cells[i, 8].Value.ToString(),
                            Machuanchi = workSheet.Cells[i, 9].Value.ToString(),
                            Solo = workSheet.Cells[i, 10].Value.ToString(),
                            Tiengd = workSheet.Cells[i, 11].Value.ToString(),
                            Phi = workSheet.Cells[i, 12].Value.ToString(),
                            VAT = workSheet.Cells[i, 13].Value.ToString(),
                            Tylephantram = workSheet.Cells[i, 14].Value.ToString(),
                            Sothamchieu = workSheet.Cells[i, 15].Value.ToString()
                        }
                        );
                    }
                    catch (Exception)
                    {

                       
                    }
                    
                }

                _context.transactions.AddRangeAsync(transactions);
                _context.SaveChanges();  
            }
            return RedirectToAction("Home", new { administrator });
        }

        public async Task Remove()
        {
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1, 19, 00, 00, 0000000);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00, 0000000);
            var failed_appoinments = await _context.appoinment.Where(m => m.Confirm == false && m.OldContract == false && m.Official == false && m.Deposit == null).OrderBy(m => m.ID).ToListAsync();
            foreach (var appoinment in failed_appoinments)
            {
                appoinment.IsActive = false;

                _context.appoinment.Update(appoinment);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IActionResult> Summary()
        {
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1, 19, 00, 00, 0000000);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00, 0000000);
            var done_appoinments = await _context.appoinment.Where(m => m.OldContract == false && m.Official == true && m.IsActive == true).OrderBy(m => m.ID).ToListAsync();
            var legal_appoinments = await _context.appoinment.Where(m => m.Deposit == "Đúng thời hạn" && m.OldContract == false && m.Official == false && m.IsActive == true).OrderBy(m => m.ID).ToListAsync();
            var illegal_appoinments = await _context.appoinment.Where(m => m.Deposit == "Không đúng thời hạn"  && m.OldContract == false && m.Official == false && m.IsActive == true).OrderBy(m => m.ID).ToListAsync();
            int max_h = done_appoinments.Max(m => m.ph);
            int max_sh = done_appoinments.Max(m => m.psh);
            int max_shh = done_appoinments.Max(m => m.pshh);
            int max_ms = done_appoinments.Max(m => m.pms);
            int max_ns = done_appoinments.Max(m => m.pns);
            int max_legal_h = 0;
            int max_legal_sh = 0;
            int max_legal_shh = 0;
            int max_legal_ms = 0;
            int max_legal_ns = 0;
            if (legal_appoinments.Count > 0)
            {
                foreach (var legal in legal_appoinments)
                {
                    int nph = 0;
                    if (legal.NCH1 > 0 || legal.NCH2 > 0 || legal.NCH3 > 0 || legal.NCH21 > 0)
                    {
                        nph = legal.NCH3 + legal.NCH2 + legal.NCH1 + legal.NCH21;
                        legal.ph = legal.NCH3 + legal.NCH2 + legal.NCH1 + max_h + legal.NCH21;
                        max_h += nph;
                    }
                    if (legal.NMS > 0)
                    {
                        legal.pms = legal.NMS + max_ms;
                        max_ms += legal.NMS;
                    }
                    if (legal.NSH > 0)
                    {
                        legal.psh = legal.NSH + max_sh;
                        max_sh += legal.NSH;
                    }
                    if (legal.NSHH > 0)
                    {
                        legal.pshh = legal.NSHH + max_shh;
                        max_shh += legal.NSHH;
                    }
                    if (legal.NS > 0)
                    {
                        legal.pns = legal.NS + max_ns;
                        max_ns += legal.NS;
                    }
                    legal.Official = true;
                    legal.New = false;
                }
                max_legal_h = legal_appoinments.Max(m => m.ph);
                max_legal_sh = legal_appoinments.Max(m => m.psh);
                max_legal_shh = legal_appoinments.Max(m => m.pshh);
                max_legal_ms = legal_appoinments.Max(m => m.pms);
                max_legal_ns = legal_appoinments.Max(m => m.pns);
            }
            else
            {
                max_legal_h = max_h;
                max_legal_sh = max_sh;
                max_legal_shh = max_shh;
                max_legal_ms = max_ms;
                max_legal_ns = max_ns;
            }
            
            if (illegal_appoinments.Count > 0)
            {
                foreach (var illegal in illegal_appoinments)
                {
                    int nph = 0;
                    if (illegal.NCH1 > 0 || illegal.NCH2 > 0 || illegal.NCH3 > 0 || illegal.NCH21 > 0)
                    {
                        nph = illegal.NCH3 + illegal.NCH2 + illegal.NCH1 + illegal.NCH21;
                        illegal.ph = illegal.NCH3 + illegal.NCH2 + illegal.NCH21 + illegal.NCH1 + max_legal_h;
                        max_legal_h += nph;
                    }
                    if (illegal.NMS > 0)
                    {
                        illegal.pms = illegal.NMS + max_legal_ms;
                        max_legal_ms += illegal.NMS;
                    }
                    if (illegal.NSH > 0)
                    {
                        illegal.psh = illegal.NSH + max_legal_sh;
                        max_legal_sh += illegal.NSH;
                    }
                    if (illegal.NSHH > 0)
                    {
                        illegal.pshh = illegal.NSHH + max_legal_shh;
                        max_legal_shh += illegal.NSHH;
                    }
                    if (illegal.NS > 0)
                    {
                        illegal.pns = illegal.NS + max_legal_ns;
                        max_legal_ns += illegal.NS;
                    }
                    illegal.Official = true;
                    illegal.New = false;
                }
            }
            await Remove();
            await _context.SaveChangesAsync();
            AdminModal modal = await GetModal(administrator);
            return View("Home", modal);
        }

        public async Task<IActionResult> Official(int? id)
        {
            var appoinment = await _context.appoinment.FirstOrDefaultAsync(m => m.ID == id);
            appoinment.Official = true;
            await _context.SaveChangesAsync();
            AdminModal modal = await GetModal(administrator);
            return View("Home", modal);
        }

        public IActionResult Switch()
        {
            return RedirectToAction("Index", "Login", new { });
        }

        public IActionResult Tutor()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Performance()
        {
            var meetings = await _context.appoinment.ToListAsync();
            var sales = await _context.sale.ToListAsync();
            Performance performance = new Performance();
            performance.meetings = meetings;
            performance.sales = sales;
            return View(performance);
        }

        [HttpGet]
        public async Task<IActionResult> Contracts(string type)
        {
            if (type == "")
            {
                return NotFound();
            }
            else if (type == "All")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true).OrderBy(ap => ap.Contract).ToListAsync());
            }
            else if (type == "Today")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.cTime.Contains(Convert.ToString(DateTime.Now.Day) + Convert.ToString(DateTime.Now.Month) + Convert.ToString(DateTime.Now.Year))).OrderBy(ap => ap.Contract).ToListAsync());
            }
            else if (type == "Cancel")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == false).OrderBy(ap => ap.Contract).ToListAsync());
            }
            else if (type == "ph1")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NCH1 > 0).OrderBy(ap => ap.Contract).ToListAsync());
            }
            else if (type == "ph21")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NCH21 > 0).OrderBy(ap => ap.Contract).ToListAsync());
            }
            else if (type == "ph2")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NCH2 > 0).OrderBy(ap => ap.Contract).ToListAsync());
            }
            else if (type == "ph3")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NCH3 > 0).OrderBy(ap => ap.Contract).ToListAsync());
            }
            else if (type == "psh")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NSH > 0).OrderBy(ap => ap.Contract).ToListAsync());
            }
            else if (type == "pshh")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NSHH> 0).OrderBy(ap => ap.Contract).ToListAsync());
            }
            else if (type == "pns")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NS > 0).OrderBy(ap => ap.Contract).ToListAsync());
            }
            else if (type == "pms")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NMS > 0).OrderBy(ap => ap.Contract).ToListAsync());
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Type(string type)
        {
            if (type == "date")
            {
                return PartialView("Date");
            }
            else if (type == "product")
            {
                return PartialView("Product");
            }
            else if (type == "customer" || type == "sale" || type == "address" || type == "place")
            {
                return PartialView("Text");
            }
            else
            {
                return PartialView("Choose");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Filter(string type, string context)
        {
            if (type == "customer")
            {
                string[] name = context.Split("_");
                context = String.Join(" ", name);
                var meetings = await _context.appoinment.Where(a => a.Customer.Contains(context)).OrderBy(m => m.Contract).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "sale")
            {
                string[] name = context.Split("_");
                context = String.Join(" ", name);
                var meetings = await _context.appoinment.Where(a => a.SaleDetails.Contains(context)).OrderBy(m => m.Contract).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "loans")
            {

                var meetings = await _context.appoinment.Where(a => a.Price > 0).OrderBy(m => m.Contract).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "ph")
            {
                var meetings = await _context.appoinment.Where(a => a.NCH1 + a.NCH2 + a.NCH21 + a.NCH3 > 0).OrderBy(m => m.Contract).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "psh")
            {
                var meetings = await _context.appoinment.Where(a => a.NSH > 0).OrderBy(m => m.Contract).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "pshh")
            {
                var meetings = await _context.appoinment.Where(a => a.NSHH > 0).OrderBy(m => m.Contract).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "pms")
            {
                var meetings = await _context.appoinment.Where(a => a.NMS > 0).OrderBy(m => m.Contract).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "pns")
            {
                var meetings = await _context.appoinment.Where(a => a.NS > 0).OrderBy(m => m.Contract).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "address")
            {
                string[] name = context.Split("_");
                context = String.Join(" ", name);
                var meetings = await _context.appoinment.Where(a => a.Address.Contains(context)).OrderBy(m => m.Contract).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "place")
            {
                string[] name = context.Split("_");
                context = String.Join(" ", name);
                var meetings = await _context.appoinment.Where(a => a.HKTT.Contains(context)).OrderBy(m => m.Contract).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "date")
            {
                string[] date = context.Split("-");
                string new_date = date[2] + date[1] + date[0];
                var meetings = await _context.appoinment.Where(a => a.dTime.Contains(new_date)).OrderBy(m => m.Contract).ToListAsync();
                return PartialView("List", meetings);
            }
            else
            {
                return NotFound();
            }
        }

        //public async Task<IActionResult> Contracts(int? id)
        //{
        //    var meetings = await _context.appoinment.Where(m => m.New == true).ToListAsync();
        //    var meeting = _context.appoinment.First();
        //    if (id == 1)
        //    {
        //        meetings = await _context.appoinment.Where(a => a.IsActive == true).OrderBy(m => m.Contract).ToListAsync();
        //    }
        //    else if (id == 2)
        //    {
        //        meetings = await _context.appoinment.Where(m => m.New == true && m.Confirm == true && m.IsActive == true).OrderBy(m => m.Contract).ToListAsync();
        //    }
        //    else if (id == 3)
        //    {
        //        meetings = await _context.appoinment.Where(m => m.New == true && m.Confirm == false && m.IsActive == true).OrderBy(m => m.Contract).ToListAsync();
        //    }
        //    else if (id == 4)
        //    {
        //        meetings = await _context.appoinment.Where(m => m.OldContract == true && m.IsActive == true).OrderBy(m => m.Contract).ToListAsync();
        //    }
        //    else if (id == 5)
        //    {
        //        meetings = await _context.appoinment.Where(m => m.IsActive == false).OrderBy(m => m.Contract).ToListAsync();
        //    }
        //    int ph = _context.appoinment.Max(m => m.ph);
        //    int psh = _context.appoinment.Max(m => m.psh);
        //    int pshh = _context.appoinment.Max(m => m.pshh);
        //    int pms = _context.appoinment.Max(m => m.pms);
        //    int pns = _context.appoinment.Max(m => m.pns);
        //    AdminModal modal = new AdminModal();
        //    modal.admin = administrator;
        //    modal.appoinment = meeting;
        //    modal.appoinments = meetings;
        //    modal.officials = new List<int>();
        //    modal.officials.Add(ph + 1);
        //    modal.officials.Add(psh + 1);
        //    modal.officials.Add(pshh + 1);
        //    modal.officials.Add(pms + 1);
        //    modal.officials.Add(pns + 1);
        //    return View("Home", modal);
        //}

        public async Task<IActionResult> _Home()
        {
            var meetings = await _context.appoinment.Where(m => m.IsActive == true).OrderBy(m => m.Contract).ToListAsync();
            var meeting = _context.appoinment.First();
            int ph = _context.appoinment.Max(m => m.ph);
            int psh = _context.appoinment.Max(m => m.psh);
            int pshh = _context.appoinment.Max(m => m.pshh);
            int pms = _context.appoinment.Max(m => m.pms);
            int pns = _context.appoinment.Max(m => m.pns);

            AdminModal modal = new AdminModal();
            modal.admin = administrator;
            modal.appoinment = meeting;
            modal.appoinments = meetings;
            modal.officials = new List<int>();
            modal.officials.Add(ph + 1);
            modal.officials.Add(psh + 1);
            modal.officials.Add(pshh + 1);
            modal.officials.Add(pms + 1);
            modal.officials.Add(pns + 1);
            return View("Home",modal);
        }

        //[HttpPost]
        public async Task<IActionResult> Home(Admin admin)
        {
            //var mm = await _context.appoinment.ToListAsync();
            //foreach (Appoinment mt in mm)
            //{
            //    mt.IsActive = true;
            //}
            //_context.UpdateRange(mm);
            //await _context.SaveChangesAsync();
            var meetings = await _context.appoinment.Where(m => m.IsActive == true).OrderBy(m => m.Contract).ToListAsync();
            var meeting = _context.appoinment.First();
            int ph = _context.appoinment.Max(m => m.ph);
            int psh = _context.appoinment.Max(m => m.psh);
            int pshh = _context.appoinment.Max(m => m.pshh);
            int pms = _context.appoinment.Max(m => m.pms);
            int pns = _context.appoinment.Max(m => m.pns);
            foreach (Admin s in admins)
            {
                if (admin.email.Equals(s.email) && admin.password.Equals(s.password))
                {
                    admin.name = s.name;
                    admin.phone = s.phone;
                    AdminModal modal = new AdminModal();
                    modal.admin = admin;
                    modal.appoinment = meeting;
                    modal.appoinments = meetings;
                    modal.officials = new List<int>();
                    modal.officials.Add(ph + 1);
                    modal.officials.Add(psh + 1);
                    modal.officials.Add(pshh + 1);
                    modal.officials.Add(pms + 1);
                    modal.officials.Add(pns + 1);
                    administrator = admin;
                    return View(modal);
                }
            }
            return View("Error");
        }
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
            foreach (Sale sale in sales)
            {
                if (sale.email == a.sale)
                    TempData["name"] = sale.display;
            }
            return RedirectToAction("Print", "Appoinments", new { id });
        }

        public async Task<IActionResult> Draft(int? id)
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
            foreach (Sale sale in sales)
            {
                if (sale.email == a.sale)
                    TempData["name"] = sale.display;
            }
            return RedirectToAction("Draft", "Appoinments", new { id });
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Edit", "Appoinments", new { id });
        }

        public async Task<IActionResult> Confirm(int? id)
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
            foreach (Sale sale in sales)
            {
                if (sale.email == a.sale)
                {
                    TempData["name"] = sale.name;
                    break;
                }
            }
            return View(a);
        }

        [HttpGet("Province", Name = "Export")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult ExportJson(string path)
        {
            string jsonContents = "[";
            List<Appoinment> appoinments = new List<Appoinment>();
            appoinments = _context.appoinment.ToList();
            foreach (Appoinment a in appoinments)
            {
                jsonContents += JsonConvert.SerializeObject(a) + ",";
            }
            jsonContents += "]";
            System.IO.File.WriteAllText(path, jsonContents);
            return Ok();
        }

        public async Task<AdminModal> GetModal(Admin admin)
        {
            var meetings = await _context.appoinment.Where(a => a.IsActive == true).OrderBy(m => m.Contract).ToListAsync();
            var meeting = _context.appoinment.First();
            int ph = _context.appoinment.Max(m => m.ph);
            int psh = _context.appoinment.Max(m => m.psh);
            int pshh = _context.appoinment.Max(m => m.pshh);
            int pms = _context.appoinment.Max(m => m.pms);
            int pns = _context.appoinment.Max(m => m.pns);
            AdminModal modal = new AdminModal();
            modal.admin = admin;
            modal.appoinment = meeting;
            modal.appoinments = meetings;
            modal.officials = new List<int>();
            modal.officials.Add(ph + 1);
            modal.officials.Add(psh + 1);
            modal.officials.Add(pshh + 1);
            modal.officials.Add(pms + 1);
            modal.officials.Add(pns + 1);
            return modal;
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

        public async Task<IActionResult> Confirmed(Appoinment a)
        {
            if (a.Contract == null)
            {
                return NotFound();
            }
            Appoinment tmp = await _context.appoinment.FirstOrDefaultAsync(m => m.Contract == a.Contract);
            tmp.dTime = a.dTime;
            tmp.Cash = a.Cash;
            tmp.Confirm = true;
            DateTime first = DateTime.Now;
            DateTime second = DateTime.Now;
            try {
                first = DateTime.ParseExact(tmp.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF",
                                     System.Globalization.CultureInfo.InvariantCulture);
            }
            catch {
                first = DateTime.ParseExact(tmp.cTime, "yyyy-MM-dd HH:mm:ss.FFFFFFF",
                                     System.Globalization.CultureInfo.InvariantCulture);
            }
            second = DateTime.ParseExact(tmp.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF",
                                       System.Globalization.CultureInfo.InvariantCulture);
            if (first.TimeOfDay.TotalHours >= 16.5)
            {
                if (second.Day == first.Day)
                {
                    TimeSpan span = second.Subtract(first);
                    if (span.TotalHours <= 2)
                    {
                        //ok
                        tmp.Deposit = "Đúng thời hạn";
                    }
                    else
                    {
                        tmp.Deposit = "Không đúng thời hạn";
                        tmp.Contract = _context.appoinment.Where(ap=> ap.IsActive == true).Max(c => c.Contract) + 1;
                        if (tmp.NCH1 > 0 || tmp.NCH2 > 0 || tmp.NCH3 > 0 || tmp.NCH21 > 0)
                        {
                            tmp.ph = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.ph) + tmp.NCH2 + tmp.NCH1 + tmp.NCH3 + tmp.NCH21;
                            //str += "Căn hộ: " + Convert.ToString(tmp.ph) + "\n";
                        }
                        if (tmp.NSH > 0)
                        {
                            tmp.psh = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.psh) + tmp.NSH;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSHH > 0)
                        {
                            tmp.pshh = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pshh) + tmp.NSHH;
                            //str += "Shophouse: " + Convert.ToString(tmp.pshh) + "\n";
                        }
                        if (tmp.NMS > 0)
                        {
                            tmp.pms = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pms) + tmp.NMS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                        if (tmp.NS > 0)
                        {
                            tmp.pns = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pns) + tmp.NS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                    }
                }
                else if (second.Day - 1 == first.Day)
                {
                    if (second.TimeOfDay.TotalHours > 10.5)
                    {
                        tmp.Deposit = "Không đúng thời hạn";
                        tmp.Contract = _context.appoinment.Max(c => c.Contract) + 1;
                        if (tmp.NCH1 > 0 || tmp.NCH2 > 0 || tmp.NCH3 > 0 || tmp.NCH21 > 0)
                        {
                            tmp.ph = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.ph) + tmp.NCH2 + tmp.NCH1 + tmp.NCH3 + tmp.NCH21;
                            //str += "Căn hộ: " + Convert.ToString(tmp.ph) + "\n";
                        }
                        if (tmp.NSH > 0)
                        {
                            tmp.psh = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.psh) + tmp.NSH;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSHH > 0)
                        {
                            tmp.pshh = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pshh) + tmp.NSHH;
                            //str += "Shophouse: " + Convert.ToString(tmp.pshh) + "\n";
                        }
                        if (tmp.NMS > 0)
                        {
                            tmp.pms = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pms) + tmp.NMS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                        if (tmp.NS > 0)
                        {
                            tmp.pns = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pns) + tmp.NS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                    }
                    else
                    {
                        tmp.Deposit = "Đúng thời hạn";
                    }
                }
            }
            else if (first.TimeOfDay.TotalHours > 14.5)
            {
                double h = 8.5 + (2 - (16.5 - first.TimeOfDay.TotalHours));
                if (second.Day - 1 == first.Day)
                {
                    if (second.TimeOfDay.TotalHours > h)
                    {
                        tmp.Deposit = "Không đúng thời hạn";
                        tmp.Contract = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.Contract) + 1;
                        if (tmp.NCH1 > 0 || tmp.NCH2 > 0 || tmp.NCH3 > 0 || tmp.NCH21 > 0)
                        {
                            tmp.ph = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.ph) + tmp.NCH2 + tmp.NCH1 + tmp.NCH3 +tmp.NCH21;
                            //str += "Căn hộ: " + Convert.ToString(tmp.ph) + "\n";
                        }
                        if (tmp.NSH > 0)
                        {
                            tmp.psh = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.psh) + tmp.NSH;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSHH > 0)
                        {
                            tmp.pshh = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pshh) + tmp.NSHH;
                            //str += "Shophouse: " + Convert.ToString(tmp.pshh) + "\n";
                        }
                        if (tmp.NMS > 0)
                        {
                            tmp.pms = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pms) + tmp.NMS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                        if (tmp.NS > 0)
                        {
                            tmp.pns = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pns) + tmp.NS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                    }
                    else
                    {
                        tmp.Deposit = "Đúng thời hạn";
                    }
                }
                else if (second.Day == first.Day)
                {
                    if (second.TimeOfDay.TotalHours > first.TimeOfDay.TotalHours + 2)
                    {
                        tmp.Deposit = "Không đúng thời hạn";
                        tmp.Contract = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.Contract) + 1;
                        if (tmp.NCH1 > 0 || tmp.NCH2 > 0 || tmp.NCH3 > 0 || tmp.NCH21 > 0)
                        {
                            tmp.ph = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.ph) + tmp.NCH2 + tmp.NCH1 + tmp.NCH3 + tmp.NCH21;
                            //str += "Căn hộ: " + Convert.ToString(tmp.ph) + "\n";
                        }
                        if (tmp.NSH > 0)
                        {
                            tmp.psh = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.psh) + tmp.NSH;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSHH > 0)
                        {
                            tmp.pshh = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pshh) + tmp.NSHH;
                            //str += "Shophouse: " + Convert.ToString(tmp.pshh) + "\n";
                        }
                        if (tmp.NMS > 0)
                        {
                            tmp.pms = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pms) + tmp.NMS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                        if (tmp.NS > 0)
                        {
                            tmp.pns = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pns) + tmp.NS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                    }
                    else
                    {
                        tmp.Deposit = "Đúng thời hạn";
                    }
                }               
            }
            else
            {
                TimeSpan span = second.Subtract(first);
                if (span.TotalHours <= 2)
                {
                    //ok
                    tmp.Deposit = "Đúng thời hạn";
                }
                else
                {
                    tmp.Deposit = "Không đúng thời hạn";
                    tmp.Contract = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.Contract) + 1;
                    if (tmp.NCH1 > 0 || tmp.NCH2 > 0 || tmp.NCH3 > 0 || tmp.NCH21 > 0)
                    {
                        tmp.ph = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.ph) + tmp.NCH2 + tmp.NCH1 + tmp.NCH3 + tmp.NCH21;
                        //str += "Căn hộ: " + Convert.ToString(tmp.ph) + "\n";
                    }
                    if (tmp.NSH > 0)
                    {
                        tmp.psh = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.psh) + tmp.NSH;
                        //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                    }
                    if (tmp.NSHH > 0)
                    {
                        tmp.pshh = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pshh) + tmp.NSHH;
                        //str += "Shophouse: " + Convert.ToString(tmp.pshh) + "\n";
                    }
                    if (tmp.NMS > 0)
                    {
                        tmp.pms = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pms) + tmp.NMS;
                        //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                    }
                    if (tmp.NS > 0)
                    {
                        tmp.pns = _context.appoinment.Where(ap => ap.IsActive == true).Max(c => c.pns) + tmp.NS;
                        //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                    }
                    //tmp.Priority = _context.appoinment.Max(c => c.Priority) + 1;
                }
            }
            
            //string[] new_day = Convert.ToString(day).Split(" ")[0].Split("/");
            //string new_time = Convert.ToString(hh) + Convert.ToString(MM) + Convert.ToString(ss) + Convert.ToString(FF);

            await _context.SaveChangesAsync();
            AdminModal modal = await GetModal(administrator);
            return View("Home", modal);
        }
    }
}