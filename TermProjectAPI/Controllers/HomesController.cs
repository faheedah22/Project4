using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        [HttpPost("AddHome")]
        public HomeInfo AddHome([FromBody] HomeInfo home)
        {
            
             HomeDB homeAdder = new HomeDB();
             homeAdder.AddHomeInfo(home);

             int homeId = homeAdder.GetHomeIDForAddHome(home); //Grabs id for home based off address, state, and zip
             home.HomeID = homeId;
             homeAdder.AddAmenities(home);
             return home;
            
        }

        [HttpDelete("DeleteHome/{homeId}")]
        public bool DeleteHome([FromRoute] int homeId)
        {
            HomeDB db = new HomeDB();
            db.DeleteHome(homeId);
            return true;
        }

        [HttpGet("GetAgentHomes")]
        public List<HomeInfo> GetAgentHomes(int agentId) 
        {
            List<HomeInfo> homes = new List<HomeInfo>();
            HomeDB db = new HomeDB();
            homes = db.GetAgentHomes(agentId);
            return homes;
        }

        [HttpPut("EditHome")]
        public HomeInfo EditHome([FromBody] HomeInfo home) 
        {
            HomeDB db = new HomeDB();
            db.EditHome(home);
            return home;
        }

        [HttpGet("GetEditHome/{homeId}")]
        public HomeInfo GetEditHome([FromRoute] int homeId)
        {
            HomeDB db = new HomeDB();
            HomeInfo home = new HomeInfo();
            home = db.GetHomeById(homeId);

            return home;
        }


    }
}