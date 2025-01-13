using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using static TermProject.Models.WordBankHomeChoices;
using static Azure.Core.HttpHeader;
using System.Data.Common;

namespace TermProject.Models
{
    public class HomeDB
    {
        //adding home info to the homeDb
        public void EditHome(HomeInfo home)
        {
            SqlCommand sqlCommand = new SqlCommand();
            DBConnect db = new DBConnect();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4EditHome";

        }

        public HomeInfo GetHomeById(int homeId) 
        {            
            SqlCommand sqlCommand = new SqlCommand();
            DBConnect db = new DBConnect();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4HomeInfoByID";

            SqlParameter param = new SqlParameter("@homeID", homeId);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            sqlCommand.Parameters.Add(param);

            DataSet ds = new DataSet();
            ds = db.GetDataSetUsingCmdObj(sqlCommand);

            List<HomeInfo> homeList = new List<HomeInfo>();

            if (ds.Tables.Count > 0)
            {
                DataTable homesTable = ds.Tables[0];

                foreach (DataRow row in homesTable.Rows)
                {
                    HomeInfo home = new HomeInfo();
                    home.HomeID = Convert.ToInt32(row["HomeID"]);
                    home.AgentID = Convert.ToInt32(row["AgentID"]);
                    home.Address = row["ListingAddress"].ToString();
                    home.City = row["ListingCity"].ToString();
                    home.State = row["ListingState"].ToString();
                    home.Zipcode = row["ListingZip"].ToString();
                    home.PropType = row["PropertyType"].ToString();
                    home.HomePrice = Convert.ToDouble(row["HomePrice"]);
                    home.Garage = row["HomeGarage"].ToString();
                    home.Description = row["HomeInfo"].ToString();
                    home.Year = Convert.ToInt32(row["YearBuilt"]);
                    home.Status = row["HomeStatus"].ToString();
                    home.Facilities.WaterType = row["WaterType"].ToString();
                    home.Facilities.SewerType = row["SewerType"].ToString();
                    home.Facilities.Cooling = row["Cooling"].ToString();
                    home.Facilities.Heating = row["Heating"].ToString();
                    homeList.Add(home);
                }
            }

            HomeInfo homeInfo = new HomeInfo();
            homeInfo = homeList[0];

            return homeInfo;
        }

