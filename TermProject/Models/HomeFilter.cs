using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermProject.Models;
using static TermProject.Models.WordBankHomeChoices;

namespace TermProject.Models
{
    public static class HomeFilter
    {
        public static List<HomeInfo> PriceRange(List<HomeInfo> homes, double minPrice, double maxPrice)
        {
            List<HomeInfo> homesFiltered = new List<HomeInfo>();
            bool passFilter = true;

            foreach (var home in homes)
            {
                if (home.HomePrice < minPrice)
                {
                    passFilter = false;
                }
                if (home.HomePrice > maxPrice)
                {
                    passFilter = false;
                }
                if (passFilter == true)
                {
                    homesFiltered.Add(home);
                }

                passFilter = true;
            }
            if (minPrice == 0 && maxPrice == 0)
            {
                return homes;
            }
            else
            {
                return homesFiltered;
            }

        }

        public static List<HomeInfo> State(List<HomeInfo> homes, string state)
        {
            List<HomeInfo> homesFiltered = new List<HomeInfo>();

            if (!Enum.TryParse<USState>(state, out var validState))
            {
                return homes;
            }
            else
            {
                foreach (var home in homes)
                {
                    if (home.State.Equals(state))
                    {
                        homesFiltered.Add(home);
                    }

                }

                return homesFiltered;
            }
            
        }

        public static List<HomeInfo> PropertyType(List<HomeInfo> homes, string property)
        {
            List<HomeInfo> homesFiltered = new List<HomeInfo>();

            if (!Enum.TryParse<PropertyType>(property, out var validState))
            {
                return homes;
            }
            else
            {
                foreach (var home in homes)
                {
                    if (home.PropType.Equals(property))
                    {
                        homesFiltered.Add(home);
                    }
                }
                return homesFiltered;
            }
            

        }

        public static List<HomeInfo> MinBathsBeds(List<HomeInfo> homes, string baths, string beds)
        {
            int numBaths;
            int numBeds;

            
            if (baths.Equals("Any") && beds.Equals("Any"))
            {
                baths = "0+";
                beds = "0+";
            }

            else if (baths.Equals("Any"))
            {
                baths = "0+";
            }
            else if (beds.Equals("Any"))
            {
                beds = "0+";
            }

            string bathsModified = baths.Replace("+", "");
            string bedsModified = beds.Replace("+", "");
            
            numBaths = int.Parse(bathsModified);
            numBeds = int.Parse(bedsModified);

            
            List<HomeInfo> homesFiltered = new List<HomeInfo>();
            
            foreach (var home in homes)
            {
                if (home.GetNumBathrooms() >= numBaths && home.GetNumBedrooms() >= numBeds)
                {
                    homesFiltered.Add(home);
                }
            }
            
            return homesFiltered;
            
        }

        
        public static List<HomeInfo> Amenities(List<HomeInfo> homes, List<string> amenities)
        {
            if (amenities.Count == 0)
            {
                return homes;
            }
            List<HomeInfo> homesFiltered = new List<HomeInfo>();
            foreach (var home in homes)
            {
                foreach(string amenity in amenities)

                    if (home.Facilities.Amenities.Contains(amenity))
                    {
                        homesFiltered.Add(home);
                    }
            }
            return homesFiltered;

            
        }

    }
}
