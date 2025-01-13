using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;


namespace HomeAPI.Controllers
{
    public class DisplayHomeDB
    {
        SqlCommand sqlCommand = new SqlCommand();
        DBConnect db = new DBConnect();

        //getting homeID for the home
        //public int GetHomeID(DBConnect db)
        //{
        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    sqlCommand.CommandText = "HomeID";

        //    DataRow dr = db.GetRow(db.GetDataSet(sqlCommand), 0);
        //    return int.Parse(dr["HomeID"].ToString());
        //}

        //gets all homes and the rooms associated with it
        public List<HomeInfo> DisplayHomes()
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4AllHome";


            DataSet ds = db.GetDataSet(sqlCommand);
            List<HomeInfo> allHome = new List<HomeInfo>(); // holds all the homes and their rooms from DB
            HomeInfo home = new HomeInfo();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                home.HomeID = int.Parse(row["HomeID"].ToString());
                home.HomePrice = double.Parse(row["HomePrice"].ToString());
                home.Address = row["ListingAddress"].ToString();
                home.City = row["ListingCity"].ToString();
                home.State = row["ListingState"].ToString();
                home.Zipcode = row["ListingZip"].ToString();
                home.PropType = row["PropertyType"].ToString();

                home.Rooms = DisplayRooms(home.HomeID);
                home.Images = GetImages(home.HomeID);
                allHome.Add(home);
                home = new HomeInfo();
            }


