using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingForm.Models
{
    public class Sale
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Tên nhân sự")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Số điện thoại")]
        public string phone { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string pass { get; set; }
        [Display(Name = "Lịch sử gặp khách hàng")]
        public ICollection<Appoinment> meetings { get; set; }
        [Display(Name = "Thông tin sale")]
        public string info { get; set; }
        [Display(Name = "Tên hiển thị")]
        public string display { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public byte[] portrait { get; set; }

        [Display(Name = "Ngày sinh")]
        public string birthday { get; set; }
        [Display(Name = "Giới tính")]
        public string gender { get; set; }
        [Display(Name = "Nơi ở hiện tại")]
        public string address { get; set; }

    }
}
