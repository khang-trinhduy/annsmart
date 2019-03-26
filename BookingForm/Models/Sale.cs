using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingForm.Models
{
    public class Sale:IdentityUser<Guid>
    {
        //public Guid ID { get; set; }
        [Required]
        [Display(Name = "Tên nhân sự")]
        public string Name { get; set; }
        [Display(Name = "Lịch sử gặp khách hàng")]
        public ICollection<Appoinment> Meetings { get; set; }
        [Display(Name = "Thông tin sale")]
        public string Info { get; set; }
        [Display(Name = "Tên hiển thị")]
        public string Display { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public byte[] Portrait { get; set; }
        [Display(Name = "Ngày sinh")]
        public string DOB { get; set; }
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }
        [Display(Name = "Nơi ở hiện tại")]
        public string Address { get; set; }
        public string Members { get; set; }
        public string Type { get; set; }
        public int NOfRequests { get; set; }
        public int NOfFeedbacks { get; set; }
        public int NOfMeetings { get; set; }
        public int LastScore { get; set; }
        public List<Result> Results { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Request> Requests { get; set; }


        public virtual ICollection<UserClaim> Claims { get; set; }
        public virtual ICollection<UserLogin> Logins { get; set; }
        public virtual ICollection<UserToken> Tokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }

    public class Role : IdentityRole<Guid>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }

    public class UserRole : IdentityUserRole<Guid>
    {
        public virtual Sale User { get; set; }
        public virtual Role Role { get; set; }
    }

    public class UserClaim : IdentityUserClaim<Guid>
    {
        public virtual Sale User { get; set; }
    }

    public class UserLogin : IdentityUserLogin<Guid>
    {
        public virtual Sale User { get; set; }
    }

    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual Role Role { get; set; }
    }

    public class UserToken : IdentityUserToken<Guid>
    {
        public virtual Sale User { get; set; }
    }
}
