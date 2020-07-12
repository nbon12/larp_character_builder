using System.Threading.Tasks;
using LarpCharacterBuilder3.Models;

namespace LarpCharacterBuilder3.Logic
{
    public interface ICharacterRepository : IRepository<Character>
    {
        public Task<int> GetCpRemaining(long characterId);
    }
}