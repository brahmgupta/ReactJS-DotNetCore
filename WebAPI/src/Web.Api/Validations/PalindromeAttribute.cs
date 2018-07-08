using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Web.Api.Validations
{
    // Custome validator to check if value is Plaindrome
    public class PalindromeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()) && IsPalindrome(value.ToString()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Value is not Palindrome.");
        }

        private bool IsPalindrome(string value)
        {
            var cleanedValue = RemoveSpecialCharacters(value);

            if (cleanedValue == null || string.IsNullOrEmpty(cleanedValue.ToString()))
            {
                return false;
            }

            return cleanedValue.SequenceEqual(cleanedValue.Reverse());
        }
        private string RemoveSpecialCharacters(String str)
        {
            var sb = new StringBuilder();
            foreach (char c in str.ToLower())
            {
                if (c >= 'a' && c <= 'z')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }       
    }
}
