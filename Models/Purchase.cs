using System.Numerics;
using System.Text.RegularExpressions;

namespace TIcketHub.Models
{
    public class Purchase
    {
        public int ConcertId;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int Quantity{ get; set; }
        public string CreditCard { get; set; } = string.Empty;
        public string Expiration { get; set; } = string.Empty;
        public string SecurityCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        //TODO :sTHhsi
        public bool isValidId (int concertId)
        {
            return true;
        }
        public bool isValidEmail (string email)
        {
            Regex nonValidEmail = new Regex(@"^[^@\\s]+@[^@\\s]+\.[^@\\s]+$");

            if(string.IsNullOrEmpty(email)){ return false; }

            if(!nonValidEmail.IsMatch(email)) { return false; }

            return true;
        }

        public bool isValidName (string name)
        {
            Regex nonNumericRegex = new Regex(@"\d");

            if(string.IsNullOrEmpty(name)){ return false; }

            if(nonNumericRegex.IsMatch(name)) { return false; }

            return true;
        }
        public bool isValidPhoneNumber (string phoneNumber)
        {
            Regex nonPhoneNumber = new Regex(@"^(?:\+1)?\s?\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$");

            if(string.IsNullOrEmpty(phoneNumber)){ return false; }

            if(!nonPhoneNumber.IsMatch(phoneNumber)) { return false; }

            return true;
        }
        public bool isValidCreditNum(string creditCardNum)
        {
            Regex nonPhoneNumber = new Regex(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\\d{3})\\d{11})$");

            if(string.IsNullOrEmpty(creditCardNum)){ return false; }

            if(!nonPhoneNumber.IsMatch(creditCardNum)) { return false; }

            return true;
        }

        public bool isValidCreditExp(string expiry)
        {

            Regex nonExpiryDate = new Regex(@"^([0][1-9]|1[0-2])\/(\d{2})$");
            
            if(string.IsNullOrEmpty(expiry)){ return false; }

            if(!nonExpiryDate.IsMatch(expiry)) { return false; }

            int CURRENT_CENTURY = 2000;

            string month = expiry.Substring(0, 2);
            string year = expiry.Substring(3, 2); // get last two digits

            var dateExpired = new DateTime(int.Parse(year)+CURRENT_CENTURY, int.Parse(month), 1);
            var now = DateTime.Now;

            //check year
            if (dateExpired < now || dateExpired > now.AddYears(6))
            {
                return false;
            }

            return true;
        }
        public bool isValidCreditSecCode(string securityCode)
        {
            Regex nonSecurityCode = new Regex(@"^\d{3}$");

            if(string.IsNullOrEmpty(securityCode)){ return false; }

            if(!nonSecurityCode.IsMatch(securityCode)) { return false; }

            return true;
        }

    }
}
