using System.Runtime.CompilerServices;

namespace TermProject.Models
{
    public static class WordBankHomeChoices
    {
        public enum Amenities
        {
            fireplace,
            walk_in_closet,
            hardwood,
            tiling,
            smart_home,
            wine_cellar,
            home_theater,
            sauna,
            internet,
            finished_basement,
            butlers_pantry,
            mudroom,
            furnished,
            granite_countertops,
            stainless_steel_appliances,
            double_oven,
            kitchen_island,
            walk_in_pantry,
            garbage_disposal,
            coffee_maker,
            induction_cooktop,
            bidet,
            pool,
            hot_tub,
            fire_pit,
            patio,
            fenced_yard,
            greenhouse,
            security_cameras,
            storm_shelter,
            insulated_doors,
            playground,
            tennis_court
        }

        public enum Status
        {
            for_sale,
            pending_sale,
            sold
        }

        public enum Cooling
        {
            central_air,
            ductless_mini_split,
            geothermal,
            whole_home_fans
        }
        public enum Heating
        {
            forced_air,
            radiant_heating,
            heat_pump,
        }
        public enum Water
        {
            well_water,
            public_supply
        }

        public enum Waste
        {
            public_sewer,
            septic
        }

        public enum PropertyType
        {
            single_family,
            multi_family,
            townhouse,
            condo
        }

        public enum RoomTypes
        {
            living_room,
            kitchen,
            diningRoom,
            bedroom,
            bathroom,
            attic,
            sunroom,
            gym,
            media_room,
            master,
            laundry
        }

        public enum USState
        {
            AL, // Alabama
            AK, // Alaska
            AZ, // Arizona
            AR, // Arkansas
            CA, // California
            CO, // Colorado
            CT, // Connecticut
            DE, // Delaware
            DC, // District of Columbia
            FL, // Florida
            GA, // Georgia
            HI, // Hawaii
            ID, // Idaho
            IL, // Illinois
            IN, // Indiana
            IA, // Iowa
            KS, // Kansas
            KY, // Kentucky
            LA, // Louisiana
            ME, // Maine
            MD, // Maryland
            MA, // Massachusetts
            MI, // Michigan
            MN, // Minnesota
            MS, // Mississippi
            MO, // Missouri
            MT, // Montana
            NE, // Nebraska
            NV, // Nevada
            NH, // New Hampshire
            NJ, // New Jersey
            NM, // New Mexico
            NY, // New York
            NC, // North Carolina
            ND, // North Dakota
            OH, // Ohio
            OK, // Oklahoma
            OR, // Oregon
            PA, // Pennsylvania
            RI, // Rhode Island
            SC, // South Carolina
            SD, // South Dakota
            TN, // Tennessee
            TX, // Texas
            UT, // Utah
            VT, // Vermont
            VA, // Virginia
            WA, // Washington
            WV, // West Virginia
            WI, // Wisconsin
            WY  // Wyoming
        }
    }
}
