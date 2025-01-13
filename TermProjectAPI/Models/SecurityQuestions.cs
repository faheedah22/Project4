using System.ComponentModel.DataAnnotations;

namespace HomeAPI.Controllers
{
    public class SecurityQuestions
    {
       // private int agentID;
        public enum PartOne 
        {
            [Display(Name ="What is your mother's maiden name?")]
            question1 = 1,

            [Display(Name = "In what city were you born?")]
            question2 = 2,

            [Display(Name = "WHat Elementary school did you attend?")]
            question3 = 3,


            [Display(Name = "Where is your dream vacation destination?")]
            question4 = 4,

            [Display(Name = "Favorite car brand?")]
            question5 = 5,

            [Display(Name = "What was your favorite high school subject?")]
            question6 = 6,

            [Display(Name = "What is your favorite album?")]
            question7 = 7,

            [Display(Name = "What is your favorite season of the year?")]
            question8 = 8,

            [Display(Name = "What is your favorite movie?")]
            question9 = 9
        }
    }
}
