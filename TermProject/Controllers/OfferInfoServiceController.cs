using Microsoft.AspNetCore.Mvc;
using TermProject.Models;
using Newtonsoft.Json;

namespace TermProject.Controllers
{
    public class OfferInfoServiceController : Controller
    {


        //public IActionResult Offer(int HomeID)
        //{
        //    CustomerOfferInfo offerInfo = new CustomerOfferInfo();
        //   // ViewBag.HomeID = HomeID;

        //    return View(offerInfo);
        //}

        [HttpPost]
        public IActionResult Offer(CustomerOfferInfo offerInfo)
        {
             

            if (offerInfo != null && ModelState.IsValid)
            {
                
                int theHomeID = (int)HttpContext.Session.GetInt32("HomeID");

                ViewBag.HomeID = theHomeID; //just might need this

                APICall apiCall = new APICall();

                offerInfo.HomeID = theHomeID;


                // string data = apiCall.GetApiPOST("api/Offer/CustomerOffer?homeID=" + theHomeID, offerInfo);
                string data = apiCall.GetApiPOST("https://cis-iis2.temple.edu/fall2024/cis3342_tun39913/WebAPI/api/Offer/CustomerOffer?homeID=" + theHomeID, offerInfo);
                bool cust = JsonConvert.DeserializeObject<Boolean>(data);

                return View("AllHome", "HomeDisplay");

            }

            return View("Offer");
        }

        // HttpContext.Session.SetInt32("HomeID", homeInfo.HomeID); - got it from setting the session in HomeDisplayController
        public IActionResult TheOfferForm(int homeID)
        {
            CustomerOfferInfo offerInfo = new CustomerOfferInfo();
            homeID = (int)HttpContext.Session.GetInt32("HomeID");
            offerInfo.HomeID = homeID;

            return View("Offer");
        }


        //agent views
        public IActionResult OfferList()
        {
            return View("OfferList");
        }

       
        public IActionResult AgentOffers()
        {
            OfferDB offerDB = new OfferDB();
            int agentID = (int)(HttpContext.Session.GetInt32("AgentID"));

            List<AgentOffers> offers = new List<AgentOffers>();


            offers = offerDB.AgentOffers(agentID);

            return View("~/Views/OfferInfoService/OffersList.cshtml", offers);
        }


        [HttpPost]
        public IActionResult DeleteOffer(CustomerOfferInfo info)
        {
            
            APICall apiCall = new APICall();
            // string data = apiCall.GetApiDelete("api/Offer/DeleteOffer?offerID=" + info.OfferID);
            string data = apiCall.GetApiPOST("https://cis-iis2.temple.edu/fall2024/cis3342_tun39913/WebAPI/api/Offer/DeleteOffer?offerID=" + info.OfferID, info);
            bool cust = JsonConvert.DeserializeObject<Boolean>(data);
            return View("OfferList");
        }


        //public IActionResult UpdateOffer(CustomerOfferInfo info)
        //{

        //}
    }
}
