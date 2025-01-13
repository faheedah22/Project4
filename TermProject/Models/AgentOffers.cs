using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class AgentOffers
    {
        private HomeInfo home;
        private AgentInfo agent;
        private CustomerOfferInfo customerOffer;

        public AgentInfo Agent
        {
            get { return agent; }
            set { agent = value; }
        }

        public HomeInfo Home
        {
            get { return home; }
            set { home = value; }
        }

        public CustomerOfferInfo CustomerOffer
        {
            get { return customerOffer; }
            set { customerOffer = value; }
        }

        public AgentOffers()
        {
            this.agent = new AgentInfo();
            this.home = new HomeInfo();
            this.customerOffer = new CustomerOfferInfo();
        }
    }
}
