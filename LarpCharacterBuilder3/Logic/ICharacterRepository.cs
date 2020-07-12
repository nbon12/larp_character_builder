using System.Threading.Tasks;
using LarpCharacterBuilder3.Models;

namespace LarpCharacterBuilder3.Logic
{
    public interface ICharacterRepository : IRepository<Character>
    {
        public int GetCpRemaining(long characterId);
        public int GetGamesAttendedCount(long characterId);
        public int GetCpSpent(long characterId);

        public int GetTotalCp(long characterId);

    }
}