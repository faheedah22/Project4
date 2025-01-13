using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Controllers
{
    [Serializable]
    public class HomeImages
    {
        private int homeId;
        private string imageURl;
        private string imageTitle;
        private IFormFile formFile;

        public IFormFile ImageFile
        {
            get { return formFile; }
            set { formFile = value; }
        }

        public int HomeId
        {
            get { return homeId; }
            set { homeId = value; }
        }
        public string ImageUrl
        {
            get { return imageURl; }
            set { imageURl = value; }
        }

        public string ImageTitle
        {
            get { return imageTitle; }
            set { imageTitle = value; }
        }
    }
}
