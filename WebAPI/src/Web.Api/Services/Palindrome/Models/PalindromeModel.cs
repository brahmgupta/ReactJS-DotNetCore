using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Services.Palindrome.Models
{
    public class PalindromeModel
    {
        public int Id { get; set; }

        public string Sequence { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
