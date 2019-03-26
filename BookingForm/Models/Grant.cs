using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingForm.Models
{
    public class Grant
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public string Resource { get; set; } 
        public string Operation { get; set; }
        public string Permission { get; set; }
        //public Guid Role { get; set; }
        public virtual Role Role { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey(name: "UserId")]
        public Sale User { get; set; }
    }
}







