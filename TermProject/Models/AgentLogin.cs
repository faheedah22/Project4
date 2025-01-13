using System.ComponentModel.DataAnnotations;
namespace TermProject.Models
{
    public class AgentLogin
    {
        private int agentID = 0;
        private string username;
        private string userPassword;


        public int AgentID
        {
            get { return agentID; }
            set { agentID = value; }
        }

        [Required(ErrorMessage = "Username is required")]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [Required(ErrorMessage = "Password is required")]
        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }
    }
}
