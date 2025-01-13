using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Reflection;


namespace HomeAPI.Controllers
{
    public class AgentLoginDB
    {
        SqlCommand sqlCommand = new SqlCommand();
        DBConnect db = new DBConnect();

        // getting the login informatiion for sign-in
        //public AgentLogin GetAgentLogin(AgentLogin login)
        //{
        //    sqlCommand.Parameters.Clear();
        //    //AgentLogin login = new AgentLogin();

        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    sqlCommand.CommandText = "dbo.P4GetLogin";

        //    SqlParameter param = new SqlParameter("@username", login.Username);
        //    param.Direction = ParameterDirection.Input;
        //    param.SqlDbType = SqlDbType.VarChar;
        //    param.Size = 50;
        //    sqlCommand.Parameters.Add(param);


        //    param = new SqlParameter("@thePassword", login.UserPassword);
        //    param.Direction = ParameterDirection.Input;
        //    param.SqlDbType = SqlDbType.VarChar;
        //    param.Size = 50;
        //    sqlCommand.Parameters.Add(param);

        //    DataRow dr = db.GetRow(db.GetDataSet(sqlCommand), 0);

        //    login.AgentID = int.Parse(dr["AgentID"].ToString());
        //    login.Username = dr["Agent_UserName"].ToString();
        //    login.UserPassword =dr["Agent_Password"].ToString();
        //    return login;

        //}

        public AgentLogin GetAgentLogin(AgentLogin login)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.P4GetLogin";
            SqlParameter param = new SqlParameter("@username", login.Username);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);


            string hashedPassword = PasswordEncrypt.EncryptPass(login.UserPassword);
            param = new SqlParameter("@thePassword", hashedPassword);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);


            DataSet ds = db.GetDataSet(sqlCommand);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                login.AgentID = int.Parse(dr["AgentID"].ToString());
                login.Username = dr["Agent_UserName"].ToString();
                login.UserPassword = dr["Agent_Password"].ToString();
            }
            else
            {
                throw new Exception("Invalid login credentials. Please check the username and password.");
            }
            return login;
        }

        //Checking to see if the account exist in the table and if not redirecting with a message  for sign up
        //public bool ValidateAcct(string username, string password)
        //{

        //   sqlCommand.Parameters.Clear();
        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    sqlCommand.CommandText = "dbo.P4GetLogin";

        //    SqlParameter param = new SqlParameter("@username", username);
        //    param.Direction = ParameterDirection.Input;
        //    param.SqlDbType = SqlDbType.VarChar;
        //    param.Size = 50;
        //    sqlCommand.Parameters.Add(param);

        //    //param = new SqlParameter("@thePassword", password);
        //    //param.Direction = ParameterDirection.Input;
        //    //param.SqlDbType = SqlDbType.VarChar;
        //    //param.Size = 50;
        //    //sqlCommand.Parameters.Add(param);

        //    bool hashPassword = PasswordEncrypt.VerifyPass(password, sqlCommand.Parameters["thePassword"].ToString());



        //   sqlCommand.Parameters.Add(hashPassword);

        //    DataSet dr = db.GetDataSet(sqlCommand);
        //    int myUser = dr.Tables[0].Rows.Count;
        //    if (myUser > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        public bool ValidateAcct(string username, string password)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.P4GetLogin";

            SqlParameter param = new SqlParameter("@username", username);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            // Hash the input password and add @thePassword parameter
            string hashedPassword = PasswordEncrypt.EncryptPass(password);
            param = new SqlParameter("@thePassword", hashedPassword);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            DataSet ds = db.GetDataSet(sqlCommand);

            return ds.Tables[0].Rows.Count > 0;
        }

        //to get the agentID from the database
        public int GetAgentID()
        {
            sqlCommand.Parameters.Clear();
           
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4GetAgentID";

            DataSet dr = db.GetDataSet(sqlCommand);
            AgentLogin agent = new AgentLogin();

            agent.Username = dr.Tables[0].Rows[0]["Agent_UserName"].ToString();
            agent.AgentID = int.Parse(dr.Tables[0].Rows[0]["AgentID"].ToString());
             
            return agent.AgentID;
        }
    }
}
