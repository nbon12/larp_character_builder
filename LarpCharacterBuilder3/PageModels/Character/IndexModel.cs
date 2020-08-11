using System.Collections.Generic;
using System.Threading.Tasks;
using LarpCharacterBuilder3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LarpCharacterBuilder3.PageModels.Character
{
    public class IndexModel : PageModel
    {
        private readonly LarpBuilderContext _context;

        public IndexModel(LarpBuilderContext context)
        {
            _context = context;
        }

        public IList<Models.Character> Characters { get; set; }

        
        public async Task OnGetAsync()
        {
            Characters = await _context.Character.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(long id)
        {
            var contact = await _context.Character.FindAsync(id);

            if (contact != null)
            {
                _context.Character.Remove(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}