using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BookingForm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingForm.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<Sale> _userManager;
        private readonly SignInManager<Sale> _signInManager;
        private readonly IEmailSender _emailSender;

        public IndexModel(
            UserManager<Sale> userManager,
            SignInManager<Sale> signInManager, IEmailSender emailSender
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }

            [Display(Name = "Full name")]
            public string Name { get; set; }

            [Display(Name = "Display name")]
            public string Display { get; set; }

            [Display(Name = "Gender")]
            public string Gender { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Birthday")]
            public string DOB { get; set; }

            [Display(Name = "Photo")]
            public byte[] Portrait { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var portrait = user.Portrait;
            var address = user.Address;
            var gender = user.Gender;
            var dOB = user.DOB;
            var display = user.Display;
            var name = user.Name;

            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                Gender = gender,
                DOB = dOB,
                Portrait = portrait,
                Display = display,
                Name = name
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile portrait)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            user.Address = user.Address == Input.Address ? user.Address : Input.Address;
            user.Gender = user.Gender == Input.Gender ? user.Gender : Input.Gender;
            user.DOB = user.DOB == Input.DOB ? user.DOB : Input.DOB;
            user.Display = user.Display == Input.Display ? user.Display : Input.Display;
            user.Name = user.Name == Input.Name ? user.Name : Input.Name;
            
            var filePath = Path.GetTempFileName();
            if (portrait != null)
            {
                long size = portrait.Length;
                if (size > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await portrait.CopyToAsync(stream);
                    }
                    using (var memoryStream = new MemoryStream())
                    {
                        await portrait.CopyToAsync(memoryStream);
                        user.Portrait = memoryStream.ToArray();
                    }
                }
            }

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<FileResult> Photo()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.Portrait != null)
            {
                return File(user.Portrait, "img/png");
            }
            var image = System.IO.File.OpenRead("~image//Profile//photo.jpg");  
            return File(image, "image/jpg");
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
