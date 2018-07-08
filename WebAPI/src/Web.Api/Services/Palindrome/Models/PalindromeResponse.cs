using System;

namespace Web.Api.Services.Palindrome.Models
{
    public class PalindromeResponse
    {
        public int Id { get; set; }

        public string Sequence { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
