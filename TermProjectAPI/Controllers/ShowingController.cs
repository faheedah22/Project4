using Microsoft.AspNetCore.Mvc;

namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ShowingController : Controller
    {

        [HttpPost("BookShowing")]
        public Boolean BookShowing([FromBody] CustomerShowingRequest showing)
        {
            if(showing != null)
            {
                TourDB showingDB = new TourDB();
                showingDB.StoreTourInfo(showing);
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