        public HomeInfo AddHomeInfo(HomeInfo home)
        {
            SqlCommand sqlCommand = new SqlCommand();
            DBConnect db = new DBConnect();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4StoreHome";

            SqlParameter param = new SqlParameter("@agentID", home.AgentID);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@address", home.Address);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@city", home.City);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@state", home.State);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@zipCode", home.Zipcode);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@propertyType", home.PropType);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@price", home.HomePrice);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Float;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@garage", home.Garage);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@description", home.Description);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = -1;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@year", home.Year);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@status", home.Status);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@water", home.Facilities.WaterType);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@sewer", home.Facilities.SewerType);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@cooling", home.Facilities.Cooling);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@heating", home.Facilities.Heating);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            //param = new SqlParameter("@sqft", home.HomeFootage);
            //param.Direction = ParameterDirection.Input;
            //param.SqlDbType = SqlDbType.Float;           
            //sqlCommand.Parameters.Add(param);

            db.DoUpdateUsingCmdObj(sqlCommand);

            return home;
        }

        //adding room info to the roomDb 
        
        public bool AddRoomInfo(RoomInfo room)
        {
            SqlCommand sqlCommand = new SqlCommand();
            DBConnect db = new DBConnect();
            sqlCommand.Parameters.Clear();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4StoreRooms";

            SqlParameter param = new SqlParameter("@homeID", room.Id);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@roomTitle", room.RoomTitle);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@roomLevel", room.RoomLevel);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@roomWidth", room.RoomWidth);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@roomLength", room.RoomLength);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            
            db.DoUpdateUsingCmdObj(sqlCommand);
            return true;
        }

        //adding amemities info to the amenitiesDB
        
        public bool AddAmenities(HomeInfo home)
        {
            foreach(string amenity in home.Facilities.Amenities)
            {
                SqlCommand sqlCommand = new SqlCommand();
                DBConnect db = new DBConnect();
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "P4StoreAmenities";

                SqlParameter param = new SqlParameter("@homeID", home.HomeID);
                param.Direction = ParameterDirection.Input;
                param.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter("@amenity", amenity);
                param.Direction = ParameterDirection.Input;
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 50;
                sqlCommand.Parameters.Add(param);

                db.DoUpdateUsingCmdObj(sqlCommand);
            }

            return true;
        }
        
        //getting homeid from the database
        public int GetHomeIDForAddHome(HomeInfo home)
        {
            DBConnect db = new DBConnect();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "P4GetHomeId";

            SqlParameter param = new SqlParameter("@address", home.Address);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            command.Parameters.Add(param);

            param = new SqlParameter("@city", home.City);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            command.Parameters.Add(param);

            param = new SqlParameter("@state", home.State);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            command.Parameters.Add(param);

            param = new SqlParameter("@zipcode", home.Zipcode);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            command.Parameters.Add(param);

            DataRow dr = db.GetRow(db.GetDataSet(command), 0);
            return int.Parse(dr["HomeID"].ToString());
           
        }

        public bool AddImage(HomeImages img, byte[] byteArray)
        {
            DBConnect db = new DBConnect();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "P4AddImages";

            SqlParameter param = new SqlParameter("@homeID", img.HomeId);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param);

            param = new SqlParameter("@imageType", img.ImageUrl);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(param);

            param = new SqlParameter("@imageTitle", img.ImageTitle);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            command.Parameters.Add(param);

            command.Parameters.AddWithValue("@imageObject", byteArray);

            db.DoUpdateUsingCmdObj(command);

            return true;
        }

        public void DeleteHome(int homeId)
        {
            DBConnect db = new DBConnect();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "P4DeleteHome";

            SqlParameter param = new SqlParameter("@homeID", homeId);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param);

            db.DoUpdateUsingCmdObj(command);
        }

        public List<HomeInfo> GetAgentHomes(int agentId)
        {
            DBConnect db = new DBConnect();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "P4GetAgentHomes";

            SqlParameter param = new SqlParameter("@agentId", agentId);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param);

            List<HomeInfo> homeList = new List<HomeInfo>();
            DataSet homes = new DataSet();
            homes = db.GetDataSetUsingCmdObj(command);

            if (homes.Tables.Count > 0) 
            {
                DataTable homesTable = homes.Tables[0]; 

                foreach (DataRow row in homesTable.Rows) 
                {
                    HomeInfo home = new HomeInfo();
                    home.HomeID = Convert.ToInt32(row["HomeID"]);
                    home.AgentID = Convert.ToInt32(row["AgentID"]);
                    home.Address = row["ListingAddress"].ToString();
                    home.City = row["ListingCity"].ToString();
                    home.State = row["ListingState"].ToString();
                    home.Zipcode = row["ListingZip"].ToString();
                    home.PropType = row["PropertyType"].ToString();
                    home.HomePrice = Convert.ToDouble(row["HomePrice"]);
                    home.Garage = row["HomeGarage"].ToString();
                    home.Description = row["HomeInfo"].ToString();
                    home.Year = Convert.ToInt32(row["YearBuilt"]);
                    home.Status = row["HomeStatus"].ToString();
                    home.Facilities.WaterType = row["WaterType"].ToString();
                    home.Facilities.SewerType = row["SewerType"].ToString();
                    home.Facilities.Cooling = row["Cooling"].ToString();
                    home.Facilities.Heating = row["Heating"].ToString();
                    homeList.Add(home);
                }
            }
            return homeList;
        }


        /*
        //to get the home footage for each room in the house
        public bool UpdateHomeForFootage(DBConnect db, int homeID)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UpdateHomeFootage";
            

            SqlParameter param = new SqlParameter("@home", homeID);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            command.Parameters.Add(param);

            db.GetDataSet(sqlCommand);
            
            return true;
           
        }*/
    }
}
