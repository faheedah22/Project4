using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Controllers
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
    }
}
