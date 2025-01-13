using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class AgentTourView
    {

        private HomeInfo home;
        private CustomerShowingRequest showing;
        private AgentInfo agent;


        public HomeInfo Home
        {
            get { return home; }
            set { home = value; }
        }

        public CustomerShowingRequest Showing
        {
            get { return showing; }
            set { showing = value; }
        }

        public AgentInfo Agent
        {
            get { return agent; }
            set { agent = value; }
        }

        public AgentTourView()
        { 
            this.agent = new AgentInfo();
            this.home = new HomeInfo();
            this.showing = new CustomerShowingRequest();

        }
    }
}
