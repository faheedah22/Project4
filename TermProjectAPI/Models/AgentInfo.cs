using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace HomeAPI.Controllers
{
    public class AgentInfo
    {
        private int agentID = 0;

        private string firstName;
        private string lastName;
        private string email;
        private string phoneNum;
        private string homeAddress;
        private string homeCity;
        private string homeState;
        private string homeZip;

        private string workEmail;
        private string workPhoneNum;
        private string workAddress;
        private string workCity;
        private string workState;
        private string workZip;

        private string companyName;
        private string companyEmail;
        private string companyPhoneNum;
        private string companyAddress;
        private string companyCity;
        private string companyState;
        private string companyZip;

        private string username;
        private string userPassword;

        public int AgentID
        {
            get { return agentID; }
            set { agentID = value; }
        }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [Required(ErrorMessage = "Email is required")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        [Required(ErrorMessage = "Home Address is required")]
        public string HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }

        [Required(ErrorMessage = "Home City is required")]
        public string HomeCity
        {
            get { return homeCity; }
            set { homeCity = value; }
        }

        [Required(ErrorMessage = "Home State is required")]
        public string HomeState
        {
            get { return homeState; }
            set { homeState = value; }
        }

        [Required(ErrorMessage = "Home Zip is required")]
        public string HomeZip
        {
            get { return homeZip; }
            set { homeZip = value; }
        }

        [Required(ErrorMessage = "Work Email is required")]
        public string WorkEmail
        {
            get { return workEmail; }
            set { workEmail = value; }
        }

        [Required(ErrorMessage = "Work Phone Number is required")]
        public string WorkPhoneNum
        {
            get { return workPhoneNum; }
            set { workPhoneNum = value; }
        }

        [Required(ErrorMessage = "Work Address is required")]
        public string WorkAddress
        {
            get { return workAddress; }
            set { workAddress = value; }
        }

        [Required(ErrorMessage = "Work City is required")]
        public string WorkCity
        {
            get { return workCity; }
            set { workCity = value; }
        }

        [Required(ErrorMessage = "Work State is required")]
        public string WorkState
        {
            get { return workState; }
            set { workState = value; }
        }

        [Required(ErrorMessage = "Work Zip is required")]
        public string WorkZip
        {
            get { return workZip; }
            set { workZip = value; }
        }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        [Required(ErrorMessage = "Company Email is required")]
        public string CompanyEmail
        {
            get { return companyEmail; }
            set { companyEmail = value; }
        }

        [Required(ErrorMessage = "Company Phone Number is required")]
        public string CompanyPhoneNum
        {
            get { return companyPhoneNum; }
            set { companyPhoneNum = value; }
        }

        [Required(ErrorMessage = "Company Address is required")]
        public string CompanyAddress
        {
            get { return companyAddress; }
            set { companyAddress = value; }
        }

        [Required(ErrorMessage = "Company City is required")]
        public string CompanyCity
        {
            get { return companyCity; }
            set { companyCity = value; }
        }

        [Required(ErrorMessage = "Company State is required")]
        public string CompanyState
        {
            get { return companyState; }
            set { companyState = value; }
        }

        [Required(ErrorMessage = "Company Zip is required")]
        public string CompanyZip
        {
            get { return companyZip; }
            set { companyZip = value; }
        }

        [Required(ErrorMessage = "Username is required")]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [Required(ErrorMessage = "Password is required")]
        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }
    }
}

