using System.ComponentModel.DataAnnotations;
using Web.Api.Validations;

namespace Web.Api.Services.Palindrome.Models
{
    public class CheckPalindromeRequest
    {
        [Required(ErrorMessage = "Sequence must be supplied.")]
        [MinLength(length: 2, ErrorMessage = "Sequence must be atleast two character.")]
        [Palindrome(ErrorMessage = "Sequence is not Palindrome.")] // Using custome validator to check if Sequence is Palindrome
        public string Sequence { get; set; }
    }
}
