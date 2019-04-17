using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookingForm.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using Serilog;
using System.Text.RegularExpressions;
using System.Drawing.Printing;

namespace BookingForm.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<Sale> _userManager;
        private readonly IHostingEnvironment _environment;
        private readonly BookingFormContext _context;
        
        public AdminController(BookingFormContext context, IHostingEnvironment hostingEnvironment, UserManager<Sale> userManager)
        {
            _userManager = userManager;
            _environment = hostingEnvironment;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public  async Task<IActionResult> RequestPrint()
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Documents", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            return View("PrintDocument");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrintDocument(int number)
        {
            if (number <= 0)
            {
                return NotFound("Vui lòng nhập số lượng bản in");
            }
            var curUser = await _userManager.GetUserAsync(User);
            if (curUser is null)
            {
                return View("Bạn phải đăng nhập để thực hiện tác vụ này");
            }
            Document docs = new Document(DateTime.UtcNow, number, curUser.Email);
            _context.Documents.Add(docs);
            await _context.SaveChangesAsync();
            return View("Documents");
        }

        public async Task<bool> IsAuthorized(Sale sale, string resource, string operation)
        {
            if (sale == null)
            {
                return false;
            }
            var roles = await _userManager.GetRolesAsync(sale);
           
            var grants = await _context.Grants.Where(g => g.Operation == operation && g.Resource == resource && g.Permission == "Allow").ToListAsync();
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

        public async Task<IActionResult> GetRequest()
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            var requests = await _context.Requests.ToListAsync();
            if (requests != null)
            {
                return View("Request", requests);
            }
            return NotFound("Unable to load request.");
        }

        [HttpGet]
        public async Task<IActionResult> Approve(Guid? id)
        {
            var request = await _context.Requests.FindAsync(id);
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (request == null)
            {
                return NotFound("Can't find request with Id: " + id);
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Approve([Bind("Id, Status", "Contents", "RequestName", "Subject")] Request request)
        {
            if (!ModelState.IsValid)
            {
                TempData["StatusMessage"] = "Can't find request!";
                return View();
            }
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Update");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (request.Status == Status.Accepted)
            {
                TempData["StatusMessage"] = "You don't have permission to accept a request. Check Help for more information!";
                return View();
            }
            TempData["StatusMessage"] = "Request has been updated!";
            if (request.Status == Status.Approved)
            {
                //string contents = "Có một yêu cầu mới cần được thông qua.";
                //SendMail(request.Subject, new MailboxAddress("Hằng Lê", "hang.le@annhome.vn"), contents);     
            }
            var tmp = await _context.Requests.FindAsync(request.Id);
            tmp.Status = request.Status;
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

        public async Task<IActionResult> Export()
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            else
            {
                string sWebRootFolder = _environment.WebRootPath;
                //string fname = @"Thông tin đặt giữ chỗ dự án Vincity" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
                string sFileName = @"Form thông tin Khách hàng Book căn VinCity" + ".xlsx";
                string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
                FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
                var memory = new MemoryStream();
                using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
                {
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("INDIVIDUAL CUSTOMER");
                    IRow row = excelSheet.CreateRow(0);

                    row.CreateCell(0).SetCellValue("Customer Name");
                    row.CreateCell(1).SetCellValue("Nationality");
                    row.CreateCell(2).SetCellValue("Gender");
                    row.CreateCell(3).SetCellValue("Birthday<YYYYMMDD>");
                    row.CreateCell(4).SetCellValue("ID Type");
                    row.CreateCell(5).SetCellValue("ID NO.");

                    var appoinments = await _context.appoinment.Where(ap => ap.IsActive == true && ap.Confirm == true).OrderBy(a => a.Contract).ToListAsync();
                    int count = 1;
                    foreach (var appoinment in appoinments)
                    {
                        row = excelSheet.CreateRow(count);

                        row.CreateCell(0).SetCellValue(appoinment.Customer);
                        row.CreateCell(1).SetCellValue("01<Native>");
                        string gender = appoinment.Gender;
                        if (gender != "")
                        {
                            if (gender == "Anh" || gender == "Nam")
                            {
                                row.CreateCell(2).SetCellValue("10<Male>");
                            }
                            else if (gender == "Chị" || gender == "Nữ")
                            {
                                row.CreateCell(2).SetCellValue("20<Female>");
                            }
                            else
                            {
                                row.CreateCell(2).SetCellValue("30<Other>");
                            }
                        }
                        if (appoinment.DOB.Year != 1)
                        {
                            row.CreateCell(3).SetCellValue(appoinment.DOB.ToString("yyyyMMdd"));
                        }
                        else
                        {
                            row.CreateCell(3).SetCellValue("thiếu");
                        }
                        string IdType = "";
                        if (appoinment.Cmnd != null)
                        {
                            if (appoinment.Cmnd.Length == 9 || appoinment.Cmnd.Length == 12)
                            {
                                IdType = "10<CCCD/CMTND>";
                            }
                            else if (Regex.IsMatch(appoinment.Cmnd.Substring(0, 1), @"^[a-zA-Z]+$") && appoinment.Cmnd.Length == 8)
                            {
                                IdType = "30<Passport>";
                            }
                            else
                            {
                                IdType = "40<Other>";
                            }
                        }
                        row.CreateCell(4).SetCellValue(IdType);

                        row.CreateCell(5).SetCellValue("'" + appoinment.Cmnd);

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
                        priority += "BTĐL(";
                        for (int i = appoinment.NSH - 1; i >= 0; i--)
                        {
                            priority += Convert.ToString(appoinment.psh - i) + " ";
                        }
                        priority = priority.TrimEnd();
                        priority += ") ";
                    }
                    if (appoinment.NSH1 > 0)
                    {
                        priority += "BTSL(";
                        for (int i = appoinment.NSH1 - 1; i >= 0; i--)
                        {
                            priority += Convert.ToString(appoinment.psh1 - i) + " ";
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
            return RedirectToAction("Dashboard");
        }

        public async Task Remove()
        {
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1, 19, 00, 00, 0000000);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00, 0000000);
            var failed_appoinments = await _context.appoinment.Where(m => m.Confirm == false && m.OldContract == false && m.Official == false && m.Deposit == null).OrderBy(m => m.Id).ToListAsync();
            foreach (var appoinment in failed_appoinments)
            {
                appoinment.IsActive = false;

                _context.appoinment.Update(appoinment);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IActionResult> Summary()
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Summary");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1, 19, 00, 00, 0000000);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00, 0000000);
            var done_appoinments = await _context.appoinment.Where(m => m.OldContract == false && m.Official == true && m.IsActive == true).OrderBy(m => m.Id).ToListAsync();
            var legal_appoinments = await _context.appoinment.Where(m => m.Deposit == "Đúng thời hạn" && m.OldContract == false && m.Official == false && m.IsActive == true).OrderBy(m => m.Id).ToListAsync();
            var illegal_appoinments = await _context.appoinment.Where(m => m.Deposit == "Không đúng thời hạn"  && m.OldContract == false && m.Official == false && m.IsActive == true).OrderBy(m => m.Id).ToListAsync();
            int max_h = done_appoinments.Max(m => m.ph);
            int max_sh = done_appoinments.Max(m => m.psh);
            int max_sh1 = done_appoinments.Max(m => m.psh1);
            int max_shh = done_appoinments.Max(m => m.pshh);
            int max_ms = done_appoinments.Max(m => m.pms);
            int max_ns = done_appoinments.Max(m => m.pns);
            int max_legal_h = 0;
            int max_legal_sh = 0;
            int max_legal_sh1 = 0;
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
                    if (legal.NSH1 > 0)
                    {
                        legal.psh1 = legal.NSH1 + max_sh1;
                        max_sh1 += legal.NSH1;
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
                max_legal_sh1 = legal_appoinments.Max(m => m.psh1);
                max_legal_shh = legal_appoinments.Max(m => m.pshh);
                max_legal_ms = legal_appoinments.Max(m => m.pms);
                max_legal_ns = legal_appoinments.Max(m => m.pns);
            }
            else
            {
                max_legal_h = max_h;
                max_legal_sh = max_sh;
                max_legal_sh1 = max_sh1;
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
                    if (illegal.NSH1 > 0)
                    {
                        illegal.psh1 = illegal.NSH1 + max_legal_sh1;
                        max_legal_sh1 += illegal.NSH1;
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
            AdminModal modal = await GetModal();
            return RedirectToAction("Dashboard");
        }

        public async Task<IActionResult> Official(Guid? id)
        {
            var appoinment = await _context.appoinment.FirstOrDefaultAsync(m => m.Id == id);
            appoinment.Official = true;
            await _context.SaveChangesAsync();
            AdminModal modal = await GetModal();
            return RedirectToAction("Dashboard");
        }

        public IActionResult Sale()
        {
            return RedirectToAction("Dashboard", "Home");
        }

        public IActionResult Tutor()
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
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Filter");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (type == "")
            {
                return NotFound();
            }
            else if (type == "All")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.Confirm == true).OrderBy(ap => DateTime.ParseExact(ap.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            else if (type == "Today")
            {
                string str = DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("00");
                var meetings = await _context.appoinment.Where(a => a.cTime.Contains(str)).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "Loans")
            {
                var meetings = await _context.appoinment.Where(a => a.Price > 0 && a.Confirm == true && a.IsActive == true).OrderBy(ap => DateTime.ParseExact(ap.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "Cancel")
            {
                return PartialView("Cancelled", await _context.appoinment.Where(a => a.IsActive == false && a.Confirm == false).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            else if (type == "Withdraws")
            {
                return PartialView("Cancelled", await _context.appoinment.Where(a => a.IsActive == false && a.Confirm == true).OrderBy(ap => DateTime.ParseExact(ap.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            else if (type == "ph1")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NCH1 > 0).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            else if (type == "ph21")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NCH21 > 0).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            else if (type == "ph2")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NCH2 > 0).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            else if (type == "ph3")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NCH3 > 0).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            else if (type == "psh")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NSH > 0).OrderBy(ap => DateTime.ParseExact(ap.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            else if (type == "psh1")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NSH1 > 0).OrderBy(ap => DateTime.ParseExact(ap.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            else if (type == "pshh")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NSHH > 0).OrderBy(ap => DateTime.ParseExact(ap.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            else if (type == "pns")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NS > 0).OrderBy(ap => DateTime.ParseExact(ap.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            else if (type == "pms")
            {
                return PartialView("List", await _context.appoinment.Where(a => a.IsActive == true && a.NMS > 0).OrderBy(ap => DateTime.ParseExact(ap.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync());
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Type(string type)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Search");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (type == "date")
            {
                return PartialView("Date");
            }
            else if (type == "product")
            {
                return PartialView("Product");
            }
            else if (type == "customer" || type == "address" || type == "place" || type == "purpose")
            {
                return PartialView("Text");
            }
            else if (type == "sale")
            {
                var sales = await _context.sale.ToListAsync();
                var m = sales.Single(s => s.Email == "khang.trinh@annhome.vn");
                sales.Remove(m);
                return PartialView("Multi", sales);
            }
            else
            {
                return PartialView("Choose");
            }
        }

        public async Task<IActionResult> Withdraw(Guid id)
        {
            var meeting = await _context.appoinment.FindAsync(id);
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (meeting.Cash > 0)
            {
                ViewBag.money = So_chu(meeting.Cash);
            }
            else
            {
                ViewBag.money = ".................................";
            }
            return View(meeting);
        }

        [HttpGet]
        public async Task<IActionResult> Additional(Guid?id)
        {
            if(id == null)
            {
                return NotFound("Can't find any id");
            }
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            var meeting = await _context.appoinment.FindAsync(id);
            if (meeting == null)
            {
                return NotFound("Can't find appointment with Id: " + Convert.ToString(id));
            }
            ViewBag.Sale = meeting.SEmail;
            ViewBag.Customer = meeting.Customer;
            ViewBag.Contract = meeting.Contract;
            
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

        [HttpPost]
        public async Task<IActionResult> Additional([Bind("RequestName", "Contents", "Subject")] Request request)
        {
            if (!ModelState.IsValid)
            {
                TempData["StatusMessage"] = "Failed to sent request!";
                return View();
            }
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Create");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            request.Status = Status.Pending;
            request.Owner = await _userManager.GetUserAsync(User);
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
            TempData["StatusMessage"] = "Your request has been sent.";
            await Badge();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Filter(string type, string context)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Filter");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (type == "customer")
            {
                string[] name = context.Split("_");
                context = String.Join(" ", name);
                var meetings = await _context.appoinment.Where(a => a.Customer.Contains(context)).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "sale")
            {
                string[] names = context.Split(" ");
                List<Appoinment> meetings = new List<Appoinment>();
                foreach (string name in names)
                {
                    string new_name = string.Join(" ", name.Split("_"));
                    var sale = await _context.sale.FirstOrDefaultAsync(s => s.Name == new_name);
                    meetings.AddRange(_context.appoinment.Where(a => a.SEmail.Equals(sale.Email)).OrderBy(m => m.Contract));
                }
                return PartialView("List", meetings);
            }
            else if (type == "purpose")
            {
                string[] name = context.Split("_");
                context = String.Join(" ", name);
                var meetings = await _context.appoinment.Where(a => a.Purpose.Contains(context)).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "ph")
            {
                var meetings = await _context.appoinment.Where(a => a.NCH1 + a.NCH2 + a.NCH21 + a.NCH3 > 0).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "psh")
            {
                var meetings = await _context.appoinment.Where(a => a.NSH > 0).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "psh1")
            {
                var meetings = await _context.appoinment.Where(a => a.NSH1 > 0).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "pshh")
            {
                var meetings = await _context.appoinment.Where(a => a.NSHH > 0).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "pms")
            {
                var meetings = await _context.appoinment.Where(a => a.NMS > 0).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "pns")
            {
                var meetings = await _context.appoinment.Where(a => a.NS > 0).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "address")
            {
                string[] name = context.Split("_");
                context = String.Join(" ", name);
                var meetings = await _context.appoinment.Where(a => a.Address.Contains(context)).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "place")
            {
                string[] name = context.Split("_");
                context = String.Join(" ", name);
                var meetings = await _context.appoinment.Where(a => a.HKTT.Contains(context)).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else if (type == "date")
            {
                string[] date = context.Split("-");
                string new_date = date[2] + date[1] + date[0];
                var meetings = await _context.appoinment.Where(a => a.cTime.Contains(new_date)).OrderBy(ap => DateTime.ParseExact(ap.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null)).ToListAsync();
                return PartialView("List", meetings);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Dashboard()
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "List");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            var admin = await _userManager.GetUserAsync(User);
            var meetings = await _context.appoinment.Where(m => m.IsActive == true).OrderBy(m => m.Contract).ToListAsync();
            var meeting = _context.appoinment.First();
            int ph = _context.appoinment.Max(m => m.ph);
            int psh = _context.appoinment.Max(m => m.psh);
            int psh1 = _context.appoinment.Max(m => m.psh1);
            int pshh = _context.appoinment.Max(m => m.pshh);
            int pms = _context.appoinment.Max(m => m.pms);
            int pns = _context.appoinment.Max(m => m.pns);
            AdminModal modal = new AdminModal();
            modal.appoinment = meeting;
            modal.appoinments = meetings;
            modal.officials = new List<int>();
            modal.officials.Add(ph + 1);
            modal.officials.Add(pms + 1);
            modal.officials.Add(psh + 1);
            modal.officials.Add(psh1 + 1);
            modal.officials.Add(pshh + 1);
            modal.officials.Add(pns + 1);
            await Badge();
            return View(modal);
        }

        //public async Task<IActionResult> _Dashboard()
        //{
        //    return RedirectToAction("_Dashboard", new { type = "Search", context = "111" });
        //}

        public async Task<IActionResult> _Dashboard()
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "List");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            var admin = await _userManager.GetUserAsync(User);
            var meetings = await _context.appoinment.Where(m => m.IsActive == true).OrderBy(m => m.Contract).ToListAsync();
            var meeting = _context.appoinment.First();
            int ph = _context.appoinment.Max(m => m.ph);
            int psh = _context.appoinment.Max(m => m.psh);
            int psh1 = _context.appoinment.Max(m => m.psh1);
            int pshh = _context.appoinment.Max(m => m.pshh);
            int pms = _context.appoinment.Max(m => m.pms);
            int pns = _context.appoinment.Max(m => m.pns);
            AdminModal modal = new AdminModal();
            modal.appoinment = meeting;
            modal.appoinments = meetings;
            modal.officials = new List<int>();
            modal.officials.Add(ph + 1);
            modal.officials.Add(pms + 1);
            modal.officials.Add(psh + 1);
            modal.officials.Add(psh1 + 1);
            modal.officials.Add(pshh + 1);
            modal.officials.Add(pns + 1);
            await Badge();
            return View(meetings);
        }

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
            if (a == null)
            {
                return NotFound();
            }
            var sale = await _userManager.FindByEmailAsync(a.SEmail);

            TempData["name"] = sale.Name;

            return RedirectToAction("Print", "Appoinments", new { id });
        }

        public async Task<IActionResult> Draft(Guid? id)
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
            if (a == null)
            {
                return NotFound();
            }
            var sale = await _userManager.FindByEmailAsync(a.SEmail);

            TempData["name"] = sale.Name;

            return RedirectToAction("Draft", "Appoinments", new { id });
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Edit");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Edit", "Appoinments", new { id });
        }

        public async Task<IActionResult> Confirm(Guid? id)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Update");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (id == null)
            {
                return NotFound();
            }
            var sales = await _context.sale.ToListAsync();
            Appoinment a = await _context.appoinment
       .FirstOrDefaultAsync(b => b.Id == id);
            if (a == null)
            {
                return NotFound();
            }
            //var sale = await _userManager.GetUserAsync(User);
            
            //TempData["name"] = sale.Name;
             
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

        public async Task<AdminModal> GetModal()
        {
            var meetings = await _context.appoinment.Where(a => a.IsActive == true).OrderBy(m => m.Contract).ToListAsync();
            var meeting = _context.appoinment.First();
            int ph = _context.appoinment.Max(m => m.ph);
            int psh = _context.appoinment.Max(m => m.psh);
            int psh1 = _context.appoinment.Max(m => m.psh1);
            int pshh = _context.appoinment.Max(m => m.pshh);
            int pms = _context.appoinment.Max(m => m.pms);
            int pns = _context.appoinment.Max(m => m.pns);
            AdminModal modal = new AdminModal();
            modal.appoinment = meeting;
            modal.appoinments = meetings;
            modal.officials = new List<int>();
            modal.officials.Add(ph + 1);
            modal.officials.Add(psh + 1);
            modal.officials.Add(psh1 + 1);
            modal.officials.Add(pshh + 1);
            modal.officials.Add(pms + 1);
            modal.officials.Add(pns + 1);
            return modal;
        }

        public async Task<IActionResult> Passport(Guid? id)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (id == null)
            {
                return View("NotFound");
            }
            var meeting = await _context.appoinment.FindAsync(id);
            ViewBag.paths = meeting.Photo;
            TempData["Name"] = meeting.Customer;
            return View();
        }

        public async Task UpdatePriority(int id)
        {
            var appoinments = _context.appoinment.Where(a => a.Contract > id && a.IsActive == true).OrderBy(a => a.Id).ToList();
            var tmp = await _context.appoinment.FirstOrDefaultAsync(m => m.Contract == id);
            int ph = tmp.NCH1 + tmp.NCH2 + tmp.NCH3 + tmp.NCH21;
            int psh = tmp.NSH;
            int psh1 = tmp.NSH1;
            int pshh = tmp.NSHH;
            int pms = tmp.NMS;
            int pns = tmp.NS;

            if (appoinments != null)
            {
                foreach (var a in appoinments)
                {
                    a.ph -= ph;
                    a.psh -= psh;
                    a.psh1 -= psh1;
                    a.pshh -= pshh;
                    a.pms -= pms;
                    a.pns -= pns;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IActionResult> Confirmed(Appoinment a)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Update");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (a == null)
            {
                return NotFound();
            }
            Appoinment tmp = await _context.appoinment.FindAsync(a.Id);
            tmp.dTime = a.dTime;
            tmp.Cash = a.Cash;
            tmp.Confirm = true;
            tmp.LastModified = DateTime.Now;
            tmp.LastModifiedBy = curUser.Email;
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
                            tmp.ph = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.ph) + tmp.NCH2 + tmp.NCH1 + tmp.NCH3 + tmp.NCH21;
                            //str += "Căn hộ: " + Convert.ToString(tmp.ph) + "\n";
                        }
                        if (tmp.NSH > 0)
                        {
                            tmp.psh = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.psh) + tmp.NSH;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSH1 > 0)
                        {
                            tmp.psh1 = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.psh1) + tmp.NSH1;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSHH > 0)
                        {
                            tmp.pshh = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pshh) + tmp.NSHH;
                            //str += "Shophouse: " + Convert.ToString(tmp.pshh) + "\n";
                        }
                        if (tmp.NMS > 0)
                        {
                            tmp.pms = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pms) + tmp.NMS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                        if (tmp.NS > 0)
                        {
                            tmp.pns = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pns) + tmp.NS;
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
                            tmp.ph = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.ph) + tmp.NCH2 + tmp.NCH1 + tmp.NCH3 + tmp.NCH21;
                            //str += "Căn hộ: " + Convert.ToString(tmp.ph) + "\n";
                        }
                        if (tmp.NSH > 0)
                        {
                            tmp.psh = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.psh) + tmp.NSH;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSH1 > 0)
                        {
                            tmp.psh1 = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.psh1) + tmp.NSH1;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSHH > 0)
                        {
                            tmp.pshh = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pshh) + tmp.NSHH;
                            //str += "Shophouse: " + Convert.ToString(tmp.pshh) + "\n";
                        }
                        if (tmp.NMS > 0)
                        {
                            tmp.pms = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pms) + tmp.NMS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                        if (tmp.NS > 0)
                        {
                            tmp.pns = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pns) + tmp.NS;
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
                            tmp.ph = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.ph) + tmp.NCH2 + tmp.NCH1 + tmp.NCH3 +tmp.NCH21;
                            //str += "Căn hộ: " + Convert.ToString(tmp.ph) + "\n";
                        }
                        if (tmp.NSH > 0)
                        {
                            tmp.psh = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.psh) + tmp.NSH;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSH1 > 0)
                        {
                            tmp.psh1 = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.psh1) + tmp.NSH1;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSHH > 0)
                        {
                            tmp.pshh = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pshh) + tmp.NSHH;
                            //str += "Shophouse: " + Convert.ToString(tmp.pshh) + "\n";
                        }
                        if (tmp.NMS > 0)
                        {
                            tmp.pms = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pms) + tmp.NMS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                        if (tmp.NS > 0)
                        {
                            tmp.pns = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pns) + tmp.NS;
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
                            tmp.ph = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.ph) + tmp.NCH2 + tmp.NCH1 + tmp.NCH3 + tmp.NCH21;
                            //str += "Căn hộ: " + Convert.ToString(tmp.ph) + "\n";
                        }
                        if (tmp.NSH > 0)
                        {
                            tmp.psh = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.psh) + tmp.NSH;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSH1 > 0)
                        {
                            tmp.psh1 = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.psh1) + tmp.NSH1;
                            //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                        }
                        if (tmp.NSHH > 0)
                        {
                            tmp.pshh = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pshh) + tmp.NSHH;
                            //str += "Shophouse: " + Convert.ToString(tmp.pshh) + "\n";
                        }
                        if (tmp.NMS > 0)
                        {
                            tmp.pms = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pms) + tmp.NMS;
                            //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                        }
                        if (tmp.NS > 0)
                        {
                            tmp.pns = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pns) + tmp.NS;
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
                        tmp.ph = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.ph) + tmp.NCH2 + tmp.NCH1 + tmp.NCH3 + tmp.NCH21;
                        //str += "Căn hộ: " + Convert.ToString(tmp.ph) + "\n";
                    }
                    if (tmp.NSH > 0)
                    {
                        tmp.psh = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.psh) + tmp.NSH;
                        //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                    }
                    if (tmp.NSH1 > 0)
                    {
                        tmp.psh1 = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.psh1) + tmp.NSH1;
                        //str += "Nhà phố: " + Convert.ToString(tmp.psh) + "\n";
                    }
                    if (tmp.NSHH > 0)
                    {
                        tmp.pshh = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pshh) + tmp.NSHH;
                        //str += "Shophouse: " + Convert.ToString(tmp.pshh) + "\n";
                    }
                    if (tmp.NMS > 0)
                    {
                        tmp.pms = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pms) + tmp.NMS;
                        //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                    }
                    if (tmp.NS > 0)
                    {
                        tmp.pns = _context.appoinment.Where(ap => ap.IsActive == true && ap.Contract < tmp.Contract - 1).Max(c => c.pns) + tmp.NS;
                        //str += "Biệt thự: " + Convert.ToString(tmp.pms) + "\n";
                    }
                    //tmp.Priority = _context.appoinment.Max(c => c.Priority) + 1;
                }
            }

            //string[] new_day = Convert.ToString(day).Split(" ")[0].Split("/");
            //string new_time = Convert.ToString(hh) + Convert.ToString(MM) + Convert.ToString(ss) + Convert.ToString(FF);
            _context.Update(tmp);
            await _context.SaveChangesAsync();
            AdminModal modal = await GetModal();
            return RedirectToAction("Dashboard");
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
    }
}