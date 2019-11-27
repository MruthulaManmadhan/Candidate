using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate.Models
{
    public class ExamMark
    {
        public int StudentID{get;set;}
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public int Malayalam { get; set; }
        public int English { get; set; }
        public int Hindi { get; set; }
        public int Mathematics { get; set; }
        public int Science { get; set; }
        public int SocialScience { get; set; }
        public int Total { get; set; }
        public int Percentage { get; set; }
        public string Grade { get; set; }
        public void Calculate()
        {
            Total = Malayalam + English + Hindi + Mathematics + Science + SocialScience;
            Percentage = Total / 6;
            if(Malayalam<40||English<40||Hindi<40||Mathematics<40||Science<40||SocialScience<40)
            {
                Grade = "Failed";
            }
            else if(Percentage>=75)
            {
                Grade = "A";
            }
            else if (Percentage >= 60)
            {
                Grade = "B";
            }
            else if (Percentage >= 50)
            {
                Grade = "C";
            }
            else
            {
                Grade = "D";
            }
        }

    }
}
