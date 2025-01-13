using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace TermProject.Models
{
    
   public  class TourDB
    {
        SqlCommand sqlCommand = new SqlCommand();
        DBConnect db = new DBConnect();

        public bool StoreTourInfo(DBConnect db, int homeID, string first, string last, string email, string phoneNum, DateTime tourDate)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "StoreTour";

            SqlParameter param = new SqlParameter("@homeID", homeID);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@firstName", first);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@lastName", last);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@custEmail", email);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@phoneNum", phoneNum);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@showDate", tourDate);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.DateTime;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            db.GetDataSet(sqlCommand);

            return true;
        }

        //to get Agent view
        public List<AgentTourView> AgentView(int agentID)
        {
           
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4AgentTourList";

            
            //AgentTourView tourView = new AgentTourView();
            // AgentInfo agent = new AgentInfo();
            SqlParameter param = new SqlParameter("@agentId", agentID);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            //param = new SqlParameter("@homeId", homeId);
            //param.Direction = ParameterDirection.Input;
            //param.SqlDbType = SqlDbType.Int;
            //param.Size = 50;
            //sqlCommand.Parameters.Add(param);


            db.GetDataSet(sqlCommand);
            
            DataSet ds = db.GetDataSet(sqlCommand);

            List<AgentTourView> tour = new List<AgentTourView>();
           
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AgentTourView tourView = new AgentTourView();
                HomeInfo homeInfo = new HomeInfo();
                CustomerShowingRequest show = new CustomerShowingRequest();

                tourView.Home = homeInfo;
                tourView.Showing = show;
               tourView.Home.HomeID = int.Parse(row["HomeID"].ToString());
                tourView.Home.Address = row["ListingAddress"].ToString();
                tourView.Home.City = row["ListingCity"].ToString();
                tourView.Home.State = row["ListingState"].ToString();
                tourView.Home.Zipcode = row["ListingZip"].ToString();
                tourView.Showing.FirstName = row["FirstName"].ToString();
                tourView.Showing.LastName = row["LastName"].ToString();
                tourView.Showing.Email = row["Email"].ToString();
                tourView.Showing.PhoneNum = row["PhoneNum"].ToString();
                tourView.Showing.ShowDate = DateTime.Parse(row["ShowDate"].ToString());
                tourView.Showing.ShowTime = DateTime.Parse(row["ShowTime"].ToString());

                tour.Add(tourView);
            }

            return tour;
        }
    }
}
