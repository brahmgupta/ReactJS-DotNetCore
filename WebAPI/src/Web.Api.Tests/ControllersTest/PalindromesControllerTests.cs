using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Web.Api.Controllers;
using Web.Api.Services.Palindrome.Models;
using Web.Api.Services.Palindrome.Processors;
using Xunit;

namespace Web.Api.Tests.ControllersTest
{
    public class PalindromesControllerTests
    {
        #region CLASS: GivenWhenSequenceIsNotPalindrome
        public sealed class GivenWhenSequenceIsNotPalindrome
        {
            Mock<IPalindromeService> _mockPalindromeService;
            Mock<IMapper> _mockMapper;

            PalindromesController _controller;

            public GivenWhenSequenceIsNotPalindrome()
            {
                _mockPalindromeService = new Mock<IPalindromeService>();
                _mockMapper = new Mock<IMapper>();

                _controller = new PalindromesController(_mockPalindromeService.Object, _mockMapper.Object);
            }

            [Fact]
            public async Task ThenShouldReturnBadRequestIfRequestIsNull()
            {
                var result = await _controller.CheckPalindrome(null);

                Assert.IsType<BadRequestResult>(result);
            }
        }

        #endregion CLASS: GivenWhenSequenceIsNotPalindrome


        #region CLASS: GivenWhenSequenceValidPalindrome
        public sealed class GivenWhenSequenceIsValidPalindrome
        {
            Mock<IPalindromeService> _mockPalindromeService;
            Mock<IMapper> _mockMapper;

            PalindromesController _controller;
            readonly PalindromeModel _svcResponse = new PalindromeModel() { Id = 1, Sequence = "Never Odd or Even", CreateDate = DateTime.Now };

            public GivenWhenSequenceIsValidPalindrome()
            {
                _mockPalindromeService = new Mock<IPalindromeService>();
                _mockPalindromeService.Setup(svc => svc.SaveAsync(It.IsAny<CreatePalindromeModel>())).ReturnsAsync(_svcResponse);

                _mockMapper = new Mock<IMapper>();

                // Mock controller request to Service Model
                _mockMapper.Setup(m => m.Map<CreatePalindromeModel>(It.IsAny<CheckPalindromeRequest>())).Returns((CheckPalindromeRequest request) =>
                {
                    return new CreatePalindromeModel() {
                        Sequence = request.Sequence
                    };

                });

                // Mock Service Model to Controller Response
                _mockMapper.Setup(m => m.Map<PalindromeResponse>(It.IsAny<PalindromeModel>())).Returns((PalindromeModel model) =>
                {
                    return new PalindromeResponse()
                    {
                        Id = model.Id,
                        Sequence = model.Sequence,
                        CreateDate = model.CreateDate
                    };
                });


                _controller = new PalindromesController(_mockPalindromeService.Object, _mockMapper.Object);
            }

            [Fact]
            public async Task ThenShouldReturnOkObjectResult()
            {
                var result = await _controller.CheckPalindrome(new CheckPalindromeRequest() { Sequence = "Never Odd or Even" });

                Assert.IsType<OkObjectResult>(result);
            }

            [Fact]
            public async Task ThenShouldSaveOnce()
            {
                var result = await _controller.CheckPalindrome(new CheckPalindromeRequest() { Sequence = "Never Odd or Even" });

                _mockPalindromeService.Verify(svc => svc.SaveAsync(It.IsAny<CreatePalindromeModel>()), Times.Once);
            }
        }

        #endregion CLASS: GivenWhenSequenceIsValidPalindrome
    }
}
