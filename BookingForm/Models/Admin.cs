using System.ComponentModel.DataAnnotations;

namespace BookingForm.Models
{
    public class Admin
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Họ và tên")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-z0-9\.\-]+@[a-z\-]+\.[\w]+)$", ErrorMessage = "Email không tồn tại")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Số điện thoại*", Prompt = "095444360")]
        [RegularExpression(@"^((\(?([0-9]{3})\)?)|(\(?([0-9]{4})\)?)|(\(?([0-9]{2})\)?))[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Sai số điện thoại")]
        public string phone { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
