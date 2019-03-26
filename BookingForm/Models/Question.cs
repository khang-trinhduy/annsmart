using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingForm.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
        public List<string> Baits { get; set; }
        public int Number { get; set; }
    }
}
