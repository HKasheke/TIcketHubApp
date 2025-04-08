using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TIcketHub.Models
{
    public class Purchase
    {
        [Required]
        public int ConcertId { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Name cannot contain numbers.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [PhoneAttribute(ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10.")]
        public int Quantity { get; set; }

        [Required]
        [CreditCard(ErrorMessage = "Please enter a valid credit card number.")]
        public string CreditCard { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^([0][1-9]|1[0-2])\/(\d{2})$",
            ErrorMessage = "Expiration date must be in format MM/YY.")]
        [CustomExpirationDate(ErrorMessage = "The expiration date is invalid or expired.")]
        public string Expiration { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Security code must be 3 digits.")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d+\s\w+\s\w+$", ErrorMessage = "Invalid Address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "City cannot contain numbers.")]
        public string City { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Province cannot contain numbers.")]
        public string Province { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$",
            ErrorMessage = "Please enter a valid postal code.")]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Country cannot contain numbers.")]
        public string Country { get; set; } = string.Empty;
    }

    // Custom validation attribute for credit card expiration date
    public class CustomExpirationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Expiration date is required.");

            string expiry = value.ToString();
            if (!Regex.IsMatch(expiry, @"^([0][1-9]|1[0-2])\/(\d{2})$"))
                return new ValidationResult("Expiration date must be in format MM/YY.");

            int CURRENT_CENTURY = 2000;
            string month = expiry.Substring(0, 2);
            string year = expiry.Substring(3, 2);

            var dateExpired = new DateTime(int.Parse(year) + CURRENT_CENTURY, int.Parse(month), 1);
            var now = DateTime.Now;

            if (dateExpired < now)
                return new ValidationResult("The credit card has expired.");

            if (dateExpired > now.AddYears(6))
                return new ValidationResult("Expiration date is too far in the future.");

            return ValidationResult.Success;
        }
    }
}
