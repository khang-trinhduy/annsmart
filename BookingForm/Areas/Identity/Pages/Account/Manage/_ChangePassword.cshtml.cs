using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookingForm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BookingForm.Areas.Identity.Pages.Account.Manage
{
    public class _ChangePasswordModel : PageModel    
    {
        private readonly UserManager<Sale> _userManager;
        private readonly SignInManager<Sale> _signInManager;
        private readonly ILogger<_ChangePasswordModel> _logger;
        private readonly BookingFormContext _context;
        public _ChangePasswordModel(
            UserManager<Sale> userManager,
            SignInManager<Sale> signInManager,
            ILogger<_ChangePasswordModel> logger, BookingFormContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public string Username { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            public string Confirm { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            public string New { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirmation password")]
            [Compare("New", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ReNew { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }
            Username = user.Name;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
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

            var result = await _userManager.CheckPasswordAsync(user, Input.Confirm);

            if (result != true)
            {
                StatusMessage = "Error: Verification failed!";
                return Page();
            }

            Sale sale = _context.sale.FirstOrDefault(s => s.Email == Input.Email);

            if (sale == null)
            {
                StatusMessage = "Error: Unable to find user with email: " + Input.Email;
                return Page();
            }

            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(sale);

            IdentityResult passwordChangeResult = await _userManager.ResetPasswordAsync(sale, resetToken, Input.New);

            if (!passwordChangeResult.Succeeded)
            {
                foreach (var error in passwordChangeResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
            //await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("Successful changed password for user: " + Input.Email);
            StatusMessage = "Your action has been saved.";

            return RedirectToPage();
        }
    }
}