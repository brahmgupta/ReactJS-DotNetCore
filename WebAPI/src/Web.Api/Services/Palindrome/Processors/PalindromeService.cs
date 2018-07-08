using AutoMapper;
using DataManager.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Services.Palindrome.Models;
using System;

namespace Web.Api.Services.Palindrome.Processors
{
    public class PalindromeService: IPalindromeService
    {
        private IPalindromeRepository _palindromeRepo;
        private IMapper _autoMapper;

        public PalindromeService(IPalindromeRepository palindromeRepo, IMapper autoMapper)
        {
            _palindromeRepo = palindromeRepo;
            _autoMapper = autoMapper;
        }

        public async Task<IEnumerable<PalindromeModel>> GetAllAsync()
        {
            var serviceModels = new List<PalindromeModel>();

            var dataModels = await _palindromeRepo.GetAllPalindromesAsync();
            foreach (var dataModel in dataModels)
            {
                var serviceModel = _autoMapper.Map<PalindromeModel>(dataModel);
                serviceModels.Add(serviceModel);
            }

            return await Task.FromResult(serviceModels);
        }

        public async Task<PalindromeModel> SaveAsync(CreatePalindromeModel createPalindromeModel)
        {
            if (createPalindromeModel == null)
            {
                throw new ArgumentNullException("createPalindromeModel");
            }

            var newPalindrome = _autoMapper.Map<DataManager.DataModels.Palindrome>(createPalindromeModel);
            newPalindrome.CreateDate = DateTime.Now;

            var savedPalindrome = await _palindromeRepo.SavePalindromeAsync(newPalindrome);

            return _autoMapper.Map<PalindromeModel>(savedPalindrome);
        }
    }
}
