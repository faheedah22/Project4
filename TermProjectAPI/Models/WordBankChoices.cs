using System.Runtime.CompilerServices;

namespace HomeAPI.Controllers
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
            media_Ent,
            master,
            laundry
        }
    }
}
