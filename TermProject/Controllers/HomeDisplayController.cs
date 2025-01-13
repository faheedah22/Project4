using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TermProject.Models;



namespace TermProject.Controllers
{
    public class HomeDisplayController : Controller
    {

        [HttpGet]
        public IActionResult AllHomes()
        {
            APICall apiCall = new APICall();
            // string data = apiCall.GetApiGet("api/HomeDisplay/HomeDisplay");
            string data = apiCall.GetApiGet("https://cis-iis2.temple.edu/fall2024/cis3342_tun39913/WebAPI/api/HomeDisplay/HomeDisplay");
            List<HomeInfo> homeInfo = JsonConvert.DeserializeObject<List<HomeInfo>>(data);

            LoadSearchFilter();
            
            return View(homeInfo);
        }

        [HttpPost]
        public IActionResult Filter(string state, double minPrice, double maxPrice, string propType, string minBaths, string minBeds)
        {
            APICall apiCall = new APICall();
            //  string data = apiCall.GetApiGet("api/HomeDisplay/HomeDisplay");
            string data = apiCall.GetApiGet("https://cis-iis2.temple.edu/fall2024/cis3342_tun39913/WebAPI/api/HomeDisplay/HomeDisplay");
            List<HomeInfo> homeInfo = JsonConvert.DeserializeObject<List<HomeInfo>>(data);
            
            //double dMinPrice = double.Parse(minPrice);
            //double dMaxPrice = double.Parse(maxPrice);

            LoadSearchFilter();
            homeInfo = HomeFilter.State(homeInfo, state);
            homeInfo = HomeFilter.PropertyType(homeInfo, propType);
            homeInfo = HomeFilter.PriceRange(homeInfo, minPrice, maxPrice);
            homeInfo = HomeFilter.MinBathsBeds(homeInfo, minBaths, minBeds);

            return View("AllHomes", homeInfo);
        }

        [HttpGet]
        public IActionResult HomeDetail(int homeID)
        {
            APICall apiCall = new APICall();
            // string data = apiCall.GetApiGet("api/HomeDisplay/HomeDetail?homeID=" + homeID);
            string data = apiCall.GetApiGet("https://cis-iis2.temple.edu/fall2024/cis3342_tun39913/WebAPI/api/HomeDisplay/HomeDetail?homeID=" + homeID);
            HomeInfo homeInfo = JsonConvert.DeserializeObject<HomeInfo>(data);

            // Check if homeInfo is null to handle errors
            if (homeInfo == null)
            {
                string errorMsg = "Home details not found.";
                
            }

            HttpContext.Session.SetInt32("HomeID", homeInfo.HomeID);
            

            return View(homeInfo);
        }

        //public IActionResult ViewDetail(int homeID)
        //{
        //    string theID = HttpContext.Session.GetString("HomeID");
        //    homeID = int.Parse(theID);
        //    //HttpContext.Session.SetString("HomeID", homeID.ToString());
        //    return View("HomeDetail", "HomeDisplay");
        
        //}


        private void LoadSearchFilter()
        {
            List<string> states = new List<string>();
            foreach (WordBankHomeChoices.USState state in Enum.GetValues(typeof(WordBankHomeChoices.USState)))
            {
                states.Add(state.ToString());
            }
            ViewBag.State = states;

            List<string> propTypes = new List<string>();
            foreach (WordBankHomeChoices.PropertyType type in Enum.GetValues(typeof(WordBankHomeChoices.PropertyType)))
            {
                propTypes.Add(type.ToString());
            }
            ViewBag.PropType = propTypes;

            WordBankSearchFilter filterOptions = new WordBankSearchFilter();
            ViewBag.MinPrice = filterOptions.GenMinMaxPrice();

            ViewBag.MaxPrice = filterOptions.GenMinMaxPrice();

            ViewBag.MinBath = filterOptions.GenNumBathsBeds();

            ViewBag.MinBed = filterOptions.GenNumBathsBeds();
        }
    }
}
