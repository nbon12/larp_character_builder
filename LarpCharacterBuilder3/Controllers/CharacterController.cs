using AutoMapper;
using HotChocolate;
using LarpCharacterBuilder3.Logic;
using LarpCharacterBuilder3.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace LarpCharacterBuilder3
{
    public class CharacterController : ControllerBasicCrud<Character>
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterController(ICharacterRepository characterRepository, [Service] IMapper mapper) : base(characterRepository, mapper)
        {
            _characterRepository = characterRepository;
        }

        public new ActionResult Update(long id, [FromBody] Delta<CharacterDto> characterDto)
        {
            base.Update<Character, CharacterDto>(id, characterDto);
            return Ok();
        }
    }
}