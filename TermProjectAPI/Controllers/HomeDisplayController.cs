using Microsoft.AspNetCore.Mvc;


namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeDisplayController : Controller
    {

        [HttpGet("HomeDisplay")]
        public List<HomeInfo> AllHomes()
      
        {
            DisplayHomeDB homeDB = new DisplayHomeDB();
            List<HomeInfo> homes = homeDB.DisplayHomes();


            return homes;

        }

        [HttpGet("HomeDetail")]
        public HomeInfo HomeDisplay(int homeID)
        {
            DisplayHomeDB display = new DisplayHomeDB();
            HomeInfo home = display.DisplayAllHomeInfo(homeID);

            return home;
        }
    }
}
