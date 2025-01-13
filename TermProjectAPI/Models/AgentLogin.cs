using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeAPI.Controllers
{
    public class AgentLogin
    {
        private int agentID;
        private string username;
        private string userPassword;

        public int AgentID
        {
            get { return agentID; }
            set { agentID = value; }
        }

        [Required(ErrorMessage = "Provide a username.")]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [Required(ErrorMessage = "Provide a password.")]
        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }
    }
}
