using Microsoft.AspNetCore.Mvc;
using TermProject.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using AspNetCoreGeneratedDocument;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;       //needed for BinaryFormatter
using System.IO;                                            //needed for the MemoryStream


namespace TermProject.Controllers
{
    public class HomeServiceController : Controller
    {
        private readonly HttpClient httpClient;
        // Uri address = new Uri("https://cis-iis2.temple.edu/Fall2024/CIS3342_tun82669/api");
        Uri address = new Uri("https://cis-iis2.temple.edu/Fall2024/CIS3342_tun39913/WebAPI/api");

        public HomeServiceController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri("https://cis-iis2.temple.edu/Fall2024/CIS3342_tun39913/WebAPI/api");
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult EditHome(int homeId)
        {
            LoadHomeOptions();
            HomeInfo home = new HomeInfo();
            var response = httpClient.GetAsync($"https://cis-iis2.temple.edu/Fall2024/CIS3342_tun39913/WebAPI/api/Homes/GetEditHome/{homeId}").Result;
            if (response.IsSuccessStatusCode)
            {
                string homeData = response.Content.ReadAsStringAsync().Result;
                home = System.Text.Json.JsonSerializer.Deserialize<HomeInfo>(homeData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(home);
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditHome(HomeInfo home)
        {
            LoadHomeOptions();

            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                return View(home);
            }

            if (home != null)
            {
                try
                {                   
                    //string apiRoute = "https://cis-iis2.temple.edu/Fall2024/CIS3342_tun8266/WebAPI/api/Homes/EditHome";
                    
                    var jsonContent = JsonConvert.SerializeObject(home);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync("https://cis-iis2.temple.edu/Fall2024/CIS3342_tun39913/WebAPI/api/Homes/EditHome", content);

                    if (response.IsSuccessStatusCode)
                    {
                        
                        ViewBag.SuccessMessage = "Home details updated successfully!";
                        return View(home);
                    }
                    else
                    {                       
                        var responseContent = await response.Content.ReadAsStringAsync();
                        ViewBag.ErrorMessage = $"Failed to update home details. API Error: {response.StatusCode}. Response: {responseContent}";
                    }
                }
                catch (HttpRequestException ex)
                {                  
                    ViewBag.ErrorMessage = $"Failed to update home details. API Error: {ex.Message}";
                }
                catch (Exception ex)
                {                  
                    ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                }
            }
           
            if (string.IsNullOrEmpty(ViewBag.ErrorMessage))
            {
                ViewBag.ErrorMessage = "Invalid input or failed API call. Please try again.";
            }
            return View(home);
        }




        [HttpGet]
        public async Task<IActionResult> GetAgentHomes()
        {
          
            try
            {               
                string apiUrl = $"https://cis-iis2.temple.edu/Fall2024/CIS3342_tun39913/WebAPI/api/Homes/GetAgentHomes?agentId={(int)HttpContext.Session.GetInt32("AgentID")}";
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the API response to a list of HomeInfo
                    var homesJson = await response.Content.ReadAsStringAsync();
                    List<HomeInfo> homes = System.Text.Json.JsonSerializer.Deserialize<List<HomeInfo>>(homesJson, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    int agentID = (int)HttpContext.Session.GetInt32("AgentID");
                    ViewBag.AgentId = agentID;
                    return View(homes);
                }
                else
                {
                    // Log error details
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {response.StatusCode}, Details: {errorContent}");
                    return View("Error");
                }
            }

            catch (Exception ex)
            {
                // Log exception details
                Console.WriteLine($"Exception: {ex.Message}");
                return View("Error");
            }
        }

        //Allows 'AddHome.cshtml to be strongly typed and for inputs on view to function
        [HttpGet]
        public IActionResult AddHome(int agentId)
        {
            HomeInfo home = new HomeInfo();

            ViewBag.AgentId = (int)HttpContext.Session.GetInt32("AgentID"); ;

            LoadHomeOptions();

            return View(home);
        }


        [HttpPost]
        public async Task<IActionResult> AddHome(HomeInfo home)
        {
            LoadHomeOptions();

            if (home != null && ModelState.IsValid)
            {
                var jsonHome = System.Text.Json.JsonSerializer.Serialize(home);
                var content = new StringContent(jsonHome, Encoding.UTF8, "application/json");

                try
                {
                    var response = await httpClient.PostAsync($"https://cis-iis2.temple.edu/Fall2024/CIS3342_tun39913/WebAPI/api/Homes/AddHome", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync(); 
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        var newHome = System.Text.Json.JsonSerializer.Deserialize<HomeInfo>(responseContent, options);

                        if (newHome != null)
                        {
                            ViewBag.NewHome = newHome;
                            ViewBag.HomeId = newHome.HomeID;
                            HttpContext.Session.SetInt32("AddHomeId", newHome.HomeID);
                            LoadRoomOptions();
                            return View("AddRoom");
                            //return RedirectToAction("AddRoom", new { homeId = newHome.HomeID });
                        }
                        return View("Index");
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error Response: {errorContent}");
                        Console.WriteLine($"Status Code: {response.StatusCode}");
                        ViewBag.ErrorMessage = $"Error occurred while adding home: {errorContent}";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                }
                return View(home);
            }
            return View(home);
        }


        /*
        [HttpPost]
        public IActionResult AddHome(HomeInfo home)
        {
            // Reload dropdown options for redisplaying the form on validation failure
       
            LoadHomeOptions();

            HomeDB db = new HomeDB();
            
            db.AddHomeInfo(home);

            home.HomeID = db.GetHomeIDForAddHome(home);
            LoadRoomOptions();
            ViewBag.HomeId=home.HomeID;
            RoomInfo newRoom = new RoomInfo();
            return View("AddRoom", newRoom);
        }
        */
        [HttpGet]
        public IActionResult AddRoom()
        {
            RoomInfo room = new RoomInfo();
            LoadRoomOptions();
            ViewBag.HomeId = (int)HttpContext.Session.GetInt32("AddHomeId");
            
            return View(room); // This will load the AddRoom Razor view.
        }

        [HttpPost]
        public IActionResult AddRoom(RoomInfo room)
        {
            LoadRoomOptions();
            if(room != null)
            {
                HomeDB db = new HomeDB();
                db.AddRoomInfo(room);
                
                ViewBag.HomeId = room.Id;
                ModelState.Clear();
                RoomInfo newRoom = new RoomInfo();
                
                return View(newRoom);
            }

            return View(room);
        }

        [HttpGet]
        public IActionResult AddImages()
        {
            HomeImages homeImages = new HomeImages();
            ViewBag.HomeId = (int)HttpContext.Session.GetInt32("AddHomeId");
            return View(homeImages);
        }

        [HttpPost]
        public IActionResult AddImages(HomeImages img)
        {
            
            if (img != null) 
            {
                HomeDB db = new HomeDB();

                MemoryStream memStream = new MemoryStream();
                Byte[] byteArray;
                System.Text.Json.JsonSerializer.Serialize(memStream, img);
                byteArray = memStream.ToArray();

                db.AddImage(img, byteArray);

                ViewBag.HomeId = img.HomeId;
                ModelState.Clear();
                HomeImages newImg = new HomeImages();
                return View(newImg);
            }
            return View(img);
        }

        [HttpPost]
        public IActionResult DeleteHome(HomeInfo home)
        {
            try
            {
                var response = httpClient.DeleteAsync($"https://cis-iis2.temple.edu/Fall2024/CIS3342_tun39913/WebAPI/api/Homes/DeleteHome/{home.HomeID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Home Deleted";
                    return RedirectToAction("GetAgentHomes", new { agentId = home.AgentID });
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return RedirectToAction("Index");
        }

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

        private void LoadHomeOptions()
        {
            List<string> amenities = new List<string>();
            foreach (WordBankHomeChoices.Amenities amenity in Enum.GetValues(typeof(WordBankHomeChoices.Amenities)))
            {
                amenities.Add(amenity.ToString());
            }
            ViewBag.Amenities = amenities;

            List<string> statuses = new List<string>();
            foreach (WordBankHomeChoices.Status status in Enum.GetValues(typeof(WordBankHomeChoices.Status)))
            {
                statuses.Add(status.ToString());
            }
            ViewBag.Statuses = statuses;

            List<string> propTypes = new List<string>();
            foreach (WordBankHomeChoices.PropertyType type in Enum.GetValues(typeof(WordBankHomeChoices.PropertyType)))
            {
                propTypes.Add(type.ToString());
            }
            ViewBag.PropTypes = propTypes;

            List<string> cooling = new List<string>();
            foreach (WordBankHomeChoices.Cooling type in Enum.GetValues(typeof(WordBankHomeChoices.Cooling)))
            {
                cooling.Add(type.ToString());
            }
            ViewBag.Cooling = cooling;

            List<string> heating = new List<string>();
            foreach (WordBankHomeChoices.Heating type in Enum.GetValues(typeof(WordBankHomeChoices.Heating)))
            {
                heating.Add(type.ToString());
            }
            ViewBag.Heating = heating;

            List<string> water = new List<string>();
            foreach (WordBankHomeChoices.Water type in Enum.GetValues(typeof(WordBankHomeChoices.Water)))
            {
                water.Add(type.ToString());
            }
            ViewBag.Water = water;

            List<string> waste = new List<string>();
            foreach (WordBankHomeChoices.Waste type in Enum.GetValues(typeof(WordBankHomeChoices.Waste)))
            {
                waste.Add(type.ToString());
            }
            ViewBag.Waste = waste;
        }

        private void LoadRoomOptions()
        {
            List<string> room = new List<string>();
            foreach (WordBankHomeChoices.RoomTypes type in Enum.GetValues(typeof(WordBankHomeChoices.RoomTypes)))
            {
                room.Add(type.ToString());
            }
            ViewBag.RoomType = room;
        }

        /*
        public IActionResult GetHomeInfo(int agentID)
        {
            agentID = (int)HttpContext.Session.GetInt32("AgentID");
            return View("AddHome");
        }

        public IActionResult GetHomeImages(int homeID)
        {
            HomeImages homeImages = new HomeImages();
            ViewBag.HomeID = homeID;
            return View(homeImages);
        }

        public IActionResult GetHomeRooms(int homeID)
        {
            RoomInfo room = new RoomInfo();
            ViewBag.HomeID = homeID;
            return View(room);
        }

        public IActionResult GetHomeFacilities(int homeID)
        {
            HomeFacilities homeFacilities = new HomeFacilities();
            ViewBag.HomeID = homeID;
            return View(homeFacilities);
        }
        */
       
    }
}