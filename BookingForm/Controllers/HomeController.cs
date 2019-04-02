using System;
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
using Microsoft.Extensions.Configuration;
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
        public IConfiguration Configuration { get; }
        //SaleAPI _api = new SaleAPI();
        //private IdentityApiController identityApiController;

        public HomeController(BookingFormContext context, UserManager<Sale> userManager, IConfiguration configuration)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://id.annhome.vn/");
            //identityApiController = new IdentityApiController(client); 
            _context = context;
            _userManager = userManager;
            Configuration = configuration;

            //StreamReader r = new StreamReader("sales.json");
            //string json = r.ReadToEnd();
            //sales = JsonConvert.DeserializeObject<List<Sale>>(json);
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

        public async Task<IActionResult> RequestsControl()
        {
            //var curUser = await _userManager.GetUserAsync(User);
            //var authorized = await IsAuthorized(curUser, "Contracts", "Create");
            //TempData["StatusMessage"] = TempData["StatusMessage"];
            //if (!authorized)
            //{
            //    return View("AccessDenied");
            //}
            var requests = await _context.Requests.Where(r => r.Subject == "Loan").ToListAsync();
            if (requests == null)
            {
                return NotFound("Can't find any requests");
            }
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "List");
            TempData["StatusMessage"] = TempData["StatusMessage"];
            if (!authorized)
            {
                return View("AccessDenied");
            }
            foreach (Request request in requests)
            {
                if (request.OwnerId != null)
                {
                    request.Owner = await _context.sale.FirstAsync(s => s.Id == request.OwnerId);
                }
                _context.Update(request);
            }
            return View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var curUser = await _userManager.GetUserAsync(User);
            if (curUser is null)
            {
                return View("Error", "Bạn phải đăng nhập để thực hiện chức năng này");
            }
            var tests = await _context.Tests.ToListAsync();
            return View(tests);
        }
