using AutoMapper;
using DataManager.DataModels;
using DataManager.Repository.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Services.Palindrome.Models;
using Web.Api.Services.Palindrome.Processors;
using Xunit;

namespace Web.Api.Tests.ServicesTest
{
    public class PalindromeServiceTest
    {
        #region CLASS: GivenWhenNewPalindromeIsSaved
        public sealed class GivenWhenNewPalindromeIsSaved
        {
            Mock<IPalindromeRepository> _mockRepository;
            Mock<IMapper> _mockMapper;
            readonly Palindrome _dbModel = new Palindrome() { Id = 1, Sequence = "Never Odd or Even", CreateDate = DateTime.Now };
            readonly PalindromeModel _svcResponse = new PalindromeModel() { Id = 1, Sequence = "Never Odd or Even", CreateDate = DateTime.Now };

            public GivenWhenNewPalindromeIsSaved()
            {
                _mockRepository = new Mock<IPalindromeRepository>();
                _mockRepository.Setup(repo => repo.SavePalindromeAsync(It.IsAny<Palindrome>())).ReturnsAsync(_dbModel);

                _mockMapper = new Mock<IMapper>();
                _mockMapper.Setup(m => m.Map<Palindrome>(It.IsAny<CreatePalindromeModel>())).Returns(new Palindrome() { Sequence = _dbModel.Sequence });
                _mockMapper.Setup(m => m.Map<PalindromeModel>(It.IsAny<Palindrome>())).Returns(_svcResponse);
            }

            [Fact]
            public async Task ThenShouldSaveSuccessfully()
            {
                var service = new PalindromeService(_mockRepository.Object, _mockMapper.Object);

                var savedPalindrome = await service.SaveAsync(new CreatePalindromeModel() { Sequence = _dbModel.Sequence });

                Assert.Equal(_dbModel.Id, savedPalindrome.Id);
                Assert.Equal(_dbModel.Sequence, savedPalindrome.Sequence);
            }
        }
        #endregion CLASS: GivenWhenNewPalindromeIsSaved
    }
}
