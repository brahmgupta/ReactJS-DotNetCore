using DataManager.Context.Contracts;
using DataManager.DataModels;
using DataManager.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Repository.Implementation
{
    public class PalindromeRepository : IPalindromeRepository
    {
        private readonly IMyDbContextFactory _contextFactory;

        public PalindromeRepository(IMyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IList<Palindrome>> GetAllPalindromesAsync()
        {
            using (var context = _contextFactory.CreateMyDbContext())
            {
                var palindromes = await (from p in context.Palindromes
                                         select p)
                              .OrderByDescending(d => d.CreateDate)
                              .AsNoTracking()
                              .ToListAsync();

                return palindromes;
            }
        }

        public async Task<Palindrome> SavePalindromeAsync(Palindrome palindrome)
        {
            using (var context = _contextFactory.CreateMyDbContext())
            {
                context.Palindromes.Add(palindrome);
                await context.Save();
            }

            return palindrome;
        }
    }
}
