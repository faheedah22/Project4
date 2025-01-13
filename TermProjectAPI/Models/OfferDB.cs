using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeAPI.Controllers
{
    public class OfferDB
    {
        SqlCommand sqlCommand = new SqlCommand();
        DBConnect db = new DBConnect();

        public CustomerOfferInfo GetCustomerOfferInfo(CustomerOfferInfo offerInfo)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4StoreCustomerOffer";


            
            SqlParameter param = new SqlParameter("@HomeID", offerInfo.HomeID);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@custFirst", offerInfo.CustFirstName);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@custLast", offerInfo.CustLastName);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@custNumber", offerInfo.CustPhoneNum);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@custEmail", offerInfo.CustEmail);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@offerAmt", offerInfo.OfferAmount);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@saleType", offerInfo.SaleType);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@currentHomeStat", offerInfo.CustHomeStatus);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@contigencies", offerInfo.Contigencies);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@moveInDate", offerInfo.MoveInDate);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.DateTime;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            db.DoUpdateUsingCmdObj(sqlCommand);
            //db.GetDataSet(sqlCommand);

            return offerInfo;

        }

        //to get Agent view
        public List<AgentOffers> AgentOffers(DBConnect db, int agentId)
        {

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "AgentOfferList";

            SqlParameter param = new SqlParameter("@agentId", agentId);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);


            db.GetDataSet(sqlCommand);

            DataSet ds = db.GetDataSet(sqlCommand);

            List<AgentOffers> offers = new List<AgentOffers>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AgentOffers offer = new AgentOffers();
                HomeInfo homeInfo = new HomeInfo();
                CustomerOfferInfo theOffer = new CustomerOfferInfo();

                offer.Home = homeInfo;
                offer.CustomerOffer = theOffer;
               
                offer.Home.Address = row["ListingAddress"].ToString();
                offer.Home.City = row["ListingCity"].ToString();
                offer.Home.State = row["ListingState"].ToString();
                offer.Home.Zipcode = row["ListingZip"].ToString();
                offer.Home.HomePrice = double.Parse(row["HomePrice"].ToString());
                offer.CustomerOffer.CustFirstName = row["CustomerFName"].ToString();
                offer.CustomerOffer.CustLastName = row["CustomerLName"].ToString();
                offer.CustomerOffer.CustEmail = row["CustomerEmail"].ToString();
                offer.CustomerOffer.CustPhoneNum = row["CustomerPhoneNum"].ToString();
                offer.CustomerOffer.MoveInDate = DateTime.Parse(row["MoveInDate"].ToString());
                offer.CustomerOffer.OfferAmount = row["OfferAmount"].ToString();
                offer.CustomerOffer.SaleType = row["SaleType"].ToString();
                offer.CustomerOffer.Contigencies = row["Contingencies"].ToString();
                offer.CustomerOffer.CustHomeStatus = row["CurrentHomeStatus"].ToString();

                offers.Add(offer);
            }

            return offers;
        }


        public void DeleteCustomerOfferInfo(int offerID)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4DeleteOffer";
            SqlParameter param = new SqlParameter("@offerID", offerID);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 50;


            sqlCommand.Parameters.Add(param);
            db.DoUpdateUsingCmdObj(sqlCommand);
        }
    }
}
