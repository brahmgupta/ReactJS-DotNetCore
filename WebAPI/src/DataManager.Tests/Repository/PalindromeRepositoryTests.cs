using DataManager.Context.Contracts;
using DataManager.Context.Implementation;
using DataManager.DataModels;
using DataManager.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DataManager.Tests.Repository
{
    public sealed partial class PalindromeRepositoryTests
    {
        #region CLASS: GivenWhenPalindromeIsSaved
        public sealed class GivenWhenPalindromeIsSaved
        {
            private Mock<IMyDbContextFactory> _dbContextFactory;

            [Fact]
            public async Task ThenItShouldReturnModel()
            {
                // Arrange
                var options = new DbContextOptionsBuilder<MyDbContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;

                using (var context = new MyDbContext(options))
                {
                    // Act
                    _dbContextFactory = new Mock<IMyDbContextFactory>();
                    _dbContextFactory.Setup(_ => _.CreateMyDbContext()).Returns(new MyDbContext(options));

                    var repository = new PalindromeRepository(_dbContextFactory.Object);
                    var dtNow = DateTime.Now;
                    var sequence = "NeverOddOrEven";
                    var savedPalindrome = await repository.SavePalindromeAsync(new Palindrome() { Sequence = sequence, CreateDate = dtNow });
                    
                    // Assert
                    Assert.True(savedPalindrome.Id >= 1);
                    Assert.Equal(sequence, savedPalindrome.Sequence);
                    Assert.Equal(dtNow, savedPalindrome.CreateDate);
                }
            }
        }
        #endregion CLASS: GivenWhenPalindromeIsSaved



        #region CLASS: GivenWhenAllPalindromesAreRequested
        public sealed class GivenWhenAllPalindromesAreRequested
        {
            private Mock<IMyDbContextFactory> _dbContextFactory;
            public GivenWhenAllPalindromesAreRequested()
            {
                var options = new DbContextOptionsBuilder<MyDbContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;

                using (var context = new MyDbContext(options))
                {
                    var dbSet = context.Set<Palindrome>();
                    var dtNow = DateTime.Now;

                    dbSet.Add(new Palindrome() { Sequence = "Never Odd Or Even", CreateDate = dtNow });
                    dbSet.Add(new Palindrome() { Sequence = "Radar", CreateDate = dtNow });                    
                    context.SaveChangesAsync();

                    _dbContextFactory = new Mock<IMyDbContextFactory>();
                    _dbContextFactory.Setup(_ => _.CreateMyDbContext()).Returns(new MyDbContext(options));
                }
            }

            [Fact]
            public async Task ThenItShouldReturnCorrectCount()
            {
                var repository = new PalindromeRepository(_dbContextFactory.Object);

                var result = await repository.GetAllPalindromesAsync();
                Assert.Equal(2, result.Count);
            }
        }
        #endregion CLASS: GivenWhenAllPalindromesAreRequested
    }


}
