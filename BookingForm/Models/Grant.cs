﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}







