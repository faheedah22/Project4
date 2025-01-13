using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace HomeAPI.Controllers
{
    
   public  class TourDB
    {
        SqlCommand sqlCommand = new SqlCommand();
        DBConnect db = new DBConnect();

        public CustomerShowingRequest StoreTourInfo(CustomerShowingRequest showReq)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4StoreTour";

            SqlParameter param = new SqlParameter("@homeID", showReq.HomeID);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@firstName", showReq.FirstName);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@lastName", showReq.LastName);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@custEmail", showReq.Email);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@phoneNum", showReq.PhoneNum);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@showDate", showReq.ShowDate);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.DateTime;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);


            param = new SqlParameter("@showTime", showReq.ShowTime);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.DateTime;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            db.DoUpdateUsingCmdObj(sqlCommand);

            return showReq;
        }

        //to get Agent view
        public List<AgentTourView> AgentView(DBConnect db, int agentId, int homeId)
        {
           
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "AgentTourList";

            SqlParameter param = new SqlParameter("@agentId", agentId);
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

                tour.Add(tourView);
            }

            return tour;
        }
    }
}
