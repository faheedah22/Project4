using Microsoft.AspNetCore.Mvc;

namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : Controller
    {


        [HttpPost("CustomerOffer")]
        public Boolean CustomerOffer([FromBody] CustomerOfferInfo offerInfo)
        {
            if(offerInfo != null)
            {
                OfferDB offerDB = new OfferDB();
                offerDB.GetCustomerOfferInfo(offerInfo);
                return true;
            }
            else
            {

                return false;
            }

            
        }

        [HttpDelete("DeleteOffer")]
        public Boolean DeleteOffer([FromBody] CustomerOfferInfo offerInfo)
        {
            
                OfferDB offerDB = new OfferDB();
                offerDB.DeleteCustomerOfferInfo(offerInfo.OfferID);
                return true;
          
        }
    }
}
