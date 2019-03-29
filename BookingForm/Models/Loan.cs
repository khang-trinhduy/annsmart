using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingForm.Models
{
    public class Loan
    {
        [Display(Name = "Tên khách hàng")]
        public string Customer { get; set; }
        [Display(Name = "SĐT")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Quốc tịch")]
        public string Nationality { get; set; }
        [Display(Name = "Số HĐ")]
        public int ContractNumber { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime DOB { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Tình trạng hôn nhân")]
        public MaritalStatus MaritalStatus { get; set; }
        [Display(Name = "Mục đích mua")]
        public string Purpose { get; set; }
        [Display(Name = "Sản phẩm")]
        public string Product { get; set; }
        [Display(Name = "Lưu ý")]
        public string Note { get; set; }
        [Display(Name = "Tình trạng yêu cầu")]
        public LoanStatus LoanStatus { get; set; }
        [Display(Name = "Thời gian hoàn tất")]
        public DateTime CompleteTime { get; set; }
        [Display(Name = "Thời gian nhận yêu cầu")]
        public DateTime SubmitTime { get; set; }
        public Guid? ContractId { get; set; }
        [ForeignKey(name: "ContractId")]
        public Appoinment Appoinment { get; set; }
        //public Guid? CustomerId { get; set; }
        //[ForeignKey(name:"CustomerId")]
        //public Customer Customer { get; set; }
    }
    public enum LoanStatus
    {
        Processing = 1,
        Contacting = 2,
        Completed = 3,
        Canceled = 4
    }
    public enum MaritalStatus
    {
        Married = 1,
        Widowed = 2,
        Divorced = 3,
        Single = 4
    }
}
