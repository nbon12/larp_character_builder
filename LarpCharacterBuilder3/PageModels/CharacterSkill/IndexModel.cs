using System.Collections.Generic;
using System.Threading.Tasks;
using LarpCharacterBuilder3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LarpCharacterBuilder3.PageModels.CharacterSkill
{
    public class IndexModel : PageModel
    {
        private readonly LarpBuilderContext _context;

        public IndexModel(LarpBuilderContext context)
        {
            _context = context;
        }

        public IList<Models.CharacterSkill> CharacterSkills { get; set; }

        public async Task OnGetAsync()
        {
            CharacterSkills = await _context.CharacterSkills.Include(c => c.Character).Include(c => c.Skill).ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(long characterId, long skillId)
        {
            var contact = await _context.CharacterSkills.FindAsync(characterId, skillId);

            if (contact != null)
            {
                _context.CharacterSkills.Remove(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}