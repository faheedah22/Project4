using Microsoft.AspNetCore.Mvc;
using TermProject.Models;
using Newtonsoft.Json;

namespace TermProject.Controllers
{
    public class ShowingServiceController : Controller
    {
        public IActionResult ShowingRequestPage(int homeID)
        {
            homeID = (int)HttpContext.Session.GetInt32("HomeID");

            return View("Tour");
        }


        //CustomerShowingRequest
        // HttpContext.Session.SetInt32("HomeID", homeInfo.HomeID); - got it from setting the session in HomeDisplayController
        
        [HttpPost]
        public IActionResult Tour(CustomerShowingRequest showing)
        {
            if (showing != null && ModelState.IsValid)
            {

                int theHomeID = (int)HttpContext.Session.GetInt32("HomeID");

                ViewBag.HomeID = theHomeID; //just might need this


                APICall apiCall = new APICall();

                showing.HomeID = theHomeID;

                // string data = apiCall.GetApiPOST("api/Showing/BookShowing?homeID=" + theHomeID, showing);
                string data = apiCall.GetApiPOST("https://cis-iis2.temple.edu/fall2024/cis3342_tun39913/WebAPI/api/Showing/BookShowing?homeID=" + theHomeID, showing);
                bool cust = JsonConvert.DeserializeObject<Boolean>(data);
               
            }
            return View("Tour");
        }


        //agent views
        public IActionResult AgentShowings()
        {
            TourDB tourDB = new TourDB();
            int agentID = (int)HttpContext.Session.GetInt32("AgentID");

          
            List<AgentTourView> agentTourView = new List<AgentTourView>();

           agentTourView = tourDB.AgentView(agentID);

            return View("ShowingsList", agentTourView);
        }

    }
}
