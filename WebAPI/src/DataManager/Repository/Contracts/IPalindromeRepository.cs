using DataManager.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataManager.Repository.Contracts
{
    public interface IPalindromeRepository
    {
        Task<IList<Palindrome>> GetAllPalindromesAsync();

        Task<Palindrome> SavePalindromeAsync(Palindrome palindrome);
    }
}
