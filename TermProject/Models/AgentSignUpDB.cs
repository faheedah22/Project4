using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Reflection;

namespace TermProject.Models
{
    public class AgentSignUpDB
    {
       // DBConnect dbConnect = new DBConnect();
        SqlCommand sqlCommand = new SqlCommand();
        DBConnect db = new DBConnect();

        //To get agent information to be stored in the database
        public bool GetAgentInfo(AgentInfo agentInfo)
        {
           // AgentInfo agentInfo = new AgentInfo();
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.P4StoreAgentSignUpInfo";
            
            SqlParameter param = new SqlParameter("@firstName", agentInfo.FirstName);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;                       
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@lastName", agentInfo.LastName);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@personalEmail", agentInfo.Email);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@phoneNum", agentInfo.PhoneNum);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@homeStreet", agentInfo.HomeAddress);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@homeCity", agentInfo.HomeCity);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@homeState", agentInfo.HomeState);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@homeZipcode", agentInfo.HomeZip);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@workEmail", agentInfo.WorkEmail);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@workPhoneNum", agentInfo.WorkPhoneNum);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@workStreet", agentInfo.WorkAddress);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@workCity", agentInfo.WorkCity);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@workState", agentInfo.WorkState);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@workZipcode", agentInfo.WorkZip);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@companyName", agentInfo.CompanyName);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@companyEmail", agentInfo.CompanyEmail);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@companyPhoneNum", agentInfo.CompanyPhoneNum);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@companyAddress", agentInfo.CompanyAddress);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@companyCity", agentInfo.CompanyCity);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@companyState", agentInfo.CompanyState);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@companyZipcode", agentInfo.CompanyZip);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@agentusername", agentInfo.Username);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            //encrypting the password and storing it in the database
            string hashedPassword = PasswordEncrypt.EncryptPass(agentInfo.UserPassword);
            sqlCommand.Parameters.Add(new SqlParameter("@userPassword", SqlDbType.VarChar,50) { Value = hashedPassword});
            //param = new SqlParameter("@userPassword", hashedPassword);
            //param = new SqlParameter("@userPassword", agentInfo.UserPassword);
            //Hello
            //param.Direction = ParameterDirection.Input;
            //param.SqlDbType = SqlDbType.VarChar;
            //param.Size = 50;
            //sqlCommand.Parameters.Add(param);
            //hi
            db.GetDataSet(sqlCommand);

           
            return true;
        }


        public bool GetSecurityQA(AgentInfo agentInfo)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4StoreQA";
            SqlParameter param = new SqlParameter("@agentID", agentInfo.AgentID);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@questionOne", agentInfo.QuestionOne);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@answerOne", agentInfo.AnswerOne);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@questionTwo", agentInfo.QuestionTwo);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@answerTwo", agentInfo.AnswerTwo);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@questionThree", agentInfo.QuestionThree);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter("@answerThree", agentInfo.AnswerThree);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            db.GetDataSet(sqlCommand);
            return true;
        }


        //to get the username to check if it already exists in the database
        public bool GetUsername(AgentInfo agentInfo)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4GetUsername";
            SqlParameter param = new SqlParameter("@username", agentInfo.Username);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 50;
            sqlCommand.Parameters.Add(param);

            DataSet dr = db.GetDataSet(sqlCommand);
            int myUser = dr.Tables[0].Rows.Count;
            if (myUser > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //to get the agentID from the database
        public int GetAgentID(AgentInfo agentInfo) 
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4GetAgentID";

            DataSet dr = db.GetDataSet(sqlCommand);


            agentInfo.Username = dr.Tables[0].Rows[0]["Agent_UserName"].ToString();
            agentInfo.AgentID = int.Parse(dr.Tables[0].Rows[0]["AgentID"].ToString());
            //agentInfo.UserPassword = dr.Tables[0].Rows[0]["Agent_Password"].ToString();

            return agentInfo.AgentID;
        }




        //login stuff
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

        public bool ValidateAcct(string username, string password)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "P4GetLogin";

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
            AgentInfo agent = new AgentInfo();

            agent.Username = dr.Tables[0].Rows[0]["Agent_UserName"].ToString();
            agent.AgentID = int.Parse(dr.Tables[0].Rows[0]["AgentID"].ToString());

            return agent.AgentID;
        }
    }
}
