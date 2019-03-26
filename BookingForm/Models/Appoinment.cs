using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingForm.Models
{
    public class Appoinment : Appointment
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Họ & tên*", Prompt = "Nguyễn Văn Minh")]
        public string Customer { get; set; }
        [Required]
        [Display(Name = "Giới tính*")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Nơi ở hiện tại*")]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Số điện thoại*", Prompt = "095444360")]
        //[RegularExpression(@"^((\(?([0-9]{3})\)?)|(\(?([0-9]{4})\)?)|(\(?([0-9]{2})\)?))[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Sai số điện thoại")]
        public string Phone { get; set; }
        //[RegularExpression(@"^([a-z0-9\.\-]+@[a-z\-]+\.[\w]+)$", ErrorMessage = "Email không tồn tại")]
        [Display(Name = "Email", Prompt = "example@mail.com")]
        public string Email { get; set; }
        [Display(Name = "Nghề nghiệp")]
        public string Job { get; set; }
        [Display(Name = "Nơi làm việc")]
        public string WorkPlace { get; set; }

        //[Required(ErrorMessage = "Số CMND không thể bỏ trống")]
        [Display(Name = "Số CMND/Căn cước/Hộ chiếu*")]
        //[RegularExpression(@"^(([0-9]{9})|([0-9]{12}))$", ErrorMessage = "Sai số CMND")]
        public string Cmnd { get; set; }
        [Display(Name = "Ngày cấp*")]
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        [Display(Name = "Nơi cấp*")]
        public string Place { get; set; }
        [Display(Name = "Số tiền giữ chỗ đặt mua*")]
        public double Money { get; set; }
        [Required]
        [Display(Name = "Mục đích*")]
        public string Purpose { get; set; }
        [Display(Name = "Yêu cầu cụ thể")]
        public string Requires { get; set; }
        [Display(Name = "Số tiền cần vay (nếu có)")]
        public double Price { get; set; }
        [Display(Name = "Đặc điểm KH")]
        public string Details { get; set; }
        [Required]
        [Display(Name = "Hình thức thanh toán*")]
        public string DType { get; set; }
        [Required]
        [Display(Name = "Tiền mặt*")]
        public double Cash { get; set; }
        [Required]
        [Display(Name = "SL Căn 1pn")]
        public int NCH1 { get; set; }
        [Required]
        [Display(Name = "SL Căn 2pn")]
        public int NCH2 { get; set; }
        [Required]
        [Display(Name = "SL Căn 2pn")]
        public int NCH21 { get; set; }
        [Required]
        [Display(Name = "SL Căn 3pn")]
        public int NCH3 { get; set; }
        [Required]
        [Display(Name = "SL dinh thự")]
        public int NMS { get; set; }
        [Required]
        [Display(Name = "SL BTDL")]
        public int NSH { get; set; }
        [Required]
        [Display(Name = "SL BTSL")]
        public int NSH1 { get; set; }
        [Required]
        [Display(Name = "SL shophouse*")]
        public int NSHH { get; set; }
        [Required]
        [Display(Name = "SL shop thương mại*")]
        public int NS { get; set; }
        [Required]
        [Display(Name = "Hộ khẩu thường trú*")]
        public string HKTT { get; set; }
        //[Required]
        //[RegularExpression(@"^([a-z0-9\.\-]+@[a-z\-]+\.[\w]+)$", ErrorMessage = "Email không tồn tại")]
        [Required]
        [Display(Name = "Confirm Password*")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "Số hợp đồng")]
        public int Contract { get; set; }
        //[Display(Name = "Số ưu tiên")]
        //public int Priority { get; set; }
        [Display(Name = "Xác nhận chuyển tiền")]
        public bool Confirm { get; set; }
        [Display(Name = "Thời gian ký hợp đồng")]
        public string cTime { get; set; }
        [Display(Name = "Thời gian xác nhận chuyển tiền")]
        public string dTime { get; set; }
        [Display(Name = "Số thứ tự ưu tiên Căn hộ")]
        public int ph { get; set; }
        [Display(Name = "Số thứ tự ưu tiên Biệt thự ĐL")]
        public int psh { get; set; }
        [Display(Name = "Số thứ tự ưu tiên Biệt thự SL")]
        public int psh1 { get; set; }
        [Display(Name = "Số thứ tự ưu tiên Shophouse")]
        public int pshh { get; set; }
        [Display(Name = "Số thứ tự ưu tiên Biệt thự")]
        public int pms { get; set; }
        [Display(Name = "Số thứ tự ưu tiên kios")]
        public int pns { get; set; }
        [Display(Name = "Thông tin sale")]
        public string SaleDetails { get; set; }
        [Display(Name = "Thanh toán")]
        public string Deposit { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        [Display(Name = "Số chính thức")]
        public bool Official { get; set; }
        public bool New { get; set; }
        public bool OldContract { get; set; }                               
        public bool supporter { get; set; }
        public bool IsActive { get; set; }
        public virtual Sale Sale { get; set; }
        public string SEmail { get; set; }
        [DataType(DataType.Date)]
        public DateTime  WDay { get; set; }
        public string WithdrawCode { get; set; }
        public double WMoney { get; set; }
        public string WType { get; set; }
        public string Photo { get; set; }
        public bool IsForeigner { get; set; }
        public Appoinment() { }

        public static implicit operator Appoinment(List<Appoinment> v)
        {
            throw new NotImplementedException();
        }
    }
}
