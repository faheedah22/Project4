using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermProject.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TermProject.Models
{
    public class HomeInfo
    {
        private int homeID = 0;
        private int agentID = 0;
        private string address;
        private string city;
        private string state;
        private string zipcode;
        private string propType;
        private double homePrice;
        private int year;
        private string description;
        private string garage;
        private string status;

        private DateTime listingDate;
        private AgentInfo? agent = new AgentInfo();
        private List<RoomInfo> rooms = new List<RoomInfo>();
        private List<HomeFacilities> amenities = new List<HomeFacilities>();
        private HomeFacilities facilities = new HomeFacilities();
        private List<HomeImages> images = new List<HomeImages>();

        private double homeFootage;

        public HomeInfo()
        {
            this.agent = new AgentInfo();
            this.facilities = new HomeFacilities();
            this.rooms = new List<RoomInfo>();
            this.images = new List<HomeImages>();
            this.amenities = new List<HomeFacilities>();

        }

        public int GetNumBathrooms()
        {
            int bathroomCount = 0;

            // Manually count bedrooms and bathrooms
            foreach (RoomInfo room in Rooms)
            {                
                if (room.RoomTitle == "bathroom")
                {
                    bathroomCount++;
                }
            }
            return bathroomCount;
        }

        public int GetNumBedrooms()
        {
            int bedroomCount = 0;           

            // Manually count bedrooms and bathrooms
            foreach (RoomInfo room in Rooms)
            {
                if (room.RoomTitle == "bedroom")
                {
                    bedroomCount++;
                }
                
            }

            return bedroomCount;
        }

        public double GetSqft()
        {
            double sqft = 0;
            foreach(RoomInfo room in Rooms)
            {
                sqft += room.RoomWidth * room.RoomLength;
            }
            return sqft;
        }

        public int AgentID
        {
            get { return agentID; }
            set { agentID = value; }
        }

        [ValidateNever]
        public AgentInfo? TheAgent
        {
            get { return agent; }
            set { agent = value; }
        }

        public List<RoomInfo> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        public List<HomeFacilities> Amenities
        {
            get { return amenities; }
            set { amenities = value; }
        }

        public HomeFacilities Facilities
        {
            get { return facilities; }
            set { facilities = value; }
        }

        public List<HomeImages> Images
        {
            get { return images; }
            set { images = value; }
        }

        public int HomeID
        {
            get { return homeID; }
            set { homeID = value; }
        }

        [Required(ErrorMessage = "Provide an address.")]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        [Required(ErrorMessage = "Provide a city.")]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [Required(ErrorMessage = "Provide a state.")]
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        [Required(ErrorMessage = "Provide a zipcode.")]
        public string Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }

        [Required(ErrorMessage = "Provide a property type.")]
        public string PropType
        {
            get { return propType; }
            set { propType = value; }
        }

        [Required(ErrorMessage = "Provide a home price.")]
        public double HomePrice
        {
            get { return homePrice; }
            set { homePrice = value; }
        }

        [Required(ErrorMessage = "Provide a year.")]
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        [Required(ErrorMessage = "Provide a description.")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [Required(ErrorMessage = "Provide a number of garage.")]
        public string Garage
        {
            get { return garage; }
            set { garage = value; }
        }

        [Required(ErrorMessage = "Provide home status.")]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        [Required(ErrorMessage = "Provide a listing date.")]
        public DateTime ListingDate
        {
            get { return listingDate; }
            set { listingDate = value; }
        }

        public double HomeFootage
        {
            get { return homeFootage; }
            set { homeFootage = value; }
        }

        //date on the market
        public int PropDaysOnTheMarkey
        {
            get
            {
                return (DateTime.Today - ListingDate).Days;
            }
        }
    }

}
