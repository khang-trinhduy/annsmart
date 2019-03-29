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
        public List<Bait> Baits { get; set; }
        public int Number { get; set; }
        public string Explain { get; set; }
        public List<Answer> Answers { get; set; }
        public int TestId { get; set; }
    }

    public class Bait
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
