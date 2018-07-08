using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Helpers;
using Web.Api.Services.Palindrome.Models;
using Web.Api.Services.Palindrome.Processors;

namespace Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Palindromes")]
    public class PalindromesController : Controller
    {
        private IPalindromeService _palindromeService;
        private readonly IMapper _autoMapper;

        public PalindromesController(IPalindromeService palindromeService, IMapper autoMapper)
        {
            _palindromeService = palindromeService;
            _autoMapper = autoMapper;
        }

        // Returns all Palindromes persisted in Database
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await _palindromeService.GetAllAsync();
            var count = models?.Count() ?? 0;

            if (count == 0)
            {
                return NotFound($"Unable to find any Palindrome");
            }

            return Ok(_autoMapper.Map<IList<PalindromeResponse>>(models));
        }

        /// <summary>
        /// This API End point will check 
        /// 1. If value passes in request is Palindrome
        /// 2. If it is Plaindrome then it will be persisted to DB and data record will be sent in response
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CheckPalindrome([FromBody] CheckPalindromeRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            // It will invoke custom validator to check if value is Palindrome
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var model = await _palindromeService.SaveAsync(_autoMapper.Map<CreatePalindromeModel>(request));

            return Ok(_autoMapper.Map<PalindromeResponse>(model));
        }
    }
}