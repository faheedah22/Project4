using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
//using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.InteropServices;
using TermProject.Models;


namespace TermProject.Controllers
{
    public class AccountController : Controller
    {
       
        AgentSignUpDB signUpDB = new AgentSignUpDB();

        AgentSignUpDB loginDB = new AgentSignUpDB();

        string AgentCookie = "agentID";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return View("HomePage");
        }



        public IActionResult SignUp(AgentInfo agentInfo)
        {
            LoadSecurityQuestions();

            if (agentInfo != null && ModelState.IsValid)
            {
               bool userCheck = signUpDB.GetUsername(agentInfo);

                //to prevent same username from being recreated by a different person
                if(userCheck == false)
                {
                    signUpDB.GetAgentInfo(agentInfo);
                    CookieOptions option = new CookieOptions();
                    // option.Expires = DateTime.Now.AddDays(30);
                     
                    

                    signUpDB.GetAgentID(agentInfo);
                    signUpDB.GetSecurityQA(agentInfo);

                    HttpContext.Response.Cookies.Append(AgentCookie, agentInfo.AgentID.ToString(), option);


                    HttpContext.Session.SetInt32("AgentID", agentInfo.AgentID);
                    return View("Portal");
                }
                else
                {
                    ViewData["ErrorMessage"] = "Username already exists";
                    
                }

                //int agentID = int.Parse(signUpDB.GetAgentInfo(agentInfo).ToString(

                  
              
               
            }
            return View("SignUp");


        }

        public IActionResult TheSignUp()
        {
            LoadSecurityQuestions();
            return View("SignUp");
        }


        public IActionResult Login()
        {

           return View("Login");
        }


        [HttpPost]
        public IActionResult Login(AgentLogin login)
        {
            
            if (login != null && ModelState.IsValid)
            {
               
                bool checkUser = loginDB.ValidateAcct(login.Username, login.UserPassword);

                if (checkUser == false)
                {
                    ViewData["ErrorMessage"] = "Username or Password is incorrect";
                }
                else
                {
                   loginDB.GetAgentLogin(login);

                    if (login.AgentID == 0) 
                    {
                        ViewData["ErrorMessage"] = "Error retrieving Agent ID. Please try again.";
                        return View("Login");
                    }

                    CookieOptions option = new CookieOptions();
                    //option.Expires = DateTime.Now.AddDays(30);
                    HttpContext.Response.Cookies.Append(AgentCookie, login.AgentID.ToString(), new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(30)
                    });


                    //APICall = new API Call
                    //string data = apicall.getpost("controller/api/account/GetHomes");
                    //AgentLogin login = JsonConvert.Deserialize<AgentLogin>(data);


                    HttpContext.Session.SetInt32("AgentID", login.AgentID);

                    return View("Portal");
                }

               
            }
           return View("Login");
        }


        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete(AgentCookie);
            HttpContext.Session.Clear();
            return View("HomePage");
        }

        

        public IActionResult Portal()
        {

            // Retrieve the session value
            int agentID = (int)HttpContext.Session.GetInt32("AgentID");

            //to handle error in transit
            if (agentID == null)
            {
                return View("Login");
            }

            AgentInfo agent = new AgentInfo();
            agent.AgentID = agentID;

            ViewBag.AgentID = agentID; // Pass to view if needed

            return View("Portal");
        }
            


        

        private void LoadSecurityQuestions()
        {
            List<string> securityQ1s = new List<string>();
            foreach (string q1 in SecurityQuestions.PartOne())
            {
                securityQ1s.Add(q1.ToString());
            }
            ViewBag.SecurityQ1 = securityQ1s;

            List<string> securityQ2s = new List<string>();
            foreach (string q2 in SecurityQuestions.PartTwo())
            {
                securityQ2s.Add(q2.ToString());
            }
            ViewBag.SecurityQ2 = securityQ2s;

            List<string> securityQ3s = new List<string>();
            foreach (string q3 in SecurityQuestions.PartThree())
            {
                securityQ3s.Add(q3.ToString());
            }
            ViewBag.SecurityQ3 = securityQ3s;

        }
    }
}
