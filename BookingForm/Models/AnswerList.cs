using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingForm.Models
{
    public class AnswerList
    {
        public AnswerList(int question_number, string answer, bool isnotcorrect)
        {
            this.question_number = question_number;
            this.answer = answer;
            this.isnotcorrect = isnotcorrect;
        }

        public AnswerList() { }

        public AnswerList(string testname, int question_number, string answer, bool isnotcorrect)
        {
            this.testname = testname;
            this.question_number = question_number;
            this.answer = answer;
            this.isnotcorrect = isnotcorrect;
        }

        public string testname { get; set; }
        public int question_number { get; set; }
        public string answer { get; set; }
        public bool isnotcorrect { get; set; }
    }
}
