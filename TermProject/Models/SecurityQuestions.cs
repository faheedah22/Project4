using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public static class SecurityQuestions
    {
       // private int agentID;
        public static List<string> PartOne()
        {

            List<string> list = new List<string>();

            list.Add("What is your mother's maiden name?");

            list.Add("In what city were you born?");

            list.Add("What Elementary school did you attend?");

            return list;
        }

        public static List<string> PartTwo()
        {

            List<string> list = new List<string>();
            list.Add("Where is your dream vacation destination?");

            list.Add("Favorite car brand?");

            list.Add("What was your favorite high school subject?");
            return list;

        }

        public static List<string> PartThree()
        {

            List<string> list = new List<string>();

            list.Add("What is your favorite album?");

            list.Add("What is your favorite season of the year?");

            list.Add("What is your favorite movie?");
            return list;
        }
    }
}
