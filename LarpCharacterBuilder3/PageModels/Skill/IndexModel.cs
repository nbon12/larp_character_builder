using System.Collections.Generic;
using System.Threading.Tasks;
using LarpCharacterBuilder3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LarpCharacterBuilder3.PageModels.Skill
{
    public class IndexModel : PageModel
    {
        private readonly LarpBuilderContext _context;

        public IndexModel(LarpBuilderContext context)
        {
            _context = context;
        }

        public IList<Models.Skill> Skills { get; set; }

        
        public async Task OnGetAsync()
        {
            Skills = await _context.Skill.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(long id)
        {
            var skill = await _context.Skill.FindAsync(id);

            if (skill != null)
            {
                _context.Skill.Remove(skill);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}