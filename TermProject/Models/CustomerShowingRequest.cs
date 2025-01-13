using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
   public class CustomerShowingRequest
    {
        private int homeID = 0;
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNum;
        private DateTime showDate;
        private DateTime showTime;
         

        public int HomeID
        {
            get { return homeID; }
            set { homeID = value; }
        }

        [Required(ErrorMessage = "Provide a first name.")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [Required(ErrorMessage = "Provide last name.")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [Required(ErrorMessage = "Provide an email.")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "Provide a phone number.")]
        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        [Required(ErrorMessage = "Provide a show date.")]
        public DateTime ShowDate
        {
            get { return showDate.Date; }
            set { showDate = value.Date; }
        }

        [Required(ErrorMessage = "Provide a show time.")]
        public DateTime ShowTime
        {
            get { return showTime; }
            set { showTime =DateTime.Today + value.TimeOfDay; }
        }
    }
}
