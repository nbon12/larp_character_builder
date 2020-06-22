using AutoMapper;
using LarpCharacterBuilder3.Logic;
using LarpCharacterBuilder3.Models;

namespace LarpCharacterBuilder3.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CharacterDto, Character>().ReverseMap();
        }
    }
}