            return allHome;
        }

        //Gets all rooms associated to the homeId 
        public List<RoomInfo> DisplayRooms(int homeId)
        {
            sqlCommand.Parameters.Clear();
            
            List<RoomInfo> rooms = new List<RoomInfo>(); //storing rooms for selected house
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4ShowHomeRooms";

            SqlParameter param = new SqlParameter("@homeID", homeId);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            DataSet ds = db.GetDataSet(sqlCommand);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                RoomInfo room = new RoomInfo();
                room.RoomTitle = row["RoomType"].ToString();
                //room.RoomLevel = int.Parse(row["RoomLevel"].ToString());

                rooms.Add(room); // gets information from the table
            }

            return rooms;

        }

        //Gets all amenities associated to the homeId 
        public List<HomeFacilities> DisplayAmenities(int homeId)
        {
            sqlCommand.Parameters.Clear();
            List<HomeFacilities> amenities = new List<HomeFacilities>(); //store the amenities for the selected home

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4AllHomeAmenities";

            SqlParameter param = new SqlParameter("@homeID", homeId);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            DataSet ds = db.GetDataSet(sqlCommand);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                HomeFacilities amenity = new HomeFacilities();
                amenity.Amenities.Add(dr["AmenitesType"].ToString());
                amenities.Add(amenity);

            }

            return amenities;
        }

        //Gets all utilities associated to the homeId
        //public HomeFacilities DisplayUtilities(int homeId)
        //{
        //    sqlCommand.Parameters.Clear();

        //    HomeFacilities utility = new HomeFacilities(); 

        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    sqlCommand.CommandText = "P4AllHome";

        //    SqlParameter param = new SqlParameter("@homeID", homeId);
        //    param.Direction = ParameterDirection.Input;
        //    param.SqlDbType = SqlDbType.Int;
        //    param.Size = 50;
        //    sqlCommand.Parameters.Add(param);

        //    DataSet ds = db.GetDataSet(sqlCommand);
        //    utility.Cooling = ds.Tables[0].Rows[0]["Cooling"].ToString();
        //    utility.Heating = ds.Tables[0].Rows[0]["Heating"].ToString();
        //    utility.SewerType = ds.Tables[0].Rows[0]["SewerType"].ToString();
        //    utility.WaterType = ds.Tables[0].Rows[0]["WaterType"].ToString();

        //    return utility;
        //}



        //to get every room information for each home
        public List<RoomInfo> GetAllRoomsInfo(int homeId)
        {
            sqlCommand.Parameters.Clear();
            List<RoomInfo> rooms = new List<RoomInfo>(); //storing rooms for selected house
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4ShowHomeRooms";

            SqlParameter param = new SqlParameter("@homeID", homeId);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            DataSet ds = db.GetDataSet(sqlCommand);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                RoomInfo room = new RoomInfo();
                room.RoomTitle = row["RoomType"].ToString();
                room.RoomLevel = int.Parse(row["RoomLevel"].ToString());
                room.RoomWidth = int.Parse(row["RoomWidth"].ToString());
                room.RoomLength = int.Parse(row["RoomLength"].ToString());

                rooms.Add(room); // gets information from the table
            }

            return rooms;
        }


        //get the agent info for the house

        public AgentInfo GetAgentInfo(DBConnect db, int agentID)
        {
            sqlCommand.Parameters.Clear();


            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4GetAgentIdInfo";

            SqlParameter param = new SqlParameter("@agentID", agentID);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            DataSet ds = db.GetDataSet(sqlCommand);


            AgentInfo info = new AgentInfo();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                DataRow row = ds.Tables[0].Rows[0];
                info.AgentID = agentID;
                info.FirstName = row["First_Name"].ToString();
                info.LastName = row["Last_Name"].ToString();

                info.WorkEmail = row["Work_Email"].ToString();
                info.WorkPhoneNum = row["Work_PhoneNum"].ToString();
                info.WorkAddress = row["Work_Address"].ToString();
                info.WorkCity = row["Work_City"].ToString();
                info.WorkState = row["Work_State"].ToString();
                info.WorkZip = row["Work_Zip"].ToString();

                info.CompanyName = row["Company_Name"].ToString();
                info.CompanyPhoneNum = row["Company_PhoneNum"].ToString();
                info.CompanyEmail = row["Company_Email"].ToString();
                info.CompanyAddress = row["Company_Address"].ToString();
                info.CompanyCity = row["Company_City"].ToString();
                info.CompanyState = row["Company_State"].ToString();
                info.CompanyZip = row["Company_Zip"].ToString();

            }

            //info.FirstName = ds.Tables[0].Rows[0]["First_Name"].ToString();
            //info.LastName = ds.Tables[0].Rows[0]["Last_Name"].ToString();


            //info.WorkEmail = ds.Tables[0].Rows[0]["Work_Email"].ToString();
            //info.WorkPhoneNum = ds.Tables[0].Rows[0]["Work_PhoneNum"].ToString();
            //info.WorkAddress = ds.Tables[0].Rows[0]["Work_Address"].ToString();
            //info.WorkCity = ds.Tables[0].Rows[0]["Work_City"].ToString();
            //info.WorkState = ds.Tables[0].Rows[0]["Work_State"].ToString();
            //info.WorkZip = ds.Tables[0].Rows[0]["Work_Zip"].ToString();

            //info.CompanyName = ds.Tables[0].Rows[0]["Company_Name"].ToString();
            //info.CompanyPhoneNum = ds.Tables[0].Rows[0]["Company_PhoneNum"].ToString();
            //info.CompanyEmail = ds.Tables[0].Rows[0]["Company_Email"].ToString();
            //info.CompanyAddress = ds.Tables[0].Rows[0]["Company_Address"].ToString();
            //info.CompanyCity = ds.Tables[0].Rows[0]["Company_City"].ToString();
            //info.CompanyState = ds.Tables[0].Rows[0]["Company_State"].ToString();
            //info.CompanyZip = ds.Tables[0].Rows[0]["Company_Zip"].ToString();


            return info;
        }

        //get all images for the home
        //public List<HomeImages> AllHomeImages(DBConnect db, int homeID)
        //{
        //    sqlCommand.Parameters.Clear();
        //    HomeImages image = new HomeImages();
        //    List<HomeImages> images = new List<HomeImages>(); //storing images for selected house
        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    sqlCommand.CommandText = "AllHomeImages";

        //    SqlParameter param = new SqlParameter("@homeID", homeID);
        //    param.Direction = ParameterDirection.Input;
        //    param.SqlDbType = SqlDbType.Int;
        //    param.Size = 50;
        //    sqlCommand.Parameters.Add(param);

        //    DataSet ds = db.GetDataSet(sqlCommand);

        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        image.ImageUrl = row["ImageUrl"].ToString();
        //        image.ImageTitle = row["ImageTitle"].ToString();

        //        images.Add(image);
        //    }

        //    return images;
        //}



        //to display every information about the home in the home details home page
        public HomeInfo DisplayAllHomeInfo(int homeID)
        {
            sqlCommand.Parameters.Clear();

            HomeInfo home = new HomeInfo();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4HomeInfoByID";

            SqlParameter param = new SqlParameter("@homeID", homeID);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            DataSet ds = db.GetDataSet(sqlCommand);




            foreach (DataRow row in ds.Tables[0].Rows)
            {
                home.HomeID = int.Parse(row["HomeID"].ToString());
                home.AgentID = int.Parse(row["AgentID"].ToString());
                home.HomePrice = double.Parse(row["HomePrice"].ToString());
                home.Address = row["ListingAddress"].ToString();
                home.City = row["ListingCity"].ToString();
                home.State = row["ListingState"].ToString();
                home.Zipcode = row["ListingZip"].ToString();
                home.PropType = row["PropertyType"].ToString();
                home.Garage = row["HomeGarage"].ToString();
                home.Description = row["HomeInfo"].ToString();
                home.Year = int.Parse(row["YearBuilt"].ToString());
                home.Facilities.Cooling = row["Cooling"].ToString();
                home.Facilities.Heating = row["Heating"].ToString();
                home.Facilities.WaterType = row["WaterType"].ToString();
                home.Facilities.SewerType = row["SewerType"].ToString();

                home.Rooms = GetAllRoomsInfo(home.HomeID);

                home.Amenities = DisplayAmenities(home.HomeID);

                // home.PropDaysOnTheMarkey = int.Parse(row[""].ToString());


                AgentInfo agent = new AgentInfo();
                agent.AgentID = home.AgentID;
                agent = GetAgentInfo(db, home.AgentID);

                home.TheAgent = agent;

            }

            return home;
        }

        public List<HomeImages> GetImages(int homeId)
        {
            sqlCommand.Parameters.Clear();

            List<HomeImages> homeImages = new List<HomeImages>();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4AllHomeImages";

            SqlParameter param = new SqlParameter("@homeID", homeId);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            
            DataSet ds = db.GetDataSet(sqlCommand);
            int rowCount = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                
                if (db.GetField("ImageObject", rowCount) != System.DBNull.Value)
                {
                    Byte[] byteArray = (Byte[])db.GetField("ImageObject", 0);

                    // Deserialize the byte array into a HomeImages object
                    HomeImages img = JsonSerializer.Deserialize<HomeImages>(byteArray);
                    homeImages.Add(img);
                    // Use the img object as needed
                }
                
            }

            return homeImages;

        }
    } 
}
