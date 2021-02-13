using System.Collections.Generic;
using System.Threading.Tasks;
using LarpCharacterBuilder3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LarpCharacterBuilder3.PageModels.Skill
{
    public class CreateModel : PageModel
    {
        private readonly LarpBuilderContext _context;

        public CreateModel(LarpBuilderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public  Models.Skill Skill { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Skill.Add(Skill);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Skills");
        }
    }
}


