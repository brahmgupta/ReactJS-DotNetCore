using DataManager.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataManager.Context.Contracts
{
    public interface IMyDbContext : IDisposable
    {
        DbSet<Palindrome> Palindromes { get; set; }
        Task Save();
    }
}