//, [FromQuery] int notc, [FromQuery] int minutes, [FromQuery] bool isnotanswered
        [HttpGet]
        public async Task<IActionResult> AttendTest(string test_name)
        {
            var curUser = await _userManager.GetUserAsync(User);
            if (curUser is null)
            {
                return View("Error", "Bạn phải đăng nhập để thực hiện chức năng này");
            }
            string[] newname = test_name.Split("_");
            var tests = await _context.Tests.Include(t => t.Questions).ThenInclude(q => q.Baits).ToListAsync();
            var model = tests.FirstOrDefault(t => t.Name == string.Join(" ", newname));
            model.Questions = model.Questions.OrderBy(q => Guid.NewGuid()).ToList();
            
            foreach (var question in model.Questions)
            {
                question.Baits.Add(new Bait { Content = question.Answer });
                question.Baits = question.Baits.OrderBy(b => Guid.NewGuid()).ToList();
            }
            // model.Questions = model.Questions.Take(not).ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Quiz()
        {
            var curUser = await _userManager.GetUserAsync(User);
            if (curUser is null)
            {
                return View("Error", "Bạn phải đăng nhập để thực hiện chức năng này");
            }
            ViewBag.score = curUser.LastScore;
            StreamReader reader = new StreamReader(Configuration["questlist"]);
            string contents = reader.ReadToEnd();
            var questions = JsonConvert.DeserializeObject<List<Question>>(contents);
            if (questions is null)
            {
                return View("Error", "Hệ thống không thể tải câu hỏi, vui lòng thử lại.");
            }
            List<Question> new_questions = new List<Question>();
            int count = 1;
            foreach (var question in questions)
            {
                List<Bait> baits = new List<Bait>();
                foreach (var item in question.Baits)
                {
                    baits.Add(item);
                }
                baits.Add(new Bait { Content = question.Answer });
                var shufflebaits = baits.OrderBy(a => Guid.NewGuid()).ToList();
                Question new_question = new Question
                {
                    Content = question.Content,
                    Baits = shufflebaits,
                    Answer = question.Answer,
                    Number = count
                };
                new_questions.Add(new_question);
                count++;
            }
            if (new_questions is null)
            {
                return View("Error", "Hệ thống không thể tải câu hỏi, vui lòng thử lại.");
            }
            var shuffled_questions = new_questions.OrderBy(a => Guid.NewGuid());
            return View(shuffled_questions);
        }

        [HttpPost]
        public async Task<IActionResult> Quiz([FromBody]List<AnswerList> answer_list)
        {
            if (answer_list is null)
            {
                return NotFound("can't read the answers");
            }
            var test = _context.Tests.FirstOrDefault(t => t.Name == answer_list[0].testname);
            var result = new Result { Test = test, Answer = new List<Answer>() };
            foreach (var anwser in answer_list)
            {
                var question = await _context.Question.FirstOrDefaultAsync(q => q.Number == anwser.question_number && q.TestId == test.Id);
                var tmp_answer = new Answer { Answered = anwser.answer, IsNotCorrect = anwser.isnotcorrect, Question = question };
                _context.Answer.Add(tmp_answer);
                result.Answer.Add(tmp_answer);
            }
            var curUser = await _userManager.GetUserAsync(User);
            result.SaleId = curUser.Id;
            if (curUser is null)
            {
                return View("Error", "Bạn phải đăng nhập để thực hiện chức năng này");
            }
            _context.Result.Add(result);
            await _context.SaveChangesAsync();
            //
            //if (curUser is null)
            //{
            //    return View("Error", "Bạn phải đăng nhập để thực hiện chức năng này");
            //}
            return Json(answer_list);
        }

        [HttpGet]
        public async Task<IActionResult> Result(string testname)
        {
            string[] testnames = testname.Split("_");
            string newtestname = string.Join(" ", testnames);
            var curUser = await _userManager.GetUserAsync(User);
            if (curUser is null)
            {
                return View("Error", "Bạn phải đăng nhập để thực hiện chức năng này");
            }
            var tests = await _context.Tests.Include(t => t.Questions).ThenInclude(q => q.Answers).Include(t => t.Questions).ThenInclude(q => q.Baits).ToListAsync();
            if (tests is null)
            {
                return View("Error", "Không tìm thấy kết quả nào.");
            }
            var test = tests.FirstOrDefault(t => t.Name == newtestname);
            if (test is null)
            {
                return View("Error", $"Không tìm thấy bài kiểm tra nào có tên {newtestname} trong dữ liệu");
            }
            var results = await _context.Result.Include(r => r.Answer).ThenInclude(a => a.Question).ToListAsync();
            if (results is null)
            {
                return View("Error", $"Không tìm thấy đáp án nào cho bài kiểm tra {newtestname} trong dữ liệu");
            }
            var answered = results.LastOrDefault(r => r.TestId == test.Id && r.SaleId == curUser.Id);
            if (answered is null)
            {
                return View("Error", $"Không tìm thấy đáp án nào cho bài kiểm tra {newtestname} trong dữ liệu");
            }
            answered.Answer = answered.Answer.OrderBy(a => a.Question.Number).ToList();
            int isnotincorrect = 0;
            foreach (var item in answered.Answer)
            {
                if (!!!item.IsNotCorrect)
                {
                    isnotincorrect += 1;
                }
            }
            ViewBag.score = isnotincorrect.ToString() + "/" + answered.Answer.Count.ToString();
            return View(answered);
        }

        public async Task<IActionResult> Requests()
        {
            //var curUser = await _userManager.GetUserAsync(User);
            //var authorized = await IsAuthorized(curUser, "Contracts", "Create");
            //TempData["StatusMessage"] = TempData["StatusMessage"];
            //if (!authorized)
            //{
            //    return View("AccessDenied");
            //}
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Read");
            TempData["StatusMessage"] = TempData["StatusMessage"];
            if (!authorized)
            {
                return View("AccessDenied");
            }
            var requests = await _context.Requests.Where(r => r.Subject == "Loan" && r.OwnerId == curUser.Id).ToListAsync();
            if (requests == null)
            {
                return NotFound("Can't find any requests");
            }

            foreach (Request request in requests)
            {
                if (request.OwnerId != null)
                {
                    request.Owner = await _context.sale.FirstAsync(s => s.Id == request.OwnerId);
                }
                _context.Update(request);
            }
            return View(requests);
        }

        public async Task<IActionResult> RequestDetails(Guid? id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound("Can't find request with id " + Convert.ToString(id));
            }
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Read");
            TempData["StatusMessage"] = TempData["StatusMessage"];
            if (!authorized)
            {
                TempData["StatusMessage"] = "Bạn không có quyền thực hiện tác vụ này!";
                return View("AccessDenied");
            }
            var owner = await _context.sale.FindAsync(request.OwnerId);
            ViewBag.Owner = owner.Name;
            return View(request);
        }

        public async Task<IActionResult> ConfirmRequest(Guid? id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                TempData["StatusMessage"] = "Không thể xác nhận yêu cầu!";
                return Json("");
            }
            if (request.LoanStatus == LoanStatus.Completed || request.LoanStatus == LoanStatus.Contacting || request.LoanStatus == LoanStatus.Canceled)
            {
                TempData["StatusMessage"] = "Không thể xác nhận yêu cầu!";
                return Json("");
            }
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Update");
            TempData["StatusMessage"] = TempData["StatusMessage"];
            if (!authorized)
            {
                TempData["StatusMessage"] = "Bạn không có quyền thực hiện tác vụ này!";
                return View("AccessDenied");
            }
            request.LoanStatus = LoanStatus.Contacting;
            _context.Update(request);
            await _context.SaveChangesAsync();
            TempData["StatusMessage"] = "Xác nhận yêu cầu thành công";
            return Json("");
        }

        public async Task<IActionResult> CompleteRequest(Guid? id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                TempData["StatusMessage"] = "Không thể hoàn tất yêu cầu!";
                return NotFound("Can't find request with id " + Convert.ToString(id));
            }
            if (request.LoanStatus == LoanStatus.Completed || request.LoanStatus == LoanStatus.Canceled || request.LoanStatus == LoanStatus.Processing)
            {
                TempData["StatusMessage"] = "Không thể hoàn tất yêu cầu!";
                return NotFound("Can't find request with id " + Convert.ToString(id));
            }
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Update");
            TempData["StatusMessage"] = TempData["StatusMessage"];
            if (!authorized)
            {
                TempData["StatusMessage"] = "Bạn không có quyền thực hiện tác vụ này!";
                return View("AccessDenied");
            }
            request.LoanStatus = LoanStatus.Completed;
            request.CompleteTime = DateTime.Now;
            _context.Update(request);
            await _context.SaveChangesAsync();
            TempData["StatusMessage"] = "Yêu cầu hoàn tất";
            return Json("");
        }

        public async Task<IActionResult> CancelRequest(Guid? id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                TempData["StatusMessage"] = "Không thể hủy yêu cầu!";
                return NotFound("Can't find request with id " + Convert.ToString(id));
            }
            if (request.LoanStatus == LoanStatus.Completed || request.LoanStatus == LoanStatus.Canceled)
            {
                TempData["StatusMessage"] = "Không thể hủy yêu cầu!";
                return NotFound("Can't find request with id " + Convert.ToString(id));
            }
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Update");
            TempData["StatusMessage"] = TempData["StatusMessage"];
            if (!authorized)
            {
                TempData["StatusMessage"] = "Bạn không có quyền thực hiện tác vụ này!";
                return View("AccessDenied");
            }
            request.LoanStatus = LoanStatus.Canceled;
            _context.Update(request);
            await _context.SaveChangesAsync();
            TempData["StatusMessage"] = "Yêu cầu đã bị hủy";
            return Json("");
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

        public async Task<IActionResult> Template(Guid? Id)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Requests", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            var meeting = await _context.appoinment.FindAsync(Id);
            if (meeting == null || meeting.Confirm == false || meeting.IsActive == false || meeting.PlanId == null)
            {
                return NotFound();
            }
            var plan = await _context.Plans.FindAsync(meeting.PlanId);
            if (plan == null)
            {
                return NotFound();
            }
            meeting.Plan = plan;
            _context.Update(meeting);
            await _context.SaveChangesAsync();
            return View(meeting);
        }

        [HttpPost]
        public new async Task<IActionResult> Request([Bind("Subject", "Contents", "RequestName", "Customer", "PhoneNumber", "Nationality", "ContractNumber", "DOB", "Email", "MaritalStatus", "Purpose", "Product", "Note", "LoanStatus")] Request request)
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
            request.SubmitTime = DateTime.Now;
            if (request.Subject == "Loan")
            {
                var meetings = await _context.appoinment.Where(m => m.Contract == request.ContractNumber && m.Customer == request.Customer && m.IsActive == true && m.Confirm == true).ToListAsync();
                if (meetings.Count == 1)
                {
                    request.Appoinment = meetings[0];
                }
                request.LoanStatus = LoanStatus.Processing;

            }
            if (!ModelState.IsValid)
            {
                TempData["StatusMessage"] = "Request submission failed!";
                return View();
            }
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            //string contents = "Bạn nhận được một yêu cầu từ " + curUser.Name + " vào lúc " + DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy");
            //SendMail(request.Subject, new MailboxAddress("Huong Ngo", "huong.ngo@annhome.vn"), contents);
            TempData["StatusMessage"] = "Yêu cầu của bạn đã được ghi nhận.\nChúng tôi sẽ giải quyết trong thời gian sớm nhất có thể.";
            return RedirectToPage("/Request");
        }

        public async Task<IActionResult> GetCustomers()
        {
            var curUser = await _userManager.GetUserAsync(User);
            if (curUser == null)
            {
                return NotFound("You haven't logged in");
            }
            var customers = await _context.appoinment.Where(a => a.Sale == curUser && a.Confirm == true && a.IsActive == true).ToListAsync();
            List<string> data = new List<string>();
            foreach (Appoinment customer in customers)
            {
                data.Add(customer.Customer);
            }
            return new JsonResult(data);
        }

        public async Task<IActionResult> GetContracts(string customer_name)
        {
            var curUser = await _userManager.GetUserAsync(User);
            if (curUser == null)
            {
                return NotFound("You haven't logged in");
            }
            var customers = await _context.appoinment.Where(a => a.Sale == curUser && a.Confirm == true && a.IsActive == true && a.Customer == customer_name).ToListAsync();
            List<int> data = new List<int>();
            foreach (Appoinment customer in customers)
            {
                data.Add(customer.Contract);
            }
            return new JsonResult(data);
        }

        public async Task<IActionResult> GetInfo(string customer_name, int contract)
        {
            var curUser = await _userManager.GetUserAsync(User);
            if (curUser == null)
            {
                return NotFound("You haven't logged in");
            }
            string[] tmp = customer_name.Split("_");
            string new_name = String.Join(" ", tmp);
            var app = await _context.appoinment.FirstAsync(a => a.Sale == curUser && a.Confirm == true && a.IsActive == true && a.Customer == new_name && a.Contract == contract);
            Customer customer = new Customer();
            customer.Name = app.Customer;
            customer.Nationality = app.IsForeigner != false ? "Others" : "VietNam";
            customer.PhoneNumber = app.Phone;
            customer.Email = app.Email;
            customer.Purpose = app.Purpose;
            string product = "";
            if (app.NCH1 + app.NCH2 + app.NCH21 + app.NCH3 > 0)
            {
                product += Convert.ToString(app.NCH1 + app.NCH2 + app.NCH21 + app.NCH3) + " Căn hộ ";
            }
            if (app.NSH + app.NSH1 > 0)
            {
                product += Convert.ToString(app.NSH + app.NSH1) + " Biệt thự ";
            }
            if (app.NSHH > 0)
            {
                product += Convert.ToString(app.NSHH) + " Shophouse (NPTM) ";
            }
            if (app.NS > 0)
            {
                product += Convert.ToString(app.NS) + " Shop (Kios) ";
            }
            if (app.NMS > 0)
            {
                product += Convert.ToString(app.NMS) + " Dinh thự ";
            }
            customer.Products = product;
            return new JsonResult(customer);
        }

        public IActionResult ChangeRequest(string type)
        {
            if (type == "Withdraw")
            {
                return PartialView("WithdrawForm");
            }
            else if (type == "Reserve")
            {
                return PartialView("Reserve");
            }
            else if (type == "Loan")
            {
                return PartialView("Loan");
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

        public async Task<IActionResult> AddDOB(Guid? id)
        {
            var curUser = await _userManager.GetUserAsync(User);
            var authorized = await IsAuthorized(curUser, "Contracts", "Read");
            if (!authorized)
            {
                return View("AccessDenied");
            }
            if (id != null)
            {
                return RedirectToAction("AddDOB", "Appoinments", new { id });
            }
            return View("Error");
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
                meetings = await _context.appoinment.Where(m => m.IsActive == true && m.Confirm == true && m.cTime.Substring(0, 8).Contains(DateTime.Now.ToString("ddMMyyyy"))).ToListAsync();
            }
            else if (id == 1)
            {
                meetings = await _context.appoinment.Where(m => m.Confirm == true && m.IsActive == true && DatesAreInTheSameWeek(DateTime.Now.Date, DateTime.ParseExact(m.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF", null))).ToListAsync();
            }
            else if (id == 2)
            {
                meetings = await _context.appoinment.Where(m => m.IsActive == true && m.Confirm == true && m.cTime.Substring(2, 6).Contains(DateTime.Now.ToString("MMyyyy"))).ToListAsync();
            }
            else if (id == 3)
            {
                meetings = await _context.appoinment.Where(m => m.Confirm == true && m.IsActive == true && m.cTime.Substring(4, 4).Contains(DateTime.Now.ToString("yyyy"))).ToListAsync();
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