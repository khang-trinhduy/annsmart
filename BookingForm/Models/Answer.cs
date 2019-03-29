using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingForm.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public string Answered { get; set; }
        public bool IsNotCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
