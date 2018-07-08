using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Services.Palindrome.Models;

namespace Web.Api.Services.Palindrome.Processors
{
    public interface IPalindromeService
    {
        Task<IEnumerable<PalindromeModel>> GetAllAsync();
        Task<PalindromeModel> SaveAsync(CreatePalindromeModel request);
    }
}
