using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class CustomerOfferInfo
    {
        private int homeID = 0;
        private int offerID = 0;
        private string custFirstName;
        private string custLastName;
        private string custEmail;
        private string custPhoneNum;
        private string offerAmount;
        private string saleType;
        private string contigencies;
        private string custHomeStatus;
        private DateTime custMoveInDate;


        public int HomeID
        {
            get { return homeID; }
            set { homeID = value; }
        }

        public int OfferID
        {
            get { return offerID; }
            set { offerID = value; }
        }

        [Required(ErrorMessage ="Provide a first name")]
        public string CustFirstName
        {
            get { return custFirstName; }
            set { custFirstName = value; }
        }

        [Required(ErrorMessage = "Provide a last name")]
        public string CustLastName {
            get { return custLastName; }
            set { custLastName = value; }
        }

        [Required(ErrorMessage = "Provide an email")]
        public string CustEmail
        {
            get { return custEmail; }
            set { custEmail = value; }
        }

        [Required(ErrorMessage = "Provide a phone number")]
        public string CustPhoneNum
        {
            get { return custPhoneNum; }
            set { custPhoneNum = value; }
        }

        [Required(ErrorMessage = "Provide an offer amount")]
        public string OfferAmount
        {
            get { return offerAmount; }
            set { offerAmount = value; }
        }

        [Required(ErrorMessage = "select a sale type")]
        public string SaleType
        {
            get { return saleType; }
            set { saleType = value; }
        }

        [Required(ErrorMessage = "Provide contigencies or put N/A if none")]
        public string Contigencies
        {
            get { return contigencies; }
            set { contigencies = value; }
        }

        [Required(ErrorMessage = "Select a home status")]

        public  string CustHomeStatus
        {
            get { return custHomeStatus; }
            set { custHomeStatus = value; }
        }

        [Required(ErrorMessage = "Provide a move in date")]
        public DateTime MoveInDate
        {
            get { return custMoveInDate; }
            set { custMoveInDate = value; }
        }
    }
}
