using AutoMapper;
using DataManager.DataModels;
using Web.Api.Services.Palindrome.Models;

namespace Web.Api.Extensions
{
    public sealed class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        : this("MyAutoMapperProfile")
        {
        }

        public AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<CheckPalindromeRequest, CreatePalindromeModel>();
            CreateMap<PalindromeModel, PalindromeResponse>();

            CreateMap<CreatePalindromeModel, Palindrome>();
            CreateMap<Palindrome, PalindromeModel>();
        }
    }
}