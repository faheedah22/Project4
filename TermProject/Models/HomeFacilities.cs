using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class HomeFacilities
    {
        private List<string> amenities = new List<string>();
        private string heating;
        private string cooling;
        private string waterType;
        private string sewerType;

        public List<string> Amenities
        {
            get { return amenities; }
            set { amenities = value; }
        }

        public string Cooling
        {
            get { return cooling; }
            set { cooling = value; }
        }
        public string Heating
        {
            get { return heating; }
            set { heating = value; }
        }
        public string WaterType
        {
            get { return waterType; }
            set { waterType = value; }
        }

        public string SewerType
        {
            get { return sewerType; }
            set { sewerType = value; }
        }
    }
}